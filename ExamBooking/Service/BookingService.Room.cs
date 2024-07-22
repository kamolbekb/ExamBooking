using System;
using System.Text.Json;
using ExamBooking.Models;
namespace ExamBooking.Service;

public partial class BookingService
{
    private List<Room> rooms = new List<Room>();

    public void AddRoom(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");

        int id = rooms.Count > 0 ? rooms.Max(t => t.Id) + 1 : 1;
        var room = new Room { Id = id, Name = name };
        var path = @"/Users/kamolshermatov096/Documents/RoomsList.txt";
        List<Room> roomList = new List<Room>();

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            if (!string.IsNullOrEmpty(json))
            {
                roomList = JsonSerializer.Deserialize<List<Room>>(json) ?? new List<Room>();
            }
        }

        roomList.Add(room);

        string updatedJson = JsonSerializer.Serialize(roomList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, updatedJson);
    }

    public void UpdateRoom(int id, string name)
    {
        var room = rooms.FirstOrDefault(r => r.Id == id);
        if (room != null)
        {
            room.Name = name;
        }
        else
        {
            throw new KeyNotFoundException("Room not found.");
        }
    }

    public void DeleteRoom(int id)
    {
        var room = rooms.FirstOrDefault(t => t.Id == id);
        if (room != null)
        {
            rooms.Remove(room);
        }
        else
        {
            throw new KeyNotFoundException("Room not found.");
        }
    }

    public void ListRooms()
    {
        if (!rooms.Any())
        {
            Console.WriteLine("No rooms available.");
            return;
        }

        foreach (var room in rooms)
        {
            Console.WriteLine($"Room ID: {room.Id}, Name: {room.Name}");
        }
    }
}
