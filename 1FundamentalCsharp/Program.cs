using System;
using System.Collections.Generic;

namespace _1FundamentalCsharp
{
    class Program
    {
        /*static string[] listRoom = new string[100];*/
        static List<string> listRoom = new List<string>();
        static void Main(string[] args)
        {
            string passwordLogin;
            
            Console.WriteLine("Welcome to Admin Page");
            do
            {
                Console.Write("Masukkan password : ");
                passwordLogin = Console.ReadLine();
                if (passwordLogin != "admin")
                {
                    Console.WriteLine("Wrong password");
                }
            } while (passwordLogin != "admin");
            int userChoice = 0;
            do
            {
                PrintMenu();
                try
                {
                    userChoice = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Masukkan angka saja! [Press Enter to continue]");
                    char ch = Console.ReadKey(true).KeyChar;
                }
                switch (userChoice)
                {
                    case 1:
                        ViewRoom();
                        break;
                    case 2:
                        AddRoom();
                        break;
                    case 3:
                        DeleteRoom();
                        break;
                    default:
                        if(userChoice != 4)
                        {
                            Console.WriteLine("Please choose 1 - 4 only! [Press Enter to continue]");
                            char ch = Console.ReadKey(true).KeyChar;
                        }
                        break;
                }

            } while (userChoice != 4);
            Console.WriteLine("Thank you");
    
        }

        static void PrintMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Penginapan ABC");
            Console.WriteLine("1. view room");
            Console.WriteLine("2. add room");
            Console.WriteLine("3. delete room");
            Console.WriteLine("4. exit");
            Console.Write("Your choice : ");
        }

        static void AddRoom()
        {
            
            string newRoom="";
            Console.Clear();
            do
            {
                Console.Write("Masukkan nama room :");
                newRoom = Console.ReadLine();
                if (IsDuplicate(newRoom))
                {
                    Console.WriteLine("Duplicate data ! please try again");
                    char ch = Console.ReadKey(true).KeyChar;
                }
            } while (IsDuplicate(newRoom));
            if (!IsDuplicate(newRoom))
            {
                listRoom.Add(newRoom);
            }
        }

        static void ViewRoom()
        {
            if(listRoom.Count == 0)
            {
                Console.WriteLine("There is no data! [Press Enter to continue]");
                char ch = Console.ReadKey(true).KeyChar;
            }
            else
            {
                for (int i = 0; i < listRoom.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {listRoom[i]}");
                }
                Console.WriteLine("[Press Enter to continue]");
                char ch = Console.ReadKey(true).KeyChar;
            }
        }

        static void DeleteRoom()
        {
            int deleteChoice;
            if (listRoom.Count == 0)
            {
                Console.WriteLine("There is no data! [Press Enter to continue]");
                char ch = Console.ReadKey(true).KeyChar;
            }
            else
            {
                ViewRoom();
                do
                {
                    Console.Write("Which room do you want to delete ? [Index] : ");
                    deleteChoice = Convert.ToInt32(Console.ReadLine());
                } while (deleteChoice < 1 || deleteChoice > listRoom.Count);
                listRoom.RemoveAt(deleteChoice - 1);
            }
        }

        static bool IsDuplicate(string keyRoom)
        {
            foreach(string room in listRoom)
            {
                if (keyRoom == room) return true;
            }
            return false;
        }

        
    }
}
