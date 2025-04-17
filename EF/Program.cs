using EF.DAL.Entities;
using EF;
using System;
using Microsoft.EntityFrameworkCore;
using MenuSevice;

namespace EF
{
    internal class Program
    {
        static void Main(string[] args)
        {


            /*
            var context = new AppDbContext();

            var user = new User()
            {
                Name = "Vlad"
            };

            var product = new Product()
            {
                Name = "Xbox",
                Price = 1000
            };

            var product2 = new Product()
            {
                Name = "Samsung",
                Price = 1999
            };


            context.Users.Add(user);
            context.Products.AddRange(product, product2);
            context.SaveChanges();

            var user1 = context.Users.FirstOrDefault();
            var product1 = context.Products.FirstOrDefault();
            var prod2 = context.Products.FirstOrDefault(p => p.Id == 2);


            var order = new Order()
            {
                UserId = user1.Id,
                ProductId = product1.Id,
                CreatedDate = DateTime.Now
            };

            var order2 = new Order()
            {
                UserId = user1.Id,
                ProductId = prod2.Id,
                CreatedDate = DateTime.Now
            };

            context.Orders.AddRange(order, order2);
            context.SaveChanges();
            */




            var context = new AppDbContext();


            var UserAndOrder = context.Orders
                    .Select(o => $"{o.User.Name}  order:{o.Product.Name}  date:{o.CreatedDate}")
                    .ToList();

            foreach (var order in UserAndOrder)
            {
                Console.WriteLine(order);
            }
            
            MenuService menuService = new MenuService();
            menuService.Run();

            /*
            var context = new AppDbContext(); 


            var userWithOrders = context.Users.Include(u => u.Orders);
            foreach (var u in userWithOrders)
            {
                Console.WriteLine($"User: {u.Name}\n \t Orders: ");
                foreach (var order in u.Orders)
                {
                    Console.WriteLine($"Order: , CreatedDate: {order.CreatedDate}");
                }
            }




            */


















            /*

            var user = new User
            {
                Name = "John Doe"
            };
            var order1 = new Order
            {
                Name = "Order1",
                CreatedDate = DateTime.Now,
                user = user
            };
            var order2 = new Order
            {
                Name = "Order2",
                CreatedDate = DateTime.Now,
                user = user
            };*/
            /* context.Users.Add(user);
            context.SaveChanges();
            user.Orders.Add(order1);
            user.Orders.Add(order2);
            context.SaveChanges();
            Console.WriteLine("User and orders saved to database.");
            */


            /*
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
            } */
        }
    }
}