using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketsAPI.Domain.Entities;

namespace TicketsAPI.Data.Configs
{
    public class TicketDoubtConfig : IEntityTypeConfiguration<TicketDoubtEntity>
    {
        public void Configure(EntityTypeBuilder<TicketDoubtEntity> builder)
        {
            MapTableAndColumsNames(builder);
            builder.HasKey(x => x.Id);
        }
        private static void MapTableAndColumsNames(EntityTypeBuilder<TicketDoubtEntity> builder)
        {
            builder.ToTable("ticketDuvida");
            builder.Property(x => x.Id).HasColumnName("idDuvida");
            builder.Property(x => x.CreatedUserId).HasColumnName("idUsuarioInclusao");
            builder.Property(x => x.UpdatedUserId).HasColumnName("idUsuarioUltimaInclusao");
            builder.Property(x => x.CreatedAt).HasColumnName("dtaInlusao");
            builder.Property(x => x.UpdatedAt).HasColumnName("dtaUltimaAlteracao");
            builder.Property(x => x.TypeId).HasColumnName("idTipo");
            builder.Property(x => x.Description).HasColumnName("descricao");
            builder.Property(x => x.Status).HasColumnName("status");
        }
    }
}
