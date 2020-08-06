using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TabsDataSource
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Componente> componentes = new List<Componente>();

            for (int t = 0; t <3; t++)
            {
                Componente componente = new Componente();
                componente.NombreCol1Atributo = "controles comercialesXX"+t.ToString();
                componente.NombreCol2Estado = "Estado" + t.ToString();
                componente.NombreCol3Observaciones = "OBSERVACIONES / MEDIDAS CORRECTIVAS"+t.ToString();
                componente.NombreCol4Fecha = "FECHA" + t.ToString();
                componente.NombreCol5Nota = "NOTA" + t.ToString();
                componente.NombrePestana = "Pestaña"+t.ToString();
                
                componente.Estados.Add(new EstadoAttr() { Nombre = "Cumple", Valor = 10 });
                componente.Estados.Add(new EstadoAttr() { Nombre = "Si cumple parcialmente", Valor = 11 });
                componente.Estados.Add(new EstadoAttr() { Nombre = "No Cumple", Valor = 12 });

                for (int i = 0; i <= 10; i++) { 
                    FilaAttr filaAttr = new FilaAttr() { Id=i, NombreAtributo="Tablero de indicadores actualizado"+i.ToString(), Estado= new EstadoAttr() , Fecha= DateTime.Now, Observacion="ninguna", Nota=10.50+i };
                    componente.Lista.Add(filaAttr);
                }
                componentes.Add(componente);
            }

            ivnTab1.ListaDataSource = componentes;
            ivnTab1.DataBind();
        }
    }
}
