namespace PskovUniversityCase.DbEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Summary")]
    public partial class Summary
    {
    	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int StudentId { get; set; }

        [Column("SummaryText")]
        [Required]
        public string SummaryText { get; set; }

        public virtual Student Student { get; set; }
    }
}
