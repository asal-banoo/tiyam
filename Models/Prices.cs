using Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Prices
    {
        [Key]
        public int ID { get; set; }
        public int ProductID { get; set; }

        [Display(Name ="تاریخ")]
        [Required(AllowEmptyStrings =false,ErrorMessage =ErrMsg.RequierdMsg)]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Display(Name = "قیمت")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(14, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        [RegularExpression(@"[\d,]*",ErrorMessage =ErrMsg.RegexMsg)]
        public string Price { get; set; }


        [ForeignKey(nameof(ProductID))]
        public virtual Product Products { get; set; }
    }
}
