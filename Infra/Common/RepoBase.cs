using Infra.Common.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Common
{
    public class RepoBase(AppDBContext dbContext)
    {
        public async Task CommitChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
