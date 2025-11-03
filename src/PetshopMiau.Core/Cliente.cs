using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetshopMiau.Core;

public class Cliente
{
    public int Id { get; set; } 
    public string Nome { get; set; }
    public string Telefone { get; set; }
    public string Endereco { get; set; }

    
    public ICollection<Pet> Pets { get; set; } = new List<Pet>();
    public ICollection<ClientePacote> PacotesAdquiridos { get; set; } = new List<ClientePacote>();
}