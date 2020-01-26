using System;
using System.Collections.Generic;


namespace Project
{
    public interface ITrainInterface            //Interface to implement operating processes for Admin & User
    {
        Boolean AddTrainDetails();
        Boolean BlockUser();
        Boolean AddMeals();
        void SearchTrain();
        int BookTicket();
        void CancelTicket();        
    }
    class TrainManager : UserManager, ITrainInterface     // A multiple inheritance to make use of userList in userRepositoy & Interface
    {
        public int trainNo { get; set; }
        public string trainName { get; set; }
        public string[] station = new string[3];
        public string arrivalTime { get; set; }
        public string departTime { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public int fare;
        short adminOption;
        short userOption;
        bool status;
        int cost;
        int number;
        int seat;
        public static List<Train> trainList = new List<Train>();        //A List to store the details related to train
        
        internal void BindUserOption()
        {
            try
            {
                Console.WriteLine(Writer.userOption);
                userOption = Convert.ToInt16(Console.ReadLine());
                do
                {
                    switch (userOption)             //Switch case for user
                    {
                        case 1:
                            SearchTrain();
                            break;
                        case 2:
                            cost = BookTicket();
                            break;
                        case 3:
                            CancelTicket();
                            break;
                        case 4:
                            ReceiveBill(number, cost);
                            break;
                        case 5:
                            System.Environment.Exit(0);
                            break;
                        default:                            
                            break;
                    }
                    Console.WriteLine(Writer.userOption);
                    userOption = Convert.ToInt16(Console.ReadLine());
                } while (true);

            }
            catch (FormatException msg)
            {
                Console.WriteLine(msg.Message);
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }
        }
        public Boolean AddTrainDetails()
        {
            try
            {
                Console.WriteLine(Writer.t_No);                // Reading train details from admin part & toring it in list
                trainNo = int.Parse(Console.ReadLine());
                Console.WriteLine(Writer.t_Name);
                trainName = Console.ReadLine();                
                Console.WriteLine(Writer.t_Arrive);
                arrivalTime = Console.ReadLine();
                Console.WriteLine(Writer.t_Depart);
                departTime = Console.ReadLine();
                Console.WriteLine(Writer.t_Fare);
                fare = int.Parse(Console.ReadLine());
                Console.WriteLine(Writer.destination);
                from = Console.ReadLine();
                Console.WriteLine(Writer.destination);
                to = Console.ReadLine();
                Train train = new Train(trainNo, trainName, station, arrivalTime, departTime, fare, from, to);      //Invoking the constructor 
                trainList.Add(train);           //Addition of object to the list
                Console.WriteLine(trainList.Count);
                //SearchTrain();
            }
            catch (FormatException msg)
            {
                Console.WriteLine(msg.Message);
            }
            catch (Exception msg)
            {
                Console.WriteLine(msg.Message);
            }
            return true;
        } 
        public Boolean BlockUser()
        {
            Console.WriteLine(Writer.b_Name);
            string name = Console.ReadLine();
            //foreach (User user in UserRepository.userList)
            //{
            //    if (user.firstName == name)
            //    {
            //        user.firstName = "XXXX";            //assiging the user's first name as XXXX to indicate that has blocked
            //        Console.WriteLine(Writer.b_Msg);                    
            //    }
            //}
            return true;
        }
        public Boolean AddMeals()
        {
            short idly = 10;
            short poori = 25;
            short dhosa = 15;
            short rice = 45;
            short water = 20;
            return true;
        }
        public void SearchTrain()
        {
            Console.WriteLine(Writer.destination);
            string area = Console.ReadLine();
            foreach(Train train in trainList)
            {
                Console.WriteLine(Writer.detail);
                if (train.from == area || train.to == area)         //searching of train according to the details from the user
                {
                    train.DisplayTrainDetails();
                    number = train.trainNo;
                }
                else
                    Console.WriteLine(Writer.notFound);                    
            }
           // return 1;
        }
        public int BookTicket()
        {
            int amount = 1;
            SearchTrain();
            int num = number;            
            Console.WriteLine(Writer.ticket);
            seat = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Writer.option);
            short wish = Convert.ToInt16(Console.ReadLine());       //Booking ticket along with Meals & seat availability to calculate the total fare
            if (wish == 1)
            {
                amount = (amount * seat) +(seat* 70);
            }
            else
                amount *= seat;
            foreach(Train train in trainList)
            {
                if(train.trainNo == num)
                {                    
                    amount += train.fare;
                }
            }
            Console.WriteLine(Writer.book);
            Console.WriteLine(Writer.thank);
            return  amount ;         
        }
        public void ReceiveBill(int num, int price)
        {
            Console.WriteLine(Writer.bill);         //Bill format for customer use
            Console.WriteLine(Writer.name);         //A static method from static class instead of hard coding
            string name = Console.ReadLine();
            //foreach(User user in userList)
            //{
            //    if(user.firstName == name)
            //    {
                    
            //        Console.WriteLine($"Name: {user.firstName}\n MobileNo: {user.mobileNum}");
            //    }
            //}
            foreach (Train train in trainList)
            {
                if (train.trainNo == num)
                {
                    Console.WriteLine($"Train number: {train.trainNo}\n Train Name: {train.trainName}\n Place: {train.from}<------------->{train.to}\n seat: {seat}\n Money: {cost}");
                }
            }
            Console.WriteLine(Writer.thank);
        }
        public void CancelTicket()
        {
            Console.WriteLine(Writer.name);
            string name = Console.ReadLine();
            //foreach (User user in userList)
            //{
            //    if (user.firstName == name )
            //    {                    
            //        Console.WriteLine($"Dear {user.firstName} your ticket under this {user.mobileNum} number is Cancelled");
            //    }
            //}
            Console.WriteLine(Writer.thank);
        }
    }
}
