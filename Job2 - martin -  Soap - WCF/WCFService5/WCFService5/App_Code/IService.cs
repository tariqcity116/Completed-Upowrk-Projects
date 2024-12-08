using System.ServiceModel;
using System.Xml.Serialization;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract(Namespace = "http://webservices.wialon.com/")]
[XmlSerializerFormat]
public interface IService
{

    [OperationContract]

    [XmlSerializerFormat]
    string storeTelemetryList(storeTelemetryList storeTelemetryList);


}

[MessageContract]
public class ProcessMessageResponse
{
    [MessageBodyMember]
    public string Result { get; set; }
}

// Use a data contract as illustrated in the sample below to add composite types to service operations.

[MessageContract(IsWrapped = false)]
public class storeTelemetryList
{
    // [System.Xml.Serialization.XmlElementAttribute("storeTelemetryLists", Namespace = "http://webservices.wialon.com/")]

    [MessageBodyMember(Name = "storeTelemetryList")]
    [XmlArray(Namespace = "http://webservices.wialon.com/")]
    [XmlArrayItem(Namespace = "")]

    public telemetryWithDetails[] storeTelemetryLists { get; set; }
}


public partial class telemetryWithDetails
{
    [System.Xml.Serialization.XmlElementAttribute("telemetry", Namespace = "")]
    [MessageBodyMember(Name = "telemetry")]
    public Telemetry telemetry { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("telemetryDetails", Namespace = "")]
    [MessageBodyMember(Name = "telemetryDetails")]
    public TelemetryDetails[] telemetryDetails { get; set; }
}


public partial class Telemetry
{
    [System.Xml.Serialization.XmlElementAttribute("coordX", Namespace = "")]
    [MessageBodyMember(Namespace = "")]
    public double coordX { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("coordY", Namespace = "")]
    [MessageBodyMember(Namespace = "")]
    public double coordY { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("date", Namespace = "")]
    [MessageBodyMember(Namespace = "")]
    public System.DateTime date { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("glonass", Namespace = "")]
    [MessageBodyMember(Namespace = "")]
    public int glonass { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("gpsCode", Namespace = "")]
    [MessageBodyMember(Namespace = "")]
    public string gpsCode { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("speed", Namespace = "")]
    [MessageBodyMember(Namespace = "")]
    public int speed { get; set; }
}


public partial class TelemetryDetails
{

    [System.Xml.Serialization.XmlElementAttribute("sensorCode", Namespace = "")]
    [MessageBodyMember(Namespace = "")]
    public string sensorCode { get; set; }

    [System.Xml.Serialization.XmlElementAttribute("value", Namespace = "")]

    [MessageBodyMember(Namespace = "")]
    public double value { get; set; }

}
