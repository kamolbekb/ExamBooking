using System;
using System.Text.Json;
using ExamBooking.Models;
namespace ExamBooking.Service;

public partial class BookingService
{
    private List<Group> groups = new List<Group>();

    public void AddGroup(string name, string language)
    {
        if (string.IsNullOrWhiteSpace(name))
        throw new ArgumentException("Name cannot be empty.");

        int id = groups.Count > 0 ? groups.Max(s => s.Id) + 1 : 1;
        var group = new Group { Id = id, Name = name , Language = language};
        var path = @"/Users/kamolshermatov096/Documents/GroupsList.txt";
        List<Group> groupList = new List<Group>();

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            if (!string.IsNullOrEmpty(json))
            {
                groupList = JsonSerializer.Deserialize<List<Group>>(json) ?? new List<Group>();
            }
        }

        groupList.Add(group);

        string updatedJson = JsonSerializer.Serialize(groupList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, updatedJson);
    }

    public void UpdateGroup(int id, string name, string language)
    {
        var group = groups.FirstOrDefault(g => g.Id == id);
        if (group != null)
        {
            group.Name = name;
            group.Language = language;
        }
        else
        {
            throw new KeyNotFoundException("Group not found.");
        }
    }

    public void DeleteGroup(int id)
    {
        var group = groups.FirstOrDefault(t => t.Id == id);
        if (group != null)
        {
            groups.Remove(group);
        }
        else
        {
            throw new KeyNotFoundException("Group not found.");
        }
    }

    public void ListGroups()
    {
        if (!groups.Any())
        {
            Console.WriteLine("No groups available.");
            return;
        }

        foreach (var group in groups)
        {
            Console.WriteLine($"Group ID: {group.Id}, Name: {group.Name}, Language: {group.Language}");
        }
    }
}