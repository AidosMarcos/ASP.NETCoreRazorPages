using System;
using System.Collections.Generic;
using ContosoUniversity.Models.SchoolViewModels;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Models;

namespace ContosoUniversity.Pages.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly ContosoUniversity.Models.SchoolContext _context;

        public IndexModel(ContosoUniversity.Models.SchoolContext context)
        {
            _context = context;
        }

        public InstructorIndexData Instructor { get; set; }
		public int InstructorID { get; set; }
		public int CourseID { get; set; }

        public async Task OnGetAsync(int? id, int? courseID)
        {
			Instructor = new InstructorIndexData();
			Instructor.Instructors = await _context.Instructors
				.Include(i => i.OfficeAssignment)
				.Include(i => i.CourseAssigments)
					.ThenInclude(i => i.Course)
						.ThenInclude(i => i.Department)
					//.Include(i => i.CourseAssigments)
					//	.ThenInclude(i => i.Course)
					//		.ThenInclude(i => i.Enrollments)
					//			.ThenInclude(i => i.Student)
				//.AsNoTracking()
				.OrderBy(i => i.LastName).ToListAsync();

			if (id != null)
			{
				InstructorID = id.Value;
				Instructor instructor = Instructor.Instructors.Where(i => i.ID == id.Value).Single();
				Instructor.Courses = instructor.CourseAssigments.Select(s => s.Course);
			}

			if (courseID != null)
			{
				CourseID = courseID.Value;
				var selectedCourse = Instructor.Courses.Where(x => x.CourseID == courseID).Single();    // this part only includes student info if a course if selected
				await _context.Entry(selectedCourse).Collection(x => x.Enrollments).LoadAsync();
				foreach (Enrollment enrollment in selectedCourse.Enrollments)
				{
					await _context.Entry(enrollment).Reference(x => x.Student).LoadAsync();
				}
				Instructor.Enrollments = selectedCourse.Enrollments;
			}
		}
    }
}
