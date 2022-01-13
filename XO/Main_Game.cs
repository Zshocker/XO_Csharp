using System;
using System.Collections.Generic;

namespace XO
{
    class Main_Game
    {
        Player _P1, _P2;
        Dictionary<Player, char> _Player_Char = new Dictionary<Player, char>();
        bool turn=true;
        private char[,] _Game_chars=new char[3,3];
        public Main_Game(Player Xplayer,Player Oplayer)
        {
            _P1 = Xplayer;
            _P2 = Oplayer;
            _Player_Char.Add(_P1, 'X');
            _Player_Char.Add(_P2, 'O');
            //init_Game();
        }
        private void init_Game()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _Game_chars[i,j] = ' ';
                }
            }
        }
        char test_colloms()
        {
            for (int i = 0; i < 3; i++)
            {
                if (_Game_chars[i, 0] == _Game_chars[i, 1] && _Game_chars[i, 1] == _Game_chars[i, 2] && _Game_chars[i, 2] != -1) return _Game_chars[i, 0];
            }
            return ' ';
        }
        char test_rows()
        {
            for (int i = 0; i < 3; i++)
            {
                if (_Game_chars[0,i] == _Game_chars[1,i] && _Game_chars[1,i] == _Game_chars[2,i] && _Game_chars[2,i] != -1) return _Game_chars[0,i];
            }
            return ' ';
        }
        char test_Ves()
        {
            if (_Game_chars[0,0] == _Game_chars[1,1] && _Game_chars[1,1] == _Game_chars[2,2] && _Game_chars[2,2] != -1) return _Game_chars[0,0];
            if (_Game_chars[0,2] == _Game_chars[1,1] && _Game_chars[1,1] == _Game_chars[2,0] && _Game_chars[0,2] != -1) return _Game_chars[1,1];
            return ' ';
        }
        bool test_draw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_Game_chars[i,j] == ' ') return false;
                }
            }
            return true;
        }
        bool test_end_game()
        {
            char a;
            a = test_colloms();
            if (a != ' ') 
            {
                return end_game(a);
            }
            a = test_rows();
            if (a != ' ')
            {
                return end_game(a);
            }
            a = test_Ves();
            if (a != ' ')
            {
                return end_game(a);
            }
            if (test_draw())
            {
               return end_game(' ');
            }
            return false;
        }
        private Player Get_Ref_Player(char value)
        {
            Dictionary<Player, char>.KeyCollection keys = _Player_Char.Keys;
            foreach (Player key in keys)
            {
                if (Get_player_Char(key) == value)
                {
                    return key;
                }
            }
            return null;
        }
        private char Get_player_Char(Player player)
        {
            _Player_Char.TryGetValue(player, out char v);
            return v;
        }
        private bool end_game(char a)
        {
            Console.Write("\nGame ended :");
            if (a==' ')
            {
                Console.WriteLine("We Have a draw!");
                return true;
            }
            Player S = Get_Ref_Player(a);
            S.Print_name();
            Console.WriteLine(" Wins");
            return true;
        }
        private void Print_Game()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(_Game_chars[i,j]==' ')
                    {
                        Console.Write(i * 3 + j+1);
                    
                    }else Console.Write(_Game_chars[i,j]);
                    Console.Write(" | ");
                }
                Console.WriteLine();
            }
        }
        private void Print_Whos_Turn()
        {
            Console.WriteLine("");
            if (turn)
            {
                _P1.Print_name();
            }
            else _P2.Print_name();
            Console.WriteLine("'s turn");
        }
        private Player Get_Whos_Turn()
        {
            if (turn)
            {
                return _P1;
            }
            return _P2;
        }
        private void Turn_ind_toPair(int ind, out int v1,out int v2)
        {
            ind--;
            v2 = ind % 3;
            v1 = ind / 3;
        }
        private bool Write_in_ind(int ind)
        {
            if (ind == -1) return false;
            Player turns = Get_Whos_Turn();
            Turn_ind_toPair(ind, out int ind1, out int ind2);
            if (Test_not_empty(ind1, ind2)) return false;
            _Game_chars[ind1, ind2] = Get_player_Char(turns);
            return true;
        }
        private bool Test_not_empty(int ind1, int ind2)
        {
            return _Game_chars[ind1, ind2] != ' ';
        }

        public void Start_Game()
        {
            init_Game();
            do
            {
                Print_Game();
                Print_Whos_Turn();
                int ind = -1;
                do
                {
                    Console.WriteLine("give the index:");
                    ind = Int32.Parse(Console.ReadLine());
                    if (ind < 1 || ind > 9)
                    {
                        Console.WriteLine("index Must be between 1 and 9");
                        ind = -1;
                    }
                    else if (!Write_in_ind(ind))
                    {
                        Console.WriteLine("index Must be of an empthy place");
                        ind = -1;
                    }
                } while (ind==-1);
                turn = !turn;
            } while (!test_end_game());
            Print_Game();
        }
    }
}
