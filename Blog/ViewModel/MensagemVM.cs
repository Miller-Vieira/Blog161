using Blog.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModel
{
    public class MensagemVM
    {
        public IEnumerable<Mensagem> Mensagens { get; set; }

        public IEnumerable<Comentario> Comentarios { get; set; }


    }
}
