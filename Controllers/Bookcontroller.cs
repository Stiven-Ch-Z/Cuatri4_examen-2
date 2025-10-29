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
        public string Registrar()
        {
            return "Mostrar formulario de registro de libro";
        }
        [HttpPost]
        public string Registrar(Libro nuevo)
        {
            var errores = ValidarModelo(nuevo);
            if (errores.Any())
            {
                return "Errores de validación: " + string.Join(" | ", errores);
            }
            bool yaExite = _libros.Any(l => l.Codigo.Equals(nuevo.Codigo, StringComparison.OrdinalIgnoreCase));
            if (yaExite)
            {
                return "El libro con ese código ya existe.";
            }
            _libros.Add(nuevo);
            return "Libro registrado exitosamente.";
        }
        public List<Libro> Listar(string codigo = null)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                return _libros.ToList();

            return _libros
                .Where(l => l.Codigo.IndexOf(codigo, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }
        [HttpGet]
        public string Eliminar(string codigo)
        {
            var libro = _libros.Find(l => l.Codigo == codigo);
            if (libro == null)
                return "Libro no encontrado.";

            _libros.Remove(libro);
            return $"Libro '{libro.Titulo}' eliminado correctamente";
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
        private List<string> ValidarModelo(Libro modelo)
        {
            var contexto = new ValidationContext(modelo, serviceProvider: null, items: null);
            var resultados = new List<ValidationResult>();
            bool valido = Validator.TryValidateObject(modelo, contexto, resultados, true);
            return valido ? new List<string>() : resultados.Select(r => r.ErrorMessage).ToList();
        }
        public Libro ObtenerPorCodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo)) return null;
            return _libros.FirstOrDefault(a =>
            a.Codigo.Equals(codigo, StringComparison.OrdinalIgnoreCase));
        }
    }
}