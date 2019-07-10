using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinksterASPCoreApi.DatabaseEntities;

namespace ThinksterASPCoreApi.Repository
{
    public class SpaceRepository : ISpaceRepository
    {
        private readonly SpaceDatabaseContext _spaceDbContext;

        public SpaceRepository(SpaceDatabaseContext spaceDbContext)
        {
            _spaceDbContext = spaceDbContext;
            _spaceDbContext.Database.EnsureCreated();
        }

        public Task<List<Planet>> GetAllPlanetsAsync()
        {
            var query = _spaceDbContext.Planets;
            return query.ToListAsync();
        }

        public Task<List<Star>> GetAllSunsAsync()
        {
            var query = _spaceDbContext.Stars;
            return query.ToListAsync();
        }
    }
}
