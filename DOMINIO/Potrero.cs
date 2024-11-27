using DOMINIO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class Potrero : IValidable, IComparable<Potrero>
    {
        private static int s_ultId = 1;
        private int _id = 1;
        private string _descripcion;
        private double _hect;
        private int _capacidad;
        private List<Animal> _animales = new List<Animal>();

        public Potrero(string descripcion, double hect, int capacidad)
        {
            _id = s_ultId;
            s_ultId++;
            _descripcion = descripcion;
            _hect = hect;
            _capacidad = capacidad;
        }

        public double Hect
        {
            get { return _hect; }
        }

        public int Capacidad
        {
            get { return _capacidad; }
        }

        public string Descripcion
        {
            get { return _descripcion; }
        }

        public int Id
        {
            get { return _id; }
        }

        public List<Animal> Animal
        {
            get { return _animales; }
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_descripcion)) throw new Exception("La descrpición no puede ser vacía ni nula");
            if (_hect < 0) throw new Exception("El tamaño del potrero no es válido");
            if (_capacidad < 1) throw new Exception("Debe ser mayor a 0");

        }

        public void AgregarAnimalAPotrero(Animal a)
        {
            {
                if (a == null) throw new Exception("El animal no puede ser nulo");
                a.Validar();
                if (!a.Libre) throw new Exception("El animal ya está asignado a un potrero");
                a.Libre = false;
                _animales.Add(a);
            }
        }
        public override string ToString()
        {
            return $"id: {_id} - Capacidad: {_capacidad} - Área: {_hect} - Descripción: {_descripcion}";
        }

        public bool HayLugar()
        {
            bool hayLugar = false;
            if (_capacidad - _animales.Count > 0) hayLugar = true ;
            return hayLugar;

        }

        public int CompareTo(Potrero other)
        {
            int comparacion = this._capacidad.CompareTo(other._capacidad);
            if (comparacion == 0) comparacion = this._animales.Count.CompareTo(other._animales.Count) * -1;
            return comparacion;
        }

        public double PotencialPrecioDeVenta()
        {
            double total = 0;
            foreach (Animal a in _animales)
            {
                total += a.PotencialPrecioFinal();
            }
            return total;
        }
    }
}
