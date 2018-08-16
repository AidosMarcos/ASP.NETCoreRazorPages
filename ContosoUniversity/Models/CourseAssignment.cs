using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ContosoUniversity.Models
{
    public class CourseAssignment   // this is a Pure Join Table (table that only contains FK without payload)
    {
		public int InstructorID { get; set; }
		public int CourseID { get; set; }
		public Instructor Instructor { get; set; }
		public Course Course { get; set; }
    }
}
