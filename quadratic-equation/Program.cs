using System;

public class QuadraticEquation
{
    public static Tuple<double, double> FindRoots(double a, double b, double c)
    {
        double root1 = (-b + Math.Sqrt((b * b) - (4 * a * c))) / (2 * a);
        double root2 = (-b - Math.Sqrt((b * b) - (4 * a * c))) / (2 * a);
        return Tuple.Create(root1, root2);
    }

    public static void Main(string[] args)
    {
        Tuple<double, double> roots = QuadraticEquation.FindRoots(2, 10, 8);
        Console.WriteLine("Roots: " + roots.Item1 + ", " + roots.Item2);

        Console.ReadKey();
    }
}


