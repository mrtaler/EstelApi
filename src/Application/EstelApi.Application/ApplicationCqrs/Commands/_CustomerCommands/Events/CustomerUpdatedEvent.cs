namespace EstelApi.Application.ApplicationCqrs.Commands._CustomerCommands.Events
{
    using EstelApi.Core.Seedwork.CoreCqrs.Events;

    public class CustomerUpdatedEvent : Event
    {
        public CustomerUpdatedEvent(
            int id,
            string firstName,
            string lastName,
            string telephone)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Telephone = telephone;
            this.AggregateId = id;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Telephone { get; set; }
    }
}