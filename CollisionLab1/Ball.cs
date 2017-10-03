namespace CollisionLab1
{
    public class Ball
    {
        public double v, pos,  a, radius, spring, mass;
        public Ball(double p1,  double v1,  double a1,  double r, double s, double m)
        {
            this.v = v1;
            this.pos = p1;
            this.a = a1;
            this.radius = r;
            this.spring = s;
            this.mass = m;
        }
        public double getposx()
        {
            return pos;
        }
        public double getvx()
        {
            return v;
        }
        public double getax()
        {
            return a;
        }
        public double getradius()
        {
            return radius;
        }
        public double getspring()
        {
            return spring;
        }
    }
}