namespace EstelApi.Application.Interfaces
{
    using System.Threading.Tasks;

    using EstelApi.Domain.DataAccessLayer.Context.Interfaces;

    public class BaseService
    {
        private readonly IQueryableUnitOfWork uow;

        public BaseService(IQueryableUnitOfWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// The commit.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        protected Task<bool> CommitAsync()
        {
            return Task.FromResult(this.uow.Commit());
        }
    }
}