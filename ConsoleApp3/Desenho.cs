using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SuperPaint
{
    class Desenho
    {
        public static ConsoleColor canetaCorFundo { set; get; }
        public static ConsoleColor canetaCorFrente { set; get; }
        public static int canetaGrossura { set; get; } // Tamanho do Ponto
        public static char chr { set; get; }


        public static void desenhaPonto()
        {
            Console.BackgroundColor = canetaCorFundo;
            Console.ForegroundColor = canetaCorFrente;
            int cx = Console.CursorLeft;
            int cy = Console.CursorTop;
            for (int y = 0; y < canetaGrossura; y++)
            {
                for (int x = 0; x < canetaGrossura; x++)
                {
                    if (cx >= Console.WindowWidth) { break; }
                    Console.SetCursorPosition(cx, cy);
                    Console.Write(chr);
                    cx++;
                }
                cy++;
                cx = cx - canetaGrossura;
            }

        }


        public static void desenharRetangulo(int xi, int xf, int yi, int yf)
        {
            string s = new string('-', xf - xi);
            Console.BackgroundColor = canetaCorFundo;
            Console.ForegroundColor = canetaCorFrente;
            Console.SetCursorPosition(xi, yi);
            Console.Write("+" + s + "+");

            for (int y = yi + 1; y < yf; y++)
            {
                Console.SetCursorPosition(xi, y);
                Console.Write("|");
                Console.SetCursorPosition(xf + 1, y);
                Console.Write("|");
            }

            Console.SetCursorPosition(xi, yf);
            Console.Write("+" + s + "+");
        }

        // https://rosettacode.org/wiki/Bitmap/Bresenham%27s_line_algorithm#C.23
        public static void desenharLinha(int x0, int y0, int x1, int y1) // Bresenham
        {
            Console.BackgroundColor = canetaCorFundo;
            Console.ForegroundColor = canetaCorFrente;
            int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
            int dy = Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
            int err = (dx > dy ? dx : -dy) / 2, e2;
            for (; ; )
            {
                Console.SetCursorPosition(x0, y0);
                Console.Write(chr);
                if (x0 == x1 && y0 == y1) break;
                e2 = err;
                if (e2 > -dx) { err -= dy; x0 += sx; }
                if (e2 < dy) { err += dx; y0 += sy; }
            }
        }
    }
}