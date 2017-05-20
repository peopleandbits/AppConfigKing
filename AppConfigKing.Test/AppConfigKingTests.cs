using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Xml.Linq;

namespace AppConfigKing.Test
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Main_ReplaceCmd()
        {
            string cmd = "-replace";
            string path = Helper.GetPath();
            string key = "sampleDatabase";
            string connStr = "tttt";

            // act
            Program.Main(new[] { cmd, path, key, connStr });

            // assert
            var acf = new AppConfigFile(Helper.GetPath());
            string edited = acf.Load();
            Assert.IsTrue(edited.Contains($"connectionString=\"{connStr}\""));
            Assert.IsTrue(Program.Cmd.ResultOK);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Main_ReplaceCmd_InvalidOperation()
        {
            string cmd = "-replace";
            string path = Helper.GetPath();
            string key = "sampleDatabase";
            string connStr = null; // this causes exception...

            // act
            Program.Main(new[] { cmd, path, key, connStr });

            // assert
            // how the fuck to test environment.exit??

        }
    }

    [TestClass]
    public class AppConfigFileTests
    {
        [TestMethod]
        public void Load()
        {
            var acf = new AppConfigFile(Helper.GetPath());

            string text = acf.Load();
            Assert.IsNotNull(text);

            XDocument xml = acf.LoadX();
            Assert.IsNotNull(xml);
        }
    }

    [TestClass]
    public class ConnectionStringEditorTests
    {
        [TestMethod]
        public void ReplaceConnectionString()
        {
            var acf = new AppConfigFile(Helper.GetPath());
            var cse = new ConnectionStringEditor(acf.Load());
            string key = "sampleDatabase";
            string connStr = "kkkk";

            string edited = cse.Replace(key, connStr);
            Assert.IsTrue(edited.Contains($"connectionString=\"{connStr}\""));
        }
    }

    public class Helper
    {
        public static string GetPath()
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = string.Format("{0}\\{1}", directory, "App.Config");
            return path;
        }
    }
}