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

        public void AddPlanet(Planet planet)
        {
            throw new NotImplementedException();
        }

        public void AddStar(Star star)
        {
            throw new NotImplementedException();
        }

        public void DeletePlanet(Planet planet)
        {
            throw new NotImplementedException();
        }

        public void DeleteStar(Star star)
        {
            throw new NotImplementedException();
        }

        public Task<List<Planet>> GetAllPlanetsAsync()
        {
            return null;
        }

        public Task<List<Planet>> GetAllPlanetsAsync(bool returnMoons = false)
        {
            var query = _spaceDbContext.Planets;
            return query.ToListAsync();
        }

        public Task<List<Star>> GetAllSunsAsync()
        {
            var query = _spaceDbContext.Stars;
            return query.ToListAsync();
        }

        public Task<Planet> GetPlanetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Planet> GetPlanetAsync(int id, bool returnMoons = false)
        {
            throw new NotImplementedException();
        }

        public Task<Star> GetStarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
