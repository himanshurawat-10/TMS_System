using TMS.Models;

namespace TMS.Interface
{
    public interface ICourse
    {
        List<Course> GetCourses();
        Course Create(Course course);
        int Edit(int id, Course course);
        int Delete(int id);
        Course GetCourseById(int id);

    }
}
