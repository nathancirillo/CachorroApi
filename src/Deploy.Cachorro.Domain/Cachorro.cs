using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deploy.Cachorro.Domain
{
    public class Cachorro : EntidadeBase<int>
    {
        public Cachorro(string nome, DateTime nascimento)
        {
            Nome = nome;
            Nascimento = nascimento;
        }

        public DateTime Nascimento { get; init; }    
        public List<Vacina> Vacinas { get; private set; }

        public void Vacinar(Vacina vacina)
        {
            Vacinas.Add(vacina);
        }
    }

    public enum Vacina
    {
        Vacina1,
        Vacina2,
        Vacina3
    }
}
