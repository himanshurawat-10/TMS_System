using TMS.Context;
using TMS.Interface;
using TMS.Models;

namespace TMS.Repository
{
    public class CourseRepository : ICourse
    {
        MyDBContext _db;
        public CourseRepository(MyDBContext db)
        {
            _db = db;





        }
        public Course Create(Course course)
        {
            _db.Courses.Add(course);
            _db.SaveChanges();
            return course;
        }





        public int Delete(int id)
        {
            Course obj2 = GetCourseById(id);
            if (obj2 != null)
            {
                _db.Courses.Remove(obj2);
                _db.SaveChanges();
                return 1;
            }
            return 0;
        }





        public int Edit(int id, Course course)
        {
            Course obj = GetCourseById(id);
            if (obj != null)
            {
                foreach (Course temp in _db.Courses)
                {
                    if (temp.CourseId == id)
                    {
                        temp.CourseName = course.CourseName;
                        temp.Description = course.Description;
                    }
                }
                _db.SaveChanges();
            }
            return 1;
        }





        public Course GetCourseById(int id)
        {
            return _db.Courses.FirstOrDefault(x => x.CourseId == id);
        }





        public List<Course> GetCourses()
        {
            return _db.Courses.ToList();
        }
    }
}
