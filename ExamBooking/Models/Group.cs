namespace ExamBooking.Models;
public class Group
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Language { get; set; }
    public List<TeacherGroup> teacherGroups { get; set; } = new List<TeacherGroup>();
    public List<Booking> Bookings { get; set; } = new List<Booking>();
    public List<RoomGroup> RoomGroups { get; set; } = new List<RoomGroup>();
}

