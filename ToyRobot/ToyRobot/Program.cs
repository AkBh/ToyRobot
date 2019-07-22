using System;

namespace ToyRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Toy Robot Application. You can use follwing commands");
            Console.WriteLine("PLACE X,Y,F");
            Console.WriteLine("MOVE");
            Console.WriteLine("LEFT");
            Console.WriteLine("RIGHT");
            Console.WriteLine("REPORT");
            Console.WriteLine("EXIT");

            string input = string.Empty;
            string output = string.Empty;
            TableSize tableSize = new TableSize();
            Robot robot = new Robot(tableSize);

            while (true)
            {
                Console.Write("\nEnter the command: ");
                input = Console.ReadLine().ToUpper();

                if (input == "EXIT")
                    break;

                output = robot.Command(input);
                Console.WriteLine(output);
            }

        }
    }
}
