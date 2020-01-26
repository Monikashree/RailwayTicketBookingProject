using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
   static class Writer                  //A static class for all the writeline to ensure code optimization and reuse
    {
        public static string welcome = "----------------Welcome to Online e-Railway Ticket Booking---------------";
        public static string choice = "For New Registration click 1 & for Login click 2 & click 3 to Exit";
        public static string choiceMsg = "Please enter a valid choice";
        public static string name = "Enter your First name";
        public static string lastName = "Enter your Last name";
        public static string nameInvalid = "Invalid name";
        public static string DOBFormat = "Enter your DOB in dd/mm/yyyy format";
        public static string sex = "Enter your gender";
        public static string sexInvalid = "Invalid gender";
        public static string email = "Enter your email ID";
        public static string invalidId = "Invalid email ID";
        public static string mobile = "Enter your Phone number";
        public static string invalidNum = "Invalid Phone Number";
        public static string password = "Enter your Password";
        public static string newPassWord = "Re-enter Password";
        public static string invalidPin = "set proper Password";
        public static string data = "-------------------Data added Successfully------------------------";
        public static string updateData = "-------------------Data Updated Successfully------------------------";
        public static string meal = "-------------------Data on meals added Successfully------------------------";
        public static string noData = "-------------------Data not added Successfully------------------------";
        public static string login = "-------------------Sign in Successfull------------------------";
        public static string log = "-------------------Incorrect User name or Password------------------------";
        public static string adminOption = "Select choice 1. Adding Train Details 2. Block User 3.AddMeals details 4.Exit";
        public static string block = "-------------------ID Blocked Successfully------------------------";
        public static string t_No = "Enter the train number";
        public static string t_Name = "Enter the train name";
        public static string t_Station = "Enter the train stations";
        public static string t_Fare = "Enter the train fare";
        public static string t_Arrive = "Enter the train Arrival Time";
        public static string t_Depart = "Enter the train Departure Time";
        public static string b_Name = "Enter the name to block user";
        public static string b_Msg = "------------ID Blocked------------";
        public static string userOption = "Select choice 1. Search Train Details 2. Book Train Ticket 3.Cancel ticket 4. Receive bill 5.Exit";
        public static string destination = "Enter your journey destination";
        public static string notFound = "-------No data found--------";
        public static string detail = "------------------Details------------------";
        public static string ticket = "Enter no of tickets needed";
        public static string option = "For ordering meals click 1 ";
        public static string bill = "Ticket for the jouney";
        public static string thank = "-----------Thanx for Using our Service----------------";
        public static string end = "----------------Happy Journey--------------";
        public static string book = "-------------Ticket  reserved Successfully-----------------";
        public static string connection = "----------------Connection Established---------------";
        public static string authentication = "-------------------Authenticated Successfully------------------------";
    }
}
