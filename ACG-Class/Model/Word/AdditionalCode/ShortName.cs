using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACG_Class.Model.Word.AdditionalCode
{
    public static class ShortName
    {
        public static string GetShortenedName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Full name cannot be null or empty.", nameof(fullName));
            }

            var parts = fullName.Split(' ');

            if (parts.Length < 3)
            {
                throw new ArgumentException("Full name must include at least three parts: last name, first name, and middle name.", nameof(fullName));
            }

            var lastName = parts[0];
            var firstNameInitial = parts[1][0];
            var middleNameInitial = parts[2][0];

            return $"{lastName} {firstNameInitial}.{middleNameInitial}.";
        }
    }
}
