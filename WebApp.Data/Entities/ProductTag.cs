using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WebApp.Infrastructure.SharedKernel;

namespace WebApp.Data.Entities
{
    public class ProductTag:DomainEntity<int>
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string TagId { get; set; }
        [ForeignKey("ProductId)")]
        public virtual ICollection<Product> Products { get; set; }
        [ForeignKey("TagId)")]
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
