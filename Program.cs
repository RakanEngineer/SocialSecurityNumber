using System.Globalization;

namespace SocialSecurityNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Social Security Number (YYMMDD-XXXX): ");
            string socialSecurityNumber = Console.ReadLine();
            Console.Clear();

            int genderNumber = int.Parse(socialSecurityNumber.Substring(9, 1));
            bool isFemale = genderNumber % 2 == 0;
            string sex = isFemale ? "Female" : "Male";
            //if (isFemale)
            //{
            //    sex = "Female";
            //}
            //else
            //{
            //    sex = "Male";
            //}

            string dateTimePart = socialSecurityNumber.Substring(0, 6);
            DateTime birthDate = DateTime.ParseExact(dateTimePart, "yyMMdd", CultureInfo.InvariantCulture);
            int age = DateTime.Now.Year - birthDate.Year;

            if (birthDate.Date > DateTime.Now.AddYears(-age))
            {
                --age;
            }
            if ((birthDate.Month > DateTime.Now.Month) ||
                (birthDate.Month == DateTime.Now.Month && birthDate.Day > DateTime.Now.Day))
            {
                --age;
            }
            Console.WriteLine($"{sex} , {age}");
        }
    }
}
