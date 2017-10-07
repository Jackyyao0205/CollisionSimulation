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

            //collision for 1d head on motionless
            /*double b1vi = b1.v, b2vi = b2.v;
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
            }*/

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
    }
}
