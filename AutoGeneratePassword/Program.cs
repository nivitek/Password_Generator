using System;
using System.Text;

namespace AutoGeneratePassword
{
    public class PasswordGenerator
    {
        //Declaration of all the characters including special characters
        private const string UpperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ", LowerChars = "abcdefghijklmnopqrstuvwxyz", num = "0123456789", SpecialChars = "!@#$%^&*";
        //Method to generate and the password
        public static string GeneratePassword(int MinLength, int MaxLength)
        {
            //adding up all the characters as an array to generate password
            string[] CharSetArray = { UpperChars, LowerChars, num, SpecialChars };
            string CharSet = string.Concat(CharSetArray);
            StringBuilder sb = new StringBuilder();
            Random rd = new Random();
            //To define password length
            int Length = rd.Next(MinLength, MaxLength);
            //Generating complex requirements(with one uppercase, one lowercase, one special character and one number)
            for (int i = 0; i < CharSetArray.Length; i++)
            {
                int Position = rd.Next(CharSetArray[i].Length);
                sb.Append(CharSetArray[i][Position]);
            }
            //To generate random password along with complex requirements
            for (int i = CharSetArray.Length; Length > i; i++)
            {
                sb = sb.Insert(rd.Next(sb.Length), CharSet[rd.Next(sb.Length - 1)]);
            }
            return sb.ToString();
        }
        //Returning the generated password to the user by calling GeneratePassword method
        public static void Main()
        {
            Console.Write("Enter the minimum length of the password: ");
            int MinLength = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the maximum length of the password: ");
            int MaxLength = Convert.ToInt32(Console.ReadLine());
            string Password = GeneratePassword(MinLength, MaxLength);
            Console.WriteLine("Your System Generated Password is: " + Password);
            Console.WriteLine("Password Length: " + Password.Length);
        }
    }
}