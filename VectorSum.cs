using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public struct Vector
    {
        public float startX;
        public float startY;
        public float endX;
        public float endY;

        public Vector(float endX, float endY, float startX, float startY)
        {
            this.startX = startX;
            this.startY = startY;
            this.endX = endX;
            this.endY = endY;
        }

        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v2.endX, v2.endY, v1.startX, v2.startY);
        }
    }
    public class VectorSum
    {
       public VectorSum()
        {
            Vector vectorA = new Vector(4, 4, 0, 0);

            Vector vectorB = new Vector(4, 8, 4, 4);

            Vector vectorAB = vectorA + vectorB;

            Console.WriteLine("sākums: (" + vectorAB.startX + "; " + vectorAB.startY + ") " + "beigas: (" + vectorAB.endX + "; " +vectorAB.endY + ")");
        }
        
        
    }
}
