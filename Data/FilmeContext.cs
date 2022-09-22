using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data
//Foi baixando:
//Microsoft.EntityFrameworkCore
//Microsoft.EntityFrameworkCore.Tools
//MySql.Microsoft.EntityFrameworkCore
//e Depois criado a pasta Data com uma classe chamada "FilmeContext"

{
    public class FilmeContext : DbContext //Herda da DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt): base(opt)  //Contrutor que pega a base de opt
        {

        }

        protected override void OnModelCreating(ModelBuilder buider)
        {
            buider.Entity<Endereco>()
                .HasOne(endereco => endereco.Cinema)
                .WithOne(cinema => cinema.Endereco)
                .HasForeignKey<Cinema>(cinema => cinema.EnderecoId);

            buider.Entity<Cinema>()
                .HasOne(cinema => cinema.Gerente)
                .WithMany(gerente => gerente.Cinemas)
                .HasForeignKey(cinema => cinema.GerenteId).IsRequired(false);


            buider.Entity<Sessao>()
                .HasOne(sessao => sessao.Filme)
                .WithMany(filme => filme.Sessoes)
                .HasForeignKey(sessao => sessao.FilmeId).IsRequired(false);

            buider.Entity<Sessao>()
                .HasOne(sessao => sessao.Cinema)
                .WithMany(cinema => cinema.Sessoes)
                .HasForeignKey(sessao => sessao.CinemaId).IsRequired(false);
        }

        public DbSet<Filme> Filmes{ get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<Gerente> Gerentes { get; set; } 
        
        public DbSet<Sessao> Sessoes { get; set; }
    }
}
