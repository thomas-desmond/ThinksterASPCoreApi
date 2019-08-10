using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinksterASPCoreApi.DatabaseEntities;

namespace ThinksterASPCoreApi.Repository
{
    public interface ISpaceRepository
    {
        Task<bool> SaveChangesAsync();

        Task<List<Planet>> GetAllPlanetsAsync(bool returnMoons = false);
        Task<Planet> GetPlanetAsync(int id, bool returnMoons = false);
        void AddPlanet(Planet planet);
        void DeletePlanet(Planet planet);


        Task<List<Star>> GetAllStarsAsync();
        Task<Star> GetStarAsync(int id);
        void AddStar(Star star);
        void DeleteStar(Star star);
    }
}
