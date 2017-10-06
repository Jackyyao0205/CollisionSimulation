using System;

namespace CollisionLab1
{
    public class Ball
    {
        public double vx,vy, posx, posy,  ax, ay, radius, spring, mass, rotation, angle ;
        public Boolean clockwise;
        public Ball(double px,double py, double v1, double a1, double r, double s, double m, double rotate, double ang, Boolean yes)
        {
            this.vx = v1*Math.Cos(ang);
            this.vy = v1 * Math.Sin(ang);
            this.posx = px;
            this.posy = py;
            this.ax = a1*Math.Cos(ang);
            this.ay = a1 * Math.Sin(ang);
            this.radius = r;
            this.spring = s;
            this.mass = m;
            this.rotation = rotate;
            this.clockwise = yes;
        }
        
    }
}