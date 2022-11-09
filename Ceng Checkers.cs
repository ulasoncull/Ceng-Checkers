using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Project_3
{
    struct Comp_move
    {
        public int gain;
        public int index_y;
        public int index_x;
        public string order; // array with length 2 {first move, second move}
        public bool biggest;
    }
    class Program
    {
        static void PrintTable(char[,] array, int round, string pattern)
        {
            Console.Write
                ("   12345678 " + $"    Round: {round}\n" +
                 "  +--------+" + $"    Turn: {pattern}\n");

            for (int i = 0; i < array.GetLength(0); i++)//y coordinate
            {
                Console.Write($"{i + 1} |");
                for (int j = 0; j < array.GetLength(1); j++)//x coordinate
                {
                    Console.Write(array[i, j]);
                }
                Console.Write("|\n");
            }
            Console.Write("  +--------+");
            Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop - 1);
        }

        static void Main(string[] args)
        {
            Comp_move[] element = new Comp_move[9];
            Random rnd = new Random();

            char temp_element;
            int turn = 1;
            int cursorx;
            int cursory;
            int checkz = 0;
            int round = 1;

            bool jumped = false;
            bool moved = false;
            bool bool_played = false;
            int int_played = 0;
            string move;

            int table = 0;
            int placex1 = -1;
            int placey1 = -1;
            int placex2 = 10;
            int placey2 = 9;
            int random;
            int index = 0;
            int comp_x;
            int comp_y;
            int ifs;
            int bound_row = 0;
            int bound_col = 0;

            int gain;
            int gain1 = 0;
            int gain2 = 0;
            int gain3 = 0;
            int gain4 = 0;

            string order;
            string order1; // array with length 2 {first move, second move}
            string order2; // array with length 2 {first move, second move}
            string order3; // array with length 2 {first move, second move}
            string order4; // array with length 2 {first move, second move}

            int o = 0; // comp moves
            ConsoleKeyInfo cki;               // required for readkey

            char[,] array = new char[8, 8]
            {
                {'o', 'o', 'o', '.', '.', '.', '.', '.', },
                {'o', 'o', 'o', '.', '.', '.', '.', '.', },
                {'o', 'o', 'o', '.', '.', '.', '.', '.', },
                {'.', '.', '.', '.', '.', '.', '.', '.', },
                {'.', '.', '.', '.', '.', '.', '.', '.', },
                {'.', '.', '.', '.', '.', 'x', 'x', 'x', },
                {'.', '.', '.', '.', '.', 'x', 'x', 'x', },
                {'.', '.', '.', '.', '.', 'x', 'x', 'x', },
            };

            PrintTable(array, round, "x");

            while (true)
            {//5,2

                if (turn % 2 == 1)
                {
                    cursorx = Console.CursorLeft;
                    cursory = Console.CursorTop;

                    //if (placex1 == Console.CursorLeft && placey1 == Console.CursorTop)
                    //  jumped = false;

                    if (Console.KeyAvailable) // true: there is a key in keyboard buffer
                    {
                        cki = Console.ReadKey(true); // true: do not write character 

                        if (cki.Key == ConsoleKey.RightArrow && cursorx < 10)//arrow movements
                        {   // key and boundary control

                            if (checkz == 0 && int_played == 0)
                            {
                                cursorx++;
                                Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                            }
                            else if (Console.CursorTop - table == placey1 && Console.CursorLeft == placex1 &&
                                int_played == 0 &&
                                array[Console.CursorTop - table - 2, cursorx - 3 + 1] == '.' &&
                                Math.Sqrt((cursorx - placex1) * (cursorx - placex1) + (cursory - table - placey1) * (cursory - table - placey1)) < 1)
                            {
                                cursorx++;
                                Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                                moved = true;
                            }
                            else if (Console.CursorTop - table == placey1 && Console.CursorLeft == placex1 &&
                                cursorx - 3 + 2 < array.GetLength(1) &&
                                int_played != 2 &&
                                array[Console.CursorTop - table - 2, cursorx - 3 + 1] != '.' &&
                                array[Console.CursorTop - table - 2, cursorx - 3 + 2] == '.')
                            {
                                cursorx += 2;
                                Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop);
                                jumped = true;
                            }

                            else if (jumped == true && Console.CursorLeft == placex1 - 2 && Console.CursorTop - table == placey1)
                            {
                                jumped = false;
                                Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop);
                                cursorx += 2;
                            }
                            else if (moved == true && Console.CursorLeft == placex1 - 1 && Console.CursorTop - table == placey1)
                            {
                                moved = false;
                                Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
                                cursorx++;
                            }

                        }
                        else if (cki.Key == ConsoleKey.LeftArrow && cursorx > 3)
                        {
                            if (checkz == 0 && int_played == 0)
                            {
                                cursorx--;
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                            }
                            else if (Console.CursorTop - table == placey1 && Console.CursorLeft == placex1 &&
                                array[Console.CursorTop - table - 2, cursorx - 3 - 1] == '.' &&
                                int_played == 0 &&
                                Math.Sqrt((cursorx - placex1) * (cursorx - placex1) + (cursory - table - placey1) * (cursory - table - placey1)) < 1)
                            {
                                cursorx--;
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                moved = true;
                            }
                            else if (Console.CursorTop - table == placey1 && Console.CursorLeft == placex1 &&
                                cursorx - 3 - 2 < array.GetLength(1) &&
                                int_played != 2 &&
                                array[Console.CursorTop - table - 2, cursorx - 3 - 1] != '.' &&
                                array[Console.CursorTop - table - 2, cursorx - 3 - 2] == '.')
                            {
                                cursorx -= 2;
                                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                                jumped = true;
                            }
                            else if (jumped == true && Console.CursorLeft == placex1 + 2 && Console.CursorTop - table == placey1)
                            {
                                jumped = false;
                                Console.SetCursorPosition(Console.CursorLeft - 2, Console.CursorTop);
                                cursorx -= 2;
                            }
                            else if (moved == true && Console.CursorLeft == placex1 + 1 && Console.CursorTop - table == placey1)
                            {
                                moved = false;
                                Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                                cursorx--;
                            }
                        }
                        else if (cki.Key == ConsoleKey.UpArrow && cursory - table > 2)
                        {
                            if (checkz == 0 && int_played == 0)
                            {
                                cursory--;
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                            }
                            else if (Console.CursorTop - table == placey1 && Console.CursorLeft == placex1 &&
                                array[Console.CursorTop - table - 2 - 1, cursorx - 3] == '.' &&
                                int_played == 0 &&
                                Math.Sqrt((cursorx - placex1) * (cursorx - placex1) + (cursory - table - placey1) * (cursory - table - placey1)) < 1)
                            {
                                cursory--;
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                                moved = true;
                            }
                            else if (Console.CursorTop - table == placey1 && Console.CursorLeft == placex1 &&
                                Console.CursorTop - table - 2 - 2 >= 0 &&
                                int_played != 2 &&
                                array[Console.CursorTop - table - 2 - 1, cursorx - 3] != '.' &&
                                array[Console.CursorTop - table - 2 - 2, cursorx - 3] == '.')
                            {
                                cursory -= 2;
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 2);
                                jumped = true;
                            }
                            else if (jumped == true && Console.CursorLeft == placex1 && Console.CursorTop - table == placey1 + 2)
                            {
                                jumped = false;
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 2);
                                cursory -= 2;
                            }
                            else if (moved == true && Console.CursorLeft == placex1 && Console.CursorTop - table == placey1 + 1)
                            {
                                moved = false;
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                                cursory--;
                            }
                        }
                        else if (cki.Key == ConsoleKey.DownArrow && Console.CursorTop - table < 9)
                        {
                            if (checkz == 0 && int_played == 0)
                            {
                                cursory++;
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                            }
                            else if (Console.CursorTop - table == placey1 && Console.CursorLeft == placex1 &&
                                array[Console.CursorTop - table - 2 + 1, cursorx - 3] == '.' &&
                                int_played == 0 &&
                                Math.Sqrt((cursorx - placex1) * (cursorx - placex1) + (cursory - table - placey1) * (cursory - table - placey1)) < 1)
                            {
                                cursory++;
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                                moved = true;
                            }
                            else if (Console.CursorTop - table == placey1 && Console.CursorLeft == placex1 &&
                                Console.CursorTop - table - 2 + 2 < array.GetLength(0) &&
                                int_played != 2 &&
                                array[Console.CursorTop - table - 2 + 1, cursorx - 3] != '.' &&
                                array[Console.CursorTop - table - 2 + 2, cursorx - 3] == '.')
                            {
                                cursory += 2;
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 2);
                                jumped = true;
                            }
                            else if (jumped == true && Console.CursorLeft == placex1 && Console.CursorTop - table == placey1 - 2)
                            {
                                jumped = false;
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 2);
                                cursory += 2;
                            }
                            else if (moved == true && Console.CursorLeft == placex1 && Console.CursorTop - table == placey1 - 1)
                            {
                                moved = false;
                                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 1);
                                cursory++;
                            }
                        }
                        if (cki.Key == ConsoleKey.Escape)
                            break;

                        if (cki.Key == ConsoleKey.Z && array[Console.CursorTop - table - 2, Console.CursorLeft - 3] == 'x' &&
                            int_played < 2)//To chose the piece which we want to move
                        {
                            placex1 = Console.CursorLeft;
                            placey1 = Console.CursorTop - table;

                            if (checkz == 0)
                                checkz = 1;
                            else
                                checkz = 0;
                        }
                        if (checkz == 1 && !(cursorx == placex1 && cursory - table == placey1) && cki.Key == ConsoleKey.X)//For choosing the square on which player wants to go
                        {
                            if (jumped)
                            {
                                int_played += 1;
                            }

                            if (moved)
                            {
                                int_played += 2;
                            }

                            checkz = 0;
                            jumped = false;
                            moved = false;
                            bool_played = true;

                            placex2 = Console.CursorLeft;
                            placey2 = Console.CursorTop - table;

                            temp_element = array[placey2 - 2, placex2 - 3];
                            array[placey2 - 2, placex2 - 3] = array[placey1 - 2, placex1 - 3];
                            array[placey1 - 2, placex1 - 3] = temp_element;

                            table += 0;
                            Console.SetCursorPosition(0, table);
                            PrintTable(array, round, "x");
                            Console.SetCursorPosition(placex2, placey2 + table);
                        }

                        if (bool_played == true && cki.Key == ConsoleKey.C)
                        {
                            bool_played = false;
                            int_played = 0;

                            table += 0;
                            Console.SetCursorPosition(0, table);
                            PrintTable(array, round, "o");
                            Console.SetCursorPosition(placex2, placey2 + table);

                            System.Threading.Thread.Sleep(1000);

                            table += 0;
                            Console.SetCursorPosition(0, table);
                            PrintTable(array, round, "x");
                            Console.SetCursorPosition(placex2, placey2 + table);
                            turn += 1;
                        }

                    }

                }
                else
                {
                    o = 0;

                    bool if_check = true;
                    bool jump_check = true;
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        if (o == 9) // program saw all the o's.
                            break;

                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            if (array[i, j] != 'o')
                                continue;

                            if_check = true;
                            jump_check = true;

                            if (j + 2 >= array.GetLength(1) - 2 && bound_col >= 6)
                            {
                                gain1 += 0;
                                order1 = "x";
                            }
                            else if (j + 2 < array.GetLength(1) && (array[i, j + 1] != '.' && array[i, j + 2] == '.'))// able to right jump
                            {
                                if_check = false;
                                jump_check = false;

                                gain1 += 2;
                                if (j + 4 < array.GetLength(1) && (array[i, j + 2 + 1] != '.' && array[i, j + 2 + 2] == '.') && j + 2 < array.GetLength(1) &&
                                    i + 2 < array.GetLength(0) && (array[i + 1, j + 2] != '.' && array[i + 2, j + 2] == '.'))
                                {
                                    ifs = rnd.Next(1, 3);
                                    if (ifs == 1)
                                    {
                                        gain1 += 2;
                                        order1 = "rj_rj";
                                    }// right jump after right jump
                                    else
                                    {
                                        gain1 += 2;
                                        order1 = "rj_dj";
                                    }// down jump after right jump
                                }
                                else if (j + 4 < array.GetLength(1) && (array[i, j + 2 + 1] != '.' && array[i, j + 2 + 2] == '.')) // right jump after right jump
                                {
                                    gain1 += 2;
                                    order1 = "rj_rj";
                                }// right jump after right jump
                                else if (j + 2 < array.GetLength(1) && i + 2 < array.GetLength(0) && (array[i + 1, j + 2] != '.' && array[i + 2, j + 2] == '.')) // down jump after right jump
                                {
                                    gain1 += 2;
                                    order1 = "rj_dj";
                                }// down jump after right jump
                                else
                                {
                                    gain1 += 0;
                                    order1 = "rj";
                                }// right jump only
                            }// able to right jump
                            else
                            {
                                gain1 += 0;
                                order1 = "x";
                            }

                            if (i + 2 >= array.GetLength(0) - 2 && bound_row >= 6)
                            {
                                gain2 += 0;
                                order2 = "x";
                            }
                            else if (i + 2 < array.GetLength(0) && (array[i + 1, j] != '.' && array[i + 2, j] == '.')) // able to down jump
                            {
                                if_check = false;
                                jump_check = false;
                                gain2 += 2;
                                if (j + 2 < array.GetLength(1) && i + 2 < array.GetLength(0) && (array[i + 2, j + 1] != '.' && array[i + 2, j + 2] == '.') &&
                                    j < array.GetLength(1) && i + 4 < array.GetLength(0) && (array[i + 2 + 1, j] != '.' && array[i + 2 + 2, j] == '.'))
                                {
                                    ifs = rnd.Next(1, 3);
                                    if (ifs == 1)
                                    {
                                        gain2 += 2;
                                        order2 = "dj_rj";
                                    }
                                    else
                                    {
                                        gain2 += 2;
                                        order2 = "dj_dj";
                                    }
                                }
                                else if (j + 2 < array.GetLength(1) && i + 2 < array.GetLength(0) && (array[i + 2, j + 1] != '.' && array[i + 2, j + 2] == '.')) // right jump after down jump
                                {
                                    gain2 += 2;
                                    order2 = "dj_rj";
                                }// dj_rj
                                else if (j < array.GetLength(1) && i + 4 < array.GetLength(0) && (array[i + 2 + 1, j] != '.' && array[i + 2 + 2, j] == '.')) // down jump after down jump
                                {
                                    gain2 += 2;
                                    order2 = "dj_dj";
                                }//dj_dj
                                else
                                {
                                    gain2 += 0;
                                    order2 = "dj";
                                }//dj
                            }// able to down jump
                            else
                            {
                                gain2 += 0;
                                order2 = "x";
                            }

                            if (gain1 > gain2)
                            {
                                gain = gain1;
                                order = order1;
                            } // to randomize computer moves
                            else if (gain1 < gain2)
                            {
                                gain = gain2;
                                order = order2;
                            }
                            else
                            {
                                ifs = rnd.Next(1, 3);

                                if (ifs == 1)
                                {
                                    gain = gain1;
                                    order = order1;
                                }

                                else
                                {
                                    gain = gain2;
                                    order = order2;
                                }
                            }

                            if (i + 1 >= array.GetLength(0) - 2 && bound_row >= 6)
                            {
                                gain3 += 0;
                                order3 = "x";
                            }
                            else if (jump_check && i + 1 < array.GetLength(0) && array[i + 1, j] == '.')// able to down step
                            {
                                if_check = false;
                                gain3 += 1;
                                order3 = "ds";

                            }// able to down step
                            else
                            {
                                gain3 += 0;
                                order3 = "x";
                            }

                            if (gain > gain3)
                            {
                                ;
                            }// to randomize computer moves
                            else if (gain < gain3)
                            {
                                gain = gain3;
                                order = order3;
                            }
                            else
                            {
                                ifs = rnd.Next(1, 3);

                                if (ifs == 1)
                                {
                                    ;
                                }

                                else
                                {
                                    gain = gain3;
                                    order = order3;
                                }
                            }

                            if (j + 1 >= array.GetLength(1) - 2 && bound_col >= 6)
                            {
                                gain4 += 0;
                                order4 = "x";
                            }
                            else if (jump_check && j + 1 < array.GetLength(1) && array[i, j + 1] == '.')// able to right step
                            {
                                if_check = false;
                                gain4 += 1;
                                order4 = "rs";

                            }// able to right step
                            else
                            {
                                gain4 += 0;
                                order4 = "x";
                            }


                            if (gain > gain4)
                            {
                                ;
                            }// to randomize computer moves
                            else if (gain < gain4)
                            {
                                gain = gain4;
                                order = order4;
                            }
                            else
                            {
                                ifs = rnd.Next(1, 3);

                                if (ifs == 1)
                                {
                                    ;
                                }

                                else
                                {
                                    gain = gain4;
                                    order = order4;
                                }
                            }

                            if (if_check) // if the program never dived in the other if s
                            {
                                gain = 0;
                                order = "x";
                            }

                            element[o].gain = gain;
                            element[o].order = order;
                            element[o].index_y = i;
                            element[o].index_x = j;

                            gain1 = 0;
                            gain2 = 0;
                            gain3 = 0;
                            gain4 = 0;

                            o += 1;
                        }// able to down step
                    } // gain calculation for each "o"

                    bool flag_big = true;
                    for (int i = 0; i < element.Length; i++)
                    {
                        flag_big = true;

                        if (element[i].gain == 4)
                        {
                            element[i].biggest = true;
                            continue;
                        }
                        for (int j = 0; j < element.Length; j++)
                        {
                            if (element[i].gain < element[j].gain)
                            {
                                flag_big = false;
                                break;
                            }

                        }
                        if (!flag_big)
                            element[i].biggest = false;
                        else
                            element[i].biggest = true;
                    }// to determine best elements to move

                    bool check_big;
                    do
                    {
                        random = rnd.Next(0, 9);

                        if (element[random].biggest == true)
                        {
                            index = random;
                            check_big = false;
                        }
                        else
                            check_big = true;
                    } // to prevent monotonous computer moves
                    while (check_big);

                    comp_y = element[index].index_y;
                    comp_x = element[index].index_x;

                    move = element[index].order;

                    if (move == "dj_dj")
                    {
                        temp_element = array[comp_y + 4, comp_x];
                        array[comp_y + 4, comp_x] = array[comp_y, comp_x];
                        array[comp_y, comp_x] = temp_element;

                        if (comp_y + 4 >= 6)
                        {
                            bound_row++;
                        }
                    }
                    else if (move == "dj_rj" || move == "rj_dj")
                    {
                        temp_element = array[comp_y + 2, comp_x + 2];
                        array[comp_y + 2, comp_x + 2] = array[comp_y, comp_x];
                        array[comp_y, comp_x] = temp_element;

                        if (comp_y + 2 >= 6)
                        {
                            bound_row++;
                        }
                        if (comp_x + 2 >= 6)
                        {
                            bound_col++;
                        }
                    }
                    else if (move == "dj")
                    {
                        temp_element = array[comp_y + 2, comp_x];
                        array[comp_y + 2, comp_x] = array[comp_y, comp_x];
                        array[comp_y, comp_x] = temp_element;
                        if (comp_y + 2 >= 6)
                        {
                            bound_row++;
                        }
                    }
                    else if (move == "rj_rj")
                    {
                        temp_element = array[comp_y, comp_x + 4];
                        array[comp_y, comp_x + 4] = array[comp_y, comp_x];
                        array[comp_y, comp_x] = temp_element;
                        if (comp_x + 4 >= 6)
                        {
                            bound_col++;
                        }
                    }
                    else if (move == "rj")
                    {
                        temp_element = array[comp_y, comp_x + 2];
                        array[comp_y, comp_x + 2] = array[comp_y, comp_x];
                        array[comp_y, comp_x] = temp_element;
                        if (comp_x + 2 >= 6)
                        {
                            bound_col++;
                        }
                    }
                    else if (move == "ds")
                    {
                        temp_element = array[comp_y + 1, comp_x];
                        array[comp_y + 1, comp_x] = array[comp_y, comp_x];
                        array[comp_y, comp_x] = temp_element;
                        if (comp_y + 1 >= 6)
                        {
                            bound_row++;
                        }
                    }
                    else if (move == "rs")
                    {
                        temp_element = array[comp_y, comp_x + 1];
                        array[comp_y, comp_x + 1] = array[comp_y, comp_x];
                        array[comp_y, comp_x] = temp_element;

                        if (comp_x + 1 >= 6)
                        {
                            bound_col++;
                        }
                    }

                    round += 1;
                    table += 0;
                    Console.SetCursorPosition(0, table);
                    PrintTable(array, round, "x");
                    Console.SetCursorPosition(placex2, placey2 + table);

                    turn += 1;
                }

            }



        }
    }
}