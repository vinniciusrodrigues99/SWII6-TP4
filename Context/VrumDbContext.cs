using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using vrumvrum.Models;

namespace vrumvrum.Context;

public class VrumDbContext : DbContext
{
    public VrumDbContext(DbContextOptions<VrumDbContext> opts) : base(opts)
    {
        
    }
    public DbSet<Piloto> Pilotos { get; set;}
    public DbSet<Corrida> Corridas { get; set; }
    public DbSet<Equipe> Equipes { get; set; }
    public DbSet<Campeonato> Campeonatos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Corrida>()
            .HasOne(e => e.Campeonato)
            .WithMany(e => e.Corridas)
            .HasForeignKey(e => e.CampeonatoId)
            .IsRequired(false);

        modelBuilder.Entity<Piloto>()
            .HasOne(e => e.Equipe)
            .WithMany(e => e.Pilotos)
            .HasForeignKey(e => e.EquipeId)
            .IsRequired(true);

        modelBuilder.Entity<Equipe>()
            .HasOne(e => e.Campeonato)
            .WithMany(e => e.Equipes)
            .HasForeignKey(e => e.CampeonatoId)
            .IsRequired(false);
    }
}