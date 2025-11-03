using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetshopMiau.Core;
public class Servico
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public ICollection<Pacote> Pacotes { get; set; } = new List<Pacote>();
}