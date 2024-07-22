using ExamBooking.Service;
namespace ExamBooking;
public class Program
{
    public static void Main(string[] args)
    {
        var schoolService = new BookingService();
        bool exit = false;
        string a = "djann";
        while (!exit)
        {
            Console.WriteLine("1. Teacher's operations");
            Console.WriteLine("2. Group's operations");
            Console.WriteLine("3. Room's operations");
            Console.WriteLine("4. Booking Process");
            Console.WriteLine("5. Reports");

            Console.WriteLine("0.Exit");

            Console.Write("Choose an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("1.Add Teacher");
                    Console.WriteLine("2. Update Teacher");
                    Console.WriteLine("3. Delete Teacher");
                    Console.WriteLine("4. Attach Teacher To Group");
                    Console.WriteLine("5. List Teachers");

                    Console.Write("\nChoose an option: ");

                    int optionTeacher = int.Parse(Console.ReadLine());
                    switch (optionTeacher)
                    {
                        case 1:
                            Console.Write("Enter Teacher Name: ");
                            var tName = Console.ReadLine();
                            schoolService.AddTeacher(tName);
                            Console.Clear();
                            break;
                        case 2:
                            Console.Write("Enter Teacher Id: ");
                            var tId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Teacher Name: ");
                            var newTName = Console.ReadLine();
                            schoolService.UpdateTeacher(tId, newTName);
                            Console.Clear();
                            break;
                        case 3:
                            Console.Write("Enter Teacher Id: ");
                            var deleteTId = int.Parse(Console.ReadLine());
                            schoolService.DeleteTeacher(deleteTId);
                            Console.Clear();
                            break;
                        case 4:
                            Console.Write("Enter Teacher Id: ");
                            var attTeId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Group Id: ");
                            var attGId = int.Parse(Console.ReadLine());
                            schoolService.AttachTeacherToGroup(attTeId, attGId);
                            Console.Clear();
                            break;
                        case 5:
                            schoolService.ListTeacherGroups();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        default:
                            break;
                    }
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("1.Add Group");
                    Console.WriteLine("2. Update Group");
                    Console.WriteLine("3. Delete Group");
                    Console.WriteLine("4. Attach Group To Room");
                    Console.WriteLine("5. List Groups");

                    Console.Write("\nChoose an option: ");

                    int optionGroup = int.Parse(Console.ReadLine());
                    switch (optionGroup)
                    {
                        case 1:
                            Console.Write("Enter Group Name: ");
                            var gName = Console.ReadLine();
                            Console.Write("Enter Group Language: ");
                            var language = Console.ReadLine();
                            schoolService.AddGroup(gName, language);
                            Console.Clear();
                            break;
                        case 2:

                        case 3:
                            Console.Write("Enter Group Id: ");
                            var deleteGId = int.Parse(Console.ReadLine());
                            schoolService.DeleteGroup(deleteGId);
                            Console.Clear();
                            break;
                        case 4:
                            Console.Write("Enter Group's Id: ");
                            var attGroupId = int.Parse(Console.ReadLine());
                            Console.Write("Enter Room Id: ");
                            var attRId = int.Parse(Console.ReadLine());
                            schoolService.AttachRoomToGroup(attGroupId, attRId);
                            Console.Clear();
                            break;
                        case 5:
                            schoolService.ListGroups();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        default:
                            break;
                    }
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("1.Add Room");
                    Console.WriteLine("3. Delete Room");
                    Console.WriteLine("5. List Rooms");

                    Console.Write("\nChoose an option: ");

                    int optionRoom = int.Parse(Console.ReadLine());
                    switch (optionRoom)
                    {
                        case 1:
                            Console.Write("Enter Room Name: ");
                            var rName = Console.ReadLine();
                            schoolService.AddRoom(rName);
                            Console.Clear();
                            break;
                        case 2:
                            Console.Write("Enter Room Id: ");
                            var deleteRId = int.Parse(Console.ReadLine());
                            schoolService.DeleteRoom(deleteRId);
                            Console.Clear();
                            break;
                        case 3:
                            schoolService.ListRooms();
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 0:

                        default:
                            break;
                    }

                    break;
                case "4":
                    Console.Clear();
                    schoolService.ListGroups();
                    Console.Write("Enter group id: ");
                    bool isTrueFormat = int.TryParse(Console.ReadLine(), out var BookingGroupId);
                    if (!isTrueFormat)
                    {
                        Console.WriteLine("Incorrect format");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    else if (BookingGroupId == 0)
                    {
                        Console.WriteLine("Id cannot be 0");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    schoolService.ListRooms();
                    Console.Write("Enter room id: ");
                    var BookingRoomId = int.Parse(Console.ReadLine());

                    schoolService.ListTeacherGroups();
                    Console.Write("enter Teacher id: ");
                    var BookingTeacherId = int.Parse(Console.ReadLine());

                    Console.Write("Enter Time Lesson start (2024-07-19 15:30:00): ");
                    bool isTrue = DateTime.TryParse(Console.ReadLine(), out var StartTime);

                    if (!isTrue)
                    {
                        Console.WriteLine("Date time format is incorrect");
                        continue;
                    }

                    Console.Write("Enter Time Lesson end (2024-07-19 15:30:00): ");
                    bool isTrue1 = DateTime.TryParse(Console.ReadLine(), out var endTime);

                    if (!isTrue)
                    {
                        Console.WriteLine("Date time format is incorrect");
                        continue;
                    }

                    schoolService.Booking(BookingRoomId, BookingTeacherId, BookingGroupId, StartTime, endTime);
                    Console.ReadKey();
                    Console.Clear();
                    break;

                case "5":
                    //Console.Clear();
                    //Console.WriteLine("| Id |    Name     |");
                    //schoolService.ListTeacherGroups();
                    Console.Clear();
                    schoolService.getBookingList();
                    Console.ReadKey();
                    Console.Clear();
                    break;

            }
        }
    }
}