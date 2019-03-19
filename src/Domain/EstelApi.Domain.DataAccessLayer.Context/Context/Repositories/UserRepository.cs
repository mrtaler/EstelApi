namespace EstelApi.Domain.DataAccessLayer.Context.Context.Repositories
{
    using EstelApi.Domain.DataAccessLayer.Context.Context;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;
    using System.Collections.Generic;
    using System.Linq;

    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;

    /// <inheritdoc cref="IUserRepository" />
    public class UserRepository : Repository<User>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerRepository"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public UserRepository(EstelContext context)
            : base(context)
        {
        }

        /* public override Customer GetById(object id)
         {
             var ret = this.unitOfWork
                 .CreateSet<Customer>()
                 .Include(x => x.Country)
                 .Include(x => x.Picture);

             var retData = ret.First(x => x.Id == (Guid)id);

             return retData;
         }*/

        /// <inheritdoc />
        public User GetByFirstName(string email)
        {
            var ret = this.GetAll().FirstOrDefault(c => c.FirstName == email);
            return ret;
        }

        /// <inheritdoc />
        public IEnumerable<User> GetEnabled()
        {
            return this.UnitOfWork.Users.Where(c => c.IsEnabled).OrderBy(c => c.FullName);
        }

        /// <inheritdoc />
        public override void Merge(User persisted, User current)
        {
            // merge customer and customer picture
            this.UnitOfWork.Entry<User>(persisted).CurrentValues.SetValues(current);
            
            // this.unitOfWork.Entry<Address>(persisted.Address).CurrentValues.SetValues(current.Address);
            //     this.unitOfWork.Entry<Picture>(persisted.Picture).CurrentValues.SetValues( current.Picture);
        }
    }
}
