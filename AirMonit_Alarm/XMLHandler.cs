using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace AirMonit_Alarm
{
    class XMLHandler
    {
        private bool isValid = false;

        public string XmlFilePath { get; set; }
        public string XsdFilePath { get; set; }
        public string ValidationMessage { get; set; }


        public XMLHandler(string xmlFile)
        {
            this.XmlFilePath = xmlFile;
        }

        public XMLHandler(string xmlFile, string xsdFile)
        {
            this.XmlFilePath = xmlFile;
            this.XsdFilePath = xsdFile;
        }


        public bool ValidadeXml()
        {

            isValid = true;
            /*
            ValidationMessage = "Document is valid!";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(XmlFilePath);
                ValidationEventHandler eventHandler = new ValidationEventHandler(MyEvent);
                doc.Schemas.Add(null, XsdFilePath);
                doc.Validate(eventHandler);

            }
            catch (XmlException e)
            {
                isValid = false;
                ValidationMessage = String.Format("Error {0}", e.Message);
            }
            */
            return isValid;
        }

        private void MyEvent(object sender, ValidationEventArgs e)
        {
            isValid = false;
            ValidationMessage = String.Format("Document not valid! {0}", e.Message);
        }
    }
}
