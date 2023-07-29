using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Business
{
    public class Table
    {
        public List<OrderItem> OrderItems { get; set; }
        public Order Order { get; set; }
        public TableStatus Status { get; set; }
        public int TableNo { get; set; }
    }

    public enum TableStatus
    {
        [Display(Name = "Bàn Trống")]
        Empty,
        [Display(Name = "Mới")]
        New,
        [Display(Name = "Chốt")]
        Confirm,
        [Display(Name = "Đang Sửa")]
        Edit,
        [Display(Name = "Đã Thanh Toán")]
        Paid
    }
}
