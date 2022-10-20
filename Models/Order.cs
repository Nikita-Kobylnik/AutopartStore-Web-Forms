﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AutopartStore2.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Пожалуйста введите свое имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Вы должны указать адрес доставки(отделение почты, домашний адрес )")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        [Required(ErrorMessage = "Пожалуйста укажите город, куда нужно доставить заказ")]
        public string City { get; set; }
        public bool Dispatched { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
    }

    public class OrderLine
    {
        public int OrderLineId { get; set; }
        public Order Order { get; set; }
        public Autopart Autopart { get; set; }
        public int Quantity { get; set; }
    }
}