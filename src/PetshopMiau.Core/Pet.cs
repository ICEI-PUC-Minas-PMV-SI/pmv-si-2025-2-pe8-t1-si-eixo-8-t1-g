using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetshopMiau.Core;


public class Pet
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Especie { get; set; }
    public string Raca { get; set; }
    public string Porte { get; set; } 
    public DateTime? DataNascimento { get; set; } 
    public string Observacoes { get; set; }

    
    public int ClienteId { get; set; }
 
    public Cliente Cliente { get; set; }
}