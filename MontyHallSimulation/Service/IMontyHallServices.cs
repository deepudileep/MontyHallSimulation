using MontyHallSimulation.Models;

namespace MontyHallSimulation.Service
{
    public interface IMontyHallServices
    {
        MontyHallResponseModel MontyHallCalculation(MontyHallResponseModel montyHallResponseModel);
    }
}
