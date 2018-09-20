using System;
using System.Windows;


namespace Metroid
{
    public class Constants
    {
        public const int TILE_WIDTH = 32;
        public const int TILE_HEIGHT = 32;

        public const int SAMUS_STANDING_HEIGHT = 43;
        public const int SAMUS_STANDING_WIDTH = 35;

        public const double Rad2Deg = 180.0 / Math.PI;


        public const int LEFT_RUN_STATES = 10;

        public static int State = 0;



        public static int SamusPositionX { get; set; } = 0;
        public static int SamusPositionY { get; set; } = 0;
        public static int SamusSpeedX { get; set; } = 0;
        public static int SamusSpeedY { get; set; } = 0;

        public static FacingDirection SamusFacing { get; set; } = FacingDirection.LEFT;



        public enum FacingDirection{LEFT, RIGHT};



        public static int MoveSpeed { get; set; } = 10;


        public static double AngleBetweenTwoPoints(Point p1, Point p2)
        {
            double radian = Math.Atan2(p1.Y - p2.Y, p1.X - p2.X);
            double angle = radian * Constants.Rad2Deg;
            if (angle < 0.0)
                angle += 360.0;
            angle = 360 - angle;
            return angle;
        }

    }
}
