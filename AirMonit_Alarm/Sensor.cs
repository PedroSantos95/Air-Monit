using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace AirMonit_Alarm
{
    [XmlRoot("alarm")]
    public class Sensor
    {
        [XmlElement("sensor_id")]
        public int Id { get; set; }
        [XmlElement("sensor_name")]
        public string Name { get; set; }
        [XmlElement("sensor_date")]
        public string Date { get; set; }
        [XmlElement("sensor_city")]
        public string City { get; set; }
        [XmlElement("sensor_value")]
        public int Value { get; set; }
        [XmlElement("sensor_trigger_rule")]
        public string Trigger_rule { get; set; }
        [XmlElement("sensor_trigger_value")]
        public int Trigger_value { get; set; }

        public Sensor()
        {
        }

        internal string Serialize()
        {
            if (this == null)
            {
                return string.Empty;
            }
            try
            {
                var xmlserializer = new XmlSerializer(typeof(Sensor));
                var stringWriter = new StringWriter();
                using (var writer = XmlWriter.Create(stringWriter))
                {
                    xmlserializer.Serialize(writer, this);
                    return stringWriter.ToString();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred", ex);
            }
        }

    }
}
