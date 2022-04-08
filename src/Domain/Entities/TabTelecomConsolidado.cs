using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class TabTelecomConsolidado : Entity
    {
        public int Id { get; set; }       //usando gui e necessario deixar essa coluna
        public DateTime Dia { get; set; }
        public int Fila { get; set; }
        public string Terminator { get; set; }
        public string StatusInicial { get; set; }
        public string StatusFinal { get; set; }
        public int Disparos { get; set; }
        public decimal Custo { get; set; }
        public string Servidor { get; set; }
    }
}
