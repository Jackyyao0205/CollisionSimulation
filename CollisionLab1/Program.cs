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
            
            //creates 2 ball objects
            Ball b1 = new Ball(-100, 0,  4.0,12, 4, -1165.66, 5,0,0,false);
            Ball b2 = new Ball(100,0,0, 0, 4, -1165.66, 6, 0,0,false);
            List<double> time = new List<double>();//creates a list for each time interval
            time.Add(0);//adds the time at 0
            List<double> Velocity1x = new List<double>();//creates a list for each velocity of ball 1
            Velocity1x.Add(b1.vx);//adds the velocity of ball 1 at time 0
            List<double> Velocity1y = new List<double>();//creates a list for each velocity of ball 1
            Velocity1y.Add(b1.vy);//adds the velocity of ball 1 at time 0
            List<double> Position1x = new List<double>();//creates a list for each of the positions of centre of ball 1
            Position1x.Add(b1.posx);//adds the position at time 0
            List<double> Position1y = new List<double>();//creates a list for each of the positions of centre of ball 1
            Position1y.Add(b1.posy);//adds the position at time 0
            List<double> Velocity2x = new List<double>();//creates a list for each velocity of ball 2
            Velocity2x.Add(b2.vx);//adds the velocity of ball 2 at time 0
            List<double> Velocity2y = new List<double>();//creates a list for each velocity of ball 2
            Velocity2y.Add(b2.vy);//adds the velocity of ball 2 at time 0
            List<double> Position2x = new List<double>();//creates a list for each of the positions of centre of ball 1
            Position2x.Add(b2.posx);//adds the position at time 0
            List<double> Position2y = new List<double>();//creates a list for each of the positions of centre of ball 1
            Position2y.Add(b2.posy);//adds the position at time 0
            int count = 0;

            //loop for before the balls meet
            count++;//increases the time by one interval
            double s = Math.Sqrt(Math.Pow(b2.posx - b1.posx, 2) + Math.Pow(b2.posy - b1.posy, 2)); //checks the distance between balls
            while (b1.radius + b2.radius > s)
            {
                time.Add(count * 0.01);
                //find new x position of ball 1
                b1.posx = b1.posx + b1.vx * count * 0.01 + 0.5 * b1.ax * Math.Pow (count * 0.01,2);//new x position of ball 1
                Position1x.Add(b1.posx);
                b1.vx = b1.vx + b1.ax * count * 0.01;//finds new x velocity 
                Velocity1x.Add(b1.vx);
                //find new y position of ball 1
                b1.posy = b1.posy + b1.vy * count * 0.01 + 0.5 * b1.ay * Math.Pow(count * 0.01, 2);//new y position of ball 1
                Position1y.Add(b1.posy);
                b1.vy = b1.vy + b1.ay * count * 0.01;//finds new x velocity 
                Velocity1y.Add(b1.vy);
                //find new x position of ball 2
                b2.posx = b2.posx + b2.vx * count * 0.01 + 0.5 * b2.ax * Math.Pow(count * 0.01, 2);//new x position of ball 1
                Position2x.Add(b2.posx);
                b2.vx = b2.vx + b2.ax * count * 0.01;//finds new x velocity 
                Velocity2x.Add(b2.vx);
                //find new y position of ball 1
                b2.posy = b2.posy + b2.vy * count * 0.01 + 0.5 * b2.ay * Math.Pow(count * 0.01, 2);//new y position of ball 1
                Position2y.Add(b2.posy);
                b2.vy = b2.vy + b2.ay * count * 0.01;//finds new x velocity 
                Velocity2y.Add(b2.vy);
                s = Math.Sqrt(Math.Pow(b2.posx - b1.posx, 2) + Math.Pow(b2.posy - b1.posy, 2)); //find new distance between balls
                count++;//increases the time by one interval
            }

            //loop for after balls compress
            for (int i = 0; i < 200; i ++)
            {
                time.Add(count * 0.01);
                //find new x position of ball 1
                b1.posx = b1.posx + b1.vx * count * 0.01 + 0.5 * b1.ax * Math.Pow(count * 0.01, 2);//new x position of ball 1
                Position1x.Add(b1.posx);
                b1.vx = b1.vx + b1.ax * count * 0.01;//finds new x velocity 
                Velocity1x.Add(b1.vx);
                //find new y position of ball 1
                b1.posy = b1.posy + b1.vy * count * 0.01 + 0.5 * b1.ay * Math.Pow(count * 0.01, 2);//new y position of ball 1
                Position1y.Add(b1.posy);
                b1.vy = b1.vy + b1.ay * count * 0.01;//finds new x velocity 
                Velocity1y.Add(b1.vy);
                //find new x position of ball 2
                b2.posx = b2.posx + b2.vx * count * 0.01 + 0.5 * b2.ax * Math.Pow(count * 0.01, 2);//new x position of ball 1
                Position2x.Add(b2.posx);
                b2.vx = b2.vx + b2.ax * count * 0.01;//finds new x velocity 
                Velocity2x.Add(b2.vx);
                //find new y position of ball 1
                b2.posy = b2.posy + b2.vy * count * 0.01 + 0.5 * b2.ay * Math.Pow(count * 0.01, 2);//new y position of ball 1
                Position2y.Add(b2.posy);
                b2.vy = b2.vy + b2.ay * count * 0.01;//finds new x velocity 
                Velocity2y.Add(b2.vy);
                s = Math.Sqrt(Math.Pow(b2.posx - b1.posx, 2) + Math.Pow(b2.posy - b1.posy, 2)); //find new distance between balls
                count++;//increases the time by one interval
            }
        }
    }
}
