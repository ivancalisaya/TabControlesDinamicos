using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;

namespace TabsDataSource
{
    public partial class IvnTab : UserControl
    {

        //List<FilaAttr> TabDS = new List<FilaAttr>();
        public List<Componente> ListaDataSource;
        
        public IvnTab()
        {
            InitializeComponent();
            //llenarTabs();
            //CrearControles();
            //CrearCabecera();
            ListaDataSource = new List<Componente>();
        }

        public IvnTab(List<Componente> pDataSource)
        {
            InitializeComponent();
            //TabDS = pTabDS;
            //llenarTabs();
            //CrearControles();
            //CrearCabecera();
            ListaDataSource = pDataSource;
        }
        public void DataBind() {
            if (ListaDataSource.Count > 0) {
                for (int i = 0; i < ListaDataSource.Count; i++) { 
                    TabPage tab = new TabPage();
                    tab.Tag = i;
                    //tabControl1.Controls.Add(tab);
                    CrearTabYCabecera(tab, ListaDataSource[i]);
                    CrearControles(i,tab, ListaDataSource[i]);
                }
            }
        }
        private void CrearControles(int pNroTab, TabPage pTabPage, Componente pComponente) {


            int oNroFilas = pComponente.Lista.Count;
            


            Label[] Col1Labels = null;
            ComboBox[] Col2Combos=null;
            TextBox[] Col3Textbox=null;
            DateTimePicker[] Col4DtPicker=null;
            Label[] Col5Labels=null;

            DeclararControlesFila(oNroFilas, ref Col1Labels, ref Col2Combos,ref Col3Textbox,ref Col4DtPicker,ref Col5Labels);
            EstablecerCaracteristicasFila(pNroTab, oNroFilas, ref Col1Labels, ref Col2Combos, ref Col3Textbox, ref Col4DtPicker, ref Col5Labels);
            CargarDatosAControles(pNroTab, pComponente, ref Col1Labels, ref Col2Combos, ref Col3Textbox, ref Col4DtPicker, ref Col5Labels);
            AgregarControlesATabPage(oNroFilas, ref pTabPage, ref Col1Labels, ref Col2Combos, ref Col3Textbox, ref Col4DtPicker, ref Col5Labels);

            

            /*
            for (int i = 0; i < comboBox1.Items.Count; i++) { 
            var intt= TextRenderer.MeasureText(comboBox1.GetItemText(comboBox1.Items[i].ToString()), comboBox1.Font).Width;
                comboBox1.DropDownWidth = intt;
            }
            */



        }

        private void DeclararControlesFila(int pNroFilas, ref Label[] pLabelCol1,  ref ComboBox[] pCombosCol2, 
            ref TextBox[] pTextCol3, ref DateTimePicker[] pDtPickerCol4, ref Label[] pLabelCol5 ) {
            pLabelCol1 = new Label[pNroFilas];
            pCombosCol2 = new ComboBox[pNroFilas];
            pTextCol3 = new TextBox[pNroFilas];
            pDtPickerCol4 = new DateTimePicker[pNroFilas];
            pLabelCol5 = new Label[pNroFilas];

            for (int i = 0; i < pNroFilas; i++) {
                pLabelCol1[i] = new Label();
                pCombosCol2[i] = new ComboBox();
                pTextCol3[i] = new TextBox();
                pDtPickerCol4[i] = new DateTimePicker();
                pLabelCol5[i] = new Label();
            }

        }

