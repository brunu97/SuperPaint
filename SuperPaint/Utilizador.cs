using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SuperPaint
{
    class Utilizador
    {
        public int corIndex { get; set; }
        public int corFrenteIndex { get; set; }
        public bool modo_Desenho { get; set; }
        public int c_x { get; set; } // Indicadores de posições do cursor
        public int c_y { get; set; }


        public Utilizador()
        {
            corIndex = 0;
            corFrenteIndex = 15;
            modo_Desenho = false;
            c_x = 0;
            c_y = 0;
            Desenho.canetaCorFrente = ConsoleColor.White;
            Desenho.canetaCorFundo = ConsoleColor.Black;
            Desenho.canetaGrossura = 1;
            Menu.informador(1);
        }

        public void controlos()
        {
            ConsoleKey key = Console.ReadKey(true).Key;
            switch (key)
            {


                case ConsoleKey.D6:
                    {
                        Desenho.chr = '#';
                        break;
                    }
                case ConsoleKey.D7:
                    {
                        Desenho.chr = '█';
                        break;
                    }
                case ConsoleKey.D8:
                    {
                        Desenho.chr = '▓';
                        break;
                    }
                case ConsoleKey.D9:
                    {
                        Desenho.chr = '░';
                        break;
                    }

                case ConsoleKey.Q: // Faz Retangulo
                    {
                        int a_cx = Console.CursorLeft; 
                        int a_cy = Console.CursorTop;
                        Menu.informador(2);
                        bool adesenhar = true;
                        while (adesenhar == true)
                        {
                            ConsoleKey key2 = Console.ReadKey(true).Key;
                            switch (key2)
                            {
                                case ConsoleKey.DownArrow:
                                    {
                                        c_y++;
                                        if (c_y > Menu.altura_menu) { c_y = Menu.altura_menu; break; }
                                        Console.SetCursorPosition(c_x, c_y);
                                        break;
                                    }
                                case ConsoleKey.UpArrow:
                                    {
                                        c_y--;
                                        if (c_y < a_cy) { c_y = a_cy; break; }
                                        Console.SetCursorPosition(c_x, c_y);
                                        break;
                                    }
                                case ConsoleKey.LeftArrow:
                                    {
                                        c_x--;
                                        if (c_x < a_cx) { c_x = a_cx; break; }
                                        Console.SetCursorPosition(c_x, c_y);
                                        break;
                                    }
                                case ConsoleKey.RightArrow:
                                    {
                                        c_x++;
                                        if (c_x >= Console.WindowWidth) { c_x = Console.WindowWidth - 1; }
                                        Console.SetCursorPosition(c_x, c_y);
                                        break;
                                    }
                                case ConsoleKey.Enter:
                                    {
                                        Desenho.desenharRetangulo(a_cx, Console.CursorLeft, a_cy, Console.CursorTop);
                                        Menu.informador(1);
                                        adesenhar = false;
                                        modo_Desenho = false;
                                        break;
                                    }
                            }
                        }
                        break;
                    }

                case ConsoleKey.U: // Desenha Linhas
                    {
                        int a_cx = Console.CursorLeft;
                        int a_cy = Console.CursorTop;
                        Menu.informador(3);
                        bool emLinha = true;
                        while (emLinha == true)
                        {
                            ConsoleKey key2 = Console.ReadKey(true).Key;
                            switch (key2)
                            {
                                case ConsoleKey.DownArrow:
                                    {
                                        c_y++;
                                        if (c_y > Menu.altura_menu) { c_y = Menu.altura_menu; break; }
                                        Console.SetCursorPosition(c_x, c_y);
                                        break;
                                    }
                                case ConsoleKey.UpArrow:
                                    {
                                        c_y--;
                                        if (c_y < 0) { c_y = 0; break; }
                                        Console.SetCursorPosition(c_x, c_y);
                                        break;
                                    }
                                case ConsoleKey.LeftArrow:
                                    {
                                        c_x--;
                                        if (c_x < Menu.comprimento_menu) { c_x = Menu.comprimento_menu; break; }
                                        Console.SetCursorPosition(c_x, c_y);
                                        break;
                                    }
                                case ConsoleKey.RightArrow:
                                    {
                                        c_x++;
                                        if (c_x >= Console.WindowWidth) { c_x = Console.WindowWidth - 1; }
                                        Console.SetCursorPosition(c_x, c_y);
                                        break;
                                    }
                                case ConsoleKey.Enter:
                                    {
                                        Desenho.desenharLinha(a_cx, a_cy, c_x, c_y);
                                        Menu.informador(1);
                                        emLinha = false;
                                        modo_Desenho = false;
                                        break;
                                    }
                            }
                        }
                        break;

                    }

                case ConsoleKey.T: // Escreve Texto
                    {
                        int a_cx = Console.CursorLeft;
                        int a_cy = Console.CursorTop;
                        Console.BackgroundColor = Desenho.canetaCorFundo;
                        Console.ForegroundColor = Desenho.canetaCorFrente;

                        string s = Console.ReadLine();
                        Console.SetCursorPosition(a_cx, a_cy);
                        break;
                    }

                case ConsoleKey.L: // Limpar Tudo
                    {
                        Console.BackgroundColor = Desenho.canetaCorFundo;
                        Console.ForegroundColor = Desenho.canetaCorFrente;
                        for (int y = 0; y <= Console.WindowHeight; y++)
                        {
                            for (int x = Menu.comprimento_menu; x < Console.WindowWidth; x++)
                            {
                                Console.SetCursorPosition(x, y);
                                Console.Write(" ");
                            }
                        }
                        break;
                    }

                case ConsoleKey.D1: // Muda tamanho da caneta do ponto
                    {
                        Menu.tamanhoSeletor(1);
                        Desenho.canetaGrossura = 1;
                        break;
                    }
                case ConsoleKey.D2: // Muda tamanho da caneta do ponto
                    {
                        Menu.tamanhoSeletor(2);
                        Desenho.canetaGrossura = 2;
                        break;
                    }
                case ConsoleKey.D3: // Muda tamanho da caneta do ponto
                    {
                        Menu.tamanhoSeletor(3);
                        Desenho.canetaGrossura = 3;
                        break;
                    }


                case ConsoleKey.C: // Escolhe Cor do Fundo
                    {
                        int a_cx = Console.CursorLeft;
                        int a_cy = Console.CursorTop;
                        Console.SetCursorPosition(3, 2 + corIndex);
                        bool selecionada = false;
                        int corAnterior = corIndex;
                        while (selecionada == false)
                        {
                            ConsoleKey key2 = Console.ReadKey(true).Key;
                            switch (key2)
                            {
                                case ConsoleKey.DownArrow:
                                    {
                                        corIndex++; if (corIndex > 15) { corIndex = 0; }
                                        Console.SetCursorPosition(3, 2 + corIndex);
                                        break;
                                    }
                                case ConsoleKey.UpArrow:
                                    {
                                        corIndex--; if (corIndex < 0) { corIndex = 15; }
                                        Console.SetCursorPosition(3, 2 + corIndex);
                                        break;
                                    }
                                case ConsoleKey.Enter:
                                    {
                                        Console.SetCursorPosition(4, 2 + corIndex); // Mostra na UI qual a cor selecionada
                                        Desenho.canetaCorFundo = (ConsoleColor)corIndex;

                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("C");

                                        Console.SetCursorPosition(4, 2 + corAnterior); // Remove cor anterior selecionada na UI
                                        Console.Write(" ");
                                        Menu.informador(1);
                                        selecionada = true;
                                        modo_Desenho = false;
                                        break;
                                    }
                            }
                        }
                        Console.SetCursorPosition(a_cx, a_cy);
                        break;
                    }

                case ConsoleKey.F: // Escolhe Cor da Frente (texto)
                    {
                        int a_cx = Console.CursorLeft;
                        int a_cy = Console.CursorTop;
                        Console.SetCursorPosition(3, 2 + corFrenteIndex);
                        bool selecionada = false;
                        int corAnterior = corFrenteIndex;
                        while (selecionada == false)
                        {
                            ConsoleKey key2 = Console.ReadKey(true).Key;
                            switch (key2)
                            {
                                case ConsoleKey.DownArrow:
                                    {
                                        corFrenteIndex++; if (corFrenteIndex > 15) { corFrenteIndex = 0; }
                                        Console.SetCursorPosition(3, 2 + corFrenteIndex);
                                        break;
                                    }
                                case ConsoleKey.UpArrow:
                                    {
                                        corFrenteIndex--; if (corFrenteIndex < 0) { corFrenteIndex = 15; }
                                        Console.SetCursorPosition(3, 2 + corFrenteIndex);
                                        break;
                                    }
                                case ConsoleKey.Enter:
                                    {
                                        Console.SetCursorPosition(5, 2 + corFrenteIndex); // Mostra na UI qual a cor selecionada
                                        Desenho.canetaCorFrente = (ConsoleColor)corFrenteIndex;

                                        Console.BackgroundColor = ConsoleColor.Black;
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("F");

                                        Console.SetCursorPosition(5, 2 + corAnterior); // Remove cor anterior selecionada na UI
                                        Console.Write(" ");
                                        Menu.informador(1);
                                        selecionada = true;
                                        modo_Desenho = false;
                                        break;
                                    }
                            }
                        }
                        Console.SetCursorPosition(a_cx, a_cy);
                        break;
                    }

                case ConsoleKey.D:
                    {
                        if (modo_Desenho) { modo_Desenho = false; Menu.informador(1); } else { Menu.informador(4); modo_Desenho = true; Desenho.desenhaPonto(); }
                        break;
                    }

                case ConsoleKey.UpArrow:
                    {
                        c_y--;
                        if (c_y < 0) { c_y = 0; break; }
                        Console.SetCursorPosition(c_x, c_y);
                        if (modo_Desenho) { Desenho.desenhaPonto(); }
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        c_y++;
                        Console.SetCursorPosition(c_x, c_y);
                        if (c_y > Menu.altura_menu) { c_y = Menu.altura_menu; break; }
                        if (modo_Desenho) { Desenho.desenhaPonto(); }
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        c_x--;
                        if (c_x < Menu.comprimento_menu) { c_x = Menu.comprimento_menu; break; } // Impede o cursor de passar para o lado do menu
                        Console.SetCursorPosition(c_x, c_y);
                        if (modo_Desenho) { Desenho.desenhaPonto(); }
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        c_x++;
                        if (c_x >= Console.WindowWidth) { c_x = Console.WindowWidth - 1; }
                        Console.SetCursorPosition(c_x, c_y);
                        if (modo_Desenho) { Desenho.desenhaPonto(); }
                        break;
                    }
            }

        }
    }
}
