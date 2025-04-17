using EF.DAL.Entities;
using EF.DAL;
using Microsoft.EntityFrameworkCore.Diagnostics;
using EF;


namespace MenuSevice
{
    public class MenuService
    {
        private readonly StudentService _StudentService;
        private readonly UserSOrderService _UserSOrderService;
        private readonly ProductService _ProductService;

        public MenuService()
        {
            _StudentService = new StudentService();
            _UserSOrderService = new UserSOrderService();
            _ProductService = new ProductService();
        }
    
        public void ShowMenu()
        {/*
            Console.WriteLine("\n1. Show all students");
            Console.WriteLine("2. Add student");
            Console.WriteLine("3. Update student");
            Console.WriteLine("4. Remove student");
            Console.WriteLine("+=================+\n work with User and Orders\n");
            Console.WriteLine("5.Show all Users");
            Console.WriteLine("6.Add new Users");
            Console.WriteLine("7.Edit Users");
            Console.WriteLine("8.Delete Users");
            Console.WriteLine("9.Show all Orders");
            Console.WriteLine("10.Add new Orders");
            Console.WriteLine("11.Delete Orders");
            Console.WriteLine("12.Edit Orders");
            Console.WriteLine("13.Show all User with Ordes");
            Console.WriteLine("14. Top 3 user order count");
            */
            Console.WriteLine("+=================+\n work with Products\n");
            Console.WriteLine("31. Show all Products");
            Console.WriteLine("32. Add Product");
            Console.WriteLine("33. Edit Product");
            Console.WriteLine("34. Delete Products");


            Console.WriteLine("0. Exitn\n");
        }
        public void ExecuteOption(int option)
        {
            switch (option)
            {
                case 1:
                    Console.Clear();
                    ShowAll();
                    break;
                case 2:
                    Console.Clear();

                    Console.WriteLine("Enter name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter description:");
                    string description = Console.ReadLine();
                    AddStudent(name, description);
                    break;
                case 3:
                    Console.Clear();

                    Console.WriteLine("Enter student ID to update:");
                    int idToUpdate = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new name:");
                    string newName = Console.ReadLine();
                    Console.WriteLine("Enter new description:");
                    string newDescription = Console.ReadLine();
                    UpdateStudent(idToUpdate, newName, newDescription);
                    break;
                case 4:
                    Console.Clear();

                    Console.WriteLine("Enter student ID to remove:");
                    int idToRemove = int.Parse(Console.ReadLine());
                    RemoveStudent(idToRemove);
                    break;
                    ////////////////////////
                case 5:
                    Console.Clear();
                    _UserSOrderService.ShowAllUsers();
                    break;
                case 6:
                    Console.Clear();
                    Console.WriteLine("Enter name:");
                    string userName = Console.ReadLine();
                    _UserSOrderService.AddUser(userName);
                    break;
                case 7:
                    Console.Clear();
                    Console.WriteLine("Enter user ID to update:");
                    int userIdToUpdate = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new name:");
                    string newUserName = Console.ReadLine();
                    _UserSOrderService.UpdateUser(userIdToUpdate, newUserName);
                    break;
                case 8:
                    Console.Clear();
                    Console.WriteLine("Enter user ID to remove:");
                    int userIdToRemove = int.Parse(Console.ReadLine());
                    _UserSOrderService.DeleteUser(userIdToRemove);
                    break;
                case 9:
                    Console.Clear();
                    //_UserSOrderService.ShowAllOrders();
                    break;
                case 10:
                    Console.Clear();
                    Console.WriteLine("Enter order name:");
                    string orderName = Console.ReadLine();
                    Console.WriteLine("Enter user ID for the order:");
                    int userIdForOrder = int.Parse(Console.ReadLine());
                   // _UserSOrderService.AddOrder(orderName, userIdForOrder);
                    break;
                case 11:
                    Console.Clear();
                    Console.WriteLine("Enter order ID to remove:");
                    int orderIdToRemove = int.Parse(Console.ReadLine());
                    _UserSOrderService.DeleteOrder(orderIdToRemove);
                    break;
                case 12:
                    Console.Clear();
                    Console.WriteLine("Enter order ID to update:");
                    int orderIdToUpdate2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new name:");
                    string newOrderName2 = Console.ReadLine();
                    //_UserSOrderService.UpdateOrder(orderIdToUpdate2, newOrderName2);
                    break;
                case 13:
                    Console.Clear();
                    Console.WriteLine(" All Users with  orders:");
                //    _UserSOrderService.ShowAllUsersWithOrders();
                    break;

                //// Homework ////
                case 14:
                    Console.Clear();
                    Console.WriteLine("Top 3 users with the most orders:");
                    _UserSOrderService.Showtop3UsersWithMostOrders();
                    break;





                case 31:
                    Console.Clear();
                    Console.WriteLine("All Products:");
                    _ProductService.ShowAllProducts();
                    break;
                case 32:
                    Console.Clear();
                    Console.WriteLine("Enter product name:");
                    string productName = Console.ReadLine();
                    Console.WriteLine("Enter product price:");
                    decimal productPrice = decimal.Parse(Console.ReadLine());
                    var product = new Product
                    {
                        Name = productName,
                        Price = productPrice
                    };
                    _ProductService.AddProduct(product);
                    break;
                case 33:
                    Console.Clear();
                    Console.WriteLine("Enter product ID to update:");
                    int productIdToUpdate = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter new name:");
                    string newProductName = Console.ReadLine();
                    Console.WriteLine("Enter new price:");
                    decimal newProductPrice = decimal.Parse(Console.ReadLine());
                    var prod1 = new Product { Name = newProductName, Price = newProductPrice };
                    
                    _ProductService.UpdateProduct(productIdToUpdate,prod1);
                    break;
                case 34:
                    Console.Clear();
                    Console.WriteLine("Enter product ID to remove:");
                    int productIdToRemove = int.Parse(Console.ReadLine());
                    var productToRemove = _ProductService.GetAllProducts().FirstOrDefault(p => p.Id == productIdToRemove);
                    if (productToRemove != null)
                    {
                        _ProductService.DeleteProduct(productToRemove);
                    }
                    else
                    {
                        Console.WriteLine("Product not found.");
                    }
                    break;

                case 0:
                    Console.Clear();

                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again. =/");
                    break;
            }
        }
        public void Run()
        {
            while (true)
            {
                ShowMenu();
                Console.WriteLine("Select an option:");
                int option = int.Parse(Console.ReadLine());
                ExecuteOption(option);
            }
        }
        public void ShowAll()
        {
            var students = _StudentService.GetAll();
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Description: {student.Description}");
            }
        }
        public void AddStudent(string name, string description)
        {
            var student = new Student
            {
                Name = name,
                Description = description
            };
            _StudentService.Add(student);
        }

        public void UpdateStudent(int id, string name, string description)
        {
            var student = _StudentService.GetAll().FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                student.Name = name;
                student.Description = description;
                _StudentService.UpdateById(id);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        public void RemoveStudent(int id)
        {
            var student = _StudentService.GetAll().FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                _StudentService.DeleteById(id);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        public static void ShowAll(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Description: {student.Description}");
            }
        }
        public static void AddStudent(List<Student> students, string name, string description)
        {
            var student = new Student
            {
                Name = name,
                Description = description
            };
            students.Add(student);
        }
        public static void UpdateStudent(List<Student> students, int id, string name, string description)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                student.Name = name;
                student.Description = description;
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        public static void RemoveStudent(List<Student> students, int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}