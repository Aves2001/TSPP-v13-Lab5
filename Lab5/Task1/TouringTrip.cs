using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab5.Task1
{
    public class TouringTrip : MusicBand
    {
        private string city, year, numberOfConcerts;
        public TouringTrip() : base()
        {
            City = "null";
            Year = "null";
            NumberOfConcerts = "null";
        }

        public TouringTrip(string id, string title, string lastNameOfTheHead, string city, string year, string numberOfConcerts) : base(id, title, lastNameOfTheHead)
        {
            City = city;
            Year = year;
            NumberOfConcerts = numberOfConcerts;
        }
        public string City
        {
            get => city;
            set
            {
                if (TestLengthIsNull(value, cL))
                {
                    city = "null";
                    return;
                }
                city = value;
            }
        }
        public string Year
        {
            get => year;
            set
            {
                if (TestLengthIsNull(value, yL))
                {
                    year = "null";
                    return;
                }
                else if (!TestIsNumber(value))
                {
                    throw new Exception("Рік має бути вказаний числом");
                }
                // перевіряє чи вказаний рік поступання не більший за теперішній і чи не менший за 1000
                if (int.Parse(value) > DateTime.Today.Year)
                {
                    throw new Exception("Рік не може бути більший за теперішній");
                }
                else if (int.Parse(value) < 1000)
                {
                    throw new Exception("Рік не може бути менший за 1000");
                }
                year = value;
            }
        }
        public string NumberOfConcerts
        {
            get => numberOfConcerts;
            set
            {
                if (TestLengthIsNull(value, yL))
                {
                    numberOfConcerts = "null";
                    return;
                }
                else if (!TestIsNumber(value))
                {
                    throw new Exception("\nКількість концертів має бути вказана числом");
                }
                if (int.Parse(value) < 0)
                {
                    throw new Exception("Вказана кількість концертів не може бути меншою нулю");
                }
                numberOfConcerts = value;
            }
        }

        public override string ToString()
        {
            string x = "\n|";
            for (int i = 0; i < tableSize; i++)
            {
                x += "=";
            }
            x += "|";
            return string.Format($"| {Id,iL} | {Title,tL} | {LastNameOfTheHead,lL} | {City,cL} | {Year,yL} | {NumberOfConcerts,nL} |" + x);
        }

        public override string LastLetter(List<TouringTrip> list = null, string str = null)
        {
            if (list == null)
            {
                list = Input();
            }
            int index;
            bool not_found = true;
            do
            {
                if (string.IsNullOrWhiteSpace(str))
                {
                Console.Clear();
                ViewTable(list);
                System.Console.WriteLine("Введіть id запису в якому потрібно вивести останню літеру в прізвищі керівника, або [Enter] для виходу");
                System.Console.Write(">");
                    str = System.Console.ReadLine();
                }
                if (str == null || str.Equals("") || str.Equals("null"))
                {
                    System.Console.Clear();
                    return null;
                }
                index = list.FindIndex(s => s.Id.Equals(str));
                not_found = index == -1;
                if (not_found)
                {
                    System.Console.WriteLine("Таке id не знайдено");
                    return null;
                }
                if (list[index].LastNameOfTheHead.Equals("null"))
                {
                    Console.WriteLine("\nІнформація не вказана!");
                    return null;
                }
            } while (not_found);
            char last = list[index].LastNameOfTheHead.Last();
            Console.WriteLine("Остання літера в прізвищі керівника: " + last);
            return last.ToString();
        }
    }
}
