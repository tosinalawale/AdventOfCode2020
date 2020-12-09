namespace AdventOfCode2020
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class DayFour
    {
        public static int CalculateResultForPartOne(string[] input)
        {
            var passports = ExtractPassports(input);

            return passports.Count(PassportContainsAllRequiredFields);
        }

        public static int CalculateResultForPartTwo(string[] input)
        {
            var passports = ExtractPassports(input);

            return passports.Count(p => PassportContainsAllRequiredFields(p) && PassportContainsValidValuesForEachField(p));
        }

        public static List<string> ExtractPassports(string[] input)
        {
            var passports = new List<string>
            {
                string.Empty
            };

            var currentInputIndex = 0;
            var currentPassportIndex = 0;

            while (currentInputIndex < input.Length)
            {
                if (input[currentInputIndex] != string.Empty)
                {
                    passports[currentPassportIndex] += " " + input[currentInputIndex].Replace(": ", ":");
                    passports[currentPassportIndex] = passports[currentPassportIndex].TrimStart();
                }
                else
                {
                    passports.Add("");
                    currentPassportIndex++;
                }

                currentInputIndex++;
            }

            return passports;
		}

        public static bool PassportContainsAllRequiredFields(string passport)
        {
            var passportDictionary = GenerateDictionaryForPassport(passport);

            string[] requiredFields = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

            return requiredFields.All(field => passportDictionary.ContainsKey(field));
        }

        public static bool PassportContainsValidValuesForEachField(string passport)
        {
            var passportDictionary = GenerateDictionaryForPassport(passport);
            
            if (!YearValueIsValid("byr", 1920, 2002, passportDictionary)) return false;

            if (!YearValueIsValid("iyr", 2010, 2020, passportDictionary)) return false;

            if (!YearValueIsValid("eyr", 2020, 2030, passportDictionary)) return false;

            //var iyrValue = passportDictionary["iyr"];
            //var iyrInt = Int16.Parse(iyrValue);
            //if (!(iyrValue.Length == 4 && iyrInt >= 2010 && iyrInt <= 2020))
            //{
            //    return false;
            //}

            //var byrValue = passportDictionary["byr"];
            //var byrInt = Int16.Parse(byrValue);
            //if (!(byrValue.Length == 4 && byrInt >= 2020 && byrInt <= 2030))
            //{
            //    return false;
            //}

            var hgtValue = passportDictionary["hgt"];
            if (hgtValue.EndsWith("cm"))
            {
                var hgtInt = short.Parse(hgtValue.Replace("cm", ""));
                if (!(hgtInt >= 150 && hgtInt <= 193)) return false;
            }
            else if (hgtValue.EndsWith("in"))
            {
                var hgtInt = short.Parse(hgtValue.Replace("in", ""));
                if (!(hgtInt >= 59 && hgtInt <= 76)) return false;
            }
            else
            {
                return false;
            }

            var hclValue = passportDictionary["hcl"];
            if (!Regex.IsMatch(hclValue, @"^#[0-9a-f]{6}$")) return false;

            var eclValue = passportDictionary["ecl"];
            if (!Regex.IsMatch(eclValue, @"(amb|blu|brn|gry|grn|hzl|oth)")) return false;

            var pidValue = passportDictionary["pid"];
            return Regex.IsMatch(pidValue, @"^\d{9}$");
        }

        private static bool YearValueIsValid(string propertyName, int min, int max, Dictionary<string, string> passportDictionary)
        {
            var propertyValue = passportDictionary[propertyName];
            var propertyInt = short.Parse(propertyValue);
            return propertyValue.Length == 4 && propertyInt >= min && propertyInt <= max;
        }

        private static Dictionary<string,string> GenerateDictionaryForPassport(string passport)
        {
            var keyValuePairs = passport.Split();

            return keyValuePairs
                .Select(keyValuePair => keyValuePair.Split(':'))
                .ToDictionary(stringParts => stringParts[0], stringParts => stringParts[1]);
        }
    }
}
