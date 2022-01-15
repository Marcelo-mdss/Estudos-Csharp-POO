using System;
using AppPedido.Entities;
using AppPedido.Entities.Enums;
using System.Globalization;


namespace AppPedido

{
    class Program
    {
        static void Main (string[] args)
        {
            Console.WriteLine("Enter cliente data:");
            Console.Write("Nome: ");
            string name = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime barthdate = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, barthdate);

            
            Console.WriteLine();

            Console.WriteLine("Enter order data:");

            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Order order = new Order(status, client);

            Console.WriteLine();

            Console.WriteLine("How many items to this order?");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");


                Console.Write("Product name: ");
                string ProductName = Console.ReadLine();

                Console.Write("Product price: ");
                double ProductPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Product product = new Product(ProductName, ProductPrice );

                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                OrderItem item = new OrderItem(quantity, product, ProductPrice);

                order.AddItem(item);
            }

            Console.WriteLine(order);


            
        }
    }
}