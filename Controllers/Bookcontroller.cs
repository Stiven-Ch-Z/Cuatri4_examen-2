using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BibliotecaMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace BibliotecaMVC.Controllers
{
    public class Bookcontroller
    {
        private static readonly List<Libro> _libros = new List<Libro>();

        [HttpGet]
        public string Registrar() // [HttpGet]: esta acción se ejecuta al cargar la página de registro.
        {
            return "Mostrar formulario de registro de libro"; 
        }
        [HttpPost]
        public string Registrar(Libro nuevo)
        {
            var errores = ValidarModelo(nuevo); //las validaciones del modelo

            if (errores.Any())
            {
                return "Errores de validación: " + string.Join(" | ", errores); //retorna los errores encontrados
            }

            bool yaExiste = _libros.Any(l => l.Codigo.Equals(nuevo.Codigo, StringComparison.OrdinalIgnoreCase));
            if (yaExiste)
            {
                return "Si el codigo del libro se repitio no se agrego, Si es diferente se agrego exitosamente";//retorna error si el libro ya existe
            }
            else
            {
                _libros.Add(nuevo);
                return "Libro registrado exitosamente.";//retorna mensaje de exito
            }
        }
        public List<Libro> Listar(string codigo = null)
        {
            if (string.IsNullOrWhiteSpace(codigo))//si no hay filtro, devuelve todos
                return _libros.ToList();

            return _libros//si hay filtro, devuelve los que coinciden
                .Where(l => l.Codigo.IndexOf(codigo, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }
        public string Eliminar(string codigo)
        {
            var libro = _libros.FirstOrDefault(l =>
                l.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));//busca el libro por codigo

            if (libro == null)
                return "Error: Libro no encontrado.";//mensaje de error si no lo encuentra

            _libros.Remove(libro);
            return $"El libro '{libro.Titulo}' fue eliminado correctamente.";//mensaje de exito
        }
        [ActionName("VerTodos")]
        public List<Libro> ListarConAlias()
        {
            return _libros.ToList();
        }
        [NonAction]
        public string GenerarCodigoInterno()
        {
            // Devuelve un código aleatorio de 6 caracteres.
            return Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper();
        }

        [NonAction]
        private List<string> ValidarModelo(Libro modelo) //valida el modelo usando Data Annotations
        {
            var contexto = new ValidationContext(modelo, serviceProvider: null, items: null);
            var resultados = new List<ValidationResult>(); // almacena los resultados de la validación
            bool valido = Validator.TryValidateObject(modelo, contexto, resultados, true);
            return valido ? new List<string>() : resultados.Select(r => r.ErrorMessage).ToList();//retorna los mensajes de error si no es valido
        }
        public Libro ObtenerPorCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return null;//si el codigo es nulo o vacio retorna null
            return _libros.FirstOrDefault(a =>a.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));//busca el libro por codigo y lo retorna
        }
        
    }
}