using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Descricao { get; set; }
        public virtual List<Mensagem> Mensagems { get; set; }
    }
}
