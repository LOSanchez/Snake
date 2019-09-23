using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake1
{
    class objeto
    {
        protected int x, y, espacio;
        public objeto()
        {
            espacio = 10;
        }
        public Boolean interseccion(objeto o)
        {
            int difx = Math.Abs(this.x - o.x);
            int dify = Math.Abs(this.y - o.y);
            if (difx >= 0 && difx < espacio && dify >= 0 && dify < espacio)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}