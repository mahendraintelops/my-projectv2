using Core.Entities;
using Core.Repositories;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class MyResourceRepository : RepositoryBase<MyResource>, IMyResourceRepository
    {
        public MyResourceRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
