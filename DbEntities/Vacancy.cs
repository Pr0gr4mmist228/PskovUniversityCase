namespace PskovUniversityCase.DbEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vacancy")]
    public partial class Vacancy
    {
        public int VacancyId { get; set; }

        public int EmployerId { get; set; }

        public int OrganizationId { get; set; }

        [Required]
        [StringLength(30)]
        public string Header { get; set; }

        [Required]
        public string Text { get; set; }

        public decimal Salary { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public virtual Organization Organization { get; set; }
		public virtual Employer Employer { get; set; }
    }
}
