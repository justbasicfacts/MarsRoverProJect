using MarsRoverProject.Classes;
using System;


namespace MarsRoverProject
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pleatue does not implemented, because there wasn't any test case regarding the pleatue
            string pleatueSize = Console.ReadLine();
            string roverData1 = Console.ReadLine();
            string roverCommand1 = Console.ReadLine();
            string roverData2 = Console.ReadLine();
            string roverCommand2 = Console.ReadLine();
       

            var plateauArray = pleatueSize.Split(' ');
            int pleatueWidth = 0;
            int pleatueHeight = 0;
            if (plateauArray.Length == 2)
            {
                int.TryParse(plateauArray[0], out pleatueWidth);
                int.TryParse(plateauArray[1], out pleatueHeight);
            }

            Plateau plateau = new Plateau(pleatueWidth, pleatueHeight);

            Rover rover1 = new Rover(roverData1, plateau);
            Rover rover2 = new Rover(roverData2, plateau);

            rover1.ProcessCommands(roverCommand1);
            rover2.ProcessCommands(roverCommand2);

            Console.WriteLine(rover1.ToString());
            Console.WriteLine(rover2.ToString());

            Console.Read();
        }
    }
}
