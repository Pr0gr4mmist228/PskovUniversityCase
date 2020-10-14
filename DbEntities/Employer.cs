namespace PskovUniversityCase.DbEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employer")]
    public partial class Employer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("User")]
        public int Id { get; set; }

        public int OrganizationId { get; set; }
        
		public virtual User User { get; set; }
    }
}
