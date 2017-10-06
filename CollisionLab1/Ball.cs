using System;

namespace CollisionLab1
{
    public class Ball
    {
        public double v, posx, posy,  a, radius, spring, mass, rotation, angle ;
        public Boolean clockwise;
        public Ball(double px,double py, double v1, double a1, double r, double s, double m, double rotate, double ang, Boolean yes)
        {
            this.v = v1;
            this.posx = px;
            this.posy = py;
            this.a = a1;
            this.radius = r;
            this.spring = s;
            this.mass = m;
            this.rotation = rotate;
            this.angle = ang;
            this.clockwise = yes;
        }
        
    }
}