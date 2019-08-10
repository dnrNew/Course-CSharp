using Course.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Course.Entities
{
    class Order
    {
        public DateTime Momment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order()
        {

        }

        public Order(DateTime momment, OrderStatus status, Client client)
        {
            Momment = momment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total(List<OrderItem> items)
        {
            double total = 0;

            foreach (var item in items)
            {
                total += item.SubTotal(item.Quantity, item.Price);
            }

            return total;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("ORDER SUMMARY:");
            sb.AppendLine("Order moment: " + Momment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Client: " + Client.Name
                + " (" + Client.BirthDate.ToString("dd/MM/yyyy") + ") "
                + Client.Email);
            sb.Append("Order items: ");

            foreach (var item in Items)
            {
                sb.AppendLine(item.Product.Name + ", "
                    + $"${item.Price.ToString("F2", CultureInfo.InvariantCulture)}, "
                    + "Quantity: " + item.Quantity
                    + " Subtotal: " + $"${item.SubTotal(item.Quantity, item.Price).ToString("F2", CultureInfo.InvariantCulture)}");
            }

            sb.AppendLine("Total price: $" + Total(Items).ToString("F2", CultureInfo.InvariantCulture));

            return sb.ToString();
        }
    }
}
