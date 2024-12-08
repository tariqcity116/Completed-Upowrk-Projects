using Microsoft.AspNetCore.Mvc;
using System.Xml.Serialization;

namespace Webhooks.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlertController : ControllerBase
    {
       

        private readonly ILogger<AlertController> _logger;

        public AlertController(ILogger<AlertController> logger)
        {
            _logger = logger;
        }

        [HttpGet("GetAlerts")]
        public Alarm GetAlerts(string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Alarm));
            StringReader stringReader = new StringReader(xmlString);
            return (Alarm)serializer.Deserialize(stringReader);
        }
    }


    [XmlRoot(ElementName = "AlarmCamera")]
    public class AlarmCamera
    {

        [XmlElement(ElementName = "CameraID")]
        public int CameraID { get; set; }

        [XmlElement(ElementName = "ServerID")]
        public int ServerID { get; set; }

        [XmlElement(ElementName = "ProductType")]
        public int ProductType { get; set; }

        [XmlElement(ElementName = "CameraDescription")]
        public int CameraDescription { get; set; }

        [XmlElement(ElementName = "Lx")]
        public int Lx { get; set; }

        [XmlElement(ElementName = "Ly")]
        public int Ly { get; set; }
    }

    [XmlRoot(ElementName = "Point1")]
    public class Point1
    {

        [XmlElement(ElementName = "X")]
        public int X { get; set; }

        [XmlElement(ElementName = "Y")]
        public int Y { get; set; }
    }

    [XmlRoot(ElementName = "Point2")]
    public class Point2
    {

        [XmlElement(ElementName = "X")]
        public int X { get; set; }

        [XmlElement(ElementName = "Y")]
        public int Y { get; set; }
    }

    [XmlRoot(ElementName = "Point3")]
    public class Point3
    {

        [XmlElement(ElementName = "X")]
        public int X { get; set; }

        [XmlElement(ElementName = "Y")]
        public int Y { get; set; }
    }

    [XmlRoot(ElementName = "Point4")]
    public class Point4
    {

        [XmlElement(ElementName = "X")]
        public int X { get; set; }

        [XmlElement(ElementName = "Y")]
        public int Y { get; set; }
    }

    [XmlRoot(ElementName = "Bounding_Box")]
    public class BoundingBox
    {

        [XmlElement(ElementName = "Point1")]
        public Point1 Point1 { get; set; }

        [XmlElement(ElementName = "Point2")]
        public Point2 Point2 { get; set; }

        [XmlElement(ElementName = "Point3")]
        public Point3 Point3 { get; set; }

        [XmlElement(ElementName = "Point4")]
        public Point4 Point4 { get; set; }
    }

    [XmlRoot(ElementName = "Side")]
    public class Side
    {

        [XmlElement(ElementName = "SideNumber")]
        public int SideNumber { get; set; }

        [XmlElement(ElementName = "SideDescription")]
        public string SideDescription { get; set; }

        [XmlElement(ElementName = "Count")]
        public int Count { get; set; }

        [XmlElement(ElementName = "Direction")]
        public string Direction { get; set; }
    }

    [XmlRoot(ElementName = "Alarm")]
    public class Alarm
    {

        [XmlElement(ElementName = "AlarmCamera")]
        public AlarmCamera AlarmCamera { get; set; }

        [XmlElement(ElementName = "AlarmID")]
        public int AlarmID { get; set; }

        [XmlElement(ElementName = "AlarmType")]
        public int AlarmType { get; set; }

        [XmlElement(ElementName = "TypeDescription")]
        public string TypeDescription { get; set; }

        [XmlElement(ElementName = "AlarmTime")]
        public DateTime AlarmTime { get; set; }

        [XmlElement(ElementName = "JTEAlarmTime")]
        public DateTime JTEAlarmTime { get; set; }

        [XmlElement(ElementName = "FilterArea")]
        public string FilterArea { get; set; }

        [XmlElement(ElementName = "FilterType")]
        public string FilterType { get; set; }

        [XmlElement(ElementName = "FilterName")]
        public string FilterName { get; set; }

        [XmlElement(ElementName = "ColorFilterType")]
        public string ColorFilterType { get; set; }

        [XmlElement(ElementName = "ColorFilterName")]
        public string ColorFilterName { get; set; }

        [XmlElement(ElementName = "Bounding_Box")]
        public BoundingBox BoundingBox { get; set; }

        [XmlElement(ElementName = "Side")]
        public Side Side { get; set; }

        [XmlElement(ElementName = "ImageUrl")]
        public string ImageUrl { get; set; }

        [XmlElement(ElementName = "VideoUrl")]
        public string VideoUrl { get; set; }

        [XmlElement(ElementName = "AlarmImage")]
        public string AlarmImage { get; set; }
    }
}