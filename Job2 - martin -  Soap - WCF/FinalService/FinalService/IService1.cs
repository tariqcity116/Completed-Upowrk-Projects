using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Xml.Serialization;

namespace FinalService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "http://webservices.wialon.com/")]
    public interface IService1
    {

        [OperationContract]

        string storeTelemetryList([MessageParameter(Name = "telemetryWithDetails")] List<telemetryWithDetails> TelemetryWithDetail);



        // TODO: Add your service operations here
    }

    [DataContract(Name = "telemetry", Namespace = "")]
    [XmlRoot(ElementName = "telemetry", Namespace = "")]
    public class Telemetry
    {
        [DataMember]
        [XmlElement(ElementName = "coordX")]
        public double CoordX { get; set; }

        [DataMember]
        [XmlElement(ElementName = "coordY")]
        public double CoordY { get; set; }

        [DataMember]
        [XmlElement(ElementName = "date")]
        public DateTime Date { get; set; }

        [DataMember]
        [XmlElement(ElementName = "glonass")]
        public int Glonass { get; set; }

        [DataMember]
        [XmlElement(ElementName = "gpsCode")]
        public string GpsCode { get; set; }

        [DataMember]
        [XmlElement(ElementName = "speed")]
        public int Speed { get; set; }
    }

    [DataContract(Name = "telemetryDetails", Namespace = "")]

    [XmlRoot(ElementName = "telemetryDetails", Namespace = "")]
    public class TelemetryDetails
    {
        [DataMember]

        [XmlElement(ElementName = "sensorCode")]
        public string SensorCode { get; set; }

        [DataMember]
        [XmlElement(ElementName = "value")]
        public double Value { get; set; }
    }



    [MessageContract(WrapperName = "Hello", IsWrapped = true, WrapperNamespace = "")]
    [XmlRoot(ElementName = "telemetryWithDetails", Namespace = "")]
    public class telemetryWithDetails
    {
        [MessageBodyMember]
        public Telemetry Telemetry { get; set; }

        [MessageBodyMember(Name = "TelemetryDetails", Namespace = "")]
        public List<TelemetryDetails> TelemetryDetails { get; set; }
    }
}
