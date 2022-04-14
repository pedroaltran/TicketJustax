using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketsAPI.Domain.Entities;

namespace TicketsAPI.Data.Configs
{
    public class TicketConfig : IEntityTypeConfiguration<TicketEntity>
    {
        public void Configure(EntityTypeBuilder<TicketEntity> builder)
        {
            MapTableAndColumsNames(builder);
            builder.HasKey(x => x.Id);
        }
        private static void MapTableAndColumsNames(EntityTypeBuilder<TicketEntity> builder)
        {
            builder.ToTable("Ticket");
            builder.Property(x => x.Id).HasColumnName("idTicket");
            builder.Property(x => x.CreatedUserId).HasColumnName("idUsuarioInclusao");
            builder.Property(x => x.UpdatedUserId).HasColumnName("idUsuarioUltimaInclusao");
            builder.Property(x => x.CreatedAt).HasColumnName("dtaInlusao");
            builder.Property(x => x.UpdatedAt).HasColumnName("dtaUltimaAlteracao");
            builder.Property(x => x.TypeId).HasColumnName("idTipo");
            builder.Property(x => x.DoubtId).HasColumnName("idDuvida");
            builder.Property(x => x.StageId).HasColumnName("idEtapa");
            builder.Property(x => x.InteractionId).HasColumnName("idInteracao");
            builder.Property(x => x.CustomerPersonId).HasColumnName("idPessoaCliente");
            builder.Property(x => x.OpeningDate).HasColumnName("dtaAbertura");
            builder.Property(x => x.ClosingDate).HasColumnName("dtaFechamento");
        } 
    }
}
