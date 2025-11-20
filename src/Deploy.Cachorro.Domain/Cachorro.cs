using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Deploy.Cachorro.Domain
{
    public class Cachorro : EntidadeBase<int>
    {
        public DateTime Nascimento { get; init; }
        public bool Adotado { get; set; }
        public string Pelagem { get; init; }
        public float Peso { get; init; }
        //public List<Vacina> Vacinas { get; }

        //public void Vacinar(Vacina vacina)
        //{
        //    Vacinas.Add(vacina);
        //}
    }

    [Flags]
    public enum Vacina
    {
        Vacina1,
        Vacina2,
        Vacina3
    }

    [Flags]
    public enum Pelagem
    {
        Curta,
        Media,
        Longa
    }
}
