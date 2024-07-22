using System;
namespace ExamBooking.Models;

public class Room
{
    public int Id;
    public string Name;
    public List<Booking> Bookings { get; set; } = new List<Booking>();
    public List<RoomGroup> RoomGroups{ get; set; } = new List<RoomGroup>();
    
}

