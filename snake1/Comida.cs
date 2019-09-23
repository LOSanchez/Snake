using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake1
{
    class Comida : objeto
    {

        public Comida()
        {
            this.x = generar(77);
            this.y = generar(37);
        }
        public void dibujar(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Red), this.x, this.y, this.espacio, this.espacio);
        }
        public void colocar()
        {
            this.x = generar(77);
            this.y = generar(37);
        }
        public int generar(int n)
        {
            Random random = new Random();
            int num = random.Next(0, n) * 10;
            return num;
        }
    }
}