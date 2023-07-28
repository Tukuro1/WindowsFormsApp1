using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.DataAdapters
{
    public class OrderDataAdapter
    {
        public static List<Staff> GetAllStaff()
        {
            using (var context = new Model1())
            {
                var query = context.Staffs;
                return query.ToList();
            }
        }

        public static List<Category> GetAllCategories()
        {
            using (var context = new Model1())
            {
                var query = context.Categories;
                return query.ToList();
            }
        }

        public static List<Dish> GetAllDish()
        {
            using (var context = new Model1())
            {
                var query = context.Dishes;
                return query.ToList();
            }
        }
    }
}
