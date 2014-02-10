using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace DataAccess
{
    public class DataAccessFacade
    {
        public void Save(string filename, string xml)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(xml);
            }
        }

        public string Load(string filename)
        {
            string xml = File.ReadAllText(filename);
            return xml;
        }
    }
}
