using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Mensagem 
    {
        public int MensagemId { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataMensagem;

        [ForeignKey("CategoriaId")]
        public int CategoriaId { get; set; }
        public Categoria Categorias { get; set; }

        public List<Comentario> Comentarios { get; set; }
    }
}
