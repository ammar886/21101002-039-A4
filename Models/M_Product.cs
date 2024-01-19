namespace e_commerce.Models
{
    using System;
    using System.Web;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class M_Product
    {
        [Key]
        public int Product_ID { get; set; }

        [StringLength(50)]
        public string Product_Name { get; set; }

        [StringLength(50)]
        public string Product_Description { get; set; }

        [StringLength(50)]
        public string Product_Picture { get; set; }

        [NotMapped]
        public HttpPostedFileBase A_img { get; set; }

        [NotMapped]
        public int qty { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Product_SalePrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Product_PuchasePrice { get; set; }

        public int? Product_Category_FID { get; set; }

        public virtual M_Category M_Category { get; set; }
    }
}
