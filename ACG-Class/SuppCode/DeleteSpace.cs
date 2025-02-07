using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ACG_Class.SuppCode
{
    public static class DeleteSpace
    {
        public static string Deletespace(string p)
        {
            try
            {
                if (p is not null)
                {
                    var cleanedData = Regex.Replace(p, @"[\r\n]+", " ").Trim();
                    return cleanedData;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Deletespace: {ex.Message}");
            }
            return null;
        }
    }
}
