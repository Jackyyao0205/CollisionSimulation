using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CollisionLab1
{
    class Collision

    {

        static void Main(string[] args)
        {
            
            //creates 2 ball objects
            Ball b1 = new Ball(-100, 0,  4.0,0, 4, -1165.66, 5,0,0,false);
            Ball b2 = new Ball(100,0,0, 0, 4, -1165.66, 6, 0,0,false);
            
            List<double> time = new List<double>();//creates a list for each time interval
            time.Add(0);//adds the time at 0
            List<double> Velocity1x = new List<double>();//creates a list for each velocity of ball 1
            Velocity1x.Add(b1.v.x);//adds the velocity of ball 1 at time 0
            List<double> Velocity1y = new List<double>();//creates a list for each velocity of ball 1
            Velocity1y.Add(b1.v.y);//adds the velocity of ball 1 at time 0
            List<double> Position1x = new List<double>();//creates a list for each of the positions of centre of ball 1
            Position1x.Add(b1.pos.x);//adds the position at time 0
            List<double> Position1y = new List<double>();//creates a list for each of the positions of centre of ball 1
            Position1y.Add(b1.pos.y);//adds the position at time 0
            List<double> Velocity2x = new List<double>();//creates a list for each velocity of ball 2
            Velocity2x.Add(b2.v.x);//adds the velocity of ball 2 at time 0
            List<double> Velocity2y = new List<double>();//creates a list for each velocity of ball 2
            Velocity2y.Add(b2.v.y);//adds the velocity of ball 2 at time 0
            List<double> Position2x = new List<double>();//creates a list for each of the positions of centre of ball 1
            Position2x.Add(b2.pos.x);//adds the position at time 0
            List<double> Position2y = new List<double>();//creates a list for each of the positions of centre of ball 1
            Position2y.Add(b2.pos.y);//adds the position at time 0
            
            int count = 0;//timer counter

            //loop for before the balls meet
            count++;//increases the time by one interval
            double s = Math.Sqrt(Math.Pow(b2.pos.x - b1.pos.x, 2) + Math.Pow(b2.pos.y - b1.pos.y, 2)); //checks the distance between balls
            while (b1.radius + b2.radius > s)
            {
                //adds increments time in time list by ten milliseconds 
                time.Add(count * 0.01);
                
                //find new position of ball 1
                b1.s = getNextPosition(b1.s, b1.v, b1.a, 0.01);
                b1.pos.x = b1.s.x;
                b1.pos.y = b1.s.y;
                Position1x.Add(b1.pos.x);
                Position1y.Add(b1.pos.y);
                
                //find new velocity of ball 1
                b1.v = getNextVelocity(b1.v, b1.a, 0.01);
                Velocity1x.Add(b1.v.x);
                Velocity1y.Add(b1.v.y);
                
                //find new position of ball 2
                b2.s = getNextPosition(b2.s, b2.v, b2.a, 0.01);
                b2.pos.x = b2.s.x;
                b2.pos.y = b2.s.y;
                Position2x.Add(b2.pos.x);
                Position2y.Add(b2.pos.y);
                
                //find new velocity of ball 2
                b2.v = getNextVelocity(b2.v, b2.a, 0.01);
                Velocity2x.Add(b2.v.x);
                Velocity2y.Add(b2.v.y);
                
                
                s = Math.Sqrt(Math.Pow(b2.pos.x - b1.pos.x, 2) + Math.Pow(b2.pos.y - b1.pos.y, 2)); //find new distance between balls
                count++;//increases the time by one interval
            }

            
            //collision for 1d head on motionless

            //double b1vi = b1.v.mag, b2vi = b2.v.mag;

            Point c; // position of point of collision
            double k; //spring constant
            double m; //mass of object (same for both objects)
            
            // force 1 is the force cause by the compression of ball 1, force of 2 is the force caused by the comporession
            // of ball 2
            Vector f1, f2;
            

            k = 20; //spring constant, change this later
            m = 4; //mass of balls, change this latef
            
            while (s <= 2)
            {
                time.Add(count * 0.01);
                
                c = getCollisionPoint(b1.pos, b2.pos);
            
                f1 = getNextForce(k, c, b1.pos);
                f2 = getNextForce(k, c, b2.pos);

                // acceleration of ball 1 is calculated with the force exerted by BALL 2 
                // acceleration of ball 2 is calculated with the force exerted by BALL 1 
                b1.a = getNextAcceleration(f2, m);
                b2.a = getNextAcceleration(f1, m);
                
                b1.v = getNextVelocity(b1.v, b1.a, 0.01);//calculates new ball 1 velocity
                Velocity1x.Add(b1.v.x);
                Velocity1y.Add(b1.v.y);
                
                b1.s = getNextPosition(b1.s, b1.v, b1.a, 0.01);//calculates new ball 1 position
                b1.pos.x = b1.s.x;
                b1.pos.y = b1.s.y;
                Position1x.Add(b1.pos.x);
                Position1y.Add(b1.pos.y);
                
                b2.v = getNextVelocity(b2.v, b2.a, 0.01);//calculates new ball 2 velocity
                Velocity1x.Add(b2.v.x);
                Velocity1y.Add(b2.v.y);
                
                b2.s = getNextPosition(b2.s, b2.v, b2.a, 0.01);//calculates new ball 2 position
                b2.pos.x = b2.s.x;
                b2.pos.y = b2.s.y;
                Position2x.Add(b2.pos.x);
                Position2y.Add(b2.pos.y);
                
                s = Math.Sqrt(Math.Pow(b2.pos.x - b1.pos.x, 2) + Math.Pow(b2.pos.y - b1.pos.y, 2));
                count++;//increase the time by interval
            }

            //after collision, acceleration of each ball should be 0
            b1.a = new Vector(0, 0);
            b2.a = new Vector(0, 0);
            
            //loop for after balls compress
            for (int i = 0; i < 200; i ++)
            {
                time.Add(count * 0.01);
 
                //find new position of ball 1
                b1.s = getNextPosition(b1.s, b1.v, b1.a, 0.01);
                b1.pos.x = b1.s.x;
                b1.pos.y = b1.s.y;
                Position1x.Add(b1.pos.x);
                Position1y.Add(b1.pos.y);
                
                //find new velocity of ball 1
                b1.v = getNextVelocity(b1.v, b1.a, 0.01);
                Velocity1x.Add(b1.v.x);
                Velocity1y.Add(b1.v.y);
                
                //find new position of ball 2
                b2.s = getNextPosition(b2.s, b2.v, b2.a, 0.01);
                b2.pos.x = b2.s.x;
                b2.pos.y = b2.s.y;
                Position2x.Add(b2.pos.x);
                Position2y.Add(b2.pos.y);
                
                //find new velocity of ball 2
                b2.v = getNextVelocity(b2.v, b2.a, 0.01);
                Velocity2x.Add(b2.v.x);
                Velocity2y.Add(b2.v.y);
                
                count++;//increases the time by one interval
            }

            //create a csv file 
            string filePath = @"C:\Users\jacky\Desktop\School\Grade 12\AP Physics\CollisionFinal\test.csv";
                         string delimiter = ",";
            
               string[][] output = new string[9][];
            output[0] = new string[count + 1];
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    output[0][i] = "Time";
                }
                else
                {
                    output[0][i] = Convert.ToString(time[i]);
                }
            }
            output[1] = new string[count + 1];
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    output[1][i] = "Ball 1 Pos X";
                }
                else
                {
                    output[1][i] = Convert.ToString(Position1x[i]);
                }
            }
            output[2] = new string[count + 1];
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    output[2][i] = "Ball 1 Pos Y";
                }
                else
                {
                    output[2][i] = Convert.ToString(Position1y[i]);
                }
            }
            output[3] = new string[count + 1];
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    output[3][i] = "Ball 1 Velocity X";
                }
                else
                {
                    output[3][i] = Convert.ToString(Velocity1x[i]);
                }
            }
            output[4] = new string[count + 1];
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    output[4][i] = "Ball 1 Velocity Y";
                }
                else
                {
                    output[4][i] = Convert.ToString(Velocity1y[i]);
                }
            }
            output[5] = new string[count + 1];
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    output[5][i] = "Ball 2 Pos x";
                }
                else
                {
                    output[5][i] = Convert.ToString(Position2x[i]);
                }
            }
            output[6] = new string[count + 1];
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    output[6][i] = "Ball 2 Pos y";
                }
                else
                {
                    output[6][i] = Convert.ToString(Position2y[i]);
                }
            }
            output[7] = new string[count + 1];
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    output[7][i] = "Ball 2 Velocity X";
                }
                else
                {
                    output[7][i] = Convert.ToString(Velocity2x[i]);
                }
            }
            output[8] = new string[count + 1];
            for (int i = 0; i < count; i++)
            {
                if (i == 0)
                {
                    output[8][i] = "Ball 2 Velocity Y";
                }
                else
                {
                    output[8][i] = Convert.ToString(Velocity2y[i]);
                }
            }
            
            int length = output.GetLength(0);
                           StringBuilder sb = new StringBuilder();
                          for (int index = 0; index < length; index++)
                                  sb.AppendLine(string.Join(delimiter, output[index]));
          
              File.WriteAllText(filePath, sb.ToString());

        }

        /// <summary>
        /// getNextPosition returns the next displacement of an object given intial displacement, velocity, acceleration, 
        /// and time
        /// </summary>
        /// <param name="so">Initial displacement vector</param>
        /// <param name="v">Velocity vection</param>
        /// <param name="a">Acceleration vector</param>
        /// <param name="t">Time</param>
        /// <returns>Returns final(next) displacement vector</returns>
        static public Vector getNextPosition(Vector so, Vector v, Vector a, double t)
        {
            double sx; //x component final position
            sx = so.x + v.x * t + 0.5 * a.x * Math.Pow (t,2); // calculating final postion using kinematics
            
            double sy; //y component final position
            sy = so.y + v.y * t + 0.5 * a.y * Math.Pow (t,2); // calculating final postion using kinematics
            
            Vector s = new Vector(sx, sy);
            
            return s;
        }

        /// <summary>
        /// getNextVelocity returns the next velocity vector of an object given intial velocity, acceleration, and time
        /// </summary>
        /// <param name="vo">Initial velocity vector</param>
        /// <param name="a">Acceleration vector</param>
        /// <param name="t">Time</param>
        /// <returns>Returns final(next) velocity</returns>
        static public Vector getNextVelocity(Vector vo, Vector a, double t)
        {
            double vx; // x component of final velocity
            vx = vo.x + a.x * t; // calculating final velocity using kinematics
            
            double vy; // y component of final velocity
            vy = vo.y + a.y * t; // calculating final velocity using kinematics
            
            Vector v = new Vector(vx, vy);
            
            return v;
        }

        /// <summary>
        /// getNextAcceleration returns the acceleration vector of an object given the force acting upon it (not the force it
        /// exerts) and its mass
        /// </summary>
        /// <param name="f">Force vector</param>
        /// <param name="m">Mass</param>
        /// <returns>Acceleration vector</returns>
        static public Vector getNextAcceleration(Vector f, double m)
        {
            double ax; // x component of acceleration
            ax = f.x / m; // acceleration using newton's second law (f=ma) where a (acceleration) is isolated
            
            double ay; // y component of acceleration
            ay = f.y / m; // acceleration using newton's second law (f=ma) where a (acceleration) is isolated
            
            Vector a = new Vector(ax, ay);
            
            return a;
        }
        
        /// <summary>
        /// getNextForce returns the force vector exerted by the ball through compression
        /// </summary>
        /// <param name="k">spring constant</param>
        /// <param name="c">Position of collision point</param>
        /// <param name="s">Position of obj's centre of mass</param>
        /// <returns>force exerted by ball (vector)</returns>
        static public Vector getNextForce(double k, Point c, Point pos)
        {
            double fMag;
            fMag = -1 * k * Math.Sqrt((c.x-pos.x)*(c.x-pos.x) + (c.y-pos.y)*(c.y-pos.y));
            
            Vector f = new Vector(pos, c, fMag);
            return f;
        }
        
        /// <summary>
        /// getCollisionPoint returns either the point at which the two objects touch during collision
        /// basically caluclated by drawing a straight line through the two object and finding the middle
        /// </summary>
        /// <param name="s1">Position of first obj</param>
        /// <param name="s2">Position of second obj</param>
        /// <returns>Position of collision point</returns>
        static public Point getCollisionPoint(Point s1, Point s2)
        {
            double cx; //x coordinate of collision point
            cx = (s1.x + s2.x) / 2;
            
            double cy; //y coordinate of collision point
            cy = (s1.y + s2.y) / 2;
            
            Point c = new Point(cx, cy);
            
            return c;
        }
        
    }
}
