using System;
using System.Collections.Generic;
using AdventureManagement.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AdventureManagement.DAL;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adventure> Adventures { get; set; }

    public virtual DbSet<AdventureOrganism> AdventureOrganisms { get; set; }

    public virtual DbSet<Guide> Guides { get; set; }

    public virtual DbSet<Organism> Organisms { get; set; }

    public virtual DbSet<Participant> Participants { get; set; }

    public virtual DbSet<ParticipantInteraction> ParticipantInteractions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=powa;Database=AdventureManagement;Trusted_Connection=True;TrustServerCertificate=True");

}
