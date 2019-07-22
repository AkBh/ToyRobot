using System;
using System.Collections.Generic;
using System.Text;

namespace ToyRobot
{
    /// <summary>
    /// Robot claas - Handles the commands and move of the robot.
    /// </summary>
    public class Robot
    {
        #region fields

        public const string ExceptionMessage = "Error, somthing went wrong";
        public const string InvalidCommand = "This is the invalid command, Please enter valid command";
        public const string OutOfBoundary = "Inavlid place or move - range is out of boundary";
        public const string SuccessfulPlaceOrMove = "Robot has been placed or Moved";
        public const string RobotNotPlaced = "Robot has not been place yet, please use place command first";
        public const string InvalidDirection = "Robot direction is invalid";
        private TableSize tableSize;

        #endregion

        #region properties

        public int XRobotPosition { get; set; }

        public int YRobotPosition { get; set; }

        public string RobotDirection { get; set; }

        public bool IsRobotPlaced { get; set; }

        #endregion

        #region constructors
        public Robot(TableSize tableSize)
        {
            this.tableSize = tableSize;
            XRobotPosition = -1;
            YRobotPosition = -1;
        }
        #endregion

        #region Public Methods

        public string Command(string input)
        {
            string result = string.Empty;

            try
            {
                if (input.Contains("PLACE"))
                    result = PlaceRobot(input);

                else if (!IsRobotPlaced)
                    result = RobotNotPlaced;

                else if (input.Contains("MOVE"))
                    result = Move();

                else if (input.Contains("LEFT"))
                    Left();

                else if (input.Contains("RIGHT"))
                    Right();

                else if (input.Contains("REPORT"))
                    result = Report();

                else
                    result = InvalidCommand;
            }
            catch
            {
                result = ExceptionMessage;
            }

            return result;
        }

        #endregion

        #region Private Methods

        private bool IsValidPlaceOrMove()
        {
            if (XRobotPosition < tableSize.XLowerBoundary || XRobotPosition > tableSize.XUpperBoundary ||
                YRobotPosition < tableSize.YLowerBoundary || YRobotPosition > tableSize.YUppperBoundary)
                return false;

            return true;
        }

        private bool IsValidDirection()
        {
            if (RobotDirection.Contains("NORTH") || RobotDirection.Contains("SOUTH") ||
                RobotDirection.Contains("EAST") || RobotDirection.Contains("WEST"))
                return true;

            return false;
        }

        private string PlaceRobot(string input)
        {
            string result = string.Empty;

            string[] commands = input.Split(' ', ',');

            XRobotPosition = Int32.Parse(commands[1]);
            YRobotPosition = Int32.Parse(commands[2]);
            RobotDirection = commands[3];

            if (IsValidDirection())
            {
                if (IsValidPlaceOrMove())
                {
                    IsRobotPlaced = true;
                    result = SuccessfulPlaceOrMove;
                }
                else
                {
                    IsRobotPlaced = false;
                    result = OutOfBoundary;
                }
            }
            else
            {
                result = InvalidDirection;
            }

            return result;
        }

        private string Move()
        {
            string result = string.Empty;
            int xPosition = XRobotPosition;
            int yPosition = YRobotPosition;

            switch (RobotDirection)
            {
                case "NORTH":
                    YRobotPosition++;
                    break;
                case "SOUTH":
                    YRobotPosition--;
                    break;
                case "EAST":
                    XRobotPosition++;
                    break;
                case "WEST":
                    XRobotPosition--;
                    break;
            }

            if(IsValidPlaceOrMove())
            {
                result = SuccessfulPlaceOrMove;
            }
            else
            {
                XRobotPosition = xPosition;
                YRobotPosition = yPosition;
                result = OutOfBoundary;
            }

            return result;
        }

        private void Left()
        {
            switch (RobotDirection)
            {
                case "NORTH":
                    RobotDirection = "WEST";
                    break;
                case "SOUTH":
                    RobotDirection = "EAST";
                    break;
                case "EAST":
                    RobotDirection = "NORTH";
                    break;
                case "WEST":
                    RobotDirection = "SOUTH";
                    break;
            }
        }

        private void Right()
        {
            switch (RobotDirection)
            {
                case "NORTH":
                    RobotDirection = "EAST";
                    break;
                case "SOUTH":
                    RobotDirection = "WEST";
                    break;
                case "EAST":
                    RobotDirection = "SOUTH";
                    break;
                case "WEST":
                    RobotDirection = "NORTH";
                    break;
            }
        }

        private string Report()
        {
            return XRobotPosition + "," + YRobotPosition + "," + RobotDirection;
        }

       #endregion
        
    }

    /// <summary>
    /// Defines the size of the toy robot application.
    /// </summary>
    public class TableSize
    {
        #region properties
        public int XLowerBoundary { get; set; }
        public int XUpperBoundary { get; set; }
        public int YLowerBoundary { get; set; }
        public int YUppperBoundary { get; set; }

        #endregion

        #region constructors
        public TableSize(int xLowerBoundary = 0, int xUpperBoundary = 5, int yLowerBoundary = 0, int yUpperBoundary = 5)
        {
            XLowerBoundary = xLowerBoundary;
            XUpperBoundary = xUpperBoundary;
            YLowerBoundary = yLowerBoundary;
            YUppperBoundary = yUpperBoundary;
        }
        #endregion

    }
}
