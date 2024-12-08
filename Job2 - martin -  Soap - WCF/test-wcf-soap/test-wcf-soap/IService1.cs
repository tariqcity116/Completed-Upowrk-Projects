using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace test_wcf_soap
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]

        string storeTelemetryList(List<telemetryWithDetails> TelemetryWithDetail);


        //[OperationContract]
        //void MyOperation(MyArrayMessage message);
    }

    //[OperationContract]
    //string AddPerson(Person[] persons);





    //[DataContract(Name = "telemetryWithDetails", Namespace = "")]

    //public class TelemetryWithDetails
    //{
    //    [DataMember(Name = "telemetry")]
    //    public Telemetry Telemetry { get; set; }

    //    [DataMember(Name = "telemetryDetailss")]

    //    public List<TelemetryDetails> TelemetryDetails { get; set; }
    //}

    //[DataContract(Name = "telemetry", Namespace = "")]

    //public class Telemetry
    //{
    //    [DataMember(Name = "coordX")]
    //    public double CoordX { get; set; }

    //    [DataMember(Name = "coordY")]
    //    public double CoordY { get; set; }

    //    [DataMember(Name = "speed")]
    //    public int Speed { get; set; }

    //    [DataMember(Name = "date")]
    //    public DateTime Date { get; set; }

    //    [DataMember(Name = "glonass")]
    //    public int Glonass { get; set; }

    //    [DataMember(Name = "gpsCode")]
    //    public string GpsCode { get; set; }
    //}

    //[DataContract(Name = "telemetryDetails", Namespace = "")]

    //public class TelemetryDetails
    //{
    //    [DataMember(Name = "sensorCode")]
    //    public string SensorCode { get; set; }

    //    [DataMember(Name = "value")]
    //    public double Value { get; set; }
    //}

    //[DataContract]
    //public class Address
    //{
    //    [DataMember]
    //    public string Street { get; set; }

    //    [DataMember]
    //    public string City { get; set; }

    //    [DataMember]
    //    public string State { get; set; }

    //    [DataMember]
    //    public string ZipCode { get; set; }
    //}

    //[DataContract]
    //public class Person
    //{
    //    [DataMember]
    //    public string Name { get; set; }

    //    [DataMember]
    //    public int Age { get; set; }

    //    [DataMember]
    //    public Address[] Addresss { get; set; }
    //}


    /////
    ///
    [DataContract]
   // [XmlRoot(ElementName = "telemetry", Namespace = "")]
    public class Telemetry
    {
        [DataMember]
      //  [XmlElement(ElementName = "coordX")]
        public double CoordX { get; set; }

        [DataMember]
      //  [XmlElement(ElementName = "coordY")]
        public double CoordY { get; set; }

        [DataMember]
     //   [XmlElement(ElementName = "date")]
        public DateTime Date { get; set; }

        [DataMember]
     //   [XmlElement(ElementName = "glonass")]
        public int Glonass { get; set; }

        [DataMember]
     //   [XmlElement(ElementName = "gpsCode")]
        public string GpsCode { get; set; }

        [DataMember]
    //    [XmlElement(ElementName = "speed")]
        public int Speed { get; set; }
    }

    [DataContract(Name = "telemetryDetails", Namespace = "")]

   // [XmlRoot(ElementName = "telemetryDetails", Namespace = "")]
    public class TelemetryDetails
    {
        [DataMember]

     //   [XmlElement(ElementName = "sensorCode")]
        public string SensorCode { get; set; }

        [DataMember]
      //  [XmlElement(ElementName = "value")]
        public double Value { get; set; }
    }



    [DataContract]
  //  [XmlRoot(ElementName = "telemetryWithDetails", Namespace = "")]
    public class telemetryWithDetails
    {
        [DataMember]
        public Telemetry Telemetry { get; set; }

        [DataMember]
        public List<TelemetryDetails> TelemetryDetails { get; set; }
    }

    //[XmlRoot(ElementName = "storeTelemetryList", Namespace = "http://webservices.wialon.com/")]
    //public class StoreTelemetryList
    //{

    //    [XmlElement(ElementName = "telemetryWithDetails", Namespace = "")]
    //    public telemetryWithDetails TelemetryWithDetails { get; set; }
    //}

    //[XmlRoot(ElementName = "TestGian", Namespace = "http://webservices.wialon.com/")]
    //public class TestGian
    //{

    //    [XmlElement(ElementName = "Listado")]
    //    public telemetryWithDetails TelemetryWithDetails { get; set; }
    //}




    ////////

    //[MessageContract]
    //public class MyArrayMessage
    //{
    //    [MessageBodyMember(Name = "Object", Namespace = "http://example.com")]
    //    public MyObject[] ObjectArray { get; set; }
    //}

   
    //public class MyObject
    //{
    //    [DataMember]
    //    public string Name { get; set; }

    //    [DataMember]
    //    public int Value { get; set; }
    //}
}