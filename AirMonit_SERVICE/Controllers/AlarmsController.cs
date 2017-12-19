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
    public class AlarmsController : ApiController
    {
        string str_conn = "server=(localdb)\\MSSQLLocalDB;Initial Catalog = DBAirMonit; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public IEnumerable<Sensor> GetAllAlarms()
        {
            List<Sensor> alarms = new List<Sensor>();
            SqlConnection conn = null;
            conn = new SqlConnection(str_conn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Alarms order by Id", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Sensor a = new Sensor();
                a.Id = (int)reader["id"];
                a.Name = (string)reader["name"];
                a.Value = (int)reader["value"];
                a.Date = (string)reader["date"];
                a.Time = (string)reader["time"];
                a.City = (string)reader["city"];
                a.Trigger_rule = (string)reader["trigger_rule"];
                a.Trigger_value =(int)reader["trigger_value"];
                alarms.Add(a);
            }
            return alarms;
        }

        [Route("api/alarms/{name}/{city}/{date}")]
        public List<Sensor> GetAlarmsByNameAndCityAndDate(string name, string city, string date)
        {
            List<Sensor> alarms = new List<Sensor>();
            SqlConnection conn = null;
            conn = new SqlConnection(str_conn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Alarms where Name='" + name + "' and City='" + city + "' and Date='" + date + "'", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Sensor a = new Sensor();
                a.Id = (int)reader["id"];
                a.Name = (string)reader["name"];
                a.Value = (int)reader["value"];
                a.Date = (string)reader["date"];
                a.Time = (string)reader["time"];
                a.City = (string)reader["city"];
                a.Trigger_rule = (string)reader["trigger_rule"];
                a.Trigger_value = (int)reader["trigger_value"];
                alarms.Add(a);
            }
            reader.Close();
            conn.Close();
            return alarms;
        }

        [Route("api/alarms/{name}/{city}/{date}")]
        public List<Sensor> GetAlarmsByNameAndCityAndBetweenTwoDates(string name, string city, string date1, string date2)
        {
            List<Sensor> alarms = new List<Sensor>();
            SqlConnection conn = null;
            conn = new SqlConnection(str_conn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Alarms where Name='" + name + "' and City='" + city + "' and Date between '" + date1 + "' and '" + date2 + "'", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Sensor a = new Sensor();
                a.Id = (int)reader["id"];
                a.Name = (string)reader["name"];
                a.Value = (int)reader["value"];
                a.Date = (string)reader["date"];
                a.Time = (string)reader["time"];
                a.City = (string)reader["city"];
                a.Trigger_rule = (string)reader["trigger_rule"];
                a.Trigger_value = (int)reader["trigger_value"];
                alarms.Add(a);
            }
            reader.Close();
            conn.Close();
            return alarms;
        }

        [Route("api/alarms/{id:int}")]
        public IHttpActionResult GetAlarm(int id)
        {
            Sensor a = new Sensor();
            SqlConnection conn = null;
            conn = new SqlConnection(str_conn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Alarms where Id=" + id + "", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                a.Id = (int)reader["id"];
                a.Name = (string)reader["name"];
                a.Value = (int)reader["value"];
                a.Date = (string)reader["date"];
                a.Time = (string)reader["time"];
                a.City = (string)reader["city"];
                a.Trigger_rule = (string)reader["trigger_rule"];
                a.Trigger_value = (int)reader["trigger_value"];
                reader.Close();
                conn.Close();
                return Ok(a);
            }
            reader.Close();
            conn.Close();
            return NotFound();
        }

        [Route("api/alarms/{name}")]
        public List<Sensor> GetAlarmByName(string name)
        {
            List<Sensor> alarms = new List<Sensor>();
            SqlConnection conn = null;
            conn = new SqlConnection(str_conn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Alarms where Name='" + name + "'", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Sensor a = new Sensor();
                a.Id = (int)reader["id"];
                a.Name = (string)reader["name"];
                a.Value = (int)reader["value"];
                a.Date = (string)reader["date"];
                a.Time = (string)reader["time"];
                a.City = (string)reader["city"];
                a.Trigger_rule = (string)reader["trigger_rule"];
                a.Trigger_value = (int)reader["trigger_value"];
                alarms.Add(a);
            }
            reader.Close();
            conn.Close();
            return alarms;
        }


        [Route("api/alarms/{name}/{city}")]
        public List<Sensor> GetAlarmsByNameAndCity(string name, string city)
        {
            List<Sensor> alarms = new List<Sensor>();
            SqlConnection conn = null;
            conn = new SqlConnection(str_conn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Alarms where Name='" + name + "' and City='" + city + "'", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Sensor a = new Sensor();
                a.Id = (int)reader["id"];
                a.Name = (string)reader["name"];
                a.Value = (int)reader["value"];
                a.Date = (string)reader["date"];
                a.Time = (string)reader["time"];
                a.City = (string)reader["city"];
                a.Trigger_rule = (string)reader["trigger_rule"];
                a.Trigger_value = (int)reader["trigger_value"];
                alarms.Add(a);
            }
            reader.Close();
            conn.Close();
            return alarms;
        }

        [Route("api/alarms/{name}/{date}")]
        public List<Sensor> GetAlarmsByNameAndDateForAllCities(string name, string date)
        {
            List<Sensor> alarms = new List<Sensor>();
            SqlConnection conn = null;
            conn = new SqlConnection(str_conn);
            conn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Alarms where Name='" + name + "' and Date='" + date + "'", conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Sensor a = new Sensor();
                a.Id = (int)reader["id"];
                a.Name = (string)reader["name"];
                a.Value = (int)reader["value"];
                a.Date = (string)reader["date"];
                a.Time = (string)reader["time"];
                a.City = (string)reader["city"];
                alarms.Add(a);
            }
            reader.Close();
            conn.Close();
            return alarms;
        }

    }
        
}
