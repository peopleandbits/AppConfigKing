using System;
using System.Linq;
using System.Collections.Generic;

namespace AppConfigKing
{
    public class Program
    {
        public static ICmd Cmd { get; set; }
        static Dictionary<string, Type> _Lookup = CommandLookup.GetConfig();
        
        public static void Main(string[] args)
        {
            try
            {
                if (!CheckArgs(args) || !CheckCommandArg(args[0]))
                    throw new InvalidOperationException("Invading arguments.");

                var t = _Lookup[args[0]];
                Cmd = (ICmd)Activator.CreateInstance(t, args.Skip(1).ToArray());
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

        #region Private API
        static bool CheckArgs(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("Error: no arguments.");
                return false;
            }
            else
                return true;
        }

        static bool CheckCommandArg(string arg)
        {
            if (!_Lookup.ContainsKey(arg))
            {
                Console.WriteLine("Error: no command defined.");
                return false;
            }

            return true;
        }
        #endregion
    }
}