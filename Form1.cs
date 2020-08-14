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

            for (int t = 0; t < 5; t++)
            {
                Componente componente = new Componente();
                componente.NombreCol1Atributo = "controles comercialesXX" + t.ToString();
                componente.NombreCol2Estado = "Estado" + t.ToString();
                componente.NombreCol3Observaciones = "OBSERVACIONES / MEDIDAS CORRECTIVAS" + t.ToString();
                componente.NombreCol4Fecha = "FECHA" + t.ToString();
                componente.NombreCol5Nota = "NOTA" + t.ToString();
                componente.NombrePestana = "Pestaña" + t.ToString();

                for (int i = 0; i <= 10; i++) {
                    FilaAttr filaAttr = new FilaAttr() { Id = i, NombreAtributo = "Tablero de indicadores" + i.ToString(), Estado = new EstadoAttr(), Estados = new List<EstadoAttr>(), Fecha = DateTime.Now, Observacion = "ninguna", Nota = 0 + i };
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
            //var gg = MiTabcito1.ListaValoresNotas();
            var dd = dataSourceSimulacion();
            MiTabcito1.ListaDataSource = dd;
            MiTabcito1.ColorCabecera = Color.ForestGreen;
            MiTabcito1.DataBind();

        }



        private List<Componente> dataSourceSimulacion()
        {
            List<Componente> oLista = new List<Componente>();


            DataTable oDT = new DataTable();
            oDT.Columns.Add("CodEvaluacion");
            oDT.Columns.Add("Evaluacion");
            oDT.Columns.Add("CodCriterio");
            oDT.Columns.Add("Criterio");
            oDT.Columns.Add("CodEstado");
            oDT.Columns.Add("Estado");
            oDT.Columns.Add("Nota");

            #region agregadoALista
            /*
            for (int i = 0; i < 5; i++)
            {
            int nro = 0;
                DataRow fila = oDT.NewRow();
                fila[0] = i;
                fila[1] = "Evaluacion "+i.ToString();
                fila[2] = nro;
                fila[3] = "Criterio "+ nro.ToString();
                fila[4] = nro;
                fila[5] = "Si Cumple";
                fila[6] = 10+i;
                oDT.Rows.Add(fila);

                for (int j = 1; j < 6; j++)
                {
                    nro++;
                    int nroEstado = 0;
                    DataRow fila2 = oDT.NewRow();
                    fila2[0] = i;
                    fila2[1] = "Evaluacion " + i.ToString();
                    fila2[2] = nro;
                    fila2[3] = "Criterio " + nro.ToString();
                    fila2[4] = nroEstado;
                    fila2[5] = "Si Cumple";
                    fila2[6] = 10 + i;
                    oDT.Rows.Add(fila2);
                    nroEstado++;
                    for (int k = 0; k < 3; k++) {
                        DataRow fila3 = oDT.NewRow();
                        fila3[0] = i;
                        fila3[1] = "Evaluacion " + i.ToString();
                        fila3[2] = nro;
                        fila3[3] = "Criterio " + nro.ToString();
                        fila3[4] = nroEstado;
                        fila3[5] = "No Cumple";
                        fila3[6] = 10 + i;
                        oDT.Rows.Add(fila3);
                    }
                }
            }
            */
            #endregion


            #region DT_Simulado
            //-----------------------------------------------------EVALUACION 1 - Criterio 1-4
            //Evaluacion1 criterio 1
            DataRow fila = oDT.NewRow();
            fila[0] = "1"; fila[1] = "Evaluacion1"; fila[2] = "1"; fila[3] = "Criterio1"; fila[4] = "0"; fila[5] = "Si cumple"; fila[6] = "10"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "1"; fila[1] = "Evaluacion1"; fila[2] = "1"; fila[3] = "Criterio1"; fila[4] = "1"; fila[5] = "Si Cumple parcialmente"; fila[6] = "11"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "1"; fila[1] = "Evaluacion1"; fila[2] = "1"; fila[3] = "Criterio1"; fila[4] = "2"; fila[5] = "No Cumple"; fila[6] = "11"; oDT.Rows.Add(fila);

            //Evaluacion1 criterio 2

            fila = oDT.NewRow();
            fila[0] = "1"; fila[1] = "Evaluacion1"; fila[2] = "2"; fila[3] = "Criterio2"; fila[4] = "0"; fila[5] = "Si cumple"; fila[6] = "10"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "1"; fila[1] = "Evaluacion1"; fila[2] = "2"; fila[3] = "Criterio2"; fila[4] = "1"; fila[5] = "Si Cumple parcialmente"; fila[6] = "11"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "1"; fila[1] = "Evaluacion1"; fila[2] = "2"; fila[3] = "Criterio2"; fila[4] = "2"; fila[5] = "No Cumple"; fila[6] = "11"; oDT.Rows.Add(fila);


            //Evaluacion1 criterio 3
            fila = oDT.NewRow();
            fila[0] = "1"; fila[1] = "Evaluacion1"; fila[2] = "3"; fila[3] = "Criterio3"; fila[4] = "0"; fila[5] = "Si cumple"; fila[6] = "10"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "1"; fila[1] = "Evaluacion1"; fila[2] = "3"; fila[3] = "Criterio3"; fila[4] = "1"; fila[5] = "Si Cumple parcialmente"; fila[6] = "11"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "1"; fila[1] = "Evaluacion1"; fila[2] = "3"; fila[3] = "Criterio3"; fila[4] = "2"; fila[5] = "No Cumple"; fila[6] = "11";
            oDT.Rows.Add(fila);

            //Evaluacion1 criterio 4
            fila = oDT.NewRow();
            fila[0] = "1"; fila[1] = "Evaluacion1"; fila[2] = "4"; fila[3] = "Criterio4"; fila[4] = "0"; fila[5] = "Si cumple"; fila[6] = "10"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "1"; fila[1] = "Evaluacion1"; fila[2] = "4"; fila[3] = "Criterio4"; fila[4] = "1"; fila[5] = "Si Cumple parcialmente"; fila[6] = "11"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "1"; fila[1] = "Evaluacion1"; fila[2] = "4"; fila[3] = "Criterio4"; fila[4] = "2"; fila[5] = "No Cumple"; fila[6] = "11";
            oDT.Rows.Add(fila);


            //-----------------------------------------------------EVALUACION 2 - Criterio 1-3
            //Evaluacion1 criterio 1
            fila = oDT.NewRow();
            fila[0] = "2"; fila[1] = "Evaluacion2"; fila[2] = "1"; fila[3] = "Criterio1"; fila[4] = "0"; fila[5] = "Si cumple"; fila[6] = "10"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "2"; fila[1] = "Evaluacion2"; fila[2] = "1"; fila[3] = "Criterio1"; fila[4] = "1"; fila[5] = "Si Cumple parcialmente"; fila[6] = "11"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "2"; fila[1] = "Evaluacion2"; fila[2] = "1"; fila[3] = "Criterio1"; fila[4] = "2"; fila[5] = "No Cumple"; fila[6] = "11"; oDT.Rows.Add(fila);

            //Evaluacion1 criterio 2

            fila = oDT.NewRow();
            fila[0] = "2"; fila[1] = "Evaluacion2"; fila[2] = "2"; fila[3] = "Criterio2"; fila[4] = "0"; fila[5] = "Si cumple"; fila[6] = "10"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "2"; fila[1] = "Evaluacion2"; fila[2] = "2"; fila[3] = "Criterio2"; fila[4] = "1"; fila[5] = "Si Cumple parcialmente"; fila[6] = "11"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "2"; fila[1] = "Evaluacion2"; fila[2] = "2"; fila[3] = "Criterio2"; fila[4] = "2"; fila[5] = "No Cumple"; fila[6] = "11"; oDT.Rows.Add(fila);


            //Evaluacion1 criterio 3
            fila = oDT.NewRow();
            fila[0] = "2"; fila[1] = "Evaluacion2"; fila[2] = "3"; fila[3] = "Criterio3"; fila[4] = "0"; fila[5] = "Si cumple"; fila[6] = "10"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "2"; fila[1] = "Evaluacion2"; fila[2] = "3"; fila[3] = "Criterio3"; fila[4] = "1"; fila[5] = "Si Cumple parcialmente"; fila[6] = "11"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "2"; fila[1] = "Evaluacion2"; fila[2] = "3"; fila[3] = "Criterio3"; fila[4] = "2"; fila[5] = "No Cumple"; fila[6] = "11";
            oDT.Rows.Add(fila);

            //-----------------------------------------------------EVALUACION 3 - Criterio 1-2
            //Evaluacion1 criterio 1
            fila = oDT.NewRow();
            fila[0] = "3"; fila[1] = "Evaluacion3"; fila[2] = "1"; fila[3] = "Criterio1"; fila[4] = "0"; fila[5] = "Si cumple"; fila[6] = "10"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "3"; fila[1] = "Evaluacion3"; fila[2] = "1"; fila[3] = "Criterio1"; fila[4] = "1"; fila[5] = "Si Cumple parcialmente"; fila[6] = "11"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "3"; fila[1] = "Evaluacion3"; fila[2] = "1"; fila[3] = "Criterio1"; fila[4] = "2"; fila[5] = "No Cumple"; fila[6] = "11"; oDT.Rows.Add(fila);

            //Evaluacion1 criterio 2

            fila = oDT.NewRow();
            fila[0] = "3"; fila[1] = "Evaluacion3"; fila[2] = "2"; fila[3] = "Criterio2"; fila[4] = "0"; fila[5] = "Si cumple"; fila[6] = "10"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "3"; fila[1] = "Evaluacion3"; fila[2] = "2"; fila[3] = "Criterio2"; fila[4] = "1"; fila[5] = "Si Cumple parcialmente"; fila[6] = "11"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "3"; fila[1] = "Evaluacion3"; fila[2] = "2"; fila[3] = "Criterio2"; fila[4] = "2"; fila[5] = "No Cumple"; fila[6] = "11"; oDT.Rows.Add(fila);


            //-----------------------------------------------------EVALUACION 4 - Criterio 1-4
            //Evaluacion1 criterio 1
            fila = oDT.NewRow();
            fila[0] = "4"; fila[1] = "Evaluacion4"; fila[2] = "1"; fila[3] = "Criterio1"; fila[4] = "0"; fila[5] = "Si cumple"; fila[6] = "10"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "4"; fila[1] = "Evaluacion4"; fila[2] = "1"; fila[3] = "Criterio1"; fila[4] = "1"; fila[5] = "Si Cumple parcialmente"; fila[6] = "11"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "4"; fila[1] = "Evaluacion4"; fila[2] = "1"; fila[3] = "Criterio1"; fila[4] = "2"; fila[5] = "No Cumple"; fila[6] = "11"; oDT.Rows.Add(fila);

            //Evaluacion1 criterio 2

            fila = oDT.NewRow();
            fila[0] = "4"; fila[1] = "Evaluacion4"; fila[2] = "2"; fila[3] = "Criterio2"; fila[4] = "0"; fila[5] = "Si cumple"; fila[6] = "10"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "4"; fila[1] = "Evaluacion4"; fila[2] = "2"; fila[3] = "Criterio2"; fila[4] = "1"; fila[5] = "Si Cumple parcialmente"; fila[6] = "11"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "4"; fila[1] = "Evaluacion4"; fila[2] = "2"; fila[3] = "Criterio2"; fila[4] = "2"; fila[5] = "No Cumple"; fila[6] = "11"; oDT.Rows.Add(fila);


            //Evaluacion1 criterio 3
            fila = oDT.NewRow();
            fila[0] = "4"; fila[1] = "Evaluacion4"; fila[2] = "3"; fila[3] = "Criterio3"; fila[4] = "0"; fila[5] = "Si cumple"; fila[6] = "10"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "4"; fila[1] = "Evaluacion4"; fila[2] = "3"; fila[3] = "Criterio3"; fila[4] = "1"; fila[5] = "Si Cumple parcialmente"; fila[6] = "11"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "4"; fila[1] = "Evaluacion4"; fila[2] = "3"; fila[3] = "Criterio3"; fila[4] = "2"; fila[5] = "No Cumple"; fila[6] = "11";
            oDT.Rows.Add(fila);

            //Evaluacion1 criterio 4
            fila = oDT.NewRow();
            fila[0] = "4"; fila[1] = "Evaluacion4"; fila[2] = "4"; fila[3] = "Criterio4"; fila[4] = "0"; fila[5] = "Si cumple"; fila[6] = "10"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "4"; fila[1] = "Evaluacion4"; fila[2] = "4"; fila[3] = "Criterio4"; fila[4] = "1"; fila[5] = "Si Cumple parcialmente"; fila[6] = "11"; oDT.Rows.Add(fila);
            fila = oDT.NewRow();
            fila[0] = "4"; fila[1] = "Evaluacion4"; fila[2] = "4"; fila[3] = "Criterio4"; fila[4] = "2"; fila[5] = "No Cumple"; fila[6] = "11";
            oDT.Rows.Add(fila);
            #endregion


            //int oCodEvaluacionInicial = Convert.ToInt32(oDT.Rows[0][0].ToString()) ;
            Componente oComponente= new Componente();
            FilaAttr oFila = new FilaAttr();
            DateTime fechaActual= DateTime.Now;

            int oCodEvaluacionInicial =-1 ;
            int oIdCriterioInicial = -1;

            int oPosicionEval = -1;
            int oPosiCriterio = -1;
            for (int i = 0; i < oDT.Rows.Count; i++)
            {

                int oValorEstado = Convert.ToInt32(oDT.Rows[i][4].ToString());
                string oNombre = oDT.Rows[i][5].ToString();
                double oNota = Convert.ToDouble(oDT.Rows[i][6].ToString());



                //detectar cambio de evaluacion / componente
                int oCodEvaluacionActual = Convert.ToInt32(oDT.Rows[i][0].ToString());
                if (oCodEvaluacionInicial != oCodEvaluacionActual)
                {
                    oPosicionEval += 1;
                    oLista.Add(new Componente());
                    oPosiCriterio = -1;
                    oLista[oPosicionEval].NombrePestana = "soy pestaña" + oPosicionEval.ToString();
                }


                EstadoAttr oEstado = new EstadoAttr() { Nombre = oNombre, Valor = oValorEstado, Nota = oNota };


                //detectar cambio de criterio.
                int oIdCriterioActual = Convert.ToInt32(oDT.Rows[i][2].ToString());
                if (oIdCriterioInicial != oIdCriterioActual) {
                    oPosiCriterio += 1;
                    oFila = new FilaAttr
                    {
                        NombreAtributo = oDT.Rows[i][3].ToString(),
                        Fecha= fechaActual
                    };
                    oLista[oPosicionEval].Lista.Add(oFila);
                    //oLista[oPosicionEval].Lista.Add(new FilaAttr());




                }
                oIdCriterioInicial = Convert.ToInt32(oDT.Rows[i][2].ToString());
                
                oCodEvaluacionInicial = Convert.ToInt32(oDT.Rows[i][0].ToString());


                oLista[oPosicionEval].Lista[oPosiCriterio].Estados.Add(oEstado);
                
               


            }
            return oLista;
        }
    }
}
