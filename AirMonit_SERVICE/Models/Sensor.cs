using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirMonit_DLog.Models
{
    [Serializable]
    public class Sensor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string City { get; set; }
        public string Trigger_rule { get; set; }
        public int Trigger_value { get; set; }
    }
}
