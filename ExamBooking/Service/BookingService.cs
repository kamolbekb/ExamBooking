using System;
using System.Text.Json;
using ExamBooking.Models;
namespace ExamBooking.Service;

public partial class BookingService
{
    private List<Booking> bookings = new List<Booking>();
    
    public void AttachTeacherToGroup(int teacherId, int groupId)
    {
        var teacher = teachers.FirstOrDefault(t => t.Id == teacherId);
        var group = groups.FirstOrDefault(s => s.Id == groupId);

        if (teacher == null || group == null)
        {
            throw new ArgumentException("Invalid teacher or group ID.");
        }

        var teacherGroup = new TeacherGroup()
        {
            TeacherId = teacherId,
            Teacher = teacher,
            GroupId = groupId,
            Group = group
        };

        teacher.teacherGroups.Add(teacherGroup);
        group.teacherGroups.Add(teacherGroup);
    }

    public void Booking(int roomId, int groupId, int teacherId, DateTime start, DateTime end)
    {
        var room = rooms.FirstOrDefault(r => r.Id == roomId);
        var group = groups.FirstOrDefault(s => s.Id == groupId);
        var teacher = teachers.FirstOrDefault(t => t.Id == teacherId);

        if (room != null && group != null && teacher != null)
        {
            Booking booking = new Booking()
            {
                RoomId = roomId,
                TeacherId = teacherId,
                GroupId = groupId,

                Group = group,
                Room = room,
                Teacher = teacher,
                startTime = start,
                endTime = end
            };

            group.Bookings.Add(booking);
            room.Bookings.Add(booking);
            teacher.Bookings.Add(booking);
            Console.Clear();
            Console.WriteLine("Room booked successfully!");
            
        }
        else
        {
            Console.WriteLine("Invalid group , room or teacher ID");
        }
    }

    public void AttachRoomToGroup(int roomId, int groupId)
    {
        var room = rooms.FirstOrDefault(t => t.Id == roomId);
        var group = groups.FirstOrDefault(s => s.Id == groupId);

        if (room == null || group == null)
        {
            throw new ArgumentException("Invalid room or group ID.");
        }

        var roomGroup = new RoomGroup()
        {
            RoomId = roomId,
            Room = room,
            GroupId = groupId,
            Group = group
        };

        room.RoomGroups.Add(roomGroup);
        group.RoomGroups.Add(roomGroup);
    }

    public void getBookingList()
    {
        foreach (var item in groups)
            foreach (var i in item.Bookings)
                Console.WriteLine($"room Name: {i.Room.Name}, Teacher Name: {i.Teacher.Name}, Group name: {i.Group.Name}, {i.startTime} ---- {i.endTime}");
    }
}

