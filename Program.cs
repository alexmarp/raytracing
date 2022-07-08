using Point3 = Vec3;
using Color = Vec3;

//IMAGE
double aspectRatio = 16.0 / 9.0;
int imHeight = 400;
int imWidth = (int)(imHeight * aspectRatio);

//CAMERA
double viewPortHeight = 2.0;
double viewPortWidth = viewPortHeight * aspectRatio;
double focalLenght = 1.0;
var horizontal = new Point3(viewPortWidth, 0.0, 0.0);
var vertical = new Vec3(0.0, viewPortHeight, 0.0);
var origin = new Vec3(0.0, 0.0, 0.0);
Vec3 lowerLeftCorner = origin - horizontal/2 - vertical/2 - new Vec3(0.0, 0.0, focalLenght);


//RENDER
string path = Path.GetFullPath($"rendered{Path.DirectorySeparatorChar}image1.ppm");

Color RayColor(Ray r)
{
    var t = 0.5 * (r.Direction.y + 1.0);
    return (1.0-t) * new Color(1.0, 1.0, 1.0) + t * new Color(0.5, 0.7, 1.0);
}

using (StreamWriter s = File.CreateText(path))
{
    s.WriteLine("P3");
    s.WriteLine(imWidth + " " + imHeight);
    s.WriteLine("255");
    for (int y = imHeight-1; y >= 0; y--)
    {
        for (int x = 0; x < imWidth; x++)
        {
            // double r = (double)x / imWidth;
            // double g = (double)y / imHeight;
            // double b = 0.25;

            // int ir = (int)(255 * r);
            // int ig = (int)(255 * g);
            // int ib = (int)(255 * b);

            var u = (double)x / imWidth;
            var v = (double)y / imHeight;
            var dir = lowerLeftCorner + u*horizontal + v*vertical - origin;
            var r = new Ray(origin, dir);
            Color pixelColor = RayColor(r);

            s.WriteLine((int)(pixelColor.x * 255) + " " + (int)(pixelColor.y * 255) + " " + (int)(pixelColor.z * 255));
        }
    }
    s.Flush();
    s.Close();
}