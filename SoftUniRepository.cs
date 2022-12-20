using PracticingEFCore.Infrastructure.Data;

namespace EFCoreBestPractices.Infrastructure.Data.Common
{
    public class SoftUniRepository : Repository, ISoftUniRepository
    {
        public SoftUniRepository(SoftUniContext context)
        {
            this.Context = context;
        }
    }
}
