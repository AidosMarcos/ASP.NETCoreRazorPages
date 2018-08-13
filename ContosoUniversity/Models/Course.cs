using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
    public class Course
    {
		[DatabaseGenerated(DatabaseGeneratedOption.None)] // this prevents from primary key to be auto-generated
		public int CourseID { get; set; } // primary key
		public string Title { get; set; }
		public int Credits { get; set; }

		public ICollection<Enrollment> Enrollments { get; set; }
    }
}
