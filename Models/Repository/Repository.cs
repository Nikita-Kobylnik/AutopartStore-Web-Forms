using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AutopartStore2.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Autopart> Autoparts
        {
            get
            {
                return context.Autoparts;
            }
        }
        public IEnumerable<Order> Orders
        {
            get
            {
                return context.Orders
                    .Include(o => o.OrderLines.Select(ol => ol.Autopart));
            }
        }

        public void SaveAutopart(Autopart autopart)
        {
            if (autopart.AutopartId == 0)
            {
                autopart = context.Autoparts.Add(autopart);
            }
            else
            {
                Autopart dbAutopart = context.Autoparts.Find(autopart.AutopartId);
                if (dbAutopart != null)
                {
                    dbAutopart.Name = autopart.Name;
                    dbAutopart.Description = autopart.Description;
                    dbAutopart.Price = autopart.Price;
                    dbAutopart.Category = autopart.Category;
                }
            }
            context.SaveChanges();
        }

        public void DeleteAutopart(Autopart autopart)
        {
            IEnumerable<Order> orders = context.Orders
                .Include(o => o.OrderLines.Select(ol => ol.Autopart))
                .Where(o => o.OrderLines
                    .Count(ol => ol.Autopart.AutopartId == autopart.AutopartId) > 0)
                .ToArray();

            foreach (Order order in orders)
            {
                context.Orders.Remove(order);
            }
            context.Autoparts.Remove(autopart);
            context.SaveChanges();
        }

        // Сохранить данные заказа в базе данных
        public void SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                order = context.Orders.Add(order);

                foreach (OrderLine line in order.OrderLines)
                {
                    context.Entry(line.Autopart).State
                        = EntityState.Modified;
                }

            }
            else
            {
                Order dbOrder = context.Orders.Find(order.OrderId);
                if (dbOrder != null)
                {
                    dbOrder.Name = order.Name;
                    dbOrder.Line1 = order.Line1;
                    dbOrder.Line2 = order.Line2;
                    dbOrder.Line3 = order.Line3;
                    dbOrder.City = order.City;
                    dbOrder.Dispatched = order.Dispatched;
                }
            }
            context.SaveChanges();
        }
    }
}