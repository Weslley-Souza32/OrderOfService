using OrderOfService.Entities;
using OrderOfService.Entities.Enums;
using System.Globalization;

namespace OrderOfService
{
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client date:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date: ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order date:");
            Console.Write("Status:");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(name, email, birthDate);
            Order order = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item date:");
                Console.Write("Product Name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double price = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(productName, price);

                Console.Write("Quantity: ");
                int quantity = Convert.ToInt32(Console.ReadLine());

                OrderItem orderItem = new OrderItem(quantity, price, product);

                order.AddItem(orderItem);
                Console.WriteLine("____________________________________________________________");
            }

            Console.WriteLine();
            Console.WriteLine("Order Sumary:");
            Console.WriteLine(order);
        }
    }
}