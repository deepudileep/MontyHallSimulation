using Microsoft.AspNetCore.Mvc;
using MontyHallSimulation.Controllers;
using MontyHallSimulation.Helper;
using MontyHallSimulation.Models;

namespace MontyHallSimulation.Service
{
    public class MontyHallServices : IMontyHallServices
    {
        private readonly ILogger<HomeController> logger;
        private readonly IMontyHallHelper helper;

        public MontyHallServices(ILogger<HomeController> logger, IMontyHallHelper helper)
        {
            this.logger = logger;
            this.helper = helper;
        }
        public MontyHallResponseModel MontyHallCalculation(MontyHallResponseModel montyHallResponseModel)
        {
            try
            {

                Random random = new Random();

                for (int i = 0; i < montyHallResponseModel.NoOfSimulation; i++)
                {
                    MontyHallPickHelperModel montyHallPickHelperModel = new MontyHallPickHelperModel()
                    {
                        SelectedDoor = random.Next(3),
                        CarDoor = random.Next(3),
                        ChangeDoor = 1,
                        GoatDoor = random.Next(1),
                    };

                    bool result = this.helper.MontyHallCalculation(montyHallPickHelperModel);

                    if (result)
                        montyHallResponseModel.Win++;
                    else
                        montyHallResponseModel.Loss++;

                    montyHallResponseModel.IsResult = true;

                    if (montyHallResponseModel.Win > montyHallResponseModel.Loss)
                    {
                        montyHallResponseModel.Impression = "The chances of winning is higher, if you change the door.";
                    }
                    else
                    {
                        montyHallResponseModel.Impression = "The chances of winning is lesser, if you change the door.";
                    }
                }

            }
            catch (Exception ex)
            {
                this.logger.LogError("Error Occured:-", ex);
            }
            return montyHallResponseModel;
        }
    }
}
