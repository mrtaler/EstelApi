namespace EstelApi.Domain.DataAccessLayer.Context.Context.Repositories
{
    using System.Collections.Generic;
    using System.Linq;

    using EstelApi.Domain.DataAccessLayer.Context.Context;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.CustomerAgg;
    using EstelApi.Domain.DataAccessLayer.Context.CoreEntities.Repositories;
    using EstelApi.Domain.DataAccessLayer.Context.Repository.Base;

    /// <inheritdoc cref="IUserRepository" />
    public class UserRepository : Repository<User>, IUserRepository
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:EstelApi.Domain.DataAccessLayer.Context.Context.Repositories.UserRepository" /> class. 
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public UserRepository(EstelContext context)
            : base(context)
        {
        }

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
            this.UnitOfWork.Entry(persisted).CurrentValues.SetValues(current);
        }
    }
}
