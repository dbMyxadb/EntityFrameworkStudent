using EF.DAL.Entities;
using EF;
using System;

namespace EF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //функціонал: оновити, видалити, додати, показати
            var context = new AppDbContext();
            while (true)
            {


                Console.WriteLine("\n1. Show ");
                Console.WriteLine("2. Add ");
                Console.WriteLine("3. Update ");
                Console.WriteLine("4. Remove ");

                string s = Console.ReadLine();
                int.TryParse(s, out int result);
                var students = context.Students.ToList();
                switch (result)
                {
                    case 1:
                        Console.Clear();
                        foreach (var stud in students)
                        {
                            Console.WriteLine($"Name: {stud.Name}\t Description:{stud.Description}");
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Enter name:");
                        string name = Console.ReadLine();

                        Console.WriteLine("Enter description:");
                        string desc = Console.ReadLine();

                        var student = new Student
                        {
                            Name = name,
                            Description = desc,
                        };

                        context.Students.Add(student);
                        context.SaveChanges();
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Enter num of object:");
                        int n = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter update name:");
                        string updname = Console.ReadLine();

                        Console.WriteLine("Enter update description:");
                        string upddesc = Console.ReadLine();

                        students[n].Name = updname;
                        students[n].Description = upddesc;
                        context.Students.Update(students[n]);
                        context.SaveChanges();
                        break;


                    case 4:
                        Console.Clear();
                        Console.WriteLine("Enter num of object:");
                        int y = int.Parse(Console.ReadLine());
                        context.Students.Remove(students[y]);
                        context.SaveChanges();

                        break;

                }

            }
        }
    }
}