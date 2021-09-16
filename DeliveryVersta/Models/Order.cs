using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;


namespace DeliveryVersta.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Введите город отправителя")]
        [MaxLength(30, ErrorMessage = "Название города не должно превышать 30 символов")]
        public string SenderCity { get; set; }

        [Required(ErrorMessage = "Введите адрес отправителя")]
        public string SenderAddress { get; set; }

        [Required(ErrorMessage = "Введите город получателя")]
        [MaxLength(30, ErrorMessage = "Название города не должно превышать 30 символов")]
        public string RecipientCity { get; set; }

        [Required(ErrorMessage = "Введите адрес получателя")]
        public string RecipientAddress { get; set; }

        [Required(ErrorMessage = "Введите вес груза")]
        public double CargoWeight { get; set; }

        [Required(ErrorMessage = "Введите дату забора груза")]
        public DateTime PickupDate { get; set; }

    }
}
