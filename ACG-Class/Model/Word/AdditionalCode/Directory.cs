using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ACG_Class.Model.Word.AdditionalCode
{
    public class Directory
    {
        private static string LoadSettingValue(string key)
        {
            var configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            var json = System.IO.File.ReadAllText(configFilePath);
            var jObject = JObject.Parse(json);
            string section = "CustomSettings";
            var myCustomSettings = jObject[section];
            if (myCustomSettings == null)
            {
                return null;
            }

            var valueToken = myCustomSettings[key];
            return valueToken?.ToString();
        }

        private static string SanitizeDirectoryName(string name)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            var sanitized = new string(name
                .Where(ch => !invalidChars.Contains(ch))
                .ToArray());
            return sanitized;
        }

        public static string CreateDirectoryForDoc(string NameGroup2D)
        {
            try
            {
                var pathFromSettings = LoadSettingValue("path");
                if (pathFromSettings == null)
                {
                    Console.WriteLine("Path not found in settings.json.");
                    return null;
                }
                var sanitizedDirectoryName = SanitizeDirectoryName(NameGroup2D);

                var full_path = Path.Combine(pathFromSettings, sanitizedDirectoryName);

                if (Directory.Exists(full_path))
                {
                    Console.WriteLine("That path exists already.");
                    return full_path;
                }

                DirectoryInfo di = Directory.CreateDirectory(full_path);
                Console.WriteLine($"Directory created successfully at {di.FullName}");
                return di.FullName;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"The process failed: {ex.ToString()}");
                return null;
            }
        }
    }
}
