using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Battle
{
    class User : Player
    {
        public void UserAttack(string[,] field, out int stop, out int counthits)                          //атака пользователя
        {
            counthits = 0;
            stop = 1;
            int x = -1;
            int y;
            string input;
            char letter;
            int number;
        A: Console.WriteLine("Введите поле, по которому хотите нанести удар: ");
            input = Console.ReadLine();
            input = input.Trim();
            input = input.ToLower();
            if ((input[0] == 'а' || input[0] == 'б' || input[0] == 'в' || input[0] == 'г' || input[0] == 'д' || input[0] == 'е' || input[0] == 'ж' || input[0] == 'з' || input[0] == 'и' || input[0] == 'к') && input.Count() <= 3
&& (input[1] == '1' || input[1] == '2' || input[1] == '3' || input[1] == '4' || input[1] == '5' || input[1] == '6' || input[1] == '7' || input[1] == '8' || input[1] == '9'))
            {
                
            }
            else 
            { 
                Console.WriteLine("Вы неправильно ввели поле, попробуйте заново");
                goto A;
            }

            letter = input[0];
            number = int.Parse(Convert.ToString(input[1]));
            if (input.Count() == 3 && input[2] == '0' && input[1] == '1')
                number = 10;
            else if (input.Count() == 3)
            {
                Console.WriteLine("Вы неправильно ввели поле, попробуйте заново");
                goto A;
            }

            switch (letter)
            {
                case 'а':
                    {
                        x = 3;
                        break;
                    }
                case 'б':
                    {
                        x = 4;
                        break;
                    }
                case 'в':
                    {
                        x = 5;
                        break;
                    }
                case 'г':
                    {
                        x = 6;
                        break;
                    }
                case 'д':
                    {
                        x = 7;
                        break;
                    }
                case 'е':
                    {
                        x = 8;
                        break;
                    }
                case 'ж':
                    {
                        x = 9;
                        break;
                    }
                case 'з':
                    {
                        x = 10;
                        break;
                    }
                case 'и':
                    {
                        x = 11;
                        break;
                    }
                case 'к':
                    {
                        x = 12;
                        break;
                    }
            }
            y = number + 2;
            Neighbor(field, y, x, out stop, 13, 13);
            if (field[y, x] == "1")
                field[y, x] = "х";
            else
            {
                field[y, x] = "о";
                stop += 1;
                counthits += 1;
            }      
        }

        public void GetUserField(string[,] userfield, out int random)
        {
            random = 0;
            for (int k = 0; k < 1; k++)
            {
                int x = -1;
                int y;
                char letter;
                int number;
            A: Console.WriteLine("Введите координаты в местах, где хотите разместить корабли");
                Console.WriteLine("Помните о количестве кораблей и расстоянии между ними!");
                Console.WriteLine("4х палубный - 1, 3х палубный - 2, 2х палубный - 3, 1палубный - 4");
                Console.WriteLine("Или вы можете задать рандомное поле введя \"рандом\"");
                string input = Console.ReadLine();
                input = input.Trim();
                input = input.ToLower();
                
                if ((input[0] == 'а' || input[0] == 'б' || input[0] == 'в' || input[0] == 'г' || input[0] == 'д' || input[0] == 'е' || input[0] == 'ж' || input[0] == 'з' || input[0] == 'и' || input[0] == 'к') && input.Count() <= 3
    && (input[1] == '1' || input[1] == '2' || input[1] == '3' || input[1] == '4' || input[1] == '5' || input[1] == '6' || input[1] == '7' || input[1] == '8' || input[1] == '9') || input == "рандом")
                {

                }
                else
                {
                    Console.WriteLine("Вы неправильно ввели поле, попробуйте заново");
                    goto A;
                }
                if (input == "рандом")
                {
                    random += 1;
                    break;
                }
                letter = input[0];
                number = int.Parse(Convert.ToString(input[1]));
                if (input.Count() == 3 && input[2] == '0' && input[1] == '1')
                    number = 10;
                else if (input.Count() == 3)
                {
                    Console.WriteLine("Вы неправильно ввели поле, попробуйте заново");
                    goto A;
                }

                switch (letter)
                {
                    case 'а':
                        {
                            x = 3;
                            break;
                        }
                    case 'б':
                        {
                            x = 4;
                            break;
                        }
                    case 'в':
                        {
                            x = 5;
                            break;
                        }
                    case 'г':
                        {
                            x = 6;
                            break;
                        }
                    case 'д':
                        {
                            x = 7;
                            break;
                        }
                    case 'е':
                        {
                            x = 8;
                            break;
                        }
                    case 'ж':
                        {
                            x = 9;
                            break;
                        }
                    case 'з':
                        {
                            x = 10;
                            break;
                        }
                    case 'и':
                        {
                            x = 11;
                            break;
                        }
                    case 'к':
                        {
                            x = 12;
                            break;
                        }
                }
                y = number + 2;
                userfield[y, x] = "1";
            }
        }

    }
}
