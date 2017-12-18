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
            //checkSensors();
            string sensorType = checkSensorType();
            string city = checkCity();
            string date = checkDate();
            lblSensorTest.Text = sensorType;
            lblCityTest.Text = city;
            lblDateTest.Text = date;
            AirMonit_SERVICE.Controllers.SensorsController service = new AirMonit_SERVICE.Controllers.SensorsController();
            Sensor s = service.GetSensorByName(sensorType, city);
            //checkParams();
            //display sensors;
            //display alarms;
        }

        private string checkSensorType()
        {
            if (cbNO2.Checked)
            {
                return "no2";
            }
            if (cbCO.Checked)
            {
                return "co";
            }
            if (cbO3.Checked)
            {
                return "o3";
            }
            return null; //mostrar erro
        }

        private string checkCity()
        {
            return cbCity.SelectedItem.ToString();
        }

        private string checkDate()
        {
            if (cbDate1.Checked)
            {
                if (cbDate2.Checked)
                {
                    if(dtpDate2.Value > dtpDate1.Value) { }
                    //fazer para as duas datas
                    //metodo a implementar
                    return dtpDate1.Value.ToString() + "  " + dtpDate2.Value.ToString();
                }
                if (cbHourlyStats.Checked)
                {
                    //fzer para as horas desse dia
                    return dtpDate1.Value.ToString();
                }
                //fazer para a date1
                return dtpDate1.Value.ToString();
            }
            //dizer que não há datas
            return "Não selecionou a data certa";
        }
    }
}
