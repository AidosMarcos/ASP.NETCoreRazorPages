using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
	public enum Grade
	{
		A, B, C, D, F
	}


    public class Enrollment
    {
		public int EnrollmentID { get; set; } // primary key
		public int CourseID { get; set; } // foreign key
		public int StudentID { get; set; } // foreign key
		[DisplayFormat(NullDisplayText = "No grade")]
		public Grade? Grade { get; set; }

		public Course Course { get; set; }
		public Student Student { get; set; }
    }
}
