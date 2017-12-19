using AirMonit_DLog.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace AirMonit_Admin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cbCity.Items.Add("Leiria");
            cbCity.Items.Add("Coimbra");
            cbCity.Items.Add("Lisboa");
            cbCity.Items.Add("Porto");
            cbCity.Items.Add("Todas");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {


            lstSensorsInfo.Items.Clear();
            string[] sensorType = checkSensorType();
            string city = checkCity();
            string date = checkDate();
            string[] dates = date.Split('#');
            if (sensorType.Length == 3)
            {
                lblSensorTest.Text = sensorType[0] + " " + sensorType[1] + " " + sensorType[2];
            }
            else if (sensorType.Length == 2)
            {
                lblSensorTest.Text = sensorType[0] + " " + sensorType[1];
            }
            else if (sensorType.Length == 1)
            {
                lblSensorTest.Text = sensorType[0];
            }

            lblCityTest.Text = city;
            lblDateTest.Text = date;
            /*lstHourlyInfo.Items.Add(dates[0]);
            lstHourlyInfo.Items.Add(dates[1]);*/
            AirMonit_SERVICE.Controllers.SensorsController service = new AirMonit_SERVICE.Controllers.SensorsController();
            //List<Sensor> sensors = service.GetSensorByNameAndCity(sensorType, city);

            if (cbHourlyStats.Checked)
            {
                label5.Text = "[Sensors]:";
                if (cbNO2.Checked)
                {
                    checkHourlyStats("NO2", city);
                }
                if (cbCO.Checked)
                {
                    checkHourlyStats("CO", city);
                }
                if (cbO3.Checked)
                {
                    checkHourlyStats("O3", city);
                }
            }

            for (int i = 0; i < sensorType.Length; i++)
            {   
                if (city == "Todas")
                {
                    lblCityTest.Text = "Leiria Coimbra Lisboa Porto";
                    string[] allCities = { "Leiria", "Coimbra", "Lisboa", "Porto" };
                    for (int j = 0; j < allCities.Length; j++)
                    {
                        if (dates.Length == 2)
                        {
                            List<Sensor> sensorsAllCitiesBetweenTwoDates = service.GetSensorByNameAndCityAndBetweenTwoDates(sensorType[i], allCities[j], dates[0], dates[1]);
                            foreach (Sensor s in sensorsAllCitiesBetweenTwoDates)
                            {
                                lstSensorsInfo.Items.Add("Id: " + s.Id + " - Name: " + s.Name + " - City: " + s.City + " - Value: " + s.Value + " - Date: " + s.Date);
                            }
                        }
                        else
                        {
                            List<Sensor> sensorsAllCities = service.GetSensorByNameAndCityAndDate(sensorType[i], allCities[j], date);
                            foreach (Sensor s in sensorsAllCities)
                            {
                                lstSensorsInfo.Items.Add("Id: " + s.Id + " - Name: " + s.Name + " - City: " + s.City + " - Value: " + s.Value + " - Date: " + s.Date);
                            }
                        }
                        
                    }
                }
                else
                {
                    if (dates.Length == 2)
                    {
                        List<Sensor> sensorsAllCitiesBetweenTwoDates = service.GetSensorByNameAndCityAndBetweenTwoDates(sensorType[i], city, dates[0], dates[1]);
                        foreach (Sensor s in sensorsAllCitiesBetweenTwoDates)
                        {
                            lstSensorsInfo.Items.Add("Id: " + s.Id + " - Name: " + s.Name + " - City: " + s.City + " - Value: " + s.Value + " - Date: " + s.Date);
                        }
                    }else
                    {
                        List<Sensor> sensors = service.GetSensorByNameAndCityAndDate(sensorType[i], city, date);
                        foreach (Sensor s in sensors)
                        {
                            lstSensorsInfo.Items.Add("Id: " + s.Id + " - Name: " + s.Name + " - City: " + s.City + " - Value: " + s.Value + " - Date: " + s.Date);
                        }
                    }
                    
                }
            }
        }

        private string[] checkSensorType()
        {
            if (cbNO2.Checked)
            {
                if (cbCO.Checked)
                {
                    if (cbO3.Checked)
                    {
                        string[] sensors1 = { "NO2", "CO", "O3" };
                        return sensors1;
                    }

                    string[] sensors2 = { "NO2", "CO" };
                    return sensors2;
                }
                if (cbO3.Checked)
                {
                    string[] sensors3 = { "NO2", "O3" };
                    return sensors3;
                }
                string[] sensors4 = { "NO2" };
                return sensors4;
            }
            if (cbCO.Checked)
            {
                if (cbO3.Checked)
                {
                    string[] sensors5 = { "CO", "O3" };
                    return sensors5;
                }
                string[] sensors6 = { "CO" };
                return sensors6;
            }
            if (cbO3.Checked)
            {
                string[] sensors7 = { "O3" };
                return sensors7;
            }
            string[] error = { "Sensor not selected" };
            return error;
        }

        private string checkCity()
        {
            if (cbCity.SelectedIndex > -1)
            {
                return cbCity.SelectedItem.ToString();
            }
            return "Todas";
        }

        private string checkDate()
        {
            if (cbDate1.Checked)
            {
                if (cbDate2.Checked)
                {
                    if (dtpDate2.Value > dtpDate1.Value)
                    {
                        string dates =  dtpDate1.Value.ToString() + "#" + dtpDate2.Value.ToString();
                        return dates;
                    }
                    else if (cbHourlyStats.Checked)
                    {
                        return "Can't show hourly stats with 2 dates";
                    }
                    else
                    {
                        return "Date2 isn't after than Date1";
                    }

                }
                string[] date = dtpDate1.Value.ToString().Split(' ');
                return date[0];
            }
            return "Date not selected";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbHourlyStats.Checked)
            {
                label5.Text = "[Alarms]:";
            }
        }

        private void checkHourlyStats(string name, string city)
        {
            AirMonit_SERVICE.Controllers.SensorsController service = new AirMonit_SERVICE.Controllers.SensorsController();
            List<Sensor> sensors = service.GetSensorByNameAndCity(name, city);
            hourlyAvg(sensors);
        }

        private void hourlyAvg(List<Sensor> sensors)
        {
            int[] hourlyValue = new int[24];
            int[] count = new int[24];
            string name = "";
            string city = "";
            foreach (Sensor s in sensors)
            {
                string time = s.Time;
                name = s.Name;
                city = s.City;
                string[] hour = time.Split(':');
                s.Time = hour[0];

                for (int i = 0; i < 24; i++)
                {
                    hourlyValue[i] += s.Value;
                    count[i]++;
                }

            }
            for(int y = 0; y<24; y++)
            {
                if (hourlyValue[y] != 0)
                {
                    int avg = hourlyValue[y] / count[y];
                    lstHourlyInfo.Items.Add(" Name: " + name + " - City: " + city + " - Average: " + avg + " - Hour: " + hourlyValue[y]);
                }
            }

        }
    }
}
