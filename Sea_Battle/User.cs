using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Battle
{
    class User
    {
        public void UserAttack(string[,] field)                          //атака пользователя
        {
            int x = -1;
            int y;
            string input;
            char letter;
            int number;
        A: Console.WriteLine("Введите поле, по которому хотите нанести удар: ");
            input = Console.ReadLine();
            input = input.Trim();
            input = input.ToLower();
            if (input[0] != 'а' && input[0] != 'б' && input[0] != 'в' && input[0] != 'г' && input[0] != 'д' && input[0] != 'е' && input[0] != 'ж' && input[0] != 'з' && input[0] != 'и' && input[0] != 'к' && input.Count() > 3
            && input[1] != '1' && input[1] != '2' && input[1] != '3' && input[1] != '4' && input[1] != '5' && input[1] != '6' && input[1] != '7' && input[1] != '8' && input[1] != '9')
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
            if (field[y, x] == "1")
                field[y, x] = "х";
            else
                field[y, x] = "о";
        }
    }
}
