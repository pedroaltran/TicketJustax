using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicketsAPI.Domain.Entities;

namespace TicketsAPI.Data.Configs
{
    public class TicketTypeConfig : IEntityTypeConfiguration<TicketTypeEntity>
    {
        public void Configure(EntityTypeBuilder<TicketTypeEntity> builder)
        {
            MapTableAndColumsNames(builder);
            builder.HasKey(x => x.Id);
        }
        
        private static void MapTableAndColumsNames(EntityTypeBuilder<TicketTypeEntity> builder)
        {
            builder.ToTable("ticketEtapa");
            builder.Property(x => x.Id).HasColumnName("idTipo");
            builder.Property(x => x.CreatedUserId).HasColumnName("idUsuarioInclusao");
            builder.Property(x => x.UpdatedUserId).HasColumnName("idUsuarioUltimaInclusao");
            builder.Property(x => x.CreatedAt).HasColumnName("dtaInlusao");
            builder.Property(x => x.UpdatedAt).HasColumnName("dtaUltimaAlteracao");
            builder.Property(x => x.Description).HasColumnName("descricao");
            builder.Property(x => x.Status).HasColumnName("status");
        }
    }
}
