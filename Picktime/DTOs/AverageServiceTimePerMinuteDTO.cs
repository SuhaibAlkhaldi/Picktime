using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Picktime.DTOs
{
    public class AverageServiceTimePerMinuteDTO
    {


        private double _expectedEstimatedTime;
        private double _actualEstimatedTime;

        public double ExpectedEstimatedTime
        {
            get => Math.Round(_expectedEstimatedTime, 1);
            set => _expectedEstimatedTime = value;
        }

        public double ActualEstimatedTime
        {
            get => Math.Round(_actualEstimatedTime, 1);
            set => _actualEstimatedTime = value;
        }
    }
}
