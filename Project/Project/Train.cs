using System;


namespace Project
{
    class Train
    {
        public int trainNo { get; set; }        //Properties of Train
        public string trainName { get; set; }
        public string[] station = new string[3];
        public string arrivalTime { get; set; }
        public string departTime { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public int fare;  
        public Train(int trainNo, string trainName, string[] station, string arrivalTime, string departTime, int fare, string from, string to)
        {
            this.trainNo = trainNo;                     //Using parameterized constructor to bind data in objects
            this.trainName = trainName;
            for (int index = 0; index < 3; index++)
            {
                this.station[index] = station[index];
            }
            this.arrivalTime = arrivalTime;
            this.departTime = departTime;
            this.fare = fare;
            this.from = from;
            this.to = to;
        } 
        public void DisplayTrainDetails()           //A method to display train details
        {
            Console.WriteLine($"TrainNo: {trainNo}\n Train Name: {trainName}\n ");
            for (int index = 0; index < 3; index++)
            {
                Console.WriteLine($"station{index + 1}");
                Console.WriteLine(station[index]);
            }
            Console.WriteLine($"ArrivalTime: {arrivalTime}\n Departure Time: {departTime}\n Fare: {fare}\n Place: {from}<------------->{to}");
        }  
    }
}
