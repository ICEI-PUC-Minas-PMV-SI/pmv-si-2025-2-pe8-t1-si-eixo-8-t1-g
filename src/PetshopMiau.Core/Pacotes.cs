using System.Collections.Generic;

namespace PetshopMiau.Core;
public class Pacote
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int QuantidadeSessoes { get; set; } 
    public decimal PrecoTotal { get; set; } 
    public int ValidadeEmDias { get; set; } 

 
    public int ServicoId { get; set; }
    public Servico Servico { get; set; }

    public ICollection<ClientePacote> PacotesAdquiridos { get; set; } = new List<ClientePacote>();
}