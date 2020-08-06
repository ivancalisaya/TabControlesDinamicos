using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TabsDataSource
{
    public class FilaAttr
    {
        public FilaAttr()
        {
            Estado = new EstadoAttr();
            //Estados = new List<EstadoAttr>();
        }

        public int Id { get; set; }
        public string NombreAtributo { get; set; }
        public EstadoAttr Estado { get; set; }

        public string Observacion { get; set; }

        public DateTime Fecha { get; set; }

        public double Nota { get; set; }
        //public List<EstadoAttr> Estados { get; set; }


    }
}
