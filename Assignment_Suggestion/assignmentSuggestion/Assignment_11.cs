using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignmentSuggestion
{
    class Assignment_11
    {
        static List<string> listloca = new List<string>();
        static List<double> listPrice = new List<double>();
        static List<int> listNumberRoom = new List<int>();
        double price;
        int NumberRoom;
        public void AddPrice()
        {
            try
            {
                Console.WriteLine("Enter the price:");
                price = double.Parse(Console.ReadLine());
                if (price < 0)
                {
                    throw new MessagePrice();
                }
                else listPrice.Add(price);
            }
            catch (MessagePrice e)
            {
                Console.WriteLine("Error" + e);
            }
        }
        public void AddRoom()
        {
            try
            {
                Console.WriteLine("Enter the Room:");
                NumberRoom = int.Parse(Console.ReadLine());
                if (NumberRoom < 0)
                {
                    throw new VacanciesLeft();
                }
                else
                {
                    listNumberRoom.Add(NumberRoom);
                    NumberRoom++;
                }
            }
            catch (MessagePrice e)
            {
                Console.WriteLine("Error" + e);
            }
        }
        public void AddLocation()
        {
            //khoi tao doi tuong lop LocationIndexxer
            LocationIndexer loca = new LocationIndexer();
            loca[0] = "SaiGon";
            loca[1] = "Hanoi";
            loca[2] = "Danang";
            loca[3] = "Hue";
            loca[4] = "Phanthiet";
            loca[5] = "Nhatrang";
            loca[6] = "Muine";
            loca[7] = "Dalat";
            loca[8] = "Vungtau";
            loca[9] = "Samson";
            loca[10] = "Doson";
            loca[11] = "Phuquoc";
            loca[12] = "Condao";
            loca[13] = "Halong";
            loca[14] = "Phongnha";
            loca[15] = "Sapa";
            //Khai bao cac bien de nhap dia danh
            Console.WriteLine("Input the location");
            string st = Console.ReadLine();
            int i;
            try
            {
                for (i = 0; i < 16; i++)
                {
                    if (st.Equals(loca[i]))
                    {
                        Console.WriteLine("That is ok");
                        listloca.Add(loca[i]);
                        break;
                    }
                }
                if (i == 16)
                {
                    throw new Venues();
                }
            }
            catch (Venues e)
            {
                Console.WriteLine("Error" + e);
            }
        }
        static void Main(string[] args)
        {
            Assignment_11 proobj = new Assignment_11();
            byte choice = 0;
            string cont = "y";
            bool find = false;
            string places = "";
            int room_No = 0;

            while (choice != 3)
            {
                Console.WriteLine("**********************************");
                Console.WriteLine("1.Input information to required");
                Console.WriteLine("2.Display Information");
                Console.WriteLine("3.Jordan Hotel Service");
                Console.WriteLine("4.Exit");
                Console.WriteLine("**********************************");
                Console.WriteLine("Input choice");
                choice = byte.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        while (cont.Equals("y") || cont.Equals("Y"))
                        {
                            try
                            {
                                proobj.AddLocation();
                                proobj.AddPrice();
                                proobj.AddRoom();
                                Console.WriteLine("Do you want to required ");
                                cont = Console.ReadLine();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error" + e);
                            }
                        }
                        break;
                    case 2:
                        for (int i = 0, j = 0, k = 0; i < listloca.Count && j < listPrice.Count && k < listNumberRoom.Count; i++, j++, k++)
                        {
                            Console.WriteLine("Location\t{0}", listloca[i]);
                            Console.WriteLine("price\t{0}", listPrice[j]);
                            Console.WriteLine("NumberRoom\t{0}", listNumberRoom[k]);
                        }
                        break;
                    case 3:
                        Console.WriteLine("\tWhere are you going to go your vacanies?");
                        for (int i = 0; i < listloca.Count; i++)
                        {
                            Console.WriteLine("{0}", listloca[i]);
                        }
                        try
                        {
                            Console.Write("Enter Location : ");
                            string Des_Place = Console.ReadLine().Trim();
                            for (int i = 0; i < listloca.Count; i++)
                            {
                                if (Des_Place.Equals(listloca[i]))
                                {
                                    places = Des_Place;
                                    room_No = listNumberRoom[i];
                                    find = true;
                                }
                            }
                            if (find == false)
                                Console.WriteLine("Service is not provided in this location.");
                            else
                            {
                                Console.Write("How many rooms do you want to book ? ");
                                int Des_Room = Int32.Parse(Console.ReadLine());
                                if (Des_Room <= 0)
                                    Console.WriteLine("Enter a positive number.");
                                else if (Des_Room != room_No)
                                    Console.WriteLine("Invalid rooms.\t{0}", Des_Room);
                                else
                                    Console.WriteLine("You were books successfull. Thank you!");
                            }
                        }
                        catch (VacanciesLeft e)
                        {
                            Console.WriteLine("Error : {0}", e.Message);

                        }
                        catch (Venues e)
                        {
                            Console.WriteLine("Error : {0}", e.Message);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error : {0}", e.Message);
                        }

                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
    class Venues : Exception
    {
        public Venues()
        {
            Console.WriteLine("Service is not Provided in this location");
        }
    }
    class MessagePrice : Exception
    {
        public MessagePrice()
        {
            Console.WriteLine("Input is not in the correct format");
        }
    }
    class VacanciesLeft : Exception
    {
        public VacanciesLeft()
        {
            Console.WriteLine("No more rooms available");
        }
    }
    class LocationIndexer
    {
        private string[] location = new string[16];
        public string this[int index]
        {
            get
            {
                if (index < 0 || index > 15) return "";
                else return location[index];
            }
            set
            {
                if (!(index <= 0 || index > 15))
                {
                    location[index] = value;
                }
            }
        }
    }
}
