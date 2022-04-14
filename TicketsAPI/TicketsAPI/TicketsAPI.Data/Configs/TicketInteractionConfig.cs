using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketsAPI.Domain.Entities;

namespace TicketsAPI.Data.Configs
{
    public class TicketInteractionConfig : IEntityTypeConfiguration<TicketInteractionEntity>
    {
        public void Configure(EntityTypeBuilder<TicketInteractionEntity> builder)
        {
            MapTableAndColumsNames(builder);
            builder.HasKey(x => x.Id);
        }
        private static void MapTableAndColumsNames(EntityTypeBuilder<TicketInteractionEntity> builder)
        {
            builder.ToTable("ticketInteracao");
            builder.Property(x => x.Id).HasColumnName("idInteracao");
            builder.Property(x => x.CreatedUserId).HasColumnName("idUsuarioInclusao");
            builder.Property(x => x.UpdatedUserId).HasColumnName("idUsuarioUltimaInclusao");
            builder.Property(x => x.CreatedAt).HasColumnName("dtaInlusao");
            builder.Property(x => x.UpdatedAt).HasColumnName("dtaUltimaAlteracao");
            builder.Property(x => x.Message).HasColumnName("mensagem");
            builder.Property(x => x.InteractionDate).HasColumnName("dtaInteracao");
        }
    }
}
