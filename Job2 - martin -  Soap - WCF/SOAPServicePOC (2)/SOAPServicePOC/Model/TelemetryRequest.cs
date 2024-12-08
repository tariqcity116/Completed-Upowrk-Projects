using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SOAPServicePOC.Model
{
    [XmlRoot(ElementName = "telemetry")]
    public class Telemetry
    {

        [XmlElement(ElementName = "coordX")]
        public double CoordX { get; set; }

        [XmlElement(ElementName = "coordY")]
        public double CoordY { get; set; }

        [XmlElement(ElementName = "date")]
        public DateTime Date { get; set; }

        [XmlElement(ElementName = "glonass")]
        public int Glonass { get; set; }

        [XmlElement(ElementName = "gpsCode")]
        public string GpsCode { get; set; }

        [XmlElement(ElementName = "speed")]
        public int Speed { get; set; }
    }

    [XmlRoot(ElementName = "telemetryDetails")]
    public class TelemetryDetails
    {

        [XmlElement(ElementName = "sensorCode")]
        public string SensorCode { get; set; }

        [XmlElement(ElementName = "value")]
        public double Value { get; set; }
    }

    [XmlRoot(ElementName = "telemetryWithDetails",  Namespace = "")]
    public class telemetryWithDetails
    {

        [XmlElement(ElementName = "telemetry")]
        public Telemetry Telemetry { get; set; }

        [XmlElement(ElementName = "telemetryDetails")]
        public List<TelemetryDetails> TelemetryDetails { get; set; }
    }

    [XmlRoot(ElementName = "storeTelemetryList" , Namespace = "http://webservices.wialon.com/")]
    public class StoreTelemetryList
    {

        [XmlElement(ElementName = "telemetryWithDetails")]
        public telemetryWithDetails TelemetryWithDetails { get; set; }
    }

    [XmlRoot(ElementName = "TestGian", Namespace = "http://webservices.wialon.com/")]
    public class TestGian
    {

        [XmlElement(ElementName = "Listado")]
        public telemetryWithDetails TelemetryWithDetails { get; set; }
    }

    //[XmlRoot(ElementName = "Body")]
    //public class Body
    //{
    //    [XmlElement(ElementName = "storeTelemetryList")]
    //    public StoreTelemetryList StoreTelemetryList { get; set; }
    //}
}

