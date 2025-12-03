using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBTPRDM_PROVA_02.Repositories
{
    public class Constants
    {
        public const string DatabaseFileName = "CBTPRDM_PROVA_02.db3";

        public const SQLiteOpenFlags Flags = 
            SQLiteOpenFlags.ReadWrite | 
            SQLiteOpenFlags.Create |                 
            SQLiteOpenFlags.SharedCache;

        public static string DatabasePath => 
            Path.Combine(FileSystem.AppDataDirectory, DatabaseFileName);
    }
}
