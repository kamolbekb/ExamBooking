using System;
using System.Text.Json;
using System.Xml;
using ExamBooking.Models;
namespace ExamBooking.Service;
public partial class BookingService
{
    private List<Teacher> teachers = new List<Teacher>();

    public void AddTeacher(string name)
    {
        int id = teachers.Count > 0 ? teachers.Max(t => t.Id) + 1 : 1;
        var spec = new Teacher { Id = id, Name = name };
        var path = @"/Users/kamolshermatov096/Documents/TeacherList.txt";
        List<Teacher> teacherList = new List<Teacher>();

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            if (!string.IsNullOrEmpty(json))
            {
                teacherList = JsonSerializer.Deserialize<List<Teacher>>(json) ?? new List<Teacher>();
            }
        }

        teacherList.Add(spec);

        string updatedJson = JsonSerializer.Serialize(teacherList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, updatedJson);

    }

    public void UpdateTeacher(int id, string name)
    {
        var teacher = teachers.FirstOrDefault(t => t.Id == id);
        if (teacher != null)
        {
            teacher.Name = name;

        }
        else
        {
            Console.WriteLine("Teacher not found.");
        }
    }

    public void DeleteTeacher(int id)
    {
        var teacher = teachers.FirstOrDefault(t => t.Id == id);
        if (teacher != null)
        {
            teachers.Remove(teacher);
        }
        else
        {
            Console.WriteLine("Teacher not found.");
        }
    }

    public void ListTeacherGroups()
    {
        foreach (var teacher in teachers)
        {
            Console.WriteLine($"|  {teacher.Id}  |  {teacher.Name}  |");
        }
    }
}

