using AirMonit_DLog.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AirMonit_SERVICE.Controllers
{
    public class SensorsController : ApiController
    {
        //string str_conn = "server=(localdb)\\MSSQLLocalDB;Database=DBSensors;Trusted_Connection=True;";

        string str_conn = "server=(localdb)\\MSSQLLocalDB;Initial Catalog = DBAirMonit; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IEnumerable<Sensor> GetAllSensors()
        {
            List<Sensor> sensors = new List<Sensor>();
            SqlConnection conn = null;
            conn = new SqlConnection(str_conn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Sensors order by Id", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Sensor s = new Sensor();
                s.Id = (int)reader["id"];
                s.Name = (string)reader["name"];
                s.Value = (int)reader["value"];
                s.Date = (string)reader["date"];
                s.City = (string)reader["city"];
                sensors.Add(s);
            }
            return sensors;
        }

        [Route("api/sensors/{id:int}")]
        public IHttpActionResult GetSensor(int id)
        {
            Sensor s = new Sensor();
            SqlConnection conn = null;
            conn = new SqlConnection(str_conn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Sensors where Id=" + id + "", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                s.Id = (int)reader["id"];
                s.Name = (string)reader["name"];
                s.Value = (int)reader["value"];
                s.Date = (string)reader["date"];
                s.City = (string)reader["city"];
                reader.Close();
                conn.Close();
                return Ok(s);
            }
            reader.Close();
            conn.Close();
            return NotFound();
        }

        [Route("api/sensors/{name}")]
        public List<Sensor> GetSensorByName(string name)
        {
            List<Sensor> sensors = new List<Sensor>();
            SqlConnection conn = null;
            conn = new SqlConnection(str_conn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Sensors where Name='" + name + "'", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Sensor s = new Sensor();
                s.Id = (int)reader["id"];
                s.Name = (string)reader["name"];
                s.Value = (int)reader["value"];
                s.Date = (string)reader["date"];
                s.City = (string)reader["city"];
                sensors.Add(s);
            }
            reader.Close();
            conn.Close();
            return sensors;
        }


        [Route("api/sensors/{name}/{city}")]
        public List<Sensor> GetSensorByNameAndCity(string name, string city)
        {
            List<Sensor> sensors = new List<Sensor>();
            SqlConnection conn = null;
            conn = new SqlConnection(str_conn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Sensors where Name='" + name + "' and City='" + city + "'", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Sensor s = new Sensor();
                s.Id = (int)reader["id"];
                s.Name = (string)reader["name"];
                s.Value = (int)reader["value"];
                s.Date = (string)reader["date"];
                s.City = (string)reader["city"];
                sensors.Add(s);
            }
            reader.Close();
            conn.Close();
            return sensors;
        }

        [Route("api/sensors/{name}/{date}")]
        public List<Sensor> GetSensorByNameAndDateForAllCities(string name, string date)
        {
            List<Sensor> sensors = new List<Sensor>();
            SqlConnection conn = null;
            conn = new SqlConnection(str_conn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Sensors where Name='" + name + "' and Date='" + date + "'", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Sensor s = new Sensor();
                s.Id = (int)reader["id"];
                s.Name = (string)reader["name"];
                s.Value = (int)reader["value"];
                s.Date = (string)reader["date"];
                s.City = (string)reader["city"];
                sensors.Add(s);
            }
            reader.Close();
            conn.Close();
            return sensors;
        }

        [Route("api/sensors/{name}/{city}/{date}")]
        public List<Sensor> GetSensorByNameAndCityAndDate(string name, string city, string date)
        {
            List<Sensor> sensors = new List<Sensor>();
            SqlConnection conn = null;
            conn = new SqlConnection(str_conn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Sensors where Name='" + name + "' and City='" + city + "' and Date='" + date + "'", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Sensor s = new Sensor();
                s.Id = (int)reader["id"];
                s.Name = (string)reader["name"];
                s.Value = (int)reader["value"];
                s.Date = (string)reader["date"];
                s.City = (string)reader["city"];
                sensors.Add(s);
            }
            reader.Close();
            conn.Close();
            return sensors;
        }

        public void PostSensor(Sensor s)
        {
            SqlConnection conn = null;
            conn = new SqlConnection(str_conn);
            conn.Open();
            string date = s.Date;
            string[] data =date.Split(' ');
            string str_cmd = "Insert into Sensors values ('" + s.Name + "', '" + s.Value + "', '" + data[0] + "', '" + data[1] + "', '" + s.City + "')";
            SqlCommand cmd = new SqlCommand(str_cmd, conn);
            //cmd.Parameters.AddWithValue("name", p.Name); <-- mais segurança
            int nRows = cmd.ExecuteNonQuery();
            conn.Close();
            /*if (nRows > 0)
            {
                return Ok(s);
            }
            else
                return NotFound();*/
        }

        public void PostAlarm(Sensor s)
        {
            SqlConnection conn = null;
            conn = new SqlConnection(str_conn);
            conn.Open();
            string date = s.Date;
            string[] data = date.Split(' ');
            string str_cmd = "Insert into Alarms values ('" + s.Id + "', '" + s.Name + "', '" + data[0] + "', '" + data[1] + "', '" + s.City + "', '" + s.Value + "', '" + s.Trigger_rule + "', '" + s.Trigger_value + "')";
            SqlCommand cmd = new SqlCommand(str_cmd, conn);
            //cmd.Parameters.AddWithValue("name", p.Name); <-- mais segurança
            int nRows = cmd.ExecuteNonQuery();
            conn.Close();
            /*if (nRows > 0)
            {
                return Ok(s);
            }
            else
                return NotFound();*/
        }

        [Route("api/sensors/{id:int}")]
        public IHttpActionResult PutSensor(int id, Sensor s)
        {
            SqlConnection conn = null;
            conn = new SqlConnection(str_conn);
            conn.Open();
            string str_cmd = "Update Sensors set Name='" + s.Name + "', Value='" + s.Value + "', Date=" + s.Date + "', City=" + s.City + " where Id=" + id;
            SqlCommand cmd = new SqlCommand(str_cmd, conn);
            int nRows = cmd.ExecuteNonQuery();
            conn.Close();
            if (nRows > 0)
            {
                return Ok(s);
            }
            else
                return NotFound();
        }

        [Route("api/sensors/{id:int}")]
        public IHttpActionResult DeleteSensor(int id)
        {
            SqlConnection conn = null;
            conn = new SqlConnection(str_conn);
            conn.Open();
            string str_cmd = "Delete from Sensors where Id=" + id;
            SqlCommand cmd = new SqlCommand(str_cmd, conn);
            int nRows = cmd.ExecuteNonQuery();
            conn.Close();
            if (nRows > 0)
            {
                return Ok();
            }
            else
                return NotFound();
        }
    }
}
