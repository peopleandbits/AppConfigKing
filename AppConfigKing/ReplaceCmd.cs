using System;

namespace AppConfigKing
{
    public class ReplaceCmd : ICmd
    {
        public ReplaceCmd(params string[] prms)
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

        public ReplacePrm Parameters { get; private set; }
        public bool ResultOK { get; set; } = false;
        
        public string Execute()
        {
            if (Parameters == null)
                throw new InvalidOperationException("Parameters are missing.");

            var config = new AppConfigFile(Parameters.Path);
            var cse = new ConnectionStringProcessor(config.Load());
            string edited = cse.Replace(Parameters.Key, Parameters.ConnectionString);
            config.Save(edited);
            ResultOK = true;
            return "Replaced connection string. OK.";
        }
    }
}