using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryVersta.Models;

namespace DeliveryVersta.Services
{
    /// <summary>
    /// Интерфейс сервиса для работы с заказами
    /// </summary>
    public interface IDeliveryService
    {
        /// <summary>
        /// Создание нового заказа
        /// </summary>
        /// <param name="order">Заказ</param>
        /// <returns>Заказ</returns>
        Task<ActionResult<Order>> CreateOrder(Order order);

        /// <summary>
        /// Получение списка заказов
        /// </summary>
        /// <returns>Список заказов</returns>
        Task<ActionResult<IEnumerable<Order>>> GetOrders();
    }
}
