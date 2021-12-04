using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover_Hepsiburada
{
    public class Rover
    {
        public Position Position { get; set; }
        public Direction Direction { get; set; }
        public Rover()
        {
        }

        private void MoveInSameDirection()
        {
            switch (this.Direction)
            {
                case Direction.N:
                    this.Position.y += 1;
                    break;
                case Direction.S:
                    this.Position.y -= 1;
                    break;
                case Direction.E:
                    this.Position.x += 1;
                    break;
                case Direction.W:
                    this.Position.x -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TurnRight()
        {
            switch (this.Direction)
            {
                case Direction.N:
                    this.Direction = Direction.E;
                    break;
                case Direction.S:
                    this.Direction = Direction.W;
                    break;
                case Direction.E:
                    this.Direction = Direction.S;
                    break;
                case Direction.W:
                    this.Direction = Direction.N;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TurnLeft()
        {
            switch (this.Direction)
            {
                case Direction.N:
                    this.Direction = Direction.W;
                    break;
                case Direction.S:
                    this.Direction = Direction.E;
                    break;
                case Direction.E:
                    this.Direction = Direction.N;
                    break;
                case Direction.W:
                    this.Direction = Direction.S;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void ExecuteCommand(Plateau plateau, string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'M':
                        this.MoveInSameDirection();
                        break;
                    case 'L':
                        this.TurnLeft();
                        break;
                    case 'R':
                        this.TurnRight();
                        break;
                    default:
                        Console.WriteLine($"Invalid Character {command}");
                        break;
                }
                if (this.Position.x < plateau.minWidth || this.Position.x > plateau.width || this.Position.y < plateau.minHeight || this.Position.y > plateau.height)
                {
                    Console.WriteLine($"Can't move anymore ({plateau.minWidth} , {plateau.minHeight}) and ({plateau.width} , {plateau.height})");
                    break;
                }
            }
        }

        public void SetPosition(Position position, Direction direction)
        {
            this.Position = position;
            this.Direction = direction;
        }

        public void PrintPosition()
        {
            Console.WriteLine(this.Position.x + " " + this.Position.y + " " + this.Direction);
        }

        public bool CheckPosition(Plateau plateau, Position position)
        {
            return plateau.minHeight <= position.y && position.y <= plateau.height &&
                   plateau.minWidth <= position.x && position.x <= plateau.width;
        }

    }
}
