using System.IO;

namespace Zadanie_3
{
    public static class FileHelper
    {
        /// <summary>
        /// Checks if config file exists if not creates it
        /// </summary>
        public static void ConfigFileExists()
        {
            if (!File.Exists(Constants.CONFIG_FILE_PATH))
                File.Create(Constants.CONFIG_FILE_PATH);
        }
    }
}