using System.Collections.Generic;
using System.Linq;

namespace EndlessEngine.Graphics.DataTypes
{
    public struct Vertex3
    {
        public float[] Data { get; }

        public Vertex3(float a1, float a2, float a3)
        {
            Data = new[] {a1, a2, a3};
        }

        private Vertex3(IEnumerable<float> data)
        {
            Data = data.ToArray();
        }
            
        public Vertex3(in Vertex3 v)
        {
            Data = v.Data.ToArray();
        }

        public Vertex3 Add(in Vertex3 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 + x2);
            return new Vertex3(result);
        }

        public static Vertex3 operator +(Vertex3 v1, in Vertex3 v2)
        {
            return v1.Add(v2);
        }

        public Vertex3 Subtract(in Vertex3 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 - x2);
            return new Vertex3(result);
        }

        public static Vertex3 operator -(Vertex3 v1, Vertex3 v2)
        {
            return v1.Subtract(v2);
        }
    }
}