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
            
            if (!NumberInRange(short.Parse(passportDictionary["byr"]), 1920, 2002)) return false;
            
            if (!NumberInRange(short.Parse(passportDictionary["iyr"]), 2010, 2020)) return false;
            
            if (!NumberInRange(short.Parse(passportDictionary["eyr"]), 2020, 2030)) return false;

            var hgtValue = passportDictionary["hgt"];
            if (hgtValue.EndsWith("cm"))
            {
                var hgtInt = short.Parse(hgtValue.Replace("cm", ""));
                if (!NumberInRange(hgtInt, 150, 193)) return false;
            }
            else if (hgtValue.EndsWith("in"))
            {
                var hgtInt = short.Parse(hgtValue.Replace("in", ""));
                if (!NumberInRange(hgtInt, 59, 76)) return false;
            }
            else
            {
                return false;
            }

            if (!Regex.IsMatch(passportDictionary["hcl"], @"^#[0-9a-f]{6}$")) return false;
            
            if (!Regex.IsMatch(passportDictionary["ecl"], @"^amb|blu|brn|gry|grn|hzl|oth$")) return false;
            
            return Regex.IsMatch(passportDictionary["pid"], @"^[0-9]{9}$");
        }

        private static bool NumberInRange(int number, int min, int max)
        {
            return number >= min && number <= max;
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
