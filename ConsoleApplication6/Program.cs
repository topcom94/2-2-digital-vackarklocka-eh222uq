using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            ViewTestHeader("test 1 \ntest av standardkonstruktorn.");
            AlarmClock T1 = new AlarmClock(); //den här skapar en ny instans utav alarm.
            Console.WriteLine(T1.ToString()); //den använder sig av tostring metoden för att kunna få ut metoden

            // nu är det test 2


            ViewTestHeader("test 2 \ntest av konstruktor med två paramentrar, (9,42).");
            AlarmClock T2 = new AlarmClock(9, 42);
            Console.WriteLine(T2.ToString());

            // test 3


            ViewTestHeader("test 3 \ntest av konstruktor med två paramentrar, (13, 24, 7, 35).");
            AlarmClock T3 = new AlarmClock(13, 24, 7, 35);
            Console.WriteLine(T3.ToString());

            // test 4

            ViewTestHeader("test 4 \nställer befintligt AlarmClock-objekt till 23:58 och låter den gå 13 minuter.");
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔══════════════════════════════════════╗ ");
            Console.WriteLine(" ║ Väckarklokan URLED <TM>              ║ ");
            Console.WriteLine(" ╚══════════════════════════════════════╝ ");
            Console.ResetColor();

            AlarmClock T4 = new AlarmClock(23, 58);
            Run(T4, 13); // anropar metoden Run .......

            // test 5

            ViewTestHeader("test 5 \nställer befentligt AlrmClock-objekt till tiden 6:12 och alarmtiden 6.15 den gå 6 minuter.");

            AlarmClock T5 = new AlarmClock(6, 12, 6, 15);
            Run(T5, 6);

            // test 6

            ViewTestHeader(" test 6\ntest av egenskaperna så att undantag kastas då tid och larmtid tilldelas värden.");
            AlarmClock T6 = new AlarmClock();

            try //
            {
                T6.Hour = 86;
            }
            catch (ArgumentException error)
            {
                ViewErrorMessage(error.Message);
            }

            try
            {
                T6.Minute = 79;
            }
            catch (ArgumentException error)
            {
                ViewErrorMessage(error.Message);
            }
            try
            {
                T6.AlarmHour = 32;
            }
            catch (ArgumentException error)
            {
                ViewErrorMessage(error.Message);
            }
            try
            {
                T6.AlarmMinute = 96;
            }
            catch (ArgumentException error)
            {
                ViewErrorMessage(error.Message);
            }
            finally
            {
                Console.WriteLine();
            }


            // test 7


            ViewTestHeader("test 7 \ntest av konstruktorer så att undantag då tid och larmtid tilldelas felaktiga värden.");


            try
            {
                AlarmClock T7 = new AlarmClock(0, 96);
            }
            catch (ArgumentException error)
            {
                ViewErrorMessage(error.Message);
            }

            try
            {
                AlarmClock T7 = new AlarmClock(0, 0, 156, 0);
            }
            catch (ArgumentException error)
            {
                ViewErrorMessage(error.Message);
            }
        }




        private static void Run(AlarmClock ac, int minutes) // skapar metoden run som används för att skriva ut metod.
        {
            for (int i = 0; i < minutes; i++) //lägger till en minut.
            {
                if (ac.TicTock())
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(ac.ToString() + "♫♫♫♫♫♫♫♫♫♫♫♫♫");
                }
                else
                {
                    Console.ResetColor();
                    Console.WriteLine(ac.ToString());
                }
            }
        }

        private static void ViewErrorMessage(string message) // här skapas Felmeddelandet.
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }



        private static void ViewTestHeader(string header)
        {
            Console.WriteLine();
            Console.WriteLine(FormatLine);
            Console.WriteLine(header);
        }
        private static string FormatLine = "══════════════════════════════════════════════════════════";
    }
}
        