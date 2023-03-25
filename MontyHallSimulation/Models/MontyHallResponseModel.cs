using System.ComponentModel.DataAnnotations;

namespace MontyHallSimulation.Models
{
    public class MontyHallResponseModel
    {
        /// <summary>
        /// No Of Simulation
        /// </summary>

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value valid number")]
        public int NoOfSimulation { get; set; }

        /// <summary>
        /// IsResult
        /// </summary>
        public bool IsResult { get; set; }

        /// <summary>
        /// No Of Win
        /// </summary>
        public int Win { get; set; }

        /// <summary>
        /// No Of Loss
        /// </summary>
        public int Loss { get; set; }

        /// <summary>
        /// Impression
        /// </summary>
        public string Impression { get; set; }
    }
}
