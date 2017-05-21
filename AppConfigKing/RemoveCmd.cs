using System;

namespace AppConfigKing
{
    public class RemoveCmd : ICmd
    {
        public RemoveCmd(params string[] prms)
        {
            try
            {
                Parameters = new RemovePrm(prms[0], prms[1]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public RemovePrm Parameters { get; private set; }
        public bool ResultOK { get; set; } = false;
        
        public string Execute()
        {
            if (Parameters == null)
                throw new InvalidOperationException("Parameters are missing.");

            var config = new AppConfigFile(Parameters.Path);
            var cse = new ConnectionStringProcessor(config.Load());
            string edited = cse.Remove(Parameters.Key);
            config.Save(edited);
            ResultOK = true;
            return "Replaced connection string. OK.";
        }
    }
}