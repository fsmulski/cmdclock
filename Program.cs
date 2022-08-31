using System;
using System.Text;
using System.Timers;

namespace cmdclock {
    class Program {
        public static string[][] display = new string[5][];

        static void Main(string[] args) {
            bool isCursorVisibile = Console.CursorVisible;
            Console.Clear();
            Timer timer = new Timer(1000);
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            Console.ReadLine();
            timer.Stop();
            Console.CursorVisible = isCursorVisibile;
        }

        private static void WriteDigit(string[][] container, string digit, int position, string fill) {
            position = (position * 6) + 1;
            switch (digit) {
                case "0":
                    for (int i = 0; i < 4; i++) {
                        container[0][position + i] = fill;
                        container[4][position + i] = fill;
                    }
                    container[1][position] = fill;
                    container[1][position + 3] = fill;
                    container[2][position] = fill;
                    container[2][position + 3] = fill;
                    container[3][position] = fill;
                    container[3][position + 3] = fill;
                    break;
                case "1":
                    for (int i = 0; i < 5; i++) {
                        container[i][position + 3] = fill;
                    }
                    break;
                case "2":
                    for (int i = 0; i < 4; i++) {
                        container[0][position + i] = fill;
                        container[2][position + i] = fill;
                        container[4][position + i] = fill;
                    }
                    container[1][position + 3] = fill;
                    container[3][position] = fill;
                    break;
                case "3":
                    for (int i = 0; i < 4; i++) {
                        container[0][position + i] = fill;
                        container[2][position + i] = fill;
                        container[4][position + i] = fill;
                    }
                    container[1][position + 3] = fill;
                    container[3][position + 3] = fill;
                    break;
                case "4":
                    for (int i = 0; i < 5; i++) {
                        container[i][position + 3] = fill;
                    }
                    for (int i = 0; i < 3; i++) {
                        container[i][position] = fill;
                    }
                    container[2][position + 1] = fill;
                    container[2][position + 2] = fill;
                    break;
                case "5":
                    for (int i = 0; i < 4; i++) {
                        container[0][position + i] = fill;
                        container[2][position + i] = fill;
                        container[4][position + i] = fill;
                    }
                    container[1][position] = fill;
                    container[3][position + 3] = fill;
                    break;
                case "6":
                    for (int i = 0; i < 4; i++) {
                        container[0][position + i] = fill;
                        container[2][position + i] = fill;
                        container[4][position + i] = fill;
                    }
                    container[1][position] = fill;
                    container[3][position] = fill;
                    container[3][position + 3] = fill;
                    break;
                case "7":
                    for (int i = 0; i < 3; i++) {
                        container[0][position + i] = fill;
                    }
                    for (int i = 0; i < 5; i++) {
                        container[i][position + 3] = fill;
                    }
                    break;
                case "8":
                    for (int i = 0; i < 5; i++) {
                        container[i][position] = fill;
                        container[i][position + 3] = fill;
                    }
                    for (int i = 1; i < 3; i++) {
                        container[0][position + i] = fill;
                        container[2][position + i] = fill;
                        container[4][position + i] = fill;
                    }
                    break;
                case "9":
                    for (int i = 0; i < 4; i++) {
                        container[0][position + i] = fill;
                        container[2][position + i] = fill;
                        container[4][position + i] = fill;
                    }
                    container[1][position] = fill;
                    container[1][position + 3] = fill;
                    container[3][position + 3] = fill;
                    break;
                default:
                    break;
            }
        }

        private static void Timer_Elapsed(object sender, ElapsedEventArgs e) {
            string dateNow = DateTime.Now.ToString("HH:mm:ss");

            for (int i = 0; i < 5; i++) {
                display[i] = new string[48];
            }

            Console.CursorTop = 0;
            Console.CursorLeft = 0;
            Console.CursorVisible = false;
            Console.OutputEncoding = Encoding.Unicode;

            for (int i = 0; i < 5; i++) {
                for (int j = 0; j < 48; j++) {
                    display[i][j] = " ";
                }
            }

            WriteTime(dateNow, display, Constants.FILL_4);

            string[] hlineRow = new string[48];
            for (int i = 0; i < 48; i++) {
                hlineRow[i] = Constants.H_LINE;
            }

            string topBorder = String.Format("{0}{1}{2}", Constants.TOP_LEFT, String.Join("", hlineRow), Constants.TOP_RIGHT);
            Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + topBorder.Length / 2) + "}", topBorder));

            for (int i = 0; i < 5; i++) {
                string joinedRow = String.Join("", display[i]);
                joinedRow = String.Format("{0}{1}{0}", Constants.V_LINE, joinedRow);
                Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + joinedRow.Length / 2) + "}", joinedRow));
            }

            string bottomBorder = String.Format("{0}{1}{2}", Constants.BOTTOM_LEFT, String.Join("", hlineRow), Constants.BOTTOM_RIGHT);
            Console.WriteLine(String.Format("{0, " + (Console.WindowWidth / 2 + bottomBorder.Length / 2) + "}", bottomBorder));
        }

        private static void WriteTime(string dateNow, string[][] display, string fill) {
            WriteColons(display, fill);

            WriteDigit(display, dateNow[0].ToString(), 0, fill);
            WriteDigit(display, dateNow[1].ToString(), 1, fill);
            WriteDigit(display, dateNow[3].ToString(), 3, fill);
            WriteDigit(display, dateNow[4].ToString(), 4, fill);
            WriteDigit(display, dateNow[6].ToString(), 6, fill);
            WriteDigit(display, dateNow[7].ToString(), 7, fill);
        }

        private static void WriteColons(string[][] display, string fill) {
            display[1][14] = fill;
            display[1][15] = fill;
            display[3][14] = fill;
            display[3][15] = fill;
            display[1][32] = fill;
            display[1][33] = fill;
            display[3][32] = fill;
            display[3][33] = fill;
        }
    }
}