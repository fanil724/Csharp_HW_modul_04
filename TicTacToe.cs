using System;

namespace C_sharp_HW_modul_04
{
    class Player
    {
        public virtual void move(char[,] board)
        {
        }

        public char _symbol { get; set; }
        public string _name { get; set; }
    }

    class PCPlayer : Player
    {
        public PCPlayer(char symbol)
        {
            _symbol = symbol;
            _name = "PC";
        }

        public override void move(char[,] board)
        {
            Random random = new Random();
            int i, j;
            do
            {
                i = random.Next(0, 2);
                j = random.Next(0, 2);
            } while (board[i, j] != '0');

            board[i, j] = _symbol;
        }
    }

    class HumanPlayer : Player
    {
        public HumanPlayer(char symbol, string name)
        {
            _symbol = symbol;
            _name = name;
        }

        public override void move(char[,] board)
        {
            uint i = 0, j = 0;
            do
            {
                try
                {
                    Console.WriteLine("Введите кординаты ячейки: ");
                    i = Convert.ToUInt32(Console.ReadLine());
                    j = Convert.ToUInt32(Console.ReadLine());
                    if (board[i, j] != '0')
                    {
                        throw new ArgumentOutOfRangeException();
                    }

                    board[i, j] = _symbol;
                    return;
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    Console.WriteLine("Ошибка: нет такой ячейки или она занята, повторите ввод!");
                }
            } while (true);
        }
    }


    public class TicTacToe
    {
        void mode()
        {
            char mode;
            Console.Write("Выбирите режим игры:");
            Console.Write("S - single-player");
            Console.WriteLine("M - multi-player");
            mode = Convert.ToChar(Console.ReadLine());
            if (mode == 's')
            {
                PCPlayer pcPlayer = new PCPlayer('x');
                _players[0] = pcPlayer;
            }
            else
            {
                Console.WriteLine("Введите имя игрока:");
                string nameplayer1 = Console.ReadLine();
                HumanPlayer humanPlayer = new HumanPlayer('x', nameplayer1);
                _players[0] = humanPlayer;
            }

            Console.WriteLine("Введите имя игрока:");
            string nameplayer2 = Console.ReadLine();
            HumanPlayer player = new HumanPlayer('o', nameplayer2);
            _players[1] = player;
        }

        void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        void Swap<T>(T a, T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        public void runGame()
        {
            mode();
            Random random = new Random();
            int number = random.Next(1, 2);
            if (number == 1)
            {
                Swap(ref _players[0], ref _players[1]);
                Swap(_players[0]._symbol, _players[1]._symbol);
            }

            do
            {
                for (int i = 0; i < _players.Length; i++)
                {
                    Console.Clear();
                    print();
                    _players[i].move(_board);
                    if (isWin(_board))
                    {
                        Console.Clear();
                        print();
                        return;
                    }

                    if (isDraw(_board))
                    {
                        Console.Clear();
                        print();
                        return;
                    }
                }
            } while (true);
        }


        bool isWin(char[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if ((board[i, 0] == board[i, 1]) && (board[i, 1] == board[i, 2]) && board[i, 0] != '0')
                {
                    Console.WriteLine("Поздрадяю с победой: " + $"{board[i, 0]}");
                    return true;
                }

                if ((board[0, i] == board[1, i]) && (board[1, i] == board[2, i]) && board[1, i] != '0')
                {
                    Console.WriteLine("Поздрадяю с победой: " + $"{board[0, i]}");
                    return true;
                }

                if ((board[0, 0] == board[1, 1]) && (board[1, 1] == board[2, 2] && board[0, 0] != '0'))
                {
                    Console.WriteLine("Поздрадяю с победой: " + $"{board[0, 0]}");
                    return true;
                }
                else if ((board[2, 0] == board[1, 1]) && (board[1, 1] == board[0, 2] && board[0, 2] != '0'))
                {
                    Console.WriteLine("Поздрадяю с победой: " + $"{board[0, 2]}");
                    return true;
                }
            }

            return false;
        }

        bool isDraw(char[,] board)
        {
            foreach (var item in board)
            {
                if (item == '0')
                {
                    return false;
                }
            }

            Console.WriteLine("Увы но нечья!!!");
            return true;
        }

        public void print()
        {
            Console.WriteLine("┌─┬─┬─┐");
            for (int i = 0; i < _board.GetLength(0); i++)
            {
                for (int j = 0; j < _board.GetLength(1); j++)
                {
                    if (_board[i, j] != '0')
                    {
                        Console.Write('|' + $"{_board[i, j]}");
                    }
                    else
                    {
                        Console.Write("| ");
                    }
                }

                Console.WriteLine('|');
                if (i != 2)
                {
                    Console.WriteLine("├─┼─┼─┤");
                }
            }

            Console.WriteLine("└─┴─┴─┘");
        }

        private Player[] _players = new Player[2];
        private char[,] _board = new char[3, 3] { { '0', '0', '0' }, { '0', '0', '0' }, { '0', '0', '0' } };
    }
}