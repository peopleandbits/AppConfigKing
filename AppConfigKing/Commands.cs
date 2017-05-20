using System;

namespace AppConfigKing
{
    public interface ICmd
    {
        void InjectParameters(string[] prms);
        string Execute();
        bool ResultOK { get; set; }
    }

    public class ReplacePrm
    {
        public ReplacePrm(string path, string key, string connStr)
        {
            if (path == null || key == null || connStr == null)
                throw new InvalidOperationException("Invalid parameters. You'd need a path, a key and a connection string.");

            Path = path;
            Key = key;
            ConnectionString = connStr;
        }

        public string Path { get; set; }
        public string Key { get; set; }
        public string ConnectionString { get; set; }
    }

    public class ReplaceCmd : ICmd
    {
        public ReplacePrm Parameters { get; private set; }
        public bool ResultOK { get; set; } = false;

        public void InjectParameters(string[] prms)
        {
            try
            {
                Parameters = new ReplacePrm(prms[0], prms[1], prms[2]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Execute()
        {
            if (Parameters == null)
                throw new InvalidOperationException("Parameters are missing.");

            var config = new AppConfigFile(Parameters.Path);
            var cse = new ConnectionStringEditor(config.Load());
            string edited = cse.Replace(Parameters.Key, Parameters.ConnectionString);
            config.Save(edited);
            ResultOK = true;
            return "Replaced connection string. OK.";
        }
    }
}