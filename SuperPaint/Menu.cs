using System;
using System.Collections.Generic;
using System.Text;

namespace SuperPaint
{
    class Menu
    {

        public static int altura_menu = 30;
        public static int comprimento_menu = 20;


        public static Dictionary<int, string> modos = new Dictionary<int, string>() {
            {1, "Caneta"},
            {2, "Retangulo" },
            {3, "Linha" },
            {4, "Caneta contínua" }
        };

        public static void criarMenu()
        {
            //Desenha UI
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            for (int altura = 0; altura < altura_menu; altura++)
            {
                for (int x = 0; x < 20; x++)
                {
                    if (altura == 0)
                    {
                        if (x == 0) { Console.SetCursorPosition(x, 0); Console.Write("+"); continue; }
                        if (x == comprimento_menu - 1) { Console.SetCursorPosition(x, 0); Console.Write("+"); continue; }
                        Console.SetCursorPosition(x, 0);
                        Console.Write("-");
                        continue;
                    }

                    if (altura == altura_menu - 1)
                    {
                        if (x == 0) { Console.SetCursorPosition(x, altura); Console.Write("+"); continue; }
                        if (x == comprimento_menu - 1) { Console.SetCursorPosition(x, altura); Console.Write("+"); continue; }
                        Console.SetCursorPosition(x, altura);
                        Console.Write("-");
                        continue;
                    }

                    Console.SetCursorPosition(0, altura);
                    string result = new string(' ', comprimento_menu - 2);
                    Console.Write("|" + result + "|");

                }
            }

            for (int i = 0; i < 16; i++)
            {
                Console.BackgroundColor = (ConsoleColor)i;
                Console.ForegroundColor = (ConsoleColor)i;
                if (i == 0) { Console.ForegroundColor = ConsoleColor.White; }
                Console.SetCursorPosition(2, 2 + i);
                Console.Write("#");
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(4, 2);
            Console.Write("C");
            Console.SetCursorPosition(5, 17);
            Console.Write("F");

            Console.SetCursorPosition(2, 19);
            Console.Write("Tamanho do ponto:");
            Console.SetCursorPosition(2, 20);
            Console.Write("[1]*- Pequeno");
            Console.SetCursorPosition(2, 21);
            Console.Write("[2] - Médio");
            Console.SetCursorPosition(2, 22);
            Console.Write("[3] - Grande");


            Console.SetCursorPosition(7, 2);
            Console.Write("[T] - Texto");
            Console.SetCursorPosition(7, 3);
            Console.Write("[L] - Limpar");
            Console.SetCursorPosition(13, 4);
            Console.Write("Tudo");
            Console.SetCursorPosition(7, 5);
            Console.Write("[D] - Caneta");
            Console.SetCursorPosition(7, 6);
            Console.Write("[E] - Ponto");



            Console.SetCursorPosition(10, 7);
            Console.Write("+---+");
            Console.SetCursorPosition(10, 8);
            Console.Write("| Q |");
            Console.SetCursorPosition(10, 9);
            Console.Write("+---+");


            Console.SetCursorPosition(9, 11);
            Console.Write("\\");
            Console.SetCursorPosition(10, 12);
            Console.Write("\\ U");
            Console.SetCursorPosition(11, 13);
            Console.Write("\\");
            Console.SetCursorPosition(12, 14);
            Console.Write("\\");

            Console.SetCursorPosition(10, 16);
            Console.Write("#-6");
            Console.SetCursorPosition(14, 16);
            Console.Write("█-7");
            Console.SetCursorPosition(10, 17);
            Console.Write("▓-8");
            Console.SetCursorPosition(14, 17);
            Console.Write("░-9");


            Console.SetCursorPosition(4, 25);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("SUPER");
            Console.SetCursorPosition(10, 26);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("PAINT");

            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(1, 28);
            Console.Write("Bruno Silva - 2021");
        }

        public static void informador(int modo)
        {
            int a_cx = Console.CursorLeft;
            int a_cy = Console.CursorTop;

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(1, 1);
            Console.Write("                  ");

            Console.SetCursorPosition(1, 1);
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("<> " + modos[modo]);
            Console.SetCursorPosition(a_cx, a_cy);
        }

        public static void tamanhoSeletor(int tamanho)
        {
            int a_cx = Console.CursorLeft;
            int a_cy = Console.CursorTop;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(5, 20 + (Desenho.canetaGrossura - 1));
            Console.Write(" ");
            Console.SetCursorPosition(5, 20 + (tamanho - 1));
            Console.Write("*");
            Console.SetCursorPosition(a_cx, a_cy);

        }
    }
}