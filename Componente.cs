using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabsDataSource
{
    public class Componente
    {
        public Componente()
        {
            NombreCol1Atributo = "NombreCol1Atributo";
            NombreCol2Estado = "NombreCol2Estado";
            NombreCol3Observaciones = "NombreCol3Observaciones";
            NombreCol4Fecha = "NombreCol4Fecha";
            NombreCol5Nota = "NombreCol5Nota";
           
            Lista = new List<FilaAttr>();

            VisiblePestana = true;
            VisibleCol1Atributo =true;
            VisibleCol2Estado =true;
            VisibleCol3Observaciones =true;
            VisibleCol4Fecha =true;
            VisibleCol5Nota =true;


        }
        public string NombrePestana { get; set; }
        public string NombreCol1Atributo { get; set; }
        public string NombreCol2Estado { get; set; }
        public string NombreCol3Observaciones { get; set; }
        public string NombreCol4Fecha { get; set; }
        public string NombreCol5Nota { get; set; }

        public List<FilaAttr> Lista { get; set; }

        public Boolean VisiblePestana { get; set; }
        public Boolean VisibleCol1Atributo { get; set; }
        public Boolean VisibleCol2Estado { get; set; }
        public Boolean VisibleCol3Observaciones { get; set; }
        public Boolean VisibleCol4Fecha { get; set; }
        public Boolean VisibleCol5Nota { get; set; }

        

    }
}
