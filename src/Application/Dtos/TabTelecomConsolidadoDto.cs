using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class TabTelecomConsolidadoDto
    {
        public int Id { get; set; }    
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


/*
[DataType(DataType.Date)]
[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")] //"{0:MM/dd/yyyy}"


[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")] // "{0:yyyy-MM-dd}"

[Display(Name = "Date")]
[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
[DataType(DataType.Date)]

*/