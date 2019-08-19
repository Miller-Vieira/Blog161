using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Models;

namespace Blog.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext (DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public DbSet<Blog.Models.Categoria> Categoria { get; set; }

        public DbSet<Blog.Models.Comentario> Comentario { get; set; }

        public DbSet<Blog.Models.Mensagem> Mensagem { get; set; }

    }
}
