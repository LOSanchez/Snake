﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace snake1
{
    class Cola : objeto
    {
        Cola siguiente;
        public Cola(int x, int y)
        {
            this.x = x;
            this.y = y;
            siguiente = null;
        }
        public void dibujar(Graphics g)
        {
            if (siguiente != null)
            {
                siguiente.dibujar(g);
            }
            g.FillRectangle(new SolidBrush(Color.Blue), this.x, this.y, this.espacio, this.espacio);
        }
        public void setxy(int x, int y)
        {
            if (siguiente != null)
            {
                siguiente.setxy(this.x, this.y);
            }
            this.x = x;
            this.y = y;
        }
        public void meter()
        {
            if (siguiente == null)
            {
                siguiente = new Cola(this.x, this.y);
            }
            else
            {
                siguiente.meter();
            }
        }
        public int getX()
        {
            return this.x;
        }
        public int getY()
        {
            return this.y;
        }
        public Cola verSiguiente()
        {
            return siguiente;
        }
    }
}