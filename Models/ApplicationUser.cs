using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace Models
{
    public class ApplicationUser
    {
        public int ID { get; set; }
        [DisplayName("نام کاربری")]
        public string UserName { get; set; }
        [DisplayName("گذرواژه")]
        public string Password { get; set; }
        [Required]
        [DisplayName("نام")]
        [MaxLength(100)]
        public string Name { get; set; }

        [DisplayName("نام خوانوادگی")]
        [MaxLength(100)]
        public string Family { get; set; }

        [DisplayName("کشور")]
        [MaxLength(100)]
        public string Country { get; set; }

        [DisplayName("استان")]
        [MaxLength(100)]
        public string State { get; set; }

        [DisplayName("شهر")]
        [MaxLength(100)]
        public string City { get; set; }

        [DisplayName("آدرس")]
        [MaxLength(300)]
        public string Address { get; set; }
        [DisplayName("کدپستی")]
        [MaxLength(15)]
        public string PostalCode { get; set; }


        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
