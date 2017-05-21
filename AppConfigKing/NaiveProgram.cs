using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Linq;
using System.IO;

namespace AppConfigKing
{
    public class NaiveProgram
    {
        #region Public API
        public static void NaiveMain(string[] args)
        {
            try
            {
                if (!CheckArgs(args) || args[0] != "-replace")
                    throw new InvalidOperationException("Invading arguments.");

                string msg = ExecuteReplace(args[1], args[2], args[3]);
                Console.WriteLine(msg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exiting.");
                Environment.Exit(-1);
            }
        }
        #endregion

        #region Private API
        static string ExecuteReplace(string path, string key, string connStr)
        {
            string xmltext = File.ReadAllText(path);
            string edited = Replace(xmltext, key, connStr);
            File.WriteAllText(path, edited);
            return "Replaced connection string. OK.";
        }

        static string Replace(string xmltext, string key, string connStr)
        {
            var xml = XDocument.Parse(xmltext);
            var keyElement = xml.Descendants("connectionStrings").Descendants().Where(c => c.Attribute("name").Value == key).First();
            keyElement.Attribute("connectionString").Value = connStr;
            return xml.ToString();
        }

        static bool CheckArgs(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Error: no arguments.");
                return false;
            }

            return true;
        }
        #endregion
    }
}