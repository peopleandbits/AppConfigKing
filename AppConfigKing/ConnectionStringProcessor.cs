using System.Linq;
using System.Xml.Linq;

namespace AppConfigKing
{
    public class ConnectionStringProcessor
    {
        public ConnectionStringProcessor(string xmltext)
        {
            _XML = XDocument.Parse(xmltext);
        }

        XDocument _XML;

        public string Replace(string key, string connStr)
        {
            var keyElement = _XML.Descendants("connectionStrings").Descendants().Where(c => c.Attribute("name").Value == key).First();
            keyElement.Attribute("connectionString").Value = connStr;
            return _XML.ToString();
        }

        public string Remove(string key)
        {
            var keyElement = _XML.Descendants("connectionStrings").Descendants().Where(c => c.Attribute("name").Value == key).First();
            keyElement.Remove();
            return _XML.ToString();
        }
    }
}