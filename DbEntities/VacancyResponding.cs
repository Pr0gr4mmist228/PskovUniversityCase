namespace PskovUniversityCase.DbEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VacancyResponding")]
    public partial class VacancyResponding
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        //[ForeignKey("Vacancy")]
        public int VacancyId { get; set; }


        //[ForeignKey("Student")]
        public int StudentId { get; set; }

        //[ForeignKey("Vacancy")]
        public int OrganizationId { get; set; }

        [StringLength(30)]
        public string Status { get; set; }
        
		public virtual Vacancy Vacancy { get; set; }
		public virtual Student Student { get; set; }
		public virtual Organization Organization { get; set; }
    }
}
