using System;
using System.Text;
using System.Timers;

namespace cmdclock {
    class Program {
        static void Main(string[] args) {
            Console.Clear();
            Timer timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            Console.ReadLine();
            timer.Stop();
        }
        static void Write(int charcode) {
            Console.Write((char)charcode);
        }
        static void WriteLine(int charcode) {
            Console.WriteLine((char)charcode);
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            string topleft = "┌";
            string hline = "─";
            string topright = "┐";
            string vline = "│";
            string bottomleft = "└";
            string bottomright = "┘";
            string dateNow = DateTime.Now.ToString("HH:mm:ss");

            Console.CursorTop = 0;
            Console.CursorLeft = 0;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Write(topleft);
            for (int i = 0; i < 8; i++) {
                Console.Write(hline);
            }
            Console.Write(topright);
            Console.WriteLine();
            Console.Write(vline);
            Console.Write(dateNow);
            Console.WriteLine(vline);
            Console.Write(bottomleft);
            for (int i = 0; i < 8; i++) {
                Console.Write(hline);
            }
            Console.Write(bottomright);
            // Console.Write(String.Format("\r{0, " + (Console.WindowWidth / 2 + dateNow.Length / 2) + "}", dateNow));
        }
    }
}