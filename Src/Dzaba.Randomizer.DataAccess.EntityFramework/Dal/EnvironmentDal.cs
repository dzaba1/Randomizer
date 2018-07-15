using Dzaba.Randomizer.DataAccess.Contracts.Dal;
using Dzaba.Randomizer.DataAccess.Contracts.Model;
using Dzaba.Randomizer.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dzaba.Randomizer.DataAccess.EntityFramework.Dal
{
    internal sealed class EnvironmentDal : IEnvironmentDal
    {
        private readonly Func<DatabaseContext> dbContextFactory;

        public EnvironmentDal(Func<DatabaseContext> dbContextFactory)
        {
            Require.NotNull(dbContextFactory, nameof(dbContextFactory));

            this.dbContextFactory = dbContextFactory;
        }

        public async Task<int> Create(string name, long creatorId)
        {
            using (var dbContext = dbContextFactory())
            {
                var entity = new Contracts.Model.Environment
                {
                    Name = name,
                    Users = new List<EnvironmentUser>()
                };

                entity.Users.Add(new EnvironmentUser
                {
                    UserId = creatorId
                });

                dbContext.Environments.Add(entity);
                await dbContext.SaveChangesAsync();

                return entity.Id;
            }
        }

        public async Task<Randomizer.Contracts.Environment[]> GetAllAsync()
        {
            using (var dbContext = dbContextFactory())
            {
                var model = await dbContext.Environments.ToArrayAsync();
                return model.Select(e => e.ToContract()).ToArray();
            }
        }

        public async Task<Randomizer.Contracts.Environment> GetAsync(int id)
        {
            using (var dbContext = dbContextFactory())
            {
                var entity = await dbContext.Environments.FirstOrDefaultAsync(e => e.Id == id);
                return entity?.ToContract();
            }
        }
    }
}
