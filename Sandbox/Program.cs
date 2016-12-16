using System;
namespace Rectangles
{
    class Rectangle
    {
        // member variables
        double length;
        double width;
        public void Acceptdetails()
        {
            length = 4.5;
            width = 3.5;
        }

        public double GetArea()
        {
            return length * width;
        }

        public void Display()
        {
            Console.WriteLine("Length: {0}", length);
            Console.WriteLine("Width: {0}", width);
            Console.WriteLine("Area: {0}", GetArea());
        }
    }

    class DisplayRectangle
    {
        public void OutputDimenstions()
        {
            Rectangle r = new Rectangle();
            r.Acceptdetails();
            r.Display();
            Console.ReadLine();
        }        
    }
}

namespace Matrices
{
    class MatrixOperations
    {
        public bool SymmetricMatrixInvert(double[,] V)
        {
            int N = (int)Math.Sqrt(V.Length);
            double[] t = new double[N];
            double[] Q = new double[N];
            double[] R = new double[N];
            double AB;
            int K, L, M;

            // Invert a symetric matrix in V
            for (M = 0; M < N; M++)
                R[M] = 1;
            K = 0;
            for (M = 0; M < N; M++)
            {
                double Big = 0;
                for (L = 0; L < N; L++)
                {
                    AB = Math.Abs(V[L, L]);
                    if ((AB > Big) && (R[L] != 0))
                    {
                        Big = AB;
                        K = L;
                    }
                }
                if (Big == 0)
                {
                    return false;
                }
                R[K] = 0;
                Q[K] = 1 / V[K, K];
                t[K] = 1;
                V[K, K] = 0;
                if (K != 0)
                {
                    for (L = 0; L < K; L++)
                    {
                        t[L] = V[L, K];
                        if (R[L] == 0)
                            Q[L] = V[L, K] * Q[K];
                        else
                            Q[L] = -V[L, K] * Q[K];
                        V[L, K] = 0;
                    }
                }
                if ((K + 1) < N)
                {
                    for (L = K + 1; L < N; L++)
                    {
                        if (R[L] != 0)
                            t[L] = V[K, L];
                        else
                            t[L] = -V[K, L];
                        Q[L] = -V[K, L] * Q[K];
                        V[K, L] = 0;
                    }
                }
                for (L = 0; L < N; L++)
                    for (K = L; K < N; K++)
                        V[L, K] = V[L, K] + t[L] * Q[K];
            }
            M = N;
            L = N - 1;
            for (K = 1; K < N; K++)
            {
                M = M - 1;
                L = L - 1;
                for (int J = 0; J <= L; J++)
                    V[M, J] = V[J, M];
            }
            return true;
        }
    }

}

namespace Execution
{
    class Runtime
    {
        static void Main()
        {

            // Rectangles.DisplayRectangle display = new Rectangles.DisplayRectangle();
            // display.OutputDimenstions();
            double[,] TestMatrix = new double[2, 2];
            TestMatrix[0, 0] = 1;
            TestMatrix[0, 1] = 2;
            TestMatrix[1, 0] = 3;
            TestMatrix[1, 1] = 5;

            System.Console.WriteLine("Input Matrix:");
            System.Console.WriteLine(TestMatrix[0, 0]);
            System.Console.WriteLine(TestMatrix[0, 1]);
            System.Console.WriteLine(TestMatrix[1, 0]);
            System.Console.WriteLine(TestMatrix[1, 1]);

            Matrices.MatrixOperations m = new Matrices.MatrixOperations();


            if (m.SymmetricMatrixInvert(TestMatrix))
            {
                System.Console.WriteLine("Output Matrix:");
                System.Console.WriteLine(TestMatrix[0, 0]);
                System.Console.WriteLine(TestMatrix[0, 1]);
                System.Console.WriteLine(TestMatrix[1, 0]);
                System.Console.WriteLine(TestMatrix[1, 1]);
            }
            else
            {
                System.Console.WriteLine("Unable to Invert: Input Matrix Singular");
            }
     


            Console.ReadLine();

        }

    }
}