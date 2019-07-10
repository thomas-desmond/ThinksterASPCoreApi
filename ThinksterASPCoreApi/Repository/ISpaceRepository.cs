using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThinksterASPCoreApi.DatabaseEntities;

namespace ThinksterASPCoreApi.Repository
{
    public interface ISpaceRepository
    {
        Task<List<Planet>> GetAllPlanetsAsync();
        Task<List<Star>> GetAllSunsAsync();

    }
}