        private void EstablecerCaracteristicasFila(int pNroTab, int pNroFilas, ref Label[] pLabelCol1, ref ComboBox[] pCombosCol2,
            ref TextBox[] pTextCol3, ref DateTimePicker[] pDtPickerCol4, ref Label[] pLabelCol5) {
            int[] PosX = new int[] { 10, 172, 270, 535, 664 };
            int[] PosY = new int[] { 41, 41, 41, 41, 41 };
            int NuevoY = 0;
            for (int i = 0; i < pNroFilas; i++) {
                //label de col1
                pLabelCol1[i].Tag = (string.Format("{0}-{1}",pNroTab,i));
                pLabelCol1[i].AutoSize = false;
                pLabelCol1[i].Width = 157;
                pLabelCol1[i].Height = 20;
                pLabelCol1[i].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                pLabelCol1[i].Text = "Label" + i.ToString();
                pLabelCol1[i].Location = new Point(PosX[0], PosY[0]+NuevoY);
                pLabelCol1[i].Name = string.Format("LblCriterio{0}{1}",pNroTab,i);
                //combo de col2
                pCombosCol2[i].Tag = (string.Format("{0}-{1}",pNroTab,i));
                pCombosCol2[i].AutoSize = false;
                pCombosCol2[i].Width = 90;
                pCombosCol2[i].Height = 20;
                pCombosCol2[i].DropDownStyle = ComboBoxStyle.DropDownList;
                pCombosCol2[i].Location = new Point(PosX[1], PosY[1] + NuevoY);
                pCombosCol2[i].Name = string.Format("CboEstado{0}{1}", pNroTab, i);
                pCombosCol2[i].SelectionChangeCommitted += ComboEstadoChangeCommitted;
                //textbox de col3
                pTextCol3[i].Tag = (string.Format("{0}-{1}",pNroTab,i));
                pTextCol3[i].AutoSize = false;
                pTextCol3[i].Width = 260;
                pTextCol3[i].Height = 20;
                pTextCol3[i].Location = new Point(PosX[2], PosY[2] + NuevoY);
                pTextCol3[i].Name = string.Format("TxtComentario{0}{1}", pNroTab, i);
                pTextCol3[i].TextChanged += TextComentario_TextChanged;
                //data picker de col4
                pDtPickerCol4[i].Tag = (string.Format("{0}-{1}",pNroTab,i));
                pDtPickerCol4[i].AutoSize = false;
                pDtPickerCol4[i].Width = 123;
                pDtPickerCol4[i].Height = 20;
                pDtPickerCol4[i].Format = DateTimePickerFormat.Short;
                pDtPickerCol4[i].Location = new Point(PosX[3], PosY[3] + NuevoY);
                pDtPickerCol4[i].Name = string.Format("DtpFecha{0}{1}", pNroTab, i);
                //label de Nota de col5
                pLabelCol5[i].Tag = (string.Format("{0}-{1}",pNroTab,i));
                pLabelCol5[i].AutoSize = false;
                pLabelCol5[i].Width = 40;
                pLabelCol5[i].Height = 20;
                pLabelCol5[i].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                pLabelCol5[i].Text = "10.0" + i.ToString();
                pLabelCol5[i].Location = new Point(PosX[4], PosY[4] + NuevoY);
                pLabelCol5[i].Name = string.Format("LblNota{0}{1}", pNroTab, i);


                NuevoY += 25;
            }
        }

        

        private void CargarDatosAControles(int pNroTab, Componente pComponente,ref Label[] pCol1Labels, ref ComboBox[] pCol2Combos, ref TextBox[] pCol3Textboxes, ref DateTimePicker[] pCol4DtPickers, ref Label[] pCol5Labels) {

            for (int i = 0; i < pComponente.Lista.Count; i++) {
                
                pCol1Labels[i].Text = pComponente.Lista[i].NombreAtributo;
                
                for (int j = 0; j < pComponente.Lista[i].Estados.Count; j++) {
                    pCol2Combos[i].Items.Add(new EstadoAttr() { Valor= pComponente.Lista[i].Estados[j].Valor, Nombre= pComponente.Lista[i].Estados[j].Nombre} );

                }
                pCol2Combos[i].ValueMember = "Valor"; pCol2Combos[i].DisplayMember = "Nombre";

                pCol3Textboxes[i].Text = pComponente.Lista[i].Observacion;
                pCol4DtPickers[i].Value = pComponente.Lista[i].Fecha;
                pCol5Labels[i].Text = pComponente.Lista[i].Nota.ToString();

                
            }


             


            /*
             for (int i = 0; i < pCombosCol2.Length; i++) {
                for (int j = 0; j < pComponente.Lista[].Estados.Count; j++) {
                    pCombosCol2[i].Items.Add(new EstadoAttr(){Nombre=pComponente.Estados[j].Nombre , Valor= pComponente.Estados[j].Valor });
                    
                }
            pCombosCol2[i].DropDownWidth = 200;
                pCombosCol2[i].DisplayMember = "Nombre";
                pCombosCol2[i].ValueMember = "Valor";

            }
            */

        }
        private void AgregarControlesATabPage(int pNroFilas, ref TabPage pTabPagex,  ref Label[] pLabelCol1, ref ComboBox[] pCombosCol2,
            ref TextBox[] pTextCol3, ref DateTimePicker[] pDtPickerCol4, ref Label[] pLabelCol5)
        {
            
            for (int i = 0; i < pNroFilas; i++)
            {
                pTabPagex.Controls.Add(pLabelCol1[i]);
                pTabPagex.Controls.Add(pCombosCol2[i]);
                pTabPagex.Controls.Add(pTextCol3[i]);
                pTabPagex.Controls.Add(pDtPickerCol4[i]);
                pTabPagex.Controls.Add(pLabelCol5[i]);
            }
        }
        private void CrearTabs(List<Componente> pComponentes) {
            
            foreach (var tp in tabControl1.TabPages) {
                var tpp = (TabPage)tp;
                foreach (var control in tpp.Controls) { 
                    if (control.GetType() == typeof(Label)) {
                        var miLabel = new Label();
                        miLabel = (Label)control;
                        MessageBox.Show(miLabel.Text);

                    }
                }
            }
        }
        private void CrearTabYCabecera( TabPage pTab, Componente pComponente) {

            Label lblTitulo1 = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = Color.White,
                Location = new Point(3, 10),
                Name = "labelTb1" + pTab.Tag,
                Size = new Size(152, 13),
                TabIndex = 1,
                Text = pComponente.NombreCol1Atributo,
                 
            };
           

