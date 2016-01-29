namespace art
{
    internal static class RectenglChek
    {
        public static bool RectenglCheked(XYkoord xy, Rectangle rectangle)
        {
            if (rectangle.X < xy.X & xy.X < rectangle.X + rectangle.width)
            {
                if (rectangle.Y < xy.Y & xy.Y < rectangle.Y + rectangle.heigh)
                {
                    return true;
                }
            }
            return false;
        }
    }
}