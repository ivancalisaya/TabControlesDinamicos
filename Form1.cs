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

            List<EstadoAttr> estados = new List<EstadoAttr>
            {
                new EstadoAttr() { Valor = 1, Nombre = "Si cumple parcialmente", Nota=11 },
                new EstadoAttr() { Valor = 2, Nombre = "No Cumple", Nota=12 },
                new EstadoAttr() { Valor = 3, Nombre = "Cumple", Nota=13 }
            };

            for (int t = 0; t <5; t++)
            {
                Componente componente = new Componente();
                componente.NombreCol1Atributo = "controles comercialesXX"+t.ToString();
                componente.NombreCol2Estado = "Estado" + t.ToString();
                componente.NombreCol3Observaciones = "OBSERVACIONES / MEDIDAS CORRECTIVAS"+t.ToString();
                componente.NombreCol4Fecha = "FECHA" + t.ToString();
                componente.NombreCol5Nota = "NOTA" + t.ToString();
                componente.NombrePestana = "Pestaña"+t.ToString();
                
                for (int i = 0; i <= 10; i++) {
                    FilaAttr filaAttr = new FilaAttr() { Id = i, NombreAtributo = "Tablero de indicadores" + i.ToString(), Estado = new EstadoAttr(), Estados = new List<EstadoAttr>() , Fecha= DateTime.Now, Observacion="ninguna", Nota=0+i };
                    for (int j = 0; j < estados.Count; j++) {
                        filaAttr.Estados.Add(estados[j]);
                    }
                    componente.Lista.Add(filaAttr);
                }
                ///componente.VisibleCol5Nota = false;
                componente.VisibleCol3Observaciones = (t % 2 == 0);
                componentes.Add(componente);
                
            }
             
            MiTabcito1.ListaDataSource = componentes;
            MiTabcito1.ColorCabecera = Color.ForestGreen;
            MiTabcito1.DataBind();
            
            
        }

         

        private void button1_Click(object sender, EventArgs e)
        {
            //e MessageBox.Show(  MiTabcito1.ListaDataSource[0].ObtenerSumatoriaNotasSeleccionadas().ToString());
            var gg = MiTabcito1.ListaValoresNotas();

        }
    }
}
