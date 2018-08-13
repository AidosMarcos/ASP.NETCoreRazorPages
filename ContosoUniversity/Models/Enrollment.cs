using System;
using System.Collections.Generic;

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
		public Grade? Grade { get; set; }

		public Course Course { get; set; }
		public Student Student { get; set; }
    }
}
