namespace PskovUniversityCase.DbEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Student")]
    public partial class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int GroupId { get; set; }
        
        public int? SummaryId { get; set; }

        public virtual User User { get; set; }
        
        public virtual Group Group { get; set; }

        public virtual ICollection<Summary> Summary { get; set; }
    }
}
