using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Npgsql;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Context
{
    public class OrganizadorContext : DbContext
    {
		[Obsolete]
		public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {
            NpgsqlConnection.GlobalTypeMapper.MapEnum<EnumStatusTarefa>();
        }

        public DbSet<Tarefa> Tarefas { get; set; }

		protected override void OnModelCreating (ModelBuilder builder) {
			builder.UseSerialColumns()
				.HasPostgresEnum<EnumStatusTarefa>()
				.Entity<Tarefa>().Property(e => e.Data)
				.HasColumnType("timestamp");
		}

    }
}