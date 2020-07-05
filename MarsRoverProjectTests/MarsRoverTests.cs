using System;
using MarsRoverProject.Exceptions;
using MarsRoverProject.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverProjectTests
{
    [TestClass]
    public class MarsRoverTests
    {
        [TestMethod]
        public void CanSpinLeft()
        {
            Rover rover = new Rover("1 5 W", GetPlateau());
            rover.SpinLeft();

            Assert.IsTrue(rover.CurrentDirection == MarsRoverProject.Enums.DirectionEnum.South);
        }

        [TestMethod]
        public void CanSpinRight()
        {
            Rover rover = new Rover("1 5 W", GetPlateau());
            rover.SpinRight();

            Assert.IsTrue(rover.CurrentDirection == MarsRoverProject.Enums.DirectionEnum.North);
        }

        [TestMethod]
        public void CanMove()
        {
            Rover rover = new Rover("1 5 W", GetPlateau());
            rover.MoveForward();

            Assert.IsTrue(rover.CoordinateX == 0);
        }

        [TestMethod]
        public void CanProcessCommandsCorrectly()
        {
            Rover rover = new Rover("1 2 N", GetPlateau());
            rover.ProcessCommands("LMLMLMLMM");

            Assert.IsTrue(rover.CoordinateX == 1);
            Assert.IsTrue(rover.CoordinateY == 3);
            Assert.IsTrue(rover.CurrentDirection == MarsRoverProject.Enums.DirectionEnum.North);

            Rover rover2 = new Rover("3 3 E", GetPlateau());
            rover2.ProcessCommands("MMRMMRMRRM");

            Assert.IsTrue(rover2.CoordinateX == 5);
            Assert.IsTrue(rover2.CoordinateY == 1);
            Assert.IsTrue(rover2.CurrentDirection == MarsRoverProject.Enums.DirectionEnum.East);
            Assert.AreEqual(rover.ToString(), "1 3 N");
            Assert.AreEqual(rover2.ToString(), "5 1 E");

        }

        [TestMethod]
        public void CannotExceedBordersOfLandingZone()
        {
            CannotExceedBordersException exception = null;
            try
            {
                Rover rover = new Rover("1 2 N", GetPlateau());
                rover.ProcessCommands("LMLMLMLMMMMM");
            }
            catch(CannotExceedBordersException ex)
            {
                exception = ex;
            }

            Assert.IsTrue(exception != null);
        }

        public Plateau GetPlateau()
        {
            return new Plateau(5, 5);
        }
    }
}
