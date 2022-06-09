using System;
using System.IO;
using System.Xml.Serialization;

namespace Exam
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Enter the num of cars u'll add");
            int num = int.Parse(Console.ReadLine());
            Auto.Autos[] info = new Auto.Autos[num];
            for (int i = 0; i < info.Length; i++)
            {
                info[i] = GetFromKeyboard();
            }
            int ch;
            do
            {
                Console.Clear();
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("Enter 1 to add ur cars to file for save.");
                Console.WriteLine("Enter 2 to find the car number by weight.");
                Console.WriteLine("Enter 3 to  check the cars by brand or color.");
                Console.WriteLine("Enter 4 to delete the old cars.");
                Console.WriteLine("Enter 0 to finish the program.");
                Console.WriteLine("------------------------------------------------");
                ch = int.Parse(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        AddToXml(info);
                        break;
                    case 2:
                        FindByWeigth();
                        break;
                    case 3:
                        FindByColorAndBrand();
                        break;
                    case 4:
                        info = DeleteOldModels();
                        Console.WriteLine("Here is ur new file");
                        foreach (Auto.Autos obj in info)
                        {
                            Console.WriteLine(obj.ToString());
                        }
                        AddToXml(info);
                        Console.WriteLine("Also u can check ur file");
                        break;
                    case 0:
                        Console.WriteLine("Ok, got it!");
                        break;
                    default:
                        Console.WriteLine("An incorrect choice try again pls!");
                        break;

                }

            } while (ch != 0);
            
            AddToXml(info);
        }

        public static Auto.Autos[] DeleteOldModels()
        {
            Auto.Autos[] info;
            info = ReadData();
            int count = 0;
            int index = 0;
            for (var i = 0; i < info.Length; i++)
            {
                if (info[i].operationTime >= 5)
                {
                    index = i;
                    for (int j = index + 1; i < info.Length; i++)
                    {
                        info[i - 1] = info[i];
                    }
                    Array.Resize(ref info, info.Length - 1);
                }
            }

            return info;
        }

        public static void FindByColorAndBrand()
        {
            Console.Clear();
            Auto.Autos[] infomation;
            infomation = ReadData();
            Console.WriteLine("Enter the car color");
            string color = Console.ReadLine();
            Console.WriteLine("Enter the car brand");
            string brand = Console.ReadLine();
            bool exist = false;
            foreach (Auto.Autos obj in infomation)
            {
                if (obj.color == color && obj.model == color)
                {
                    exist = true;
                    Console.WriteLine(obj.ToString());
                }
            }
            if (exist == false)
            {
                Console.WriteLine("There is no car with such weight");
            }
            Console.WriteLine("Press Enter to go to the main Menu");
            Console.ReadKey();
        }

        public static void FindByWeigth()
        {
           Console.Clear();
           Auto.Autos[] infomation;
           infomation = ReadData();
           Console.WriteLine("Enter the car weigth");
           int weigth = int.Parse(Console.ReadLine());
           bool exist = false;
           foreach (Auto.Autos obj in infomation)
           {
               if (obj.vantag == weigth)
               {
                   exist = true;
                    Console.WriteLine(obj.ToString());
               }
           }
           if (exist == false)
           {
               Console.WriteLine("There is no car with such weight");
           }
           Console.WriteLine("Press Enter to go to the main Menu");
           Console.ReadKey();
        }

         static Auto.Autos[] ReadData()
        {
            XmlSerializer xmls = new XmlSerializer(typeof(Auto.Autos[]));
            using (StreamReader stream = new StreamReader("info.xml"))
            {
                return (Auto.Autos[]) xmls.Deserialize(stream);
            }
        }


        public static void AddToXml(Auto.Autos[] info)
        {
            XmlSerializer xmls = new XmlSerializer(typeof(Auto.Autos[]));
            using (FileStream stream = new FileStream("info.xml", FileMode.Create))
            {
                xmls.Serialize(stream, info);
            }
        }

        public static Auto.Autos GetFromKeyboard()
        {
            Console.Clear();
            string firstType = "вант";
            string secondType = "легковик";
            int kgOfCar = 0;
            int TimeOfOper = 0;
            string numOfCar = " ";
            string color = "none";
            Console.WriteLine("Enter the car brand");
            string modelOfCar = Console.ReadLine();
            Console.WriteLine("Enter the type of car like this: вант/легковик");
            string typeOfCar = Console.ReadLine();
            if (typeOfCar == firstType)
            {
                Console.WriteLine("Enter the weight of the car in kilograms");
                kgOfCar = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the car number like this: CA1234CA, dont use spaces");
                numOfCar = Console.ReadLine();
                Console.WriteLine("Enter the operation time of the car only by number, like this: 2");
                TimeOfOper = int.Parse(Console.ReadLine());
            }
            else if(typeOfCar == secondType)
            {
                Console.WriteLine("Enter the color of the car");
                color = Console.ReadLine();
                Console.WriteLine("Enter the car number like this: CA1234CA, dont use spaces");
                numOfCar = Console.ReadLine();
                Console.WriteLine("Enter the operation time of the car only by number, like this: 2");
                TimeOfOper = int.Parse(Console.ReadLine());
            }
            return new Auto.Autos(modelOfCar, typeOfCar, numOfCar, TimeOfOper, color, kgOfCar);
        }
    }
}
