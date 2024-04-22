using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WrapUpBilleterie.Models
{
    [Table("Affiche", Schema = "Spectacles")]
    [Index("Identifiant", Name = "UC_Image_Identifiant", IsUnique = true)]
    public partial class Affiche
    {
        [Key]
        [Column("AfficheID")]
        public int AfficheId { get; set; }
        public Guid Identifiant { get; set; }
        [Column("SpectacleID")]
        public int SpectacleId { get; set; }
        public byte[]? AfficheContent { get; set; }

        [ForeignKey("SpectacleId")]
        [InverseProperty("Affiches")]
        public virtual Spectacle Spectacle { get; set; } = null!;
    }
}
