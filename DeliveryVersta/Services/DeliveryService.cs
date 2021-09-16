using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DeliveryVersta.Models;

namespace DeliveryVersta.Services
{
    /// <summary>
    /// Сервис реализующий методы создания заказа и получения списка заказов
    /// </summary>
    public class DeliveryService : IDeliveryService
    {
        private OrdersContext db;

        /// <summary>
        /// Конструктор сервиса
        /// </summary>
        /// <param name="context">Контекст бд</param>
        public DeliveryService(OrdersContext context)
        {
            db = context;
        }

        /// <summary>
        /// Создание нового заказа
        /// </summary>
        /// <param name="order"></param>
        /// <returns>Созданный заказ типа Order</returns>
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            db.Orders.Add(order);
            await db.SaveChangesAsync();
            return order;
        }

        /// <summary>
        /// Получение всех заказов
        /// </summary>
        /// <returns>Список заказов</returns>
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await db.Orders.ToListAsync();
        }
    }
}
