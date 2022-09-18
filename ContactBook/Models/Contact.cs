using System;
using System.ComponentModel.DataAnnotations;

namespace ContactBook.Models
{
    public class Contact
    {
        public static int ADULT_AGE = 18;

        public int ID { get; set; }

        [Required(ErrorMessage = "El campo [nombre] es requerido")]
        [StringLength(20, ErrorMessage = "El campo [nombre] no puede exceder 20 caracteres")]
        [Display(Name ="Nombre")]
        public String? name { get; set; }

        [Required(ErrorMessage = "El campo [edad] es requerido")]
        [Range(0, 110, ErrorMessage = "Edad invalida")]
        [Display(Name = "Edad")]
        public int age { get; set; }

        [EnumDataType(typeof(GenderEnum), ErrorMessage = "Debe especificar un Genero")]
        [Required(ErrorMessage = "El campo [genero] es requerido")]
        [Display(Name = "Genero")]
        public GenderEnum gender { get; set; }

        [EmailAddress(ErrorMessage ="Formato de correo invalido ")]
        [Required(ErrorMessage ="El campo [email] es requerido")]
        [Display(Name = "Email")]
        public String? email { get; set; }

        [StringLength(30, ErrorMessage="El campo [Cerveza Favorita] no puede exceder 30 caracteres")]
        //[RegularExpression("/^[a-zA-Z]+$/", ErrorMessage = "El campo [Cerveza Favorita] no permite numeros")]
        [Display(Name = "Cerveza Favorita")]
        public String? favoriteBeer { get; set; }


        public bool isAdult()
        {
            return this.age >= ADULT_AGE;
        }

        public int getAdultAge()
        {
            return ADULT_AGE;
        }
    }

    public enum GenderEnum
    {
        FEMENIMO = 1,
        MASCULINO = 2
    }
}

