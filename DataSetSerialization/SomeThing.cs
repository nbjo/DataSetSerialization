using System.Xml.Serialization;

namespace DataSetSerialization
{
    public class SomeThing
    {
        [XmlElement("Things")]
        public List<Things> ThingsList { get; set; }
        [XmlElement("Person")]
        public List<Person> Persons { get; set; }
    }
}
