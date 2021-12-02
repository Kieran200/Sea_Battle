using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sea_Battle
{
    class Computer
    {
        public void InsallShip(string[,] invisiblefield, Computer comp)
        {
            int count = 0;
            Random rnd = new Random();
        M: int x = rnd.Next(3, 13);
            int y = rnd.Next(3, 13);
            invisiblefield[x, y] = "1";
            for (int j = 0; j < invisiblefield.GetLength(1); j++)        //4х палубный
            {
                for (int i = 0; i < invisiblefield.GetLength(0); i++)
                {
                    int direction = rnd.Next(0, 2);
                    if (invisiblefield[i, j] == "1" && direction == 0)
                    {
                        if (x + 3 <= 10 && x - 3 >= 1)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                x++;
                                invisiblefield[x, y] = "1";
                            }
                            count++;
                            break;
                        }
                        else
                        {
                            invisiblefield[x, y] = ".";
                            goto M;
                        }
                    }
                    if (invisiblefield[i, j] == "1" && direction == 1)
                    {
                        if (y + 3 <= 10 && y - 3 >= 1)
                        {
                            for (int k = 0; k < 3; k++)
                            {
                                y++;
                                invisiblefield[x, y] = "1";
                            }
                            count++;
                            break;
                        }
                        else
                        {
                            invisiblefield[x, y] = ".";
                            goto M;
                        }
                    }
                }
                if (count > 0)
                    break;
            }

            for (int i = 0; i < 2; i++)        //2 3хпалубных
            {
                int stop = 0;            
                int stop1;
                int direction1 = rnd.Next(0, 2);
            A: int x1 = rnd.Next(3, 13);
                int y1 = rnd.Next(3, 13);

                comp.Neighbor(invisiblefield, x1, y1, out stop1, 13, 13);     //проверка соседей для 3хпалубного
                stop += stop1;


                comp.Neighbor(invisiblefield, x1 + 1, y1, out stop1, 13, 13);
                stop += stop1;
                comp.Neighbor(invisiblefield, x1 + 2, y1, out stop1, 13, 13);
                stop += stop1;


                comp.Neighbor(invisiblefield, x1, y1 + 1, out stop1, 13, 13);
                stop += stop1;
                comp.Neighbor(invisiblefield, x1, y1 + 2 , out stop1, 13, 13);
                stop += stop1;

                if (stop > 0 | invisiblefield[x1, y1] == "1" )
                {
                    stop = 0;
                    goto A;
                }
                if (invisiblefield[x1, y1] == "." && stop == 0 && direction1 == 0)
                {
                    if (x1 + 2 > 12)
                    {
                        goto A;
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        invisiblefield[x1, y1] = "1";
                        x1++;
                    }
                        
                }
                if (invisiblefield[x1, y1] == "." && stop == 0 && direction1 == 1)
                {
                    if (y1 + 2 > 12)
                    {
                        goto A;
                    }
                    for (int j = 0; j < 3; j++)
                    {
                        invisiblefield[x1, y1] = "1";
                        y1++;
                    }
                }
            }


            for (int i = 0; i < 3; i++)        //3 2хпалубных
            {
                int stop = 0;
                int stop1;
                int direction1 = rnd.Next(0, 2);
            A: int x1 = rnd.Next(3, 13);
                int y1 = rnd.Next(3, 13);

                comp.Neighbor(invisiblefield, x1, y1, out stop1, 13, 13);     //проверка соседей для 2хпалубного
                stop += stop1;


                comp.Neighbor(invisiblefield, x1 + 1, y1, out stop1, 13, 13);
                stop += stop1;
                


                comp.Neighbor(invisiblefield, x1, y1 + 1, out stop1, 13, 13);
                stop += stop1;
                

                if (stop > 0 | invisiblefield[x1, y1] == "1")
                {
                    stop = 0;
                    goto A;
                }
                if (invisiblefield[x1, y1] == "." && stop == 0 && direction1 == 0)
                {
                    if (x1 + 1 > 12)
                    {
                        goto A;
                    }
                    for (int j = 0; j < 2; j++)
                    {
                        invisiblefield[x1, y1] = "1";
                        x1++;
                    }

                }
                if (invisiblefield[x1, y1] == "." && stop == 0 && direction1 == 1)
                {
                    if (y1 + 1 > 12)
                    {
                        goto A;
                    }
                    for (int j = 0; j < 2; j++)
                    {
                        invisiblefield[x1, y1] = "1";
                        y1++;
                    }
                }
            }


            for (int i = 0; i < 4; i++)        //4 1палубных
            {
                int stop = 0;
                int stop1;
                int direction1 = rnd.Next(0, 2);
            A: int x1 = rnd.Next(3, 13);
                int y1 = rnd.Next(3, 13);

                comp.Neighbor(invisiblefield, x1, y1, out stop1, 13, 13);     //проверка соседей для 1палубного
                stop += stop1;


                if (stop > 0 | invisiblefield[x1, y1] == "1")
                {
                    stop = 0;
                    goto A;
                }
                if (invisiblefield[x1, y1] == "." && stop == 0 && direction1 == 0)
                {
                    
                    invisiblefield[x1, y1] = "1";
                    x1++;
                    
                }
                if (invisiblefield[x1, y1] == "." && stop == 0 && direction1 == 1)
                {
                 
                    invisiblefield[x1, y1] = "1";
                    y1++;
                    
                }
            }
        }

        public void Neighbor(string[,] invisiblefield, int x, int y, out int stop, int N, int M)
        {
            stop = 0;
            for (int j = 0; j < 1; j++)
            {
                stop = 0;
                if (invisiblefield[x, y + 1] == "1" && y + 1 < M)
                {
                    stop++;
                    break;
                }
                if (invisiblefield[x, y - 1] == "1" && y - 1 > 2)
                {
                    stop++;
                    break;
                }
                if (invisiblefield[x + 1, y] == "1" && x + 1 < N)
                {
                    stop++;
                    break;
                }
                if (invisiblefield[x - 1, y] == "1" && x - 1 > 2)
                {
                    stop++;
                    break;
                }
                if (invisiblefield[x + 1, y + 1] == "1" && y + 1 < M && x + 1 < N)
                {
                    stop++;
                    break;
                }
                if (invisiblefield[x + 1, y - 1] == "1" && y - 1 > 2 && x + 1 < N)
                {
                    stop++;
                    break;
                }
                if (invisiblefield[x - 1, y + 1] == "1" && y + 1 < M && x - 1 > 2)
                {
                    stop++;
                    break;
                }
                if (invisiblefield[x - 1, y - 1] == "1" && y - 1 > 2 && x - 1 > 2)
                {
                    stop++;
                    break;
                }
            }
        }
    }
}