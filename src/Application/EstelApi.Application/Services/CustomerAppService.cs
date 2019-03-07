using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using EstelApi.Application.Cqrs.Commands.Commands.CustomerCommands.Commands;
using EstelApi.Application.Cqrs.Queries.Queries.CustomerQueries;
using EstelApi.Application.EventSourcedNormalizers;
using EstelApi.Application.Interfaces;
using EstelApi.Application.ViewModels.Customer;
using EstelApi.Core.Seedwork.Adapter;
using EstelApi.Core.Seedwork.CoreCqrs.Events;

using MediatR;

namespace EstelApi.Application.Services
{
    using EstelApi.Application.Dto;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerRepository;
        private readonly IEventStoreRepository eventStoreRepository;
        private readonly IMediator bus;

        public CustomerAppService(IMapper mapper,
                                  ICustomerRepository customerRepository,
                                  IMediator bus,
                                  IEventStoreRepository eventStoreRepository)
        {
            this.mapper = mapper;
            this.customerRepository = customerRepository;
            this.bus = bus;
            this.eventStoreRepository = eventStoreRepository;
        }
        #region 2
        public IEnumerable<CustomerViewModelApp> GetAll()
        {
            var result = this.bus.Send(new AllCustomersQuery()).Result;

            List<CustomerViewModelApp> ret = result.ProjectedAsCollection<CustomerViewModelApp>();

            return
                ret; // _customerRepository.GetAll().AsQueryable().ProjectTo<CustomerViewModelApp>(_mapper.ConfigurationProvider);
        }

        public CustomerViewModelApp GetById(Guid id)
        {
            return this.mapper.Map<CustomerViewModelApp>(this.customerRepository.GetById(id));
        }

        public async Task<CustomerViewModelApp> Register(CreateCustomerViewModel customerViewModel)
        {
            var registerCommand = customerViewModel.ProjectedAs<RegisterNewCustomerCommand>();// _mapper.Map<>(customerViewModel);
            var result = await this.bus.Send(registerCommand);
            if (result.IsSuccess)
            {
                var retVal = new CustomerViewModelApp
                {
                    BirthDate = result.Object.BirthDate,
                    Email = result.Object.Email,
                    Id = result.Object.Id,
                    Name = result.Object.Name
                };

                return retVal;
            }

            return new CustomerViewModelApp();
        }

        public void Update(UpdateCustomerViewModel customerViewModel)
        {
            var updateCommand = customerViewModel.ProjectedAs<UpdateCustomerCommand>();// _mapper.Map<>(customerViewModel);
            this.bus.Send(updateCommand);
        }

        public void Remove(Guid id)
        {
            var removeCommand = new RemoveCustomerCommand(id);
            this.bus.Send(removeCommand);
        }

        public async Task<IList<CustomerHistoryData>> GetAllHistory(Guid id)
        {
            return CustomerHistory.ToJavaScriptCustomerHistory(await this.eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion
        public CustomerDTO AddNewCustomer(CustomerDTO customerDTO)
        {
            //check preconditions
            if (customerDTO == null || customerDTO.CountryId == Guid.Empty)
                throw new ArgumentException("_resources.GetStringResource(LocalizationKeys.Application.warning_CannotAddCustomerWithEmptyInformation)");
// to command handler
            var country = _countryRepository.Get(customerDTO.CountryId);

            if (country != null)
            {
                //Create the entity and the required associated data
                var address = new Address(
                    customerDTO.AddressCity, 
                    customerDTO.AddressZipCode,
                    customerDTO.AddressAddressLine1, 
                    customerDTO.AddressAddressLine2);

                var customer = CustomerFactory.CreateCustomer(customerDTO.FirstName,
                                                              customerDTO.LastName,
                                                              customerDTO.Telephone,
                                                              customerDTO.Company,
                                                              country,
                                                              address);

                //save entity
                SaveCustomer(customer);

                //return the data with id and assigned default values
                return customer.ProjectedAs<CustomerDTO>();
            }
            else
                return null;
        }

        public void UpdateCustomer(CustomerDTO customerDTO)
        {
            if (customerDTO == null || customerDTO.Id == Guid.Empty)
                throw new ArgumentException(_resources.GetStringResource(LocalizationKeys.Application.warning_CannotUpdateCustomerWithEmptyInformation));

            //get persisted item
            var persisted = _customerRepository.Get(customerDTO.Id);

            if (persisted != null) //if customer exist
            {
                //materialize from customer dto
                var current = MaterializeCustomerFromDto(customerDTO);

                //Merge changes
                _customerRepository.Merge(persisted, current);

                //commit unit of work
                _customerRepository.UnitOfWork.Commit();
            }
            else
                _logger.LogWarning(_resources.GetStringResource(LocalizationKeys.Application.warning_CannotUpdateNonExistingCustomer));
        }

        public void RemoveCustomer(Guid customerId)
        {
            var customer = _customerRepository.Get(customerId);

            if (customer != null) //if customer exist
            {
                //disable customer ( "logical delete" ) 
                customer.Disable();

                //commit changes
                _customerRepository.UnitOfWork.Commit();
            }
            else //the customer not exist, cannot remove
                _logger.LogWarning(_resources.GetStringResource(LocalizationKeys.Application.warning_CannotRemoveNonExistingCustomer));
        }

        public List<CustomerListDTO> GetAllCustomers()
        {
            throw new NotImplementedException();
        }

        public List<CustomerListDTO> FindCustomers(string text)
        {
            //get the specification

            var enabledCustomers = CustomerSpecifications.EnabledCustomers();
            var filter = CustomerSpecifications.CustomerFullText(text);

            ISpecification<Customer> spec = enabledCustomers & filter;

            //Query this criteria
            var customers = _customerRepository.AllMatching(spec);

            if (customers != null
                &&
                customers.Any())
            {
                //return adapted data
                return customers.ProjectedAsCollection<CustomerListDTO>();
            }
            else // no data..
                return null;
        }

        public CustomerDTO FindCustomer(Guid customerId)
        {
            //recover existing customer and map
            var customer = _customerRepository.Get(customerId);

            if (customer != null) //adapt
            {
                return customer.ProjectedAs<CustomerDTO>();
            }
            else
                return null;
        }

        public List<CountryDTO> FindCountries(int pageIndex, int pageCount)
        {
            if (pageIndex < 0 || pageCount <= 0)
                throw new ArgumentException(_resources.GetStringResource(LocalizationKeys.Application.warning_InvalidArgumentsForFindCountries));

            //recover countries
            var countries = _countryRepository.GetPaged(pageIndex, pageCount, c => c.CountryName, false);

            if (countries != null
                &&
                countries.Any())
            {
                return countries.ProjectedAsCollection<CountryDTO>();
            }
            else // no data.
                return null;
        }

        public List<CountryDTO> FindCountries(string text)
        {
            //get the specification
            ISpecification<Country> specification = CountrySpecifications.CountryFullText(text);

            //Query this criteria
            var countries = _countryRepository.AllMatching(specification);

            if (countries != null
                &&
                countries.Any())
            {
                return countries.ProjectedAsCollection<CountryDTO>();
            }
            else // no data
                return null;
        }
    }
}
