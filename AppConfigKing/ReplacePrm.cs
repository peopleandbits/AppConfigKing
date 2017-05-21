using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppConfigKing
{
    public class ReplacePrm
    {
        public ReplacePrm(string path, string key, string connStr)
        {
            Init(path, key, connStr);
        }

        public ReplacePrm(string[] prms)
        {
            if (prms == null || prms.Length != 3)
                throw new InvalidOperationException("Invalid parameters. You'd need a path, a key and a connection string.");

            Init(prms[0], prms[1], prms[2]);
        }

        void Init(string path, string key, string connStr)
        {
            Path = path;
            Key = key;
            ConnectionString = connStr;
        }

        public string Path { get; set; }
        public string Key { get; set; }
        public string ConnectionString { get; set; }
    }
}