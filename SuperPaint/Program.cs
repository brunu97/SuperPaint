using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace SuperPaint
{

    class Program
    {

        static void Main(string[] args)
        {


            Menu.criarMenu();
            Utilizador user = new Utilizador();
            Desenho.chr = '#';

            Console.SetCursorPosition(25, 10);
            user.c_x = 25;
            user.c_y = 10;

            while (true)
            {
                user.controlos();
            }
        }

    }
}
