using System;
using System.Data.SqlClient;

namespace Project
{
    static class Portal
    {
        
        public enum UserOption      //Enum to get automatic value to the options
        {
            Registration = 1,
            Login,
            Exit
        };
        internal static void SelectOption()
        {
            try
            {
                SqlConnection sqlConnection = DBUtils.GetDBConnection();
                sqlConnection.Open();
                Console.WriteLine(Writer.connection);
                int ID;          
                Console.WriteLine(Writer.welcome);
                Console.WriteLine(Writer.choice);
                string choose = Console.ReadLine();
                do
                {
                    UserManager userManager = new UserManager();
                    UserOption userOption = (UserOption)Enum.Parse(typeof(UserOption), choose);     //usage enum values 
                    switch (userOption)
                    {
                        case UserOption.Registration:       //A case to work in options
                            userManager.RegisterDetail(sqlConnection);
                            break;
                        case UserOption.Login:
                            ID = userManager.Login();
                            Console.WriteLine(ID);
                            string role = userManager.GetRole(ID);
                            Console.WriteLine(role);
                            if (role == "Admin")
                                BindAdminOption();
                            else
                                BindUserOption();
                            break;
                        case UserOption.Exit:
                            System.Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                   
                    Console.WriteLine(Writer.choice);
                    choose = Console.ReadLine();
                } while (true);                

            }
            catch (FormatException msg)           //A common catch block for exception
            {
                Console.WriteLine(msg.Message);
            }
            catch (Exception msg)           //A common catch block for exception
            {
                Console.WriteLine(msg.Message);
            }
        }

        static void BindAdminOption()
        {
            try
            {
                TrainManager trainManager = new TrainManager();
                Console.WriteLine(Writer.adminOption);
                short adminOption = Convert.ToInt16(Console.ReadLine());
                Boolean status;
                do
                {
                    switch (adminOption)                        //usage of switch case to go with Admin operations
                    {
                        case 1:
                            status = trainManager.AddTrainDetails();         //Getting confirmation to check whether the detail is added or not
                            if (status)
                                Console.WriteLine(Writer.data);
                            break;
                        //case 2:
                        //    status = trainManager.UpdateTrainDetails();         //Getting confirmation to check whether the detail is added or not
                        //    if (status)
                        //        Console.WriteLine(Writer.updateData);
                        //    break;
                        case 3:
                            status = trainManager.BlockUser();
                            if (status)
                                Console.WriteLine(Writer.block);
                            break;
                        case 4:
                            status = trainManager.AddMeals();
                            if (status)
                                Console.WriteLine(Writer.meal);
                            break;
                        //case 5:
                        //    status = trainManager.ProvideAuthentication();
                        //    if (status)
                        //        Console.WriteLine(Writer.authentication);
                        //case 6:
                        //    status = trainManager.AddMembershipDetails();
                        //    if (status)
                        //        Console.WriteLine(Writer.data);
                        //    break;
                        case 7:
                            System.Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                    Console.WriteLine(Writer.adminOption);
                    adminOption = Convert.ToInt16(Console.ReadLine());
                } while (true);                             //Making a do while to continue working until the user need
            }
            catch (FormatException msg)                                 //Catching exception to show the invalid operation
            {
                Console.WriteLine(msg.Message);
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }
        }
        static void BindUserOption()
        {

        }

    }
}
