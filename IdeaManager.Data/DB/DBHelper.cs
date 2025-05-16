using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaManager.Data.DB
{
    internal class DBHelper
    {
        public static string GetDatabasePath()
        {
            // AppData folder
            string userDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

            string appDataPath = Path.Combine(userDataFolder, "IdeaManager");
            Directory.CreateDirectory(appDataPath);
            return Path.Combine(appDataPath, "Idea.db");
        }
    }
}
