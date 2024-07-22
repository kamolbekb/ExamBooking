using System;
namespace ExamBooking.Models;

public class Booking
{
    public int Id;
    public int GroupId;
    public int RoomId;
    public int TeacherId;

    public Group Group { get; set; }
    public Room Room { get; set; }
    public Teacher Teacher { get; set; }

    public DateTime startTime;
    public DateTime endTime;
}