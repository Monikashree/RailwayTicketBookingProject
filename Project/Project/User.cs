using System;

namespace Project
{
    class User
    {
        public string firstName { get; set; }       //Properties of user
        public string lastName { get; set; }
        public string DOB { get; set; }
        public string sex { get; set; }
        public string email { get; set; }
        public string mobileNum { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string role { get; set; }
        
        public User(string firstName, string lastName, string DOB, string sex, string email, string mobileNum, string password, string role)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.DOB = DOB;
            this.sex = sex;
            this.email = email;
            this.mobileNum = mobileNum;
            this.password = password;
            this.confirmPassword = confirmPassword;
            this.role = role;
            
        }
        public override string ToString()       //Overriding to string method for reusability
        {
            return firstName + " " + lastName + " " + DOB + " " + sex + " " + email + " " + mobileNum + " " + password + " " + role;
        }
    }
}
