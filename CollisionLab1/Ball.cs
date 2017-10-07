using System;

namespace CollisionLab1
{
    public class Ball
    {
        public double radius, spring, mass, rotation, angle ;
        public Vector v, s, a;
        public Point pos;
        public Boolean clockwise;
        public Ball(double px,double py, double v1, double a1, double r, double k, double m, double rotate, double angle, Boolean yes)
        {
            v = new Vector(v1, 'v', angle);
            s = new Vector(px, py, angle);
            a = new Vector(a1, 'v', angle);
            pos = new Point(px, py);
            
            this.radius = r;
            this.spring = k;
            this.mass = m;
            this.rotation = rotate;
            this.clockwise = yes;
            //this.angle = Math.Atan(posy / posx);
        }
        
    }
}