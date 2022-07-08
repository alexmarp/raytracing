struct Vec3
{
    private double[] e = new double[3];

    public double x { get { return e[0]; } private set { e[0] = value; } }
    public double y { get { return e[1]; } private set { e[1] = value; } }
    public double z { get { return e[2]; } private set { e[2] = value; } }

    public Vec3(double x, double y, double z)
    {
        e[0] = x;
        e[1] = y;
        e[2] = z;
    }

    public static Vec3 operator +(Vec3 a, Vec3 b) => new (a.x + b.x, a.y + b.y, a.z + b.z);
    public static Vec3 operator -(Vec3 a, Vec3 b) => new (a.x - b.x, a.y - b.y, a.z - b.z);
    public static Vec3 operator *(Vec3 a, Vec3 b) => new (a.x * b.x, a.y * b.y, a.z * b.z);
    public static Vec3 operator *(Vec3 a, double b) => new (a.x * b, a.y * b, a.z * b);
    public static Vec3 operator *(double a, Vec3 b) => new (a * b.x, a * b.y, a * b.z);
    public static Vec3 operator /(Vec3 a, Vec3 b) => new (a.x / b.x, a.y / b.y, a.z / b.z);
    public static Vec3 operator /(Vec3 a, double b) => new (a.x / b, a.y / b, a.z / b);

    public double Lenght() => Math.Sqrt(LenghtSquared());
    public double LenghtSquared() => e[0]*e[0] + e[1]*e[1] + e[2]*e[2];
    public double Dot(Vec3 a, Vec3 b) => a.x * b.x + a.y * b.y + a.z * b.z;
    public Vec3 UnitVector(Vec3 a) => a / a.Lenght();
}

struct Ray
{
    public Vec3 Origin { get; private set; }
    public Vec3 Direction { get; private set; }

    public Ray(Vec3 origin, Vec3 direction)
    {
        Origin = origin;
        Direction = direction.UnitVector(direction);
    }
}

