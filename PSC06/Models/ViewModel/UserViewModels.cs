using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace PSC06.Models.ViewModel
{
    public class AddUserViewModels
    {
        [Required]
        [Display(Name ="Nombre Corto")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "correo")]
        [EmailAddress]
        [StringLength(100, ErrorMessage ="El {0} debe tener al 1 caracter", MinimumLength =1)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirma password")]
        [DataType(DataType.Password)]
        public string ConfirmaPassword { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public string Edad { get; set; }
    }
}