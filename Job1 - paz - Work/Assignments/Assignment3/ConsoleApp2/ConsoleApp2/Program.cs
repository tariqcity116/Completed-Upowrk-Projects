// See https://aka.ms/new-console-template for more information
using System.Xml.Serialization;

Console.WriteLine("Hello, World!");

//using System.Xml.Serialization;
//using System.IO;



// Create an instance of the XmlSerializer for your C# class
XmlSerializer serializer = new XmlSerializer(typeof(Example));

// Create a StringReader to read the XML string
string xmlString = "<example><name>John</name><age>30</age></example>";
StringReader stringReader = new StringReader(xmlString);

// Deserialize the XML string into a C# object
Example exampleObject = (Example)serializer.Deserialize(stringReader);
var result = "";
// Define your C# class that corresponds to the XML structure
[XmlRoot("example")]
public class Example
{
    [XmlElement("name")]
    public string Name { get; set; }

    [XmlElement("age")]
    public int Age { get; set; }
}