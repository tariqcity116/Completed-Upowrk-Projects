using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Serialization;

namespace Martin_Soap_WCF
{
    

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace = "http://webservices.wialon.com/")]
    public interface IService1
    {

        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
      
        string storeTelemetryList(TelemetryWithDetails[] telemetryWithDetails);

        // TODO: Add your service operations here
    }


    //// Use a data contract as illustrated in the sample below to add composite types to service operations.
    //[DataContract]
    //public class CompositeType
    //{
    //    bool boolValue = true;
    //    string stringValue = "Hello ";

    //    [DataMember]
    //    public bool BoolValue
    //    {
    //        get { return boolValue; }
    //        set { boolValue = value; }
    //    }

    //    [DataMember]
    //    public string StringValue
    //    {
    //        get { return stringValue; }
    //        set { stringValue = value; }
    //    }
    //}

    [DataContract(Name = "telemetryWithDetails", Namespace = "http://webservices.wialon.com/")]
   
    public class TelemetryWithDetails
    {
        [DataMember(Name = "telemetry")]
        public Telemetry Telemetry { get; set; }

        [DataMember(Name = "telemetryDetails")]
        
        public TelemetryDetails[] TelemetryDetails { get; set; }
    }

    [DataContract(Name = "telemetry", Namespace = "http://webservices.wialon.com/")]
  
    public class Telemetry
    {
        [DataMember(Name = "coordX")]
        public double CoordX { get; set; }

        [DataMember(Name = "coordY")]
        public double CoordY { get; set; }

        [DataMember(Name = "speed")]
        public int Speed { get; set; }

        [DataMember(Name = "date")]
        public DateTime Date { get; set; }

        [DataMember(Name = "glonass")]
        public int Glonass { get; set; }

        [DataMember(Name = "gpsCode")]
        public string GpsCode { get; set; }
    }

    [DataContract(Name = "telemetryDetails", Namespace = "http://webservices.wialon.com/")]
   
    public class TelemetryDetails
    {
        [DataMember(Name = "sensorCode")]
        public string SensorCode { get; set; }

        [DataMember(Name = "value")]
        public double Value { get; set; }
    }
}
