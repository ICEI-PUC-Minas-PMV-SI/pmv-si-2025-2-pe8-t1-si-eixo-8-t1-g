using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetshopMiau.Core;

public class Agendamento
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public decimal ValorCobrado { get; set; }
    public string Observacoes { get; set; }
    public StatusAgendamento Status { get; set; }
    public StatusPagamento Pagamento { get; set; }


    public DateTime? DataPagamento { get; set; } 


    public int PetId { get; set; }
    public Pet Pet { get; set; }

    public int ServicoId { get; set; }
    public Servico Servico { get; set; }

    public int? ClientePacoteId { get; set; } 
    public ClientePacote ClientePacote { get; set; }
}