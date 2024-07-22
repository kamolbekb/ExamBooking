namespace ExamBooking.Models;

public class RoomGroup
{
    public int RoomId { get; set; }
    public Room Room { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
}

