using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L2C
{
    class Program
    {
        private static string HorizontalLine = "═══════════════════════════════════════════════════════════════════════════════";

        /// <summary>
        /// The core of the test program
        /// </summary>
        /// <param name="args">Command-line Arguments</param>
        static void Main(string[] args)
        {
            //Test 1
            ViewTestHeader("Test 1.\nTest av standardkonstuktorn.");
            AlarmClock test = new AlarmClock();
            Console.WriteLine(test.ToString());

            //Test2
            ViewTestHeader("Test 2.\nTest av konstruktorn med två parametrar, (9, 42).");
            test = new AlarmClock(9, 42);
            Console.WriteLine(test.ToString());

            //Test3
            ViewTestHeader("Test 3.\nTest av konstruktorn med fyra parametrar, (13, 24, 7, 35).");
            test = new AlarmClock(13, 24, 7, 35);
            Console.WriteLine(test.ToString());

            //Test4
            ViewTestHeader("Test 4.\nTest av konstruktorn med minst två parametrar av typen string. (\"7:07\", \"7:10\", \"7:15\", \"7:30\").");
            test = new AlarmClock("7:07", new[]{"7:10", "7:15", "7:30"});
            Console.WriteLine(test.ToString());

            //Test5
            ViewTestHeader("Test 5.\nStäller befintligt AlarmClock-objekt till 23:58 och låter den gå 13 minuter.");
            test.Time = "23:58";
            Run(test, 13);

            //Test6
            ViewTestHeader("Test 6.\nStäller befintligt AlarmClock-objekt till tiden 6:12 och alarmtiden till 6:15 och låter den gå 6 minuter");
            test.Time = "6:12";
            test.AlarmTimes = new[] { "6:15" };
            Run(test, 6);

            //Test7
            ViewTestHeader("Test 7.\nTestar egenskaperna så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.");
            try
            {
                test.Time = "24:89";
            }
            catch (FormatException ex)
            {
                ViewErrorMessage(string.Format("Strängen '{0}' kan inte tolkas som en tid på formatet HH:mm", ex.Message));
            }
            try
            {
                test.AlarmTimes = new[] { "7:69" };
            }
            catch (FormatException ex)
            {
                ViewErrorMessage(string.Format("Strängen '{0}' kan inte tolkas som en tid på formatet HH:mm", ex.Message));
            }

            //Test8
            ViewTestHeader("Test 8.\nTestar konstruktorer så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.");
            try
            {
                test = new AlarmClock(32, 03, 0, 0);
            }
            catch (ArgumentException ex)
            {
                ViewErrorMessage(string.Format("Strängen '{0}' kan inte tolkas som en tid på formatet HH", ex.Message));
            }
            try
            {
                test = new AlarmClock(0, 0, 27, 00);
            }
            catch (ArgumentException ex)
            {
                ViewErrorMessage(string.Format("Strängen '{0}' kan inte tolkas som en tid på formatet HH", ex.Message));
            }

            //Test9
            ViewTestHeader("Test 9 (extra).\nTestar ifall flera alarmtider kan aktiveras under en och samma körning");
            test = new AlarmClock("7:07", new[] { "7:09", "7:11", "7:14" });
            Run(test, 8);
        }

        /// <summary>
        /// Engine of the clock. Makes calls to AlarmClock.cs to run the clock. Only uses a simulation of minutes and not real minutes.
        /// </summary>
        /// <param name="ac">AlarmClock object containing the times and alarmtimes the clock should start with.</param>
        /// <param name="minutes">An interger of the number of minutes the clock should run.</param>
        private static void Run(AlarmClock ac, int minutes)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔═════════════════════════════════════╗ ");
            Console.WriteLine(" ║       Väckarklockan URLED (TM)      ║ ");
            Console.Write(" ║");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("        Modellnr.: 1DV402S2L2C       ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("║ ");
            Console.WriteLine(" ╚═════════════════════════════════════╝ ");
            Console.ResetColor();
            int minute = 0;
            string[] alarmTimes = ac.AlarmTimes;
            bool result;
            do
            {
                result = ac.TickTock();
                int formating = ac.ToString().Length + 2;
                if (result)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(string.Format(" ♫{0, " + formating + "}   BEEP! BEEP! BEEP! BEEP!", ac.ToString()));
                    Console.ResetColor();
                }
                else
                {
                    if (ac.Time.Length < 5)
                    {
                        formating++;
                    }
                    Console.WriteLine(string.Format(" {0, " + formating + "}", ac.ToString()));
                }
                minute++;
            } while (minute < minutes);
        }

        /// <summary>
        /// Displays a error message with red background and white text
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        private static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a header with a specified header message
        /// </summary>
        /// <param name="header"The header message to be displayed></param>
        private static void ViewTestHeader(string header)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.WriteLine(HorizontalLine);
            Console.WriteLine(header);
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
