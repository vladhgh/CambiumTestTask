using System;

namespace LasmartTest.Shared
{
    public class Rover
    {
		public int Id { get; set; }

		public int PositionX { get; set; }

		public int PositionY { get; set; }

		public char CurrentDirection { get; set; }

        public char NextAction { get; set; }

        public string GetClassName()
        {
            return "roverDeployed-" + this.CurrentDirection + " rover-" + this.Id;
        }

        public void Move()
        {
            if (this.CurrentDirection == Direction.North)
            {
                this.PositionY++;
            } else if (this.CurrentDirection == Direction.West)
            {
                this.PositionX--;
            } else if (this.CurrentDirection == Direction.South)
            {
                this.PositionY--;
            } else if (this.CurrentDirection == Direction.East)
            {
                this.PositionX++;
            } else
            {
                throw new Exception("Current rover direction undefined!");
            }
        }

		public void Rotate(char rotateDirection)
        {
            if (this.CurrentDirection == Direction.North)
            {
                this.CurrentDirection = rotateDirection == Action.RotateLeft ? Direction.West : Direction.East;
            } else if (this.CurrentDirection == Direction.West)
            {
                this.CurrentDirection = rotateDirection == Action.RotateLeft ? Direction.South : Direction.North;
            } else if (this.CurrentDirection == Direction.South)
            {
                this.CurrentDirection = rotateDirection == Action.RotateLeft ? Direction.East : Direction.West;
            } else if (this.CurrentDirection == Direction.East)
            {
                this.CurrentDirection = rotateDirection == Action.RotateLeft ? Direction.North : Direction.South;
            } else
            {
                throw new Exception("Current rover direction undefined!");
            }
        }
	}
}
