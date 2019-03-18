namespace EstelApi.Application.AutoMapper
{
    using EstelApi.Application.ApplicationCqrs.Commands.UpdateCommands;

    using global::AutoMapper;
    // using EstelApi.Application.Dto;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;

    using Serilog;

    /// <inheritdoc />
    /// <summary>
    /// The dto to cqrs command profile rev.
    /// </summary>
    public class DtoToCqrsCommandProfileRev : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DtoToCqrsCommandProfileRev"/> class.
        /// </summary>
        public DtoToCqrsCommandProfileRev()
        {
            Log.Debug($"AutoMapper profile {nameof(DtoToCqrsCommandProfileRev)} was launch");
         //   this.CreateMap<Customer, RegisterNewCustomerCommand>().PreserveReferences();
         //   this.CreateMap<Customer, UpdateCustomerCommand>().PreserveReferences(); 

            // .ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            /* this.CreateMap<UpdateCustomerViewModel, UpdateCustomerCommand>()
                 .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));*/
        }
    }
}