using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollisionLab1
{
    class Collision
    {
        static void Main(string[] args)
        {
            
            //suck dck jacky
            Console.WriteLine("Good job we did it");
            //creates 2 ball objects
            Ball b1 = new Ball(-100, 4.0,12, 4, -1165.66, 5);
            Ball b2 = new Ball(100,  0, 0, 4, -1165.66, 6);
            double sx = Math.Abs(b1.posx - b2.posx);//checks how far the balls are at start
            List<double> time = new List<double>();//creates a list for each time interval
            time.Add(0);//adds the time at 0
            List<double> Velocity1 = new List<double>();//creates a list for each velocity of ball 1
            Velocity1.Add(b1.v);//adds the velocity of ball 1 at time 0
            List<double> Position1 = new List<double>();//creates a list for each of the positions of centre of ball 1
            Position1.Add(b1.pos);//adds the position at time 0
            List<double> Velocity2 = new List<double>();//creates a list for each velocity of ball 2
            Velocity2.Add(b2.v);//adds the velocity of ball 2 at time 0
            List<double> Position2 = new List<double>();//creates a list for each of the positions of centre of ball 1
            Position1.Add(b2.pos);//adds the position at time 0
            int count = 0;
            //loop for before the balls meet
            count++;//increases the time by one intervak
            while (b1.getradius() + b2.getradius() > sx)
            {
                time.Add(count * 0.01);
                b1.pos = b1.pos + b1.v * 0.01 + 0.5*b1.a* 0.01*0.01;//calculates new ball 1 position
                Position1.Add(b1.pos);
                b1.v = b1.v + b1.a * 0.01;//calculates new ball 1 velocity
                Velocity1.Add(b1.v);
                b2.pos = b2.pos + b2.v * 0.01 + 0.5 * b2.a * 0.01 * 0.01;//calculate new ball 2 position
                Position2.Add(b2.pos);
                b2.v = b2.v + b2.a * 0.01;//calculate new ball 2 velocity
                Velocity2.Add(b2.v);
                count++;//increases the time by one interval
            }

            //collision for 1d head on motionless
            double b1vi = b1.v, b2vi = b2.v;
            double Force1 = b1.spring * (b1.pos - b2.pos), Force2 = b2.spring * (b1.pos - b2.pos);//not right thanks megan 
            b1.a = Force1 / b1.mass;//find new acceleration for b1
            b2.a = Force2 / b2.mass;//find new acceleration for b2 
            while (((b1vi > 0 && b1.v > 0) || (b1vi < 0 && b1.v < 0)) && ((b2vi > 0 && b2.v > 0) || (b2vi > 0 && b2.v > 0)))
            {
                time.Add(count * 0.01);
                b1.v = b1.v + b1.a * 0.01;//calculates new ball 1 velocity
                Velocity1.Add(b1.v);
                b1.pos = b1.pos + b1.v * 0.01 + 0.5 * b1.a * 0.01 * 0.01;//calculates new ball 1 position
                Position1.Add(b1.pos);
                b2.v = b2.v + b2.a * 0.01;//calculate new ball 2 velocity
                Velocity1.Add(b2.v);
                b2.pos = b2.pos + b2.v * 0.01 + 0.5 * b2.a * 0.01 * 0.01;//calculate new ball 2 position
                Position2.Add(b2.pos);
                count++;//increase the time by interval
            }

            //loop for after balls compress
            while (Math.Abs(b1.pos) >= 100 && Math.Abs(b2.pos) >= 100)
            {
                time.Add(count * 0.01);
                b1.pos = b1.pos + b1.v * 0.01 + 0.5 * b1.a * 0.01 * 0.01;//calculates new ball 1 position
                Position1.Add(b1.pos);
                b1.v = b1.v + b1.a * 0.01;//calculates new ball 1 velocity
                Velocity1.Add(b1.v);
                b2.pos = b2.pos + b2.v * 0.01 + 0.5 * b2.a * 0.01 * 0.01;//calculate new ball 2 position
                Position2.Add(b2.pos);
                b2.v = b2.v + b2.a * 0.01;//calculate new ball 2 velocity
                Velocity1.Add(b2.v);
                count++;//increases the time by one interval
            }

            
        }
    }
}
