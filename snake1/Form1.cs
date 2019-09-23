using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake1
{
    public partial class Form1 : Form
    {
        Graphics juego;
        Cola cabeza;
        Comida comida;
        int espacio;
        int xdir = 0, ydir = 0;
        int puntaje = 0;
        Boolean ejex = true, ejey = true;
        public Form1()
        {
            espacio = 10;
            InitializeComponent();
            juego = canvas.CreateGraphics();
            cabeza = new Cola(10, 10);
            comida = new Comida();
        }
        public void findeJuego()
        {
            xdir = 0;
            ydir = 0;
            puntaje = 0;
            puntos.Text = "0";
            ejex = true;
            ejey = true;
            cabeza = new Cola(10, 10);
            comida = new Comida();
            MessageBox.Show("Perdiste");
        }
        public void choqueCuerpo()
        {
            Cola temp;
            try
            {
                temp = cabeza.verSiguiente().verSiguiente();
            }
            catch (Exception)
            {
                temp = null;
            }
            while (temp != null)
            {
                if (cabeza.interseccion(temp))
                {
                    findeJuego();
                }
                else
                {
                    temp = temp.verSiguiente();
                }
            }
        }

        public void choquePared()
        {
            if (cabeza.getX() < 0 || cabeza.getX() > 760 || cabeza.getY() < 0 || cabeza.getY() > 360)
            {
                findeJuego();
            }
        }

        public void dibujar()
        {
            juego.Clear(Color.White);
            cabeza.dibujar(juego);
            comida.dibujar(juego);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (ejex)
            {
                if (e.KeyCode == Keys.Up)
                {
                    ydir = -espacio;
                    xdir = 0;
                    ejex = false;
                    ejey = true;
                }
                if (e.KeyCode == Keys.Down)
                {
                    ydir = espacio;
                    xdir = 0;
                    ejex = false;
                    ejey = true;
                }
            }
            if (ejey)
            {
                if (e.KeyCode == Keys.Right)
                {
                    ydir = 0;
                    xdir = espacio;
                    ejex = true;
                    ejey = false;
                }
                if (e.KeyCode == Keys.Left)
                {
                    ydir = 0;
                    xdir = -espacio;
                    ejex = true;
                    ejey = false;
                }
            }
        }

        public void movimiento()
        {
            cabeza.setxy(cabeza.getX() + xdir, cabeza.getY() + ydir);
        }

        private void bucle_Tick(object sender, EventArgs e)
        {
            dibujar();
            movimiento();
            choqueCuerpo();
            choquePared();
            if (cabeza.interseccion(comida))
            {
                comida.colocar();
                cabeza.meter();
                puntos.Text = (puntaje++).ToString();
            }
        }
    }
}
