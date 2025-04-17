using EF.DAL.Entities;
using EF.DAL;
using Microsoft.EntityFrameworkCore.Diagnostics;
    public class UserSOrderService
    {
        public readonly UserRepository _userRepository;
        public readonly OrderRepository _orderRepository;

        public UserSOrderService()
        {
            _userRepository = new UserRepository();
            _orderRepository = new OrderRepository();
        }
        public void AddUser(string name)
        {
            var user = new User { Name = name };
            _userRepository.Add(user);
        }
        public void AddOrder(string name, int userId)
        {
            var order = new Order { Name = name, UserId = userId };
            _orderRepository.Add(order);
        }
        public void UpdateUser(int id, string name)
        {
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.Name = name;
                _userRepository.Update(user);
            }
        }
        public void UpdateOrder(int id, string name)
        {
            var order = _orderRepository.GetAll().FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                order.Name = name;
                _orderRepository.Update(order);
            }
        }
        public void DeleteUser(int id)
        {
            var user = _userRepository.GetAll().FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                _userRepository.Delete(user);
            }
        }
        public void DeleteOrder(int id)
        {
            var order = _orderRepository.GetAll().FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                _orderRepository.Delete(order);
            }
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }
        public void ShowAllUsers()
        {
            var users = GetAllUsers();
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}, Name: {user.Name}");
            }
        }
        public void ShowAllOrders()
        {
            var orders = GetAllOrders();
            foreach (var order in orders)
            {
                Console.WriteLine($"Id: {order.Id}, Name: {order.Name}, UserId: {order.UserId}");
            }
        }
        public void ShowUserOrders(int userId)
        {
            var orders = GetAllOrders().Where(o => o.UserId == userId);
            foreach (var order in orders)
            {
                Console.WriteLine($"Order Id: {order.Id}, Name: {order.Name}");
            }
        }
        public void ShowOrderUser(int orderId)
        {
            var order = GetAllOrders().FirstOrDefault(o => o.Id == orderId);
            if (order != null)
            {
                var user = GetAllUsers().FirstOrDefault(u => u.Id == order.UserId);
                if (user != null)
                {
                    Console.WriteLine($"Order Id: {order.Id}, Name: {order.Name}, User Id: {user.Id} User: {user.Name}");
                }
            }
        }
        public void ShowAllUsersWithOrders()
        {
            var users = GetAllUsers();
            foreach (var user in users)
            {
                Console.WriteLine($" User id: {user.Id} ,User: {user.Name}");
                var orders = GetAllOrders().Where(o => o.UserId == user.Id);
                foreach (var order in orders)
                {
                    Console.WriteLine($"\tOrder: {order.Name}");
                }
            }
        }
    public int OrderCount(int userId)
    {
        var orders = GetAllOrders().Where(o => o.UserId == userId);
        return orders.Count();
    }
        public void Showtop3UsersWithMostOrders()
    {
        var users = GetAllUsers();
        var orders = GetAllOrders();
        var userOrderCount = users.Select(u => new
        {
            User = u,
            OrderCount = orders.Count()
        }).OrderByDescending(u => u.OrderCount).Take(3);
        foreach (var user in userOrderCount)
        {
            Console.WriteLine($"User: {user.User.Name}, Orders: {user.OrderCount}");
        }
    }   


}
