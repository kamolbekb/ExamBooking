using System;
namespace ExamBooking.Models;

public class TeacherGroup
{
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
    public List<Booking> Bookings { get; set; } = new List<Booking>();
}

