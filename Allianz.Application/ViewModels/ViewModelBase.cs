using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Company.Application.ViewModels
{
    public class ViewModelBase
    {
        [Key]
        public int Id { get; set; }

        //[Required(ErrorMessage = "The Created is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        //[DisplayName("Created Date")]
        public DateTime? Created { get; set; }

        //[Required(ErrorMessage = "The LastModified is Required")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        //[DisplayName("LastModified Date")]
        public DateTime? LastModified { get; set; }
    }
}
