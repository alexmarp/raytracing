class Sphere
{
    public Vec3 Center { get; private set; }
    public double Radius { get; private set; }

    public Sphere(Vec3 center, double radius)
    {
        Center = center;
        Radius = radius;
    }
    
    public static bool Hit(Sphere sphere, Ray ray)
    {
        var a = ray.Direction.LenghtSquared();
        var oc = sphere.Center - ray.Origin;
        var b = 2.0 * ray.Direction.Dot(ray.Direction, oc);
        var c = oc.LenghtSquared() - Math.Pow(sphere.Radius, 2);
        var discriminant = b*b - 4*a*c;

        if (discriminant <= 0)
        {
            return false;
        }
        return true;
    }
}
