using System;
using System.Collections.Generic;

namespace Blog.Models
{
    public class Comentario
    {
        public int ComentarioId { get; set; }   
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataComentario;
        public string Autor { get; set; }
        public virtual List<Mensagem> Mensagens { get; set; }
    }
}
