using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConfigKing
{
    public class CommandLookup
    {
        public static Dictionary<string, Type> GetConfig()
        {
            return new Dictionary<string, Type>()
            {
                { "-replace", typeof(ReplaceCmd) }
            };
        }
    }
}