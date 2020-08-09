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
            NombreCol1Atributo = "NombreColAtributo";
            NombreCol2Estado = "Estado";
            NombreCol3Observaciones = "Observaciones/Medidas correctivas";
            NombreCol4Fecha = "Fecha";
            NombreCol5Nota = "Nota";
           
            Lista = new List<FilaAttr>();

        }
        public string NombrePestana { get; set; }
        public string NombreCol1Atributo { get; set; }
        public string NombreCol2Estado { get; set; }
        public string NombreCol3Observaciones { get; set; }
        public string NombreCol4Fecha { get; set; }
        public string NombreCol5Nota { get; set; }

        public List<FilaAttr> Lista { get; set; }
       
       

    }
}
