using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Battle
{
    class Program
    {
        static void Main(string[] args)
        {
            int randomfield;
            int stop = 1;
            int count = 1;
            string[,] field = new string[16, 16];
            string[,] invisiblefield = new string[16, 16];
            string[,] userfield = new string[16, 16];
            User user = new User();
            Computer comp = new Computer();

            for (int j = 0; j < field.GetLength(1); j++)       //начальная конфигурация поля
            {
                for (int i = 0; i < field.GetLength(0); i++)
                {
                    field[i, j] = ".";
                    invisiblefield[i, j] = ".";
                    userfield[i, j] = ".";
                }
            }

            while (count <= 20)
            {
                Console.Clear();
                for (int j = 3; j < userfield.GetLength(1) - 3; j++)
                {
                    for (int i = 3; i < userfield.GetLength(0) - 3; i++)
                    {
                        Console.Write(userfield[i, j]);
                    }
                    Console.WriteLine("");
                }
                user.GetUserField(userfield, out randomfield);
                if (randomfield > 0)
                {
                    user.InsallShip(userfield, user);
                    break;
                }
                count++;
            }


            comp.InsallShip(invisiblefield, comp);
            DrawField(field, userfield);

            while (true)
            {
                int usercounthits = 0;
                int compcounthits = 0;
                while (usercounthits == 0)
                {
                    user.UserAttack(invisiblefield, out stop, out usercounthits);
                    for (int j = 0; j < field.GetLength(1); j++)
                    {
                        for (int i = 0; i < field.GetLength(0); i++)
                        {
                            if (invisiblefield[i, j] != "1")
                                field[i, j] = invisiblefield[i, j];
                        }
                    }
                    DrawField(field, userfield);
                }
                Console.WriteLine("Нажмите Enter для атаки компьютера");
                Console.ReadKey();             
                while (compcounthits == 0)
                {
                    comp.ComputerAttack(userfield, out compcounthits);
                    DrawField(field, userfield);
                }
            }

            

            void DrawField(string [,] field1, string[,] field2)        //метод вырисовки поля
            {
                Console.Clear();
                for (int j = 3; j < field1.GetLength(1)-3; j++)
                {
                    for (int i = 3; i < field1.GetLength(0)-3; i++)
                    {
                        if (field1[i, j] == "х")
                            Console.ForegroundColor = ConsoleColor.Red;
                        if (field1[i, j] == "о")
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(field1[i, j]);
                        Console.ResetColor();
                    }
                    Console.WriteLine("");
                }
                Console.WriteLine("/");
                for (int j = 3; j < field2.GetLength(1) - 3; j++)
                {
                    for (int i = 3; i < field2.GetLength(0) - 3; i++)
                    {
                        if (field2[i, j] == "х")
                            Console.ForegroundColor = ConsoleColor.Red;
                        if (field2[i, j] == "о")
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write(field2[i, j]);
                        Console.ResetColor();
                    }
                    Console.WriteLine("");
                }
                if (stop == 0)
                {
                    Console.WriteLine("Корабль убит");
                }
            }
        }
    }
}
