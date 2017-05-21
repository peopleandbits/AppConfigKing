using System;

namespace AppConfigKing
{
    public class RemovePrm
    {
        public RemovePrm(string path, string key)
        {
            Init(path, key);
        }

        public RemovePrm(string[] prms)
        {
            if (prms == null || prms.Length != 2)
                throw new InvalidOperationException("Invalid parameters. You'd need a path, a key and a connection string.");

            Init(prms[0], prms[1]);
        }

        void Init(string path, string key)
        {
            Path = path;
            Key = key;
        }

        public string Path { get; set; }
        public string Key { get; set; }
    }
}