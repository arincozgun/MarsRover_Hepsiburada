using System;
using System.Collections.Generic;

namespace MarsRover_Hepsiburada
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int numberOfRovers = 2;
                string[] positions;
                Position position;
                Direction direction;
                Plateau plateau = new Plateau();
                List<Rover> roverList = new List<Rover>();
                Console.Write("Plateau Boundries {x y}:");
                plateau.DefinePlateauSize(Console.ReadLine().Trim().Split(' '));
                for (int i = 0; i < numberOfRovers; i++)
                {
                    roverList.Add(new Rover());

                    Console.Write($"Start position of Rover#{i + 1}:");
                    positions = Console.ReadLine().Trim().Split(' ');
                    position = new Position(int.Parse(positions[0]), int.Parse(positions[1]));
                    direction = Enum.Parse<Direction>(positions[2].ToUpper());

                    roverList[i].SetPosition(position, direction);
                    if (!roverList[i].CheckPosition(plateau, roverList[i].Position))
                    {
                        Console.WriteLine("Outside Landing Bounderies!!!");
                    }
                    else
                    {
                        Console.Write($"Commands of Rover{i + 1}:");
                        roverList[i].ExecuteCommand(plateau, Console.ReadLine().Trim().ToUpper());
                    }

                }
                for (int i = 0; i < roverList.Count; i++)
                {
                    roverList[i].PrintPosition();
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed --> " + ex.Message);
            }
            
        }
    }
}
