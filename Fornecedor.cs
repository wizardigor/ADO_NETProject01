using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_NetProject01
{
    class Fornecedor
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        protected bool Equals(Fornecedor other)
        {
            return Id.Equals(other.Id);
        }
    }
}
