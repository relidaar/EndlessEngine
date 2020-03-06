using System.Collections.Generic;
using System.Linq;

namespace EndlessEngine.Graphics.DataTypes
{
    public struct Vertex2
    {
        public IEnumerable<float> Data => _data;
        private readonly float[] _data;

        public Vertex2(float a1, float a2)
        {
            _data = new[] {a1, a2};
        }

        private Vertex2(IEnumerable<float> data)
        {
            _data = data.ToArray();
        }
            
        public Vertex2(in Vertex2 v)
        {
            _data = v.Data.ToArray();
        }

        public Vertex2 Add(in Vertex2 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 + x2);
            return new Vertex2(result);
        }

        public static Vertex2 operator +(Vertex2 v1, in Vertex2 v2)
        {
            return v1.Add(v2);
        }

        public Vertex2 Subtract(in Vertex2 v)
        {
            var result = Data.Zip(v.Data, (x1, x2) => x1 - x2);
            return new Vertex2(result);
        }

        public static Vertex2 operator -(Vertex2 v1, Vertex2 v2)
        {
            return v1.Subtract(v2);
        }
    }
}