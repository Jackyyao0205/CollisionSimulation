using System;
using System.Data;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

/*
namespace CollisionLab1
{
    /// <summary>
    /// Stores the components and the angle counter-clockwise from the positive x-axis of a vector
    /// Can be a position, velocity, acceleration vector, as long as it has both a magnitude and a directioin
    /// </summary>
    public class Vector
    {
        public double x, y, mag;
        public double angle;

        /// <summary>
        /// Constructs a vector given magnitude of x and y components and the angle of the vector counter-clockwise from
        /// the positive x-axis
        /// </summary>
        /// <param name="x">Magnitude of x component</param>
        /// <param name="y">Magnitude of y component</param>
        /// <param name="angle">Angdle</param>
        public Vector(double x, double y, double angle)
        {
            this.x = x;
            this.y = y;
            this.angle = angle;
            this.mag = Math.Sqrt(x * x + y * y); 
        }

        /// <summary>
        /// Constructs a vector given x and y components
        /// </summary>
        /// <param name="x">Magnitude of x component</param>
        /// <param name="y">Magnitude of y component</param>
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
            this.mag = Math.Sqrt(x * x + y * y);
            this.angle = Math.Atan(y / x);// angle = arctan(y/x)
           /* if (this.angle <0)
            {
                this.angle += 2 * Math.PI;
            }
        }
        
        /// <summary>
        /// Constructs a vector given the magnitude of either the x or y component or the magnitude of the vectir 
        /// AND the angle  of the vector counter clockwise from the positive x-axis
        /// </summary>
        /// <param name="mag">Magnitude of component (x or y or of the vector)</param>
        /// <param name="comp">'x' or 'y' character, indicates which component magnitude was given</param>
        /// <param name="angle">Anglel of vector</param>
        public Vector(double mag, char comp, double angle)
        {
            if (comp == 'x') //if given component is x, calculate magnitude of y
            {
                this.x = mag;
                this.angle = angle;
                this.y = x * Math.Tan(angle); //y = x * tan(angle)
                this.mag = Math.Sqrt(x * x + y * y);
            }
            else if (comp == 'y') //if given component is y, calculate magnitude of x
            {
                this.y = mag;
                this.angle = angle;
                this.x = y * Math.Tan(angle); //x = y * tan(angle)
                this.mag = Math.Sqrt(x * x + y * y);
            }
            else // if given magnitude of vector and angle, calculate magnitude of x and y
            {
                this.mag = mag;
                this.angle = angle;
                this.x = mag * Math.Cos(angle); 
                this.y = mag * Math.Sin(angle);
            }
            /*if (this.angle < 0)
            {
                this.angle += 2 * Math.PI;
            }
        }

        /// <summary>
        /// Constructs a vector going FROM POINT A TO POINT B
        /// the result will be different if the vector were computed to be going from point b to a
        /// please be careful with the order of what is passed through the parameters, first point must be the end of the
        /// tail of the vector and point b must be the head of the vector
        /// </summary>
        /// <param name="a">Point where the tail of the vector begins</param>
        /// <param name="b">Point where the head of the vector is</param>
        public Vector(Point a, Point b, double mag)
        {
            double abx, aby;

            this.mag = mag;
            abx = b.x - a.x;
            aby = b.y - a.y;
            this.angle = 0;
            if(aby != 0)
            {
                this.angle = Math.Atan(aby / abx);
            }
            else if(a.x > b.x)
            {
                this.angle = Math.PI;
            }
            this.x = mag * Math.Cos(angle);
            this.y = mag * Math.Sin(angle);
            /*if (this.angle < 0)
            {
                this.angle += 2 * Math.PI;
            }
        }
        */
namespace CollisionLab1
{
    /// <summary>
    /// Stores the components and the angle counter-clockwise from the positive x-axis of a vector
    /// Can be a position, velocity, acceleration vector, as long as it has both a magnitude and a directioin
    /// </summary>
    public class Vector
    {
        public double x, y, mag;
        public double angle;

        /// <summary>
        /// Constructs a vector given magnitude of x and y components and the angle of the vector counter-clockwise from
        /// the positive x-axis
        /// </summary>
        /// <param name="x">Magnitude of x component</param>
        /// <param name="y">Magnitude of y component</param>
        /// <param name="angle">Angdle</param>
        public Vector(double x, double y, double angle)
        {
            this.x = x;
            this.y = y;
            this.angle = angle;
            this.mag = Math.Sqrt(x * x + y * y);
        }

        /// <summary>
        /// Constructs a vector given x and y components
        /// </summary>
        /// <param name="x">Magnitude of x component</param>
        /// <param name="y">Magnitude of y component</param>
        public Vector(double x, double y)
        {
            this.x = x;
            this.y = y;
            this.mag = Math.Sqrt(x * x + y * y);
            this.angle = Math.Atan(y / x);// angle = arctan(y/x)
        }

        /// <summary>
        /// Constructs a vector given the magnitude of either the x or y component or the magnitude of the vectir 
        /// AND the angle  of the vector counter clockwise from the positive x-axis
        /// </summary>
        /// <param name="mag">Magnitude of component (x or y or of the vector)</param>
        /// <param name="comp">'x' or 'y' character, indicates which component magnitude was given</param>
        /// <param name="angle">Anglel of vector</param>
        public Vector(double mag, char comp, double angle)
        {
            if (comp == 'x') //if given component is x, calculate magnitude of y
            {
                this.x = mag;
                this.angle = angle;
                this.y = x * Math.Tan(angle); //y = x * tan(angle)
                this.mag = Math.Sqrt(x * x + y * y);
            }
            else if (comp == 'y') //if given component is y, calculate magnitude of x
            {
                this.y = mag;
                this.angle = angle;
                this.x = y * Math.Tan(angle); //x = y * tan(angle)
                this.mag = Math.Sqrt(x * x + y * y);
            }
            else // if given magnitude of vector and angle, calculate magnitude of x and y
            {
                this.mag = mag;
                this.angle = angle;
                this.x = mag * Math.Cos(angle);
                this.y = mag * Math.Sin(angle);
            }
        }

        /// <summary>
        /// Constructs a vector going FROM POINT A TO POINT B
        /// the result will be different if the vector were computed to be going from point b to a
        /// please be careful with the order of what is passed through the parameters, first point must be the end of the
        /// tail of the vector and point b must be the head of the vector
        /// </summary>
        /// <param name="a">Point where the tail of the vector begins</param>
        /// <param name="b">Point where the head of the vector is</param>
        public Vector(Point a, Point b, double mag)
        {
            double abx, aby, abmag;
            this.mag = mag;

            abx = b.x - a.x;
            aby = b.y - a.y;
            abmag = Math.Sqrt(abx * abx + aby * aby);
            this.angle = Math.Acos(abx/abmag);
            this.x = mag * Math.Cos(angle);
            this.y = mag * Math.Sin(angle);
        }

        /// <summary>
        /// Computed the cross product of two vectors
        /// </summary>
        /// <param name="a">First Vector</param>
        /// <param name="b">Second Vector</param>
        /// <returns>Scalar cross product</returns>
        public static double crossProduct(Vector a, Vector b)
        {
            double cp, theta;

            theta = 0;//if angle of a is equal to the angle of b, the angle between them is 0
            if (a.angle > b.angle)
            {
                theta = a.angle - b.angle;
            }
            else if (b.angle > a.angle)
            {
                theta = b.angle - a.angle;
            }

            cp = a.mag * b.mag * Math.Sin(theta); //cp = |a| * |b| * sin(theta)
            return cp;
        }

        /*
        /// <summary>
        /// Computed the cross product of two vectors
        /// </summary>
        /// <param name="a">First Vector</param>
        /// <param name="b">Second Vector</param>
        /// <returns>Scalar cross product</returns>
        public static double crossProduct(Vector a, Vector b)
        {
            double cp, theta;

            theta = 0;//if angle of a is equal to the angle of b, the angle between them is 0
            if (a.angle > b.angle)
            {
                theta = a.angle - b.angle;
            }
            else if (b.angle > a.angle)
            {
                theta = b.angle - a.angle;
            }

            cp = a.mag * b.mag * Math.Sin(theta); //cp = |a| * |b| * sin(theta)
            return cp;
        }
        */

    }
}
    