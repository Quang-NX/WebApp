using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebApp.Infrastructure.SharedKernel;

namespace WebApp.Data.Entities
{
    public class Tag:DomainEntity<string>
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
    }
}
