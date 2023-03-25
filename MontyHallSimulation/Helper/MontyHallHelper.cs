using MontyHallSimulation.Models;
using System.Security.AccessControl;

namespace MontyHallSimulation.Helper
{
    public class MontyHallHelper :IMontyHallHelper
    {
        public bool MontyHallCalculation(MontyHallPickHelperModel montyHallPickHelperModel)
        {
            bool win = false;
            ProbableGoat probableGoat = new ProbableGoat()
            {
                Left = 0,
                Right = 2
            };

            //Select the probable option from switch case
            probableGoat = GetGoatDetails(montyHallPickHelperModel.SelectedDoor);

            int keepGoat = montyHallPickHelperModel.GoatDoor == 0 ? probableGoat.Right : probableGoat.Left;

            if (montyHallPickHelperModel.ChangeDoor == 0)
            {
                // go ahead with selected one
                win = montyHallPickHelperModel.CarDoor == montyHallPickHelperModel.SelectedDoor;
            }
            else
            {
                // Ready to change the selected one
                win = montyHallPickHelperModel.CarDoor != keepGoat;
            }
            return win;
        }
        private ProbableGoat GetGoatDetails(int selectDoor) => selectDoor switch
        {
            0 => new ProbableGoat() { Left = 1, Right = 2 },
            1 => new ProbableGoat() { Left = 0, Right = 2 },
            2 => new ProbableGoat() { Left = 0, Right = 1 },
            _ => throw new ArgumentOutOfRangeException(nameof(selectDoor), $"Not expected selected value: {selectDoor}"),
        };
    }
}
