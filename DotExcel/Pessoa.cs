using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotExcel
{
    public class Pessoa
    {      
        public string nome { get; set; }
        public string email { get; set; }
        public int id { get; set; }

        public Pessoa()
        {
            this.nome = String.Empty;
            this.email = String.Empty;
            this.id = -1;
        }
    }
}
