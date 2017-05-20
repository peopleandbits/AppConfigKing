using System;
using System.Linq;
using System.Collections.Generic;

namespace AppConfigKing
{
    public class Program
    {
        #region Properties
        public static ICmd Cmd { get; set; }
        #endregion

        #region Fields
        static Dictionary<string, ICmd> _Lookup = new Dictionary<string, ICmd>()
            {
                { "-replace", new ReplaceCmd() }
            };
        #endregion

        #region Public API
        public static void Main(string[] args)
        {
            try
            {
                if (!CheckCommandArg(args))
                    throw new InvalidOperationException("Invading arguments.");

                Cmd = _Lookup[args[0]];
                Cmd.InjectParameters(args.Skip(1).ToArray());
                string msg = Cmd.Execute();
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
        static bool CheckCommandArg(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Error: no arguments.");
                return false;
            }

            if (!_Lookup.ContainsKey(args[0]))
            {
                Console.WriteLine("Error: no command defined.");
                return false;
            }

            return true;
        }
        #endregion
    }
}