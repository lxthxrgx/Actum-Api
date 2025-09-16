using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ACG_Api.model.XPath
{
    public class CheckFolder
    {

        public int ParseName(string path){
            string name = Path.GetFileNameWithoutExtension(path);
            bool match = Regex.IsMatch(name, @"_\d+$");
            if (match is true)
            {
                var value = Regex.Match(name, @"_(\d+)$");
                if (value.Success)
                {
                    string numberStr = value.Groups[1].Value;
                    int number = int.Parse(numberStr);

                    return number;
                }
            }
            else
            {
                Console.WriteLine("No number in file name");
            }
            return 0;
        }

        public string CheckFiles(string path){
            if(Path.Exists($"{path}"))
            {
                int number = ParseName(path);
                if(number is 0)
                {
                    return "No number in file name";
                }else{
                    //Save file with name _number+1
                }
            }
            else{
                Console.WriteLine("No file in thid directory");
            }
            return "";
        }
    }
}