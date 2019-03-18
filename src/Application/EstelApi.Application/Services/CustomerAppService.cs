//namespace EstelApi.Application.Services
//{
//    //  using EstelApi.Application.Dto;
//    using EstelApi.Application.EventSourcedNormalizers;
//    using EstelApi.Application.Interfaces;
//    using EstelApi.Core.Seedwork.Adapter;
//    using EstelApi.Core.Seedwork.CoreCqrs.Events;
//    using MediatR;
//    using System;
//    using System.Collections.Generic;
//    using System.Linq;
//    using System.Threading.Tasks;

//    using EstelApi.Application.ApplicationCqrs.Commands.CreateCommands;
//    using EstelApi.Application.ApplicationCqrs.Commands.UpdateCommands;
//    using EstelApi.Application.ApplicationCqrs.Queries;
//    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

//    /// <inheritdoc />
//    /// <summary>
//    /// The customer app service.
//    /// </summary>
//    public class CustomerAppService : ICustomerAppService
//    {
//        /// <summary>
//        /// The event store repository.
//        /// </summary>
//        private readonly IEventStoreRepository eventStoreRepository;

//        /// <summary>
//        /// The bus.
//        /// </summary>
//        private readonly IMediator bus;

//        /// <summary>
//        /// Initializes a new instance of the <see cref="CustomerAppService"/> class.
//        /// </summary>
//        /// <param name="bus">
//        /// The bus.
//        /// </param>
//        /// <param name="eventStoreRepository">
//        /// The event store repository.
//        /// </param>
//        public CustomerAppService(
//            IMediator bus,
//            IEventStoreRepository eventStoreRepository)
//        {
//            this.bus = bus;
//            this.eventStoreRepository = eventStoreRepository;
//        }

//        /// <inheritdoc />
//        public async Task<IList<CustomerHistoryData>> GetAllHistory(int id)
//        {
//            return CustomerHistory.ToJavaScriptCustomerHistory(await this.eventStoreRepository.All(id));
//        }

//        /// <inheritdoc />
//        public void Dispose()
//        {
//            GC.SuppressFinalize(this);
//        }

//        /// <inheritdoc />
//        /// <summary>
//        /// The add new customer.
//        /// </summary>
//        /// <param name="customerDto">
//        /// The customer dto.
//        /// </param>
//        /// <returns>
//        /// The <see cref="T:System.Threading.Tasks.Task" />.
//        /// </returns>
//        public async Task<Customer> AddNewCustomer(CreateCustomerViewModel customerDto)
//        {
//            var registerCommand =
//                customerDto.ProjectedAs<CreateNewCustomerCommand>(); // _mapper.Map<>(customerViewModel);
//            var result = await this.bus.Send(registerCommand);
//            return result.IsSuccess ? result.Object : null;
//        }

//        /// <inheritdoc />
//        public async Task UpdateCustomer(Customer customerDto)
//        {
//            var updateCommand =
//                customerDto.ProjectedAs<UpdateCustomerCommand>();
//            var result = await this.bus.Send(updateCommand);
//        }

//        /// <inheritdoc />
//        public async Task RemoveCustomer(int customerId)
//        {
//            var deleteCommand = new RemoveCustomerCommand(customerId);
//            var result = await this.bus.Send(deleteCommand);
//        }

//        /*  public void RemoveCustomer(Guid customerId)
//          {
//              throw new NotImplementedException();
//              // var customer = _customerRepository.Get(customerId);

//              // if (customer != null) //if customer exist
//              // {
//              // //disable customer ( "logical delete" ) 
//              // customer.Disable();

//              // //commit changes
//              // _customerRepository.UnitOfWork.Commit();
//              // }
//              // else //the customer not exist, cannot remove
//              // _logger.LogWarning(_resources.GetStringResource(LocalizationKeys.Application.warning_CannotRemoveNonExistingCustomer));
//          }*/

//        public List<Customer> GetAllCustomers()
//        {
//            var result = this.bus.Send(new AllEntitiesQuery<Customer>()).Result;
//            return result.ToList();
//        }

//        /*     public List<CustomerDto> FindCustomers(string text)
//             {
//                 throw new NotImplementedException();
//                 ////get the specification

//                 // var enabledCustomers = CustomerSpecifications.EnabledCustomers();
//                 // var filter = CustomerSpecifications.CustomerFullText(text);

//                 // ISpecification<Customer> spec = enabledCustomers & filter;

//                 ////Query this criteria
//                 // var customers = _customerRepository.AllMatching(spec);

//                 // if (customers != null
//                 // &&
//                 // customers.Any())
//                 // {
//                 // //return adapted data
//                 // return customers.ProjectedAsCollection<CustomerListDTO>();
//                 // }
//                 // else // no data..
//                 // return null;
//             }*/

//        public Customer FindCustomer(int customerId)
//        {
//            var result = this.bus.Send(new EntityByIdQuery<Customer>(customerId)).Result;
//            return result;
//        }

//        /*  public List<CountryDto> FindCountries(int pageIndex, int pageCount)
//          {
//              throw new NotImplementedException();
//              // if (pageIndex < 0 || pageCount <= 0)
//              // throw new ArgumentException(_resources.GetStringResource(LocalizationKeys.Application.warning_InvalidArgumentsForFindCountries));

//              ////recover countries
//              // var countries = _countryRepository.GetPaged(pageIndex, pageCount, c => c.CountryName, false);

//              // if (countries != null
//              // &&
//              // countries.Any())
//              // {
//              // return countries.ProjectedAsCollection<CountryDTO>();
//              // }
//              // else // no data.
//              // return null;
//          }*/

//        /*  public List<CountryDto> FindCountries(string text)
//          {
//              throw new NotImplementedException();
//              ////get the specification
//              // ISpecification<Country> specification = CountrySpecifications.CountryFullText(text);

//              ////Query this criteria
//              // var countries = _countryRepository.AllMatching(specification);

//              // if (countries != null
//              // &&
//              // countries.Any())
//              // {
//              // return countries.ProjectedAsCollection<CountryDTO>();
//              // }
//              // else // no data
//              // return null;
//          }*/
//    }
//}
