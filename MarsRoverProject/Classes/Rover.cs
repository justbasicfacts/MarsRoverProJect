using MarsRoverProject.Enums;
using MarsRoverProject.Exceptions;
using System;

namespace MarsRoverProject.Classes
{
    public class Rover
    {
        public Rover()
        {
            CoordinateX = 0;
            CoordinateY = 0;
            CurrentDirection = DirectionEnum.North;
        }

        public Rover(string input, Plateau plateau)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                var stringInputs = input.Split(' ');

                if (stringInputs.Length < 3)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else
                {
                    var x = stringInputs[0];
                    var y = stringInputs[1];
                    var direction = stringInputs[2];
                    CoordinateX = Convert.ToInt32(x);
                    CoordinateY = Convert.ToInt32(y);
                    CurrentDirection = direction.GetEnumFromStringValue<DirectionEnum>();
                }

                if (plateau != null)
                {
                    this.plateau = plateau;
                }
            }
        }

        public int CoordinateX { get; set; }

        public int CoordinateY { get; set; }

        public DirectionEnum CurrentDirection { get; set; }

        private Plateau plateau { get; set; }

        public void MoveForward()
        {
            bool hasMaximumLandingZoneReached = false;
            switch (CurrentDirection)
            {
                case DirectionEnum.North:
                    if (plateau.Height >= CoordinateY + 1)
                    {
                        CoordinateY += 1;
                    }
                    else
                    {
                        hasMaximumLandingZoneReached = true;
                    }
                    break;

                case DirectionEnum.East:
                    if (plateau.Width >= CoordinateX + 1)
                    {
                        CoordinateX += 1;
                    }
                    else
                    {
                        hasMaximumLandingZoneReached = true;
                    }
                    break;

                case DirectionEnum.South:
                    if (CoordinateY - 1 > 0)
                    {
                        CoordinateY -= 1;
                    }
                    else
                    {
                        hasMaximumLandingZoneReached = true;
                    }
                    break;

                case DirectionEnum.West:
                    if (plateau.Width - 1 > 0)
                    {
                        CoordinateX -= 1;
                    }
                    else
                    {
                        hasMaximumLandingZoneReached = true;
                    }
                    break;

                default:
                    throw new ArgumentException();
            }

            if (hasMaximumLandingZoneReached)
            {
                throw new CannotExceedBordersException();
            }
        }

        public void ProcessCommands(string commands)
        {
            if (!string.IsNullOrWhiteSpace(commands))
            {
                var commandsArray = commands.ToCharArray();

                ExecuteCommands(commandsArray);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        private void ExecuteCommands(char[] commandsArray)
        {
            for (int i = 0; i < commandsArray.Length; i++)
            {
                if (!char.IsWhiteSpace(commandsArray[i]))
                {
                    CommandEnum command = commandsArray[i].GetEnumFromCharValue<CommandEnum>();

                    switch (command)
                    {
                        case CommandEnum.SpinLeft:
                            SpinLeft();
                            break;

                        case CommandEnum.SpinRight:
                            SpinRight();
                            break;

                        case CommandEnum.MoveForward:
                            MoveForward();
                            break;

                        default:
                            throw new ArgumentException();
                    }
                }
            }
        }

        public void SpinLeft()
        {
            switch (CurrentDirection)
            {
                case DirectionEnum.North:
                    CurrentDirection = DirectionEnum.West;
                    break;

                case DirectionEnum.East:
                    CurrentDirection = DirectionEnum.North;
                    break;

                case DirectionEnum.South:
                    CurrentDirection = DirectionEnum.East;
                    break;

                case DirectionEnum.West:
                    CurrentDirection = DirectionEnum.South;
                    break;

                default:
                    throw new ArgumentException();
            }
        }

        public void SpinRight()
        {
            switch (CurrentDirection)
            {
                case DirectionEnum.North:
                    CurrentDirection = DirectionEnum.East;
                    break;

                case DirectionEnum.East:
                    CurrentDirection = DirectionEnum.South;
                    break;

                case DirectionEnum.South:
                    CurrentDirection = DirectionEnum.West;
                    break;

                case DirectionEnum.West:
                    CurrentDirection = DirectionEnum.North;
                    break;

                default:
                    throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            return $"{CoordinateX} {CoordinateY} {CurrentDirection.ToText()}";
        }
    }
}