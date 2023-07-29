using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DataAdapters;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Business
{
    public class OrderBU
    {
        public static void LoadMasterData()
        {
            Global.Staff = OrderDataAdapter.GetAllStaff();
            Global.Categories = OrderDataAdapter.GetAllCategories();
            Global.Dishes = OrderDataAdapter.GetAllDish();
            Global.Tables = new List<Table>();
            for(int i = 0; i <= 10; i++)
            {
                Table table = new Table();
                table.Status = TableStatus.Empty;
                Global.Tables.Add(table);
            }
        }

        public static decimal CalculateTotal(Table table)
        {
            decimal? total = 0;
            foreach(var orderItem in table.OrderItems)
            {
                if (orderItem.Quantity > 0)
                {
                    var dish = Global.Dishes.Where(x => x.DishNo == orderItem.DishNo).FirstOrDefault();
                    orderItem.Price = dish.Price * orderItem.Quantity;
                    total += orderItem.Price;
                }
            }
            return total.Value;
        }

        public static void Paid(Table table)
        {
            table.Order.OrderItems = new List<OrderItem>();
            foreach (var orderItem in table.OrderItems)
            {
                if (orderItem.Quantity > 0)
                {
                    table.Order.OrderItems.Add(orderItem);
                }
            }
            OrderDataAdapter.CreateOrder(table.Order);
        }
    }
}
