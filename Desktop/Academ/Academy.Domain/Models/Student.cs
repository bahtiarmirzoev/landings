using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Academy.Domain.Models
{
    public class Student
    {
        public const int MAX_STUDENTNAME_LENGHT = 100;
        public const int MAX_PHONE_LENGHT = 15;

        private Student(Guid id , string firstname , string lastname , string email , string phone)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Phone = phone;


        }
        public Guid Id { get; set; }

        public string FirstName {  get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Phone {  get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public static (Student Student , string Error) Create(Guid id, string firstname, string lastname, string email, string phone)
        {
            var error = string.Empty;
            if (string.IsNullOrEmpty(firstname) || firstname.Length>MAX_STUDENTNAME_LENGHT)
            {
                error = "Student's Name  can't be empty or longer than 100 symbols"; 
            }
            if (string.IsNullOrEmpty(lastname) || lastname.Length > MAX_STUDENTNAME_LENGHT)
            {
                error = "Student's Lastname  can't be empty or longer than 100 symbols";
            }
            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            {
                error = "Invalid email format";
            }
            if (string.IsNullOrEmpty(phone) || phone.Length > MAX_PHONE_LENGHT)
            {
                error =  "Phone can't be empty or longer than 15 characters.";
            }



            var student = new Student(id , firstname , lastname , email , phone);

            return (student, error);
        }
        private static bool IsValidEmail(string email)
        {
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(email);
        }
    }
}
