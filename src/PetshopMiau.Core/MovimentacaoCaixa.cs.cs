using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace PetshopMiau.Core
{
    public class MovimentacaoCaixa
    {
        public int Id { get; set; }
        public DateTime DataHora { get; set; }
        public TipoMovimentacao Tipo { get; set; } 
        public string Descricao { get; set; }
        public decimal Valor { get; set; } 
    }
}
