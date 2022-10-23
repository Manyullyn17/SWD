namespace satellite
{
    public class Par
    {
        public const int ITER_PER_TICK = 50; // 50
        public const double DT = 1.0 / (double)ITER_PER_TICK;
        public const double EPS_V = 1E-3;
        public const double COLLIDE_DIST = 25;
        // public const double EARTH_ACCEL = 1E3 / ITER_PER_TICK; // 0.2
        public const double EARTH_ACCEL = 50E3 * DT; // 0.2
        public const double ENGINE_ACCEL = 0.005;
    }
}
