namespace EstelApi.Application.EventSourcedNormalizers
{
    using EstelApi.Core.Seedwork.CoreCqrs.Events;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The customer history.
    /// </summary>
    public class CustomerHistory
    {
        /// <summary>
        /// Gets or sets the history data.
        /// </summary>
        public static IList<CustomerHistoryData> HistoryData { get; set; }

        /// <summary>
        /// The to java script customer history.
        /// </summary>
        /// <param name="storedEvents">
        /// The stored events.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Collections.Generic.IList`1"/>.
        /// </returns>
        public static IList<CustomerHistoryData> ToJavaScriptCustomerHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<CustomerHistoryData>();
            CustomerHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<CustomerHistoryData>();
            var last = new CustomerHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new CustomerHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? string.Empty
                        : change.Id,
                    FirstName = string.IsNullOrWhiteSpace(change.FirstName) || change.FirstName == last.FirstName
                                    ? string.Empty
                                    : change.FirstName,
                    LastName = string.IsNullOrWhiteSpace(change.LastName) || change.LastName == last.LastName
                                   ? string.Empty
                                   : change.LastName,
                    Telephone = string.IsNullOrWhiteSpace(change.Telephone) || change.Telephone == last.Telephone
                                    ? string.Empty
                                    : change.Telephone,
                    Company = string.IsNullOrWhiteSpace(change.Company) || change.Company == last.Company
                                  ? string.Empty
                                  : change.Company,
                    CreditLimit = change.CreditLimit == last.CreditLimit
                                      ? default(decimal)
                                      : change.CreditLimit,
                    CountryId = change.CountryId == Guid.Empty || change.CountryId == last.CountryId
                                   ? Guid.Empty
                                   : change.CountryId,
                    AddressCity = string.IsNullOrWhiteSpace(change.AddressCity) || change.AddressCity == last.AddressCity
                                      ? string.Empty
                                      : change.AddressCity,
                    AddressZipCode = string.IsNullOrWhiteSpace(change.AddressZipCode) || change.AddressZipCode == last.AddressZipCode
                                         ? string.Empty
                                         : change.AddressZipCode,
                    AddressAddressLine1 = string.IsNullOrWhiteSpace(change.AddressAddressLine1) || change.AddressAddressLine1 == last.AddressAddressLine1
                                              ? string.Empty
                                              : change.AddressAddressLine1,
                    AddressAddressLine2 = string.IsNullOrWhiteSpace(change.AddressAddressLine2) || change.AddressAddressLine2 == last.AddressAddressLine2
                                              ? string.Empty
                                              : change.AddressAddressLine2,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? string.Empty : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }

            return list;
        }

        /// <summary>
        /// The customer history deserializer.
        /// </summary>
        /// <param name="storedEvents">
        /// The stored events.
        /// </param>
        private static void CustomerHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new CustomerHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "CustomerRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);

                        slot.Action = "Registered";
                        slot.Id = values["Id"];
                        slot.FirstName = values["FirstName"];
                        slot.LastName = values["LastName"];
                        slot.Telephone = values["Telephone"];
                        slot.Company = values["Company"];
              //          slot.CreditLimit = values["CreditLimit"];
                        slot.CountryId = values["CountryId"];
                        slot.AddressCity = values["AddressCity"];
                        slot.AddressZipCode = values["AddressZipCode"];
                        slot.AddressAddressLine1 = values["AddressAddressLine1"];
                        slot.AddressAddressLine2 = values["AddressAddressLine2"];
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "CustomerUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Updated";
                        slot.Id = values["Id"];
                        slot.FirstName = values["FirstName"];
                        slot.LastName = values["LastName"];
                        slot.Telephone = values["Telephone"];
                        slot.Company = values["Company"];
                        slot.CreditLimit = values["CreditLimit"];
                        slot.CountryId = values["CountryId"];
                        slot.AddressCity = values["AddressCity"];
                        slot.AddressZipCode = values["AddressZipCode"];
                        slot.AddressAddressLine1 = values["AddressAddressLine1"];
                        slot.AddressAddressLine2 = values["AddressAddressLine2"];
                        slot.When = values["Timestamp"];
                        slot.Who = e.User;
                        break;
                    case "CustomerRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }

                HistoryData.Add(slot);
            }
        }
    }
}
