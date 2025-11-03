using System;
using System.Collections.Generic;

namespace PetshopMiau.Core;

public class ClientePacote
{
    public int Id { get; set; }
    public DateTime DataAquisicao { get; set; }
    public DateTime DataVencimento { get; set; }
    public int SessoesDisponiveis { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public int PacoteId { get; set; }
    public Pacote Pacote { get; set; }

    public ICollection<Agendamento> AgendamentosUsados { get; set; } = new List<Agendamento>();
}