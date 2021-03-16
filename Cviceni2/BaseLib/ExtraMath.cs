using System;

namespace Fei
{
    namespace BaseLib
    {
        
        public class ExtraMath
        {
            public bool KvadratickaRovnice(double a, double b, double c, out double? x1, out double? x2)
            {
                x1 = null;
                x2 = null;
                
                double d = Math.Pow(b, 2) - 4 * a * c;

                if (d < 0 ) return false;
                

                x1 = (-b - Math.Sqrt(d)) / (2 * a); 
                x2 = (-b + Math.Sqrt(d)) / (2 * a);

                return true;
                
            }
        }
    }
}