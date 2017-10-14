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
            double deltaT = 0.0009;
            
            //creates 2 ball objects (posx, posy, velocity, acceleration, radius, spring constant, mass, rotational speed, angle, if glancing)
            Ball b1 = new Ball(-3, 0, 5, 0, 2, 1130, 5,0,0,false, 1);
            Ball b2 = new Ball(3, 0, 3, 0, 2, 1130, 5, 0,0,false, 1);
            
            List<double> time = new List<double>();//creates a list for each time interval
            time.Add(0);//adds the time at 0

            List<double> Velocity1x = new List<double>();//creates a list for each velocity of ball 1
            Velocity1x.Add(b1.v.x);//adds the velocity of ball 1 at time 0
            List<double> Velocity1y = new List<double>();//creates a list for each velocity of ball 1
            Velocity1y.Add(b1.v.y);//adds the velocity of ball 1 at time 0
            List<double> Vfinal1 = new List<double>();//final velocity of ball 1
            Vfinal1.Add(b1.v.mag);
            List<double> Vangle1 = new List<double>();
            Vangle1.Add(b1.v.angle);
            List<double> Position1x = new List<double>();//creates a list for each of the positions of centre of ball 1
            Position1x.Add(b1.pos.x);//adds the position at time 0
            List<double> Position1y = new List<double>();//creates a list for each of the positions of centre of ball 1
            Position1y.Add(b1.pos.y);//adds the position at time 0
            List<double> A1x = new List<double>();//creates a list for each of the positions of centre of ball 1
            A1x.Add(b1.a.x);//adds the position at time 0
            List<double> A1y = new List<double>();//creates a list for each of the positions of centre of ball 1
            A1y.Add(b1.a.y);//adds the position at time 0
            List<double> A1final = new List<double>();//creates a list for each of the positions of centre of ball 1
            A1final.Add(b1.a.mag);//adds the position at time 0
            List<double> A1angle = new List<double>();
            A1angle.Add(b1.a.angle);
            List<double> A1xforce = new List<double>();
            A1xforce.Add(0);
            List<double> A1yforce = new List<double>();
            A1yforce.Add(0);
            List<double> A1force = new List<double>();
            A1force.Add(0);
            List<double> A1fangle = new List<double>();
            A1fangle.Add(0);

            List<double> Velocity2x = new List<double>();//creates a list for each velocity of ball 2
            Velocity2x.Add(b2.v.x);//adds the velocity of ball 2 at time 0
            List<double> Velocity2y = new List<double>();//creates a list for each velocity of ball 2
            Velocity2y.Add(b2.v.y);//adds the velocity of ball 2 at time 0
            List<double> Vfinal2 = new List<double>();//final velocity of ball 2
            Vfinal2.Add(b2.v.mag);
            List<double> Vangle2 = new List<double>();
            Vangle2.Add(b2.v.angle);
            List<double> Position2x = new List<double>();//creates a list for each of the positions of centre of ball 1
            Position2x.Add(b2.pos.x);//adds the position at time 0
            List<double> Position2y = new List<double>();//creates a list for each of the positions of centre of ball 1
            Position2y.Add(b2.pos.y);//adds the position at time 0
            List<double> A2x = new List<double>();//creates a list for each of the positions of centre of ball 1
            A2x.Add(b2.a.x);//adds the position at time 0
            List<double> A2y = new List<double>();//creates a list for each of the positions of centre of ball 1
            A2y.Add(b2.a.y);//adds the position at time 0
            List<double> A2final = new List<double>();//creates a list for each of the positions of centre of ball 1
            A2final.Add(b2.a.mag);//adds the position at time 0
            List<double> A2angle = new List<double>();
            A2angle.Add(b2.a.angle);
            List<double> A2xforce = new List<double>();
            A2xforce.Add(0);
            List<double> A2yforce = new List<double>();
            A2yforce.Add(0);
            List<double> A2force = new List<double>();
            A2force.Add(0);
            List<double> A2fangle = new List<double>();
            A2fangle.Add(0);

            List<double> cx = new List<double>();
            cx.Add(0);
            List<double> cy = new List<double>();
            cy.Add(0);


            int count = 0; //timer counter

            //loop for before the balls meet
            count++; //increases the time by one interval
            double s = Math.Sqrt(Math.Pow(b2.pos.x - b1.pos.x, 2) +
                                 Math.Pow(b2.pos.y - b1.pos.y, 2)); //checks the distance between balls

            while (b1.radius + b2.radius < s)
            {
                
                //adds increments time in time list by ten milliseconds 
                time.Add(count * deltaT);

                //find new position of ball 1
                b1.s = getNextPosition(b1.s, b1.v, b1.a, deltaT);
                b1.pos.x = b1.s.x;
                b1.pos.y = b1.s.y;
                Position1x.Add(b1.pos.x);
                Position1y.Add(b1.pos.y);

                //find new velocity of ball 1
                b1.v = getNextVelocity(b1.v, b1.a, deltaT);
                Velocity1x.Add(b1.v.x);
                Velocity1y.Add(b1.v.y);
                Vfinal1.Add(b1.v.mag);
                Vangle1.Add(b1.v.angle);
                

                //find new position of ball 2
                b2.s = getNextPosition(b2.s, b2.v, b2.a, deltaT);
                b2.pos.x = b2.s.x;
                b2.pos.y = b2.s.y;
                Position2x.Add(b2.pos.x);
                Position2y.Add(b2.pos.y);

                //find new velocity of ball 2
                b2.v = getNextVelocity(b2.v, b2.a, deltaT);
                Velocity2x.Add(b2.v.x);
                Velocity2y.Add(b2.v.y);
                Vfinal2.Add(b2.v.mag);
                Vangle2.Add(b2.v.angle);

                //add to list that a is 0 for both balls
                A1final.Add(0);
                A1x.Add(0);
                A1y.Add(0);
                A1angle.Add(b1.a.angle);
                A1xforce.Add(0);
                A1yforce.Add(0);
                A1force.Add(0);
                A1fangle.Add(0);

                A2final.Add(0);
                A2x.Add(0);
                A2y.Add(0);
                A2angle.Add(b2.a.angle);
                A2xforce.Add(0);
                A2yforce.Add(0);
                A2force.Add(0);
                A2fangle.Add(0);

                cx.Add(0);
                cy.Add(0);
                
                s = Math.Sqrt(Math.Pow(b2.pos.x - b1.pos.x, 2) +
                              Math.Pow(b2.pos.y - b1.pos.y, 2)); //find new distance between balls
                count++; //increases the time by one interval
            }

            //collision for 1d head on motionless

            Point c; // position of point of collision
            
            // force 1 is the force cause by the compression of ball 1, force of 2 is the force caused by the comporession
            // of ball 2
            Vector f1, f2;
            
            
            while (s <= b1.radius + b2.radius)
            {
                Console.WriteLine("HI");
                time.Add(count * deltaT);

                c = getCollisionPoint(b1.pos, b2.pos);
                cx.Add(c.x);
                cy.Add(c.y);
            
                f1 = getNextForce(b1.spring, c, b1);
                A1xforce.Add(f1.x);
                A1yforce.Add(f1.y);
                A1force.Add(f1.mag);
                A1fangle.Add(f1.angle);
                
                f2 = getNextForce(b2.spring, c, b2);
                //f2.x *= -1; //DELETE LATER
                A2xforce.Add(f2.x);
                A2yforce.Add(f2.y);
                A2force.Add(f2.mag);
                A2fangle.Add(f2.angle);

                // acceleration of ball 1 is calculated with the force exerted by BALL 2 
                // acceleration of ball 2 is calculated with the force exerted by BALL 1 
                b1.a = getNextAcceleration(f2, b1.mass);
                A1final.Add(b1.a.mag);
                A1x.Add(b1.a.x);
                A1y.Add(b1.a.y);
                A1angle.Add(b1.a.angle);

                b2.a = getNextAcceleration(f1, b2.mass);
                A2final.Add(b2.a.mag);
                A2x.Add(b2.a.x);
                A2y.Add(b2.a.y);
                A2angle.Add(b2.a.angle);


                b1.v = getNextVelocity(b1.v, b1.a, deltaT);//calculates new ball 1 velocity
                Velocity1x.Add(b1.v.x);
                Velocity1y.Add(b1.v.y);
                Vfinal1.Add(b1.v.mag);
                Vangle1.Add(b1.v.angle);
                
                b1.s = getNextPosition(b1.s, b1.v, b1.a, deltaT);//calculates new ball 1 position
                b1.pos.x = b1.s.x;
                b1.pos.y = b1.s.y;
                Position1x.Add(b1.pos.x);
                Position1y.Add(b1.pos.y);

                b2.v = getNextVelocity(b2.v, b2.a, deltaT); //calculates new ball 2 velocity
                Velocity2x.Add(b2.v.x);
                Velocity2y.Add(b2.v.y);
                Vfinal2.Add(b2.v.mag);
                Vangle2.Add(b2.v.angle);
                
                b2.s = getNextPosition(b2.s, b2.v, b2.a, deltaT);//calculates new ball 2 position
                b2.pos.x = b2.s.x;
                b2.pos.y = b2.s.y;
                Position2x.Add(b2.pos.x);
                Position2y.Add(b2.pos.y);

                s = Math.Sqrt(Math.Pow(b2.pos.x - b1.pos.x, 2) + Math.Pow(b2.pos.y - b1.pos.y, 2));
                count++; //increase the time by interval
            }

            //after collision, acceleration of each ball should be 0
            b1.a = new Vector(0, 0);
            b2.a = new Vector(0, 0);

            //loop for after balls compress
            for (int i = 0; i < 200; i++)
            {
                time.Add(count * deltaT);

                //find new position of ball 1
                b1.s = getNextPosition(b1.s, b1.v, b1.a, deltaT);
                b1.pos.x = b1.s.x;
                b1.pos.y = b1.s.y;
                Position1x.Add(b1.pos.x);
                Position1y.Add(b1.pos.y);

                //find new velocity of ball 1
                b1.v = getNextVelocity(b1.v, b1.a, deltaT);
                Velocity1x.Add(b1.v.x);
                Velocity1y.Add(b1.v.y);
                Vfinal1.Add(b1.v.mag);
                Vangle1.Add(b1.v.angle);

                //find new position of ball 2
                b2.s = getNextPosition(b2.s, b2.v, b2.a, deltaT);
                b2.pos.x = b2.s.x;
                b2.pos.y = b2.s.y;
                Position2x.Add(b2.pos.x);
                Position2y.Add(b2.pos.y);

                //find new velocity of ball 2
                b2.v = getNextVelocity(b2.v, b2.a, deltaT);
                Velocity2x.Add(b2.v.x);
                Velocity2y.Add(b2.v.y);
                Vfinal2.Add(b2.v.mag);
                Vangle2.Add(b2.v.angle);

                //add to list that a is 0 for both balls
                A1final.Add(0);
                A1x.Add(0);
                A1y.Add(0);
                A1angle.Add(b1.a.angle);
                A1xforce.Add(0);
                A1yforce.Add(0);
                A1force.Add(0);
                A1fangle.Add(0);

                A2final.Add(0);
                A2x.Add(0);
                A2y.Add(0);
                A2angle.Add(b2.a.angle);
                A2xforce.Add(0);
                A2yforce.Add(0);
                A2force.Add(0);
                A2fangle.Add(0);
                
                cx.Add(0);
                cy.Add(0);

                count++; //increases the time by one interval
            }

            Console.WriteLine("v1 = " + b1.v.mag);
            Console.WriteLine("v1 theta = " + b1.v.angle);

            Console.WriteLine("v2 = " + b2.v.mag);
            Console.WriteLine("v2 theta = " + b2.v.angle);




            //create a csv file 
            string filePath = @"C:\Users\Megan Niu\Desktop\12 Physics\test.csv";
            string delimiter = ",";

            string[][] output = new string[count + 1][];
            for (int i = 0; i < count + 1; i++)

            {
                output[i] = new string[31];
                if (i == 0)
                {
                    output[i][0] = "Time";
                    output[i][1] = "X Pos of Ball 1";
                    output[i][2] = "Y Pos of Ball 1";
                    output[i][3] = "X Velocity of Ball 1";
                    output[i][4] = "Y Velocity of Ball 1";
                    output[i][5] = "Final Velocity of Ball 1";
                    output[i][6] = "Angle of Velocity of Ball 1";
                    output[i][7] = "Ax of Ball 1";
                    output[i][8] = "Ay of Ball 1";
                    output[i][9] = "Afinal of Ball 1";
                    output[i][10] = "Angle of A Ball 1";
                    output[i][11] = "Fx from Ball 1";
                    output[i][12] = "Fy from Ball 1";
                    output[i][13] = "Force from Ball 1";
                    output[i][14] = "Angle of Force";
                    output[i][15] = "X Pos of Ball 2";
                    output[i][16] = "Y Pos of Ball 2";
                    output[i][17] = "X Velocity of Ball 2";
                    output[i][18] = "Y Velocity of Ball 2";
                    output[i][19] = "Final Velocity of Ball 2";
                    output[i][20] = "Angle of Velocity of Ball 2";
                    output[i][21] = "Ax of Ball 2";
                    output[i][22] = "Ay of Ball 2";
                    output[i][23] = "Afinal of Ball 2";
                    output[i][24] = "Angle of A Ball 2";
                    output[i][25] = "Fx from Ball 2";
                    output[i][26] = "Fy from Ball 2";
                    output[i][27] = "Force from Ball 2";
                    output[i][28] = "Angle of Force";
                    output[i][29] = "cx";
                    output[i][30] = "cy";

                }
                else
                {
                    output[i][0] = Convert.ToString(time[i - 1]);
                    output[i][1] = Convert.ToString(Position1x[i - 1]);
                    output[i][2] = Convert.ToString(Position1y[i - 1]);
                    output[i][3] = Convert.ToString(Velocity1x[i - 1]);
                    output[i][4] = Convert.ToString(Velocity1y[i - 1]);
                    output[i][5] = Convert.ToString(Vfinal1[i - 1]);
                    output[i][6] = Convert.ToString(Vangle1[i - 1]);
                    output[i][7] = Convert.ToString(A1x[i - 1]);
                    output[i][8] = Convert.ToString(A1y[i - 1]);
                    output[i][9] = Convert.ToString(A1final[i - 1]);
                    output[i][10] = Convert.ToString(A1angle[i - 1]);
                    output[i][11] = Convert.ToString(A1xforce[i - 1]);
                    output[i][12] = Convert.ToString(A1yforce[i - 1]);
                    output[i][13] = Convert.ToString(A1force[i - 1]);
                    output[i][14] = Convert.ToString(A1fangle[i - 1]);
                    output[i][15] = Convert.ToString(Position2x[i - 1]);
                    output[i][16] = Convert.ToString(Position2y[i - 1]);
                    output[i][17] = Convert.ToString(Velocity2x[i - 1]);
                    output[i][18] = Convert.ToString(Velocity2y[i - 1]);
                    output[i][19] = Convert.ToString(Vfinal2[i - 1]);
                    output[i][20] = Convert.ToString(Vangle2[i - 1]);
                    output[i][21] = Convert.ToString(A2x[i - 1]);
                    output[i][22] = Convert.ToString(A2y[i - 1]);
                    output[i][23] = Convert.ToString(A2final[i - 1]);
                    output[i][24] = Convert.ToString(A2angle[i - 1]);
                    output[i][25] = Convert.ToString(A2xforce[i - 1]);
                    output[i][26] = Convert.ToString(A2yforce[i - 1]);
                    output[i][27] = Convert.ToString(A2force[i - 1]);
                    output[i][28] = Convert.ToString(A2fangle[i - 1]);
                    output[i][29] = Convert.ToString(cx[i - 1]);
                    output[i][30] = Convert.ToString(cy[i - 1]);
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
            sx = so.x + v.x * t + 0.5 * a.x * Math.Pow(t, 2); // calculating final postion using kinematics

            double sy; //y component final position
            sy = so.y + v.y * t + 0.5 * a.y * Math.Pow(t, 2); // calculating final postion using kinematics
            //sy = 0;//DELETE LATER
            
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
        static public Vector getNextForce(double k, Point c, Ball a)
        {
            double fMag;

           // fMag = -1 * k * Math.Sqrt((c.x - pos.x) * (c.x - pos.x) + (c.y - pos.y) * (c.y - pos.y));

           // Vector f = new Vector(pos, c, fMag);

            fMag = k * (a.radius - Math.Sqrt((c.x-a.pos.x)*(c.x-a.pos.x) + (c.y-a.pos.y)*(c.y-a.pos.y)));
            
            Vector f = new Vector(a.pos, c, fMag);

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

        /**
        static public Vector getNextTorqueForce(Point c, Ball b1, Ball b2)
        {
            Vector f, n;
            n = new Vector(b1.pos, b2.pos, 1);
            if (b1.v.x < 0)
            {
                f = new Vector();
            }
            else
            {
                
            }

        }
        **/
/*
        /// <summary>
        /// getNextAngularVelocity calculated the next angular velocity of a ball
        /// </summary>
        /// <param name="c">Point of collision</param>
        /// <param name="ball">Point of centre of mass</param>
        /// <param name="force">Vector of force causing torque</param>
        /// <param name="wo">Initial angular velocity</param>
        /// <param name="radius">Radius of ball</param>
        /// <param name="time">Time</param>
        /// <returns>Next angular velocity</returns>
        static public double getNextAngularVelocity(Point c, Point ball, Vector force, double wo, double radius, double time)
        {
            double i, torque, a, w; 
            Vector s;
             
            //moment of inertia
            i = Math.PI / 64 * Math.Pow(2 * radius, 4);
            
            //vector of centre of ball to point of collision
            s = new Vector(c, ball, Math.Sqrt((c.x - ball.x) * (c.x - ball.x) + (c.y - ball.y) * (c.y - ball.y)));

            //torque caused by force on the centre of ball to point of collision vector
            torque = Vector.crossProduct(s, force);

            //angular acceleratioin calculated by torque, divided by moment of inertia
            a = torque / i;

            //angular velocity
            w = wo + a * time;

            return w;
        }

    }
}*/
        /*
namespace CollisionLab1
{
    class Collision

    {

        static void Main(string[] args)
        {
            //creates 2 ball objects
            Ball b1 = new Ball(-6, 0, 5, 0, 2, 1165.66, 2, 0, 0, false);
            Ball b2 = new Ball(0, 0, 3, 0, 2, 1165.66, 2, 0, Math.PI, false);

            List<double> time = new List<double>(); //creates a list for each time interval
            time.Add(0); //adds the time at 0

            List<double> Velocity1x = new List<double>(); //creates a list for each velocity of ball 1
            Velocity1x.Add(b1.v.x); //adds the velocity of ball 1 at time 0
            List<double> Velocity1y = new List<double>(); //creates a list for each velocity of ball 1
            Velocity1y.Add(b1.v.y); //adds the velocity of ball 1 at time 0
            List<double> Vfinal1 = new List<double>(); //final velocity of ball 1
            Vfinal1.Add(b1.v.mag);
            List<double> Position1x = new List<double>(); //creates a list for each of the positions of centre of ball 1
            Position1x.Add(b1.pos.x); //adds the position at time 0
            List<double> Position1y = new List<double>(); //creates a list for each of the positions of centre of ball 1
            Position1y.Add(b1.pos.y); //adds the position at time 0
            List<double> A1x = new List<double>(); //creates a list for each of the positions of centre of ball 1
            A1x.Add(b1.a.x); //adds the position at time 0
            List<double> A1y = new List<double>(); //creates a list for each of the positions of centre of ball 1
            A1y.Add(b1.a.y); //adds the position at time 0
            List<double> A1final = new List<double>(); //creates a list for each of the positions of centre of ball 1
            A1final.Add(b1.a.mag); //adds the position at time 0
            List<double> A1angle = new List<double>();
            A1angle.Add(b1.a.angle);

            List<double> Velocity2x = new List<double>(); //creates a list for each velocity of ball 2
            Velocity2x.Add(b2.v.x); //adds the velocity of ball 2 at time 0
            List<double> Velocity2y = new List<double>(); //creates a list for each velocity of ball 2
            Velocity2y.Add(b2.v.y); //adds the velocity of ball 2 at time 0
            List<double> Vfinal2 = new List<double>(); //final velocity of ball 2
            Vfinal2.Add(b2.v.mag);
            List<double> Position2x = new List<double>(); //creates a list for each of the positions of centre of ball 1
            Position2x.Add(b2.pos.x); //adds the position at time 0
            List<double> Position2y = new List<double>(); //creates a list for each of the positions of centre of ball 1
            Position2y.Add(b2.pos.y); //adds the position at time 0
            List<double> A2x = new List<double>(); //creates a list for each of the positions of centre of ball 1
            A2x.Add(b2.a.x); //adds the position at time 0
            List<double> A2y = new List<double>(); //creates a list for each of the positions of centre of ball 1
            A2y.Add(b2.a.y); //adds the position at time 0
            List<double> A2final = new List<double>(); //creates a list for each of the positions of centre of ball 1
            A2final.Add(b2.a.mag); //adds the position at time 0
            List<double> A2angle = new List<double>();
            A2angle.Add(b2.a.angle);


            int count = 0; //timer counter

            //loop for before the balls meet
            count++; //increases the time by one interval
            double s = Math.Sqrt(Math.Pow(b2.pos.x - b1.pos.x, 2) + Math.Pow(b2.pos.y - b1.pos.y, 2)); //checks the distance between balls
            while (b1.radius + b2.radius < s)
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
                Vfinal1.Add(b1.v.mag);

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
                Vfinal2.Add(b2.v.mag);

                //add to list that a is 0 for both balls
                A1final.Add(0);
                A1x.Add(0);
                A1y.Add(0);
                A1angle.Add(0);

                A2final.Add(0);
                A2x.Add(0);
                A2y.Add(0);
                A2angle.Add(0);

                s = Math.Sqrt(Math.Pow(b2.pos.x - b1.pos.x, 2) + Math.Pow(b2.pos.y - b1.pos.y, 2)); //find new distance between balls
                count++; //increases the time by one interval
            }


            //collision for 1d head on motionless

            //double b1vi = b1.v.mag, b2vi = b2.v.mag;

            Point c; // position of point of collision
            double k; //spring constant
            double m; //mass of object (same for both objects)

            // force 1 is the force cause by the compression of ball 1, force of 2 is the force caused by the comporession
            // of ball 2
            // f3 is the force that causes torque on ball 2, produced by ball 1
            // f4 is the force that causes torque on ball 1, produced by ball 2
            Vector f1, f2, f3, f4;


            while (s <= b1.radius + b2.radius)
            {
                time.Add(count * 0.01);

                c = getCollisionPoint(b1.pos, b2.pos);

                f1 = getNextForce(b1.spring, c, b1);
                f2 = getNextForce(b2.spring, c, b2);

                // acceleration of ball 1 is calculated with the force exerted by BALL 2 
                // acceleration of ball 2 is calculated with the force exerted by BALL 1 
                b1.a = getNextAcceleration(f2, b1.mass);
                A1final.Add(b1.a.mag);
                A1x.Add(b1.a.x);
                A1y.Add(b1.a.y);
                A1angle.Add(b1.a.angle);

                b2.a = getNextAcceleration(f1, b2.mass);
                A2final.Add(b2.a.mag);
                A2x.Add(b2.a.x);
                A2y.Add(b2.a.y);
                A2angle.Add(b2.a.angle);

                b1.v = getNextVelocity(b1.v, b1.a, 0.01); //calculates new ball 1 velocity
                Velocity1x.Add(b1.v.x);
                Velocity1y.Add(b1.v.y);
                Vfinal1.Add(b1.v.mag);

                b1.s = getNextPosition(b1.s, b1.v, b1.a, 0.01); //calculates new ball 1 position
                b1.pos.x = b1.s.x;
                b1.pos.y = b1.s.y;
                Position1x.Add(b1.pos.x);
                Position1y.Add(b1.pos.y);

                b2.v = getNextVelocity(b2.v, b2.a, 0.01); //calculates new ball 2 velocity
                Velocity2x.Add(b2.v.x);
                Velocity2y.Add(b2.v.y);
                Vfinal2.Add(b2.v.mag);

                b2.s = getNextPosition(b2.s, b2.v, b2.a, 0.01); //calculates new ball 2 position
                b2.pos.x = b2.s.x;
                b2.pos.y = b2.s.y;
                Position2x.Add(b2.pos.x);
                Position2y.Add(b2.pos.y);

                s = Math.Sqrt(Math.Pow(b2.pos.x - b1.pos.x, 2) + Math.Pow(b2.pos.y - b1.pos.y, 2));
                count++; //increase the time by interval
            }

            //after collision, acceleration of each ball should be 0
            b1.a = new Vector(0, 0);
            b2.a = new Vector(0, 0);

            //loop for after balls compress
            for (int i = 0; i < 200; i++)
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
                Vfinal1.Add(b1.v.mag);

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
                Vfinal2.Add(b2.v.mag);

                //add to list that a is 0 for both balls
                A1final.Add(0);
                A1x.Add(0);
                A1y.Add(0);
                A1angle.Add(b1.a.angle);

                A2final.Add(0);
                A2x.Add(0);
                A2y.Add(0);
                A2angle.Add(b2.a.angle);

                count++; //increases the time by one interval
            }

            Console.WriteLine("v1 = " + b1.v.mag);
            Console.WriteLine("v1 theta = " + b1.v.angle);

            Console.WriteLine("v2 = " + b2.v.mag);
            Console.WriteLine("v2 theta = " + b2.v.angle);




            //create a csv file 
            string filePath = @"C:\Users\jacky\Desktop\School\Grade 12\AP Physics\CollisionFinal\Output.csv";
            string delimiter = ",";

            string[][] output = new string[count + 1][];
            for (int i = 0; i < count + 1; i++)
            {
                output[i] = new string[19];
                if (i == 0)
                {
                    output[i][0] = "Time";
                    output[i][1] = "X Pos of Ball 1";
                    output[i][2] = "Y Pos of Ball 1";
                    output[i][3] = "X Velocity of Ball 1";
                    output[i][4] = "Y Velocity of Ball 1";
                    output[i][5] = "Final Velocity of Ball 1";
                    output[i][6] = "Ax of Ball 1";
                    output[i][7] = "Ay of Ball 1";
                    output[i][8] = "Afinal of Ball 1";
                    output[i][9] = "Angle of A B1";
                    output[i][10] = "X Pos of Ball 2";
                    output[i][11] = "Y Pos of Ball 2";
                    output[i][12] = "X Velocity of Ball 2";
                    output[i][13] = "Y Velocity of Ball 2";
                    output[i][14] = "Final Velocity of Ball 2";
                    output[i][15] = "Ax of Ball 2";
                    output[i][16] = "Ay of Ball 2";
                    output[i][17] = "Afinal of Ball 2";
                    output[i][18] = "Angle of A B2";
                }
                else
                {
                    output[i][0] = Convert.ToString(time[i - 1]);
                    output[i][1] = Convert.ToString(Position1x[i - 1]);
                    output[i][2] = Convert.ToString(Position1y[i - 1]);
                    output[i][3] = Convert.ToString(Velocity1x[i - 1]);
                    output[i][4] = Convert.ToString(Velocity1y[i - 1]);
                    output[i][5] = Convert.ToString(Vfinal1[i - 1]);
                    output[i][6] = Convert.ToString(A1x[i - 1]);
                    output[i][7] = Convert.ToString(A1y[i - 1]);
                    output[i][8] = Convert.ToString(A1final[i - 1]);
                    output[i][9] = Convert.ToString(A1angle[i - 1]);
                    output[i][10] = Convert.ToString(Position2x[i - 1]);
                    output[i][11] = Convert.ToString(Position2y[i - 1]);
                    output[i][12] = Convert.ToString(Velocity2x[i - 1]);
                    output[i][13] = Convert.ToString(Velocity2y[i - 1]);
                    output[i][14] = Convert.ToString(Vfinal2[i - 1]);
                    output[i][15] = Convert.ToString(A2x[i - 1]);
                    output[i][16] = Convert.ToString(A2y[i - 1]);
                    output[i][17] = Convert.ToString(A2final[i - 1]);
                    output[i][18] = Convert.ToString(A2angle[i - 1]);
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
            sx = so.x + v.x * t + 0.5 * a.x * Math.Pow(t, 2); // calculating final postion using kinematics

            double sy; //y component final position
            //sy = so.y + v.y * t + 0.5 * a.y * Math.Pow(t, 2); // calculating final postion using kinematics
            sy = 0;
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
        static public Vector getNextForce(double k, Point c, Ball a)
        {
            double fMag;
            fMag = -1 * k * (a.radius - Math.Sqrt((c.x - a.pos.x) * (c.x - a.pos.x) + (c.y - a.pos.y) * (c.y - a.pos.y)));

            Vector f = new Vector(a.pos, c, fMag);
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

        
        static public Vector getNextTorqueForce(Point c, Ball b1, Ball b2)
        {
            Vector f, n;
            n = new Vector(b1.pos, b2.pos, 1);
            if (b1.v.x < 0)
            {
                f = new Vector();
            }
            else
            {

            }

        }

        
        /// <summary>
        /// getNextAngularVelocity calculated the next angular velocity of a ball
        /// </summary>
        /// <param name="c">Point of collision</param>
        /// <param name="ball">Point of centre of mass</param>
        /// <param name="force">Vector of force causing torque</param>
        /// <param name="wo">Initial angular velocity</param>
        /// <param name="radius">Radius of ball</param>
        /// <param name="time">Time</param>
        /// <returns>Next angular velocity</returns>
        static public double getNextAngularVelocity(Point c, Point ball, Vector force, double wo, double radius, double time)
        {
            double i, torque, a, w;
            Vector s;

            //moment of inertia
            i = Math.PI / 64 * Math.Pow(2 * radius, 4);

            //vector of centre of ball to point of collision
            s = new Vector(c, ball, Math.Sqrt((c.x - ball.x) * (c.x - ball.x) + (c.y - ball.y) * (c.y - ball.y)));

            //torque caused by force on the centre of ball to point of collision vector
            torque = Vector.crossProduct(s, force);

            //angular acceleratioin calculated by torque, divided by moment of inertia
            a = torque / i;

            //angular velocity
            w = wo + a * time;

            return w;
        }
        */


    }
}

