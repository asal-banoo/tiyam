using Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "عنوان")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [MaxLength(255, ErrorMessage = ErrMsg.MaxLenghtMsg)]
        [MinLength(3, ErrorMessage = ErrMsg.MinLenghtMsg)]
        [RegularExpression(@"[a-zا-یA-Z0-9آ\s_\-]*", ErrorMessage = ErrMsg.RegexMsg)]
        public string Title { get; set; }

        [Display(Name ="معرفی اجمالی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [Column(TypeName ="nvarchar(max)")]
        public string Text { get; set; }

        [Display(Name = "نقد و برسی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        [Column(TypeName = "nvarchar(max)")]
        public string Evaluation { get; set; }

        [Display(Name = "تاریخ")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "وضعیت")]
        [Range(0,10,ErrorMessage =ErrMsg.RangeMsg)]
        public int Status { get; set; }

        [Display(Name = "موجودی")]
        [Required(AllowEmptyStrings = false, ErrorMessage = ErrMsg.RequierdMsg)]
        public int Count { get; set; }


        [Display(Name = "وزن")]
        public int Wight { get; set; }

        [Display(Name = "ابعاد")]
        public string Size { get; set; }



        public virtual ICollection<Prices> Prices { get; set; }
        public virtual ICollection<Image> Images { get; set; }
        public virtual ICollection<Order> Orders { get; set; }



    }
}
