using DOMINIO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class Vacuna : IValidable
    {
        private string _nombre;
        private string _descripcion;
        private string _patogeno;

        public Vacuna(string nombre, string descripcion, string patogeno)
        {
            _nombre = nombre;
            _descripcion = descripcion;
            _patogeno = patogeno;
        }

        public string Nombre
        {
            get { return _nombre; }
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser vacío ni nulo");
            if (string.IsNullOrEmpty(_descripcion)) throw new Exception("La descrpición no puede ser vacía ni nula");
            if (string.IsNullOrEmpty(_patogeno)) throw new Exception("El patógeno no puede ser vacío ni nulo");
        }

        public override bool Equals(object obj)
        {
            Vacuna v = obj as Vacuna;
            return v != null && this._nombre.Equals(v._nombre);
        }
        
        public override string ToString()
        {
            return $"Nombre: {_nombre} - Patógeno: {_patogeno}";
        }

        public string Patogeno
        {
            get { return _patogeno; }   
        }
    }
}
