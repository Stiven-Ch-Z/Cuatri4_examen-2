using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

    


namespace BibliotecaMVC.Models
{
    public class Libro
    {
        [Required(ErrorMessage = "El código es obligatorio")]
        [StringLength(8, ErrorMessage = "El código no puede tener más de 8 caracteres")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El título es obligatorio para continuar")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "El autor es obligatorio para continuar")]
        public string Autor { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaPublicacion { get; set; }

    }
}