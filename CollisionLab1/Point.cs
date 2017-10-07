namespace CollisionLab1
{
    /// <summary>
    /// Point class stores a x and y coordinates of a point on a cartesian coordinate plane
    /// </summary>
    public class Point
    {
        public double x, y;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
}