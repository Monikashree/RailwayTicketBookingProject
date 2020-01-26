using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace Project
{
    public class UserManager
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string DOB { get; set; }
        public string sex { get; set; }
        public string email { get; set; }
        public string mobileNum { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
        public string role;
        bool result;
        User user;
        UserRepository userRepository = new UserRepository();
        public void RegisterDetail(SqlConnection sqlConnection)            //Method to make user to register with the account
        {
            Console.WriteLine(Writer.name);
            firstName = ValidateName();
            Console.WriteLine(Writer.lastName);
            lastName = ValidateName();

            DOB = ValidateDOB();
            role = "User";
            do
            {
                Console.WriteLine(Writer.sex);
                sex = Console.ReadLine();
                if (sex != "Male" && sex != "Female")       //Validation part to check whether the given input is crct or not
                {
                    Console.WriteLine(Writer.sexInvalid);
                }
            } while (sex != "Male" && sex != "Female");

            do
            {
                Console.WriteLine(Writer.email);            //Validation part for email
                email = Console.ReadLine();
                string strRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

                Regex re = new Regex(strRegex, RegexOptions.IgnoreCase);
                if (!re.IsMatch(email))
                {
                    Console.WriteLine(Writer.invalidId);
                    result = true;
                }
                else
                    result = false;
            } while (result);           //A do while to process continuosly until the crct the data is crct

            do
            {
                Console.WriteLine(Writer.mobile);
                mobileNum = (Console.ReadLine());
                string strRegex = @"(0/91)?[6-9][0-9]{9}";  //Validation part using regex for phone num starting from 6-9
                Regex re = new Regex(strRegex);
                if (!re.IsMatch(mobileNum))
                {
                    Console.WriteLine(Writer.invalidNum);
                    result = true;
                }
                else
                    result = false;
            } while (result);

            Console.WriteLine(Writer.password);
            password = Console.ReadLine();

            do
            {
                Console.WriteLine(Writer.newPassWord);
                confirmPassword = Console.ReadLine();
                if (confirmPassword != password)
                {
                    Console.WriteLine(Writer.invalidPin);
                    result = true;
                }
                else
                    result = false;
            } while (result);

            User user = new User(firstName, lastName, DOB, sex, email, mobileNum, password, role);           
            userRepository.RegisterDetail(user, sqlConnection);
            //Login();
        }
        
        public string ValidateName()
        {
            string name = Console.ReadLine();
            if (!Regex.Match(name, "^[A-Z][a-zA-Z]*$").Success)     // Validating the name
            {
                Console.WriteLine(Writer.nameInvalid);
                ValidateName();
            }
            return name;
        }
        public string ValidateDOB()
        {
            //try
            //{
            Console.WriteLine(Writer.DOBFormat);
            DOB = (Console.ReadLine());
            //}
            //catch (Exception e)
            //{
            //    ValidateDOB();
            //}
            return DOB;
        }
        //    static UserRepository()         //Binding admin details for console level application  
        //    {
        //        BindAdminCredentials();
        //    }
        //    public static void BindAdminCredentials()
        //    {
        //        User user = new User("Moni", "Kamaraj", "1998-11-12", "Female", "monikashreek@gmail.com", "8807697440", "moni", "Admin");
        //        userList.Add(user);
        //        userList.Add(new User("Banu", "Durai", "1999-07-17", "Female", "banu@gmail.com", "8807697441", "banu", "Admin"));
        //        userList.Add(new User("Diya", "Ram", "1998-10-12", "Female", "diya@gmail.com", "7890654321", "diya", "User"));
        //        userList.Add(new User("Kamaraj", "Krish", "1965-10-12", "Male", "krish@gmail.com", "8148443426", "kamaraj", "User"));
        //    }
        //    public Boolean AddData(User user)
        //    {
        //        userList.Add(user);
        //        return true;
        //    }
        //    public User MatchDetail(string value, string code)
        //    {
        //        foreach (User user in userList)
        //        {
        //            if (user.firstName == value && user.password == code && user.firstName != "XXXX")
        //            {
        //                Console.WriteLine(Writer.login);
        //                return user;
        //            }
        //            if (user.firstName == "XXXX")
        //                Console.WriteLine(Writer.b_Msg);
        //        }
        //        return null;
        //    }
        //    public void Display()
        //    {
        //        foreach (User user in userList)
        //            Console.WriteLine(user.ToString());
        //    }
        //}
        public int Login()
        {
            Console.WriteLine(Writer.name);     //Login to make the user get contact with the application
            string name = Console.ReadLine();
            Console.WriteLine(Writer.password);
            string pin = Console.ReadLine();
            int id = userRepository.VerifyWithDB(name, pin);
            if (id == 1)
            {
                Console.WriteLine(Writer.log);
                Login();                
            }
            return id;
        }
        public string GetRole(int id)
        {
            string status = userRepository.FetchRole(id);            
            return status;
        }
    }
}
