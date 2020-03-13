using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebApp.Data.Enums;
using WebApp.Data.Interfaces;
using WebApp.Infrastructure.SharedKernel;

namespace WebApp.Data.Entities
{
    public class ProductCategory : DomainEntity<int>, IHasSeoMetaData, IHasOwner<int>, IHasSortDelete, ISortable, ISwitchable, IDateTracking
    {
        //list product maybe null,should be add constructor
        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }
        [StringLength(255)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int? HomeOrder { get; set; }
        public string Image { get; set; }
        //is home position
        public bool? HomeFlag { get; set; }
        //maybe null
        public virtual ICollection<Product> Products { get; set; }
        #region common property
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Status Status { get; set; }
        public int SortOrder { get; set; }
        public bool IsDeleted { get; set; }
        public string SeoPageTitle { get; set; }
        [Column(TypeName ="varchar")]
        [StringLength(255)]
        public string SeoAlias { get; set; }
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public int OwnerId { get; set; }
        #endregion
    }
}
