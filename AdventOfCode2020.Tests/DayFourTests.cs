namespace AdventOfCode2020.Tests
{
    using System.IO;
    using FluentAssertions;
    using NUnit.Framework;

    public class DayFourTests
    {
        [Test]
        public void Part1_CanExtractFirstPassportFromInput()
        {
            var input = new[]
            {
                "ecl:gry pid:860033327 eyr: 2020 hcl:#fffffd",
                "byr: 1937 iyr: 2017 cid: 147 hgt: 183cm",
                "",
                "iyr:2013 ecl: amb cid:350 eyr: 2023 pid: 028048884",
                "hcl:#cfa07d byr:1929",
                "",
                "hcl:#ae17e1 iyr:2013",
                "eyr: 2024",
                "ecl: brn pid:760753108 byr: 1931",
                "hgt: 179cm",
                "",
                "hcl:#cfa07d eyr:2025 pid:166559648",
                "iyr: 2011 ecl: brn hgt:59in"
            };

            DayFour.ExtractPassports(input)[0].Should().Be("ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm");
        }

        [Test]
        public void Part1_CanExtractAllPassportsFromInput()
        {
            var input = new[]
            {
                "ecl:gry pid:860033327 eyr: 2020 hcl:#fffffd",
                "byr: 1937 iyr: 2017 cid: 147 hgt: 183cm",
                "",
                "iyr:2013 ecl: amb cid:350 eyr: 2023 pid: 028048884",
                "hcl:#cfa07d byr:1929",
                "",
                "hcl:#ae17e1 iyr:2013",
                "eyr: 2024",
                "ecl: brn pid:760753108 byr: 1931",
                "hgt: 179cm",
                "",
                "hcl:#cfa07d eyr:2025 pid:166559648",
                "iyr: 2011 ecl: brn hgt:59in"
            };

            var expectedPassports = new[]
            {
                "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm",
                "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884 hcl:#cfa07d byr:1929",
                "hcl:#ae17e1 iyr:2013 eyr:2024 ecl:brn pid:760753108 byr:1931 hgt:179cm",
                "hcl:#cfa07d eyr:2025 pid:166559648 iyr:2011 ecl:brn hgt:59in"
            };

            DayFour.ExtractPassports(input).Should().BeEquivalentTo(expectedPassports);
        }

        [TestCase("ecl:gry pid:860033327 eyr:2020 hcl:#fffffd byr:1937 iyr:2017 cid:147 hgt:183cm", true)]
        [TestCase("iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884 hcl:#cfa07d byr:1929", false)]
        [TestCase("hcl:#ae17e1 iyr:2013 eyr:2024 ecl:brn pid:760753108 byr:1931 hgt:179cm", true)]
        public void Part1_CanCheckPassportContainsAllRequiredFields(string passport, bool expectedIsValid)
        {
            DayFour.PassportContainsAllRequiredFields(passport).Should().Be(expectedIsValid);
        }

        [Test]
        public void Part1_CalculateResultFromInput()
        {
            var input = File.ReadAllLines(@"Input/input4.txt");
            System.Console.WriteLine(DayFour.CalculateResultForPartOne(input));
        }

        [TestCase("pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980 hcl:#623a2f", true)]
        [TestCase("eyr:1972 cid:100 hcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926", false)]
        public void Part2_CanCheckPassportContainsValidValuesForEachField(string passport, bool expectedIsValid)
        {
            DayFour.PassportContainsValidValuesForEachField(passport).Should().Be(expectedIsValid);
        }

        [Test]
        public void Part2_CalculateResultFromInput()
        {
            var input = File.ReadAllLines(@"Input/input4.txt");
            System.Console.WriteLine(DayFour.CalculateResultForPartTwo(input));
        }
    }
}
