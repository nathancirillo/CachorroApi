using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deploy.Cachorro.Domain
{
    public class EntidadeBase<T>
    {
        public T Id { get; set; }
        public string Nome { get; set; }
    }
}
