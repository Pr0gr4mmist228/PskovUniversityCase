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
		
        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }
        
       	[StringLength(20)]
		public string Email { get; set; }
		[StringLength(12)]
		public string Phone { get; set; }
        
		public virtual User User { get; set; }
		
		public virtual Organization Organization { get; set; }
    }
}
