using myDNA.Robot.Services;
using System;

namespace myDNA.Robot
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = string.Empty;
            var myHorsePosition = new RobotPositionService();

            while (true)
            {
               input = Console.ReadLine();


                try
                {
                    string[] temp = input.Split();
                    switch (temp[0].ToUpper())
                    {
                        case "PLACE":
                            var temp2 = temp[1].Split(",");
                            if (temp2.Length == 3)
                            {

                                myHorsePosition.place(Int32.Parse(temp2[0]),
                                                       Int32.Parse(temp2[1]),
                                                       temp2[2]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid String");
                            }
                            break;
                        case "LEFT":
                            myHorsePosition.left();
                            break;
                        case "RIGHT":
                            myHorsePosition.right();
                            break;
                        case "MOVE":
                            myHorsePosition.move();
                            break;
                        case "REPORT":
                            myHorsePosition.report();
                            break;
                        default:
                            break;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }





        }
    }
}
