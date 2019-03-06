using Autofac;
using EstelApi.Core.Seedwork.CoreCqrs.Events;
using EstelApi.Domain.DataAccessLayer.Context.Context;
using EstelApi.Domain.DataAccessLayer.Context.EventSourcing;
using EstelApi.Domain.DataAccessLayer.Context.Interfaces;
using EstelApi.Domain.DataAccessLayer.Context.Repository;
using EstelApi.Domain.DataAccessLayer.Context.Repository.EventSourcing;

namespace EstelApi.Domain.DataAccessLayer.Context
{
    public class EstelApiDomainDataAccessLayerContextModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                /*.Register(c => new EstelContext(
                    new DbContextOptionsBuilder<EstelContext>()
                        .UseSqlServer(c.Resolve<IOptions<ConnectionSettings>>().Value.EFConnectionString)
                        // .UseLazyLoadingProxies()
                        .Options
                ))*/
                .RegisterType<EstelContext>()
                //.AsSelf().InstancePerLifetimeScope(); ;
                .As<IQueryableUnitOfWork>().InstancePerLifetimeScope();

            /*   builder
                   .RegisterType<UnitOfWork>()
                   .As<IUnitOfWork>()
                   .InstancePerLifetimeScope();
   */
            builder
                .RegisterType<EventStoreSqlContext>()
                .AsSelf().InstancePerLifetimeScope(); ;
            builder
                .RegisterType<SqlEventStore>()
                .As<IEventStore>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<EventStoreSqlRepository>()
                .As<IEventStoreRepository>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<CustomerRepository>()
                .As<ICustomerRepository>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<CourseRepository>()
                .As<ICourseRepository>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<CourseTypeRepository>()
                .As<ICourseTypeRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
