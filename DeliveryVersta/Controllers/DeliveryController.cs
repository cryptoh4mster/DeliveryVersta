using DeliveryVersta.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using DeliveryVersta.Services;
    
namespace DeliveryVersta.Controllers
{
    /// <summary>
    /// Контроллер для реализации методов создания и получения списка заказов
    /// </summary>
    public class DeliveryController : Controller
    {
        private readonly ILogger<DeliveryController> _logger;
        private IDeliveryService DeliveryService;

        /// <summary>
        /// Конструктор 
        /// </summary>
        /// <param name="logger">Здесь не используется логгирование</param>
        /// <param name="deliveryService">Сервис с методами</param>
        public DeliveryController(ILogger<DeliveryController> logger, IDeliveryService deliveryService)
        {
            _logger = logger;
            DeliveryService = deliveryService;
        }
        
        /// <summary>
        /// Создание нового заказа
        /// </summary>
        /// <param name="order">Полученный заказ</param>
        /// <returns>Валидация и возврат предтавления</returns>
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                await DeliveryService.CreateOrder(order);
                return RedirectToAction("GetOrders", "Delivery");
            }
            return View("Ordering");
        }

        /// <summary>
        /// Метод для получения списка заказов
        /// </summary>
        /// <returns>Страницу с заказами и передает туда список заказов</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = (await DeliveryService.GetOrders()).Value;
            return View("Orders",orders);
        }
        
        /// <summary>
        /// Метод для перехода на главную страницу
        /// </summary>
        /// <returns>Главная страница</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Метод для перехода на страницу с оформлением заказа
        /// </summary>
        /// <returns>Страница оформления заказа</returns>
        public IActionResult Ordering()
        {
            return View("Ordering");
        }

        /// <summary>
        /// Метод для перехода на страницу с заказами
        /// </summary>
        /// <returns>Выполнение метода получения заказов</returns>
        public IActionResult Orders()
        {
            return RedirectToAction("GetOrders");
        }
    }
}
