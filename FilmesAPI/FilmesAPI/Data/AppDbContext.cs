using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema)
                .WithOne(Cinema => Cinema.endereco)
                .HasForeignKey<Cinema>(cinema => cinema.enderecoId);
        }


        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

    }
}
