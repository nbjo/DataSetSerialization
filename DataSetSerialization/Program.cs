// See https://aka.ms/new-console-template for more information

using System.Xml.Linq;
using System.Xml.Serialization;
using DataSetSerialization;

Console.WriteLine("Hello, World!");

//string fileName = @"c:\temp\SomeThings.xml";
var dataSetHandler = new DataSetHandler();
//dataSetHandler.SerializeDataSet(filename: fileName); // Works!
MemoryStream memoryStream = dataSetHandler.SerializeDataSetMemoryStream();
memoryStream.Position = 0;
XDocument doc = XDocument.Load(memoryStream);
memoryStream.Close();

//XDocument doc = XDocument.Load(fileName);
List<XElement> items = doc.Descendants("SomeThing").ToList();
XElement xElement = items[0];

var serializer = new XmlSerializer(typeof(SomeThing));
SomeThing? someThing = serializer.Deserialize(xElement.CreateReader()) as SomeThing;
var thingsList = someThing?.ThingsList;
