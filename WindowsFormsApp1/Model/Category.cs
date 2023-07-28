namespace WindowsFormsApp1.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        [Key]
        public int CategoryNo { get; set; }

        [Required]
        [StringLength(255)]
        public string CategoryName { get; set; }

        [StringLength(255)]
        public string Image { get; set; }
    }
}
