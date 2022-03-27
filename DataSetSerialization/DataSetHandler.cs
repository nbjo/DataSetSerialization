using System.Data;
using System.Xml.Serialization;

namespace DataSetSerialization
{
    public class DataSetHandler
    {
        public void SerializeDataSet(string filename)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataSet));

            // Creates a DataSet; adds a table, column, and ten rows.
            DataSet dataSet = new DataSet("SomeThing");
            AddDataTableThings(dataSet);
            AddDataTablePerson(dataSet);
            TextWriter textWriter = new StreamWriter(filename);
            xmlSerializer.Serialize(textWriter, dataSet);
            //dataSet.WriteXml(textWriter, XmlWriteMode.DiffGram);
            textWriter.Close();
        }

        public MemoryStream SerializeDataSetMemoryStream()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(DataSet));

            // Creates a DataSet and adds tables
            DataSet dataSet = new DataSet("SomeThing");
            AddDataTableThings(dataSet);
            AddDataTablePerson(dataSet);

            MemoryStream memoryStream = new MemoryStream();
            xmlSerializer.Serialize(memoryStream, dataSet);

            return memoryStream;
        }

        private static void AddDataTableThings(DataSet dataSet)
        {
            DataTable dataTable = new DataTable("Things");
            DataColumn c1 = new DataColumn("Thing", typeof(string));
            DataColumn c2 = new DataColumn("AnotherThing", typeof(string));
            dataTable.Columns.Add(c1);
            dataTable.Columns.Add(c2);
            dataSet.Tables.Add(dataTable);
            for (int i = 0; i < 10; i++)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow[0] = "Thing content " + i;
                dataRow[1] = "Another Thing content " + i;
                dataTable.Rows.Add(dataRow);
            }
        }

        private static void AddDataTablePerson(DataSet dataSet)
        {
            DataTable dataTable = new DataTable("Person");
            DataColumn c1 = new DataColumn("Name", typeof(string));
            DataColumn c2 = new DataColumn("Age", typeof(string));
            DataColumn c3 = new DataColumn("Ssn", typeof(string));
            dataTable.Columns.Add(c1);
            dataTable.Columns.Add(c2);
            dataTable.Columns.Add(c3);
            dataSet.Tables.Add(dataTable);
            DataRow dataRow = dataTable.NewRow();
            dataRow["Name"] = "Peter Jensen";
            dataRow["Age"] = "34";
            dataRow["Ssn"] = "0101881457";
            dataTable.Rows.Add(dataRow);

            dataRow = dataTable.NewRow();
            dataRow["Name"] = "Vera Andersen";
            dataRow["Age"] = "42";
            dataRow["Ssn"] = "0102802412";
            dataTable.Rows.Add(dataRow);

            dataRow = dataTable.NewRow();
            dataRow["Name"] = "Karl Ejner";
            dataRow["Age"] = "52";
            dataRow["Ssn"] = "0108703677";
            dataTable.Rows.Add(dataRow);
        }
    }
}
