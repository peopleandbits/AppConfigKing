using System.IO;
using System.Xml.Linq;

namespace AppConfigKing
{
    public class AppConfigFile
    {
        public AppConfigFile(string path)
        {
            Path = path;
        }

        public string Path { get; set; }

        public string Load()
        {
            return File.ReadAllText(Path);
        }

        public XDocument LoadX()
        {
            return XDocument.Load(Path);
        }

        public void Save(string text)
        {
            File.WriteAllText(Path, text);
        }
    }
}
