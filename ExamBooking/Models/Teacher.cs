using System;
namespace ExamBooking.Models;
public class Teacher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    public List<TeacherGroup> teacherGroups { get; set; } = new List<TeacherGroup>();
    public List<Booking> Bookings { get; set; } = new List<Booking>();
}