            Label lblTitulo2 = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = Color.White,
                Location = new Point(187, 10),
                Name = "labelTb2" + pTab.Tag,
                Size = new Size(51, 13),
                TabIndex = 5,
                Text = pComponente.NombreCol2Estado
            };
            Label lblTitulo3 = new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = Color.White,
                Location = new Point(264, 10),
                Name = "labelTb3" + pTab.Tag,
                Size = new Size(237, 13),
                TabIndex = 2,
                Text = pComponente.NombreCol3Observaciones
            };
            Label lblTitulo4 = new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = Color.White,
                Location = new Point(553, 10),
                Name = "labelTb4" + pTab.Tag,
                Size = new Size(42, 13),
                TabIndex = 4,
                Text = pComponente.NombreCol4Fecha
            };
            Label lblTitulo5 = new Label
            {
                AutoSize = true,
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))),
                ForeColor = Color.White,
                Location = new Point(659, 10),
                Name = "labelTb5" + pTab.Tag,
                Size = new Size(37, 13),
                TabIndex = 3,
                Text = pComponente.NombreCol5Nota
            };

            Panel pnlTitulos = new Panel
            {
                BackColor =  Color.SlateGray,
                Dock = DockStyle.Top,
                Location = new Point(3, 3),
                Name = "panelTb1" + pTab.Tag,
                Size = new Size(717, 32),
                TabIndex = 0
            };

            pnlTitulos.Controls.Add(lblTitulo1);
            pnlTitulos.Controls.Add(lblTitulo2);
            pnlTitulos.Controls.Add(lblTitulo3);
            pnlTitulos.Controls.Add(lblTitulo4);
            pnlTitulos.Controls.Add(lblTitulo5);
            pnlTitulos.ResumeLayout(false);
            pnlTitulos.PerformLayout();
            
             
            pTab.AutoScroll = true;
            pTab.BackColor = Color.Transparent;
            pTab.Controls.Add(pnlTitulos);
            /*pTab.Controls.Add(this.dateTimePicker1);
            pTab.Controls.Add(this.textBox1);
            pTab.Controls.Add(this.label6);
            pTab.Controls.Add(this.comboBox1);
            pTab.Controls.Add(this.panel1);*/
            pTab.Location = new Point(4, 22);
            //pTab.Name = "tabPage1";
            pTab.Padding = new System.Windows.Forms.Padding(3);
            pTab.Size = new Size(723, 287);
            //pTab.TabIndex = 0;
            //pTab.Text = "tabPage1";
            pTab.ResumeLayout(false);
            pTab.PerformLayout();

            pTab.Text = pComponente.NombrePestana;


            /*
            Panel panelCabecera = new Panel();
            panelCabecera.BackColor = Color.SlateGray;
            panelCabecera.Dock = DockStyle.Top;
            */
            tabControl1.TabPages.Add(pTab);

        }


        private void ComboEstadoChangeCommitted(Object sender, System.EventArgs e) {
            //_ = new ComboBox();
            //ComboBox cbo = (ComboBox)sender;
            string correlativoCtl = ((ComboBox)sender).Name.Substring(9, ((ComboBox)sender).Name.Length - 9);
            int tabTag = Convert.ToInt32(((ComboBox)sender).Tag.ToString().Split('-')[0]);
            int indextag= Convert.ToInt32(((ComboBox)sender).Tag.ToString().Split('-')[1]);
            var lblNota = (Label)tabControl1.TabPages[tabTag].Controls["LblNota" + correlativoCtl];
            lblNota.Text = ((TabsDataSource.EstadoAttr)((ComboBox)sender).SelectedItem).Valor.ToString();

            ListaDataSource[tabTag].Lista[indextag].Estado.Nombre = ((TabsDataSource.EstadoAttr)((ComboBox)sender).SelectedItem).Nombre;
            ListaDataSource[tabTag].Lista[indextag].Estado.Valor = ((TabsDataSource.EstadoAttr)((ComboBox)sender).SelectedItem).Valor;
            //ListaDataSource[tabTag].Lista[indextag].Estado.Nota = ((TabsDataSource.EstadoAttr)cbo.SelectedItem).Nota;

            //var ddd = ListaDataSource;

        }

        private void TextComentario_TextChanged(object sender, EventArgs e)
        {

            int tabTag = Convert.ToInt32( ((TextBox)sender).Tag.ToString().Split('-')[0]);
            int indextag = Convert.ToInt32( ((TextBox)sender).Tag.ToString().Split('-')[1]);
            ListaDataSource[tabTag].Lista[indextag].Observacion = ((TextBox)sender).Text;

            var ddd = ListaDataSource;
        }

        public List<Componente> ObtenerDatos() {
             
            return ListaDataSource;

        }

    }
}
