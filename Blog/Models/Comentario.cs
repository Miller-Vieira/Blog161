using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    public class Comentario
    {
        public int ComentarioId { get; set; }   
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataComentario;
        public string Autor { get; set; }

        [ForeignKey("MensagemId")]
        public int? MensagemId { get; set; }
        public Mensagem Mensagens { get; set; }
    }
}
