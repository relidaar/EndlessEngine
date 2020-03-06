using System.Collections.Generic;
using System.Linq;

namespace EndlessEngine.Graphics.DataTypes
{
    public struct Vertex2
    {
        public float[] Data { get; private set; }

        public Vertex2(float a1, float a2)
        {
            Data = new[] {a1, a2};
        }

        private Vertex2(IEnumerable<float> data)
        {
            Data = data.ToArray();
        }
            
        public Vertex2(in Vertex2 v)
        {
            Data = v.Data.ToArray();
        }

        public Vertex2 Add(in Vertex2 v)
        {
            var result = Data.Zip(v.Data, (a1, a2) => a1 + a2);
            return new Vertex2(result);
        }

        public static Vertex2 operator +(Vertex2 v1, in Vertex2 v2)
        {
            return v1.Add(v2);
        }

        public Vertex2 Subtract(in Vertex2 v)
        {
            var result = Data.Zip(v.Data, (a1, a2) => a1 - a2);
            return new Vertex2(result);
        }

        public static Vertex2 operator -(Vertex2 v1, Vertex2 v2)
        {
            return v1.Subtract(v2);
        }
    }
}