using DOMINIO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public abstract class Animal : IValidable,  IEquatable<Animal>
    {
        private string _codigo;
        private Sexo _sexo;
        private string _raza;
        private DateTime _fchNac;
        private double _costoAdq;
        private double _costoAlim;
        private double _pesoActual;
        private bool _hibrido;
        private bool _libre = true;
        private List<Vacunacion> _vacunaciones = new List<Vacunacion>();

        public Animal(string codigo, Sexo sexo, string raza, DateTime fchNac, double costoAdq, double costoAlim, double pesoActual, bool hibrido)
        {
            _codigo = codigo;
            _sexo = sexo;
            _raza = raza;
            _fchNac = fchNac;
            _costoAdq = costoAdq;
            _costoAlim = costoAlim;
            _pesoActual = pesoActual;
            _hibrido = hibrido;
        //  _libre = libre;
        }

        public Animal()
        {

        }

        public string Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }    
        }
        public Sexo Sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }

        public string Raza
        {
            get { return _raza; }
            set { _raza = value; }
        }
        public DateTime FchNac
        {
            get { return _fchNac; }
            set { _fchNac = value; }
        }

        public double CostoAdq
        {
            get { return _costoAdq; }
            set { _costoAdq = value; }
        }
        public double CostoAlim
        {
            get { return _costoAlim; }
            set { _costoAlim = value; }
        }
        public double PesoActual
        {
            get { return _pesoActual; }
            set { _pesoActual = value; }
        }

        public bool Hibrido
        {
            get { return _hibrido; }
            set { _hibrido = value; }
        }

        public bool Libre
        {
            set { _libre = value; }
            get { return _libre; }
        }
        public void Validar()
        {
            if (string.IsNullOrEmpty(_codigo)) throw new Exception("El código no puede ser vacío ni nulo");
            if (_codigo.Length != 8) throw new Exception("El código debe ser un alfanumérico de 8 caracteres");
            if (string.IsNullOrEmpty(_raza)) throw new Exception("La raza no puede ser vacía ni nula");
            if (_fchNac > DateTime.Now) throw new Exception("La fecha de nacimiento no es correcta");
            if (_costoAdq < 0) throw new Exception("El costo de adquisición no puede ser negativo");
            if (_costoAlim < 0) throw new Exception("El costo de alimentación no puede ser negativo");
            if (_pesoActual < 0) throw new Exception("El peso actual no puede ser negativo");
            if (_sexo == null) throw new Exception("El sexo no puede ser nulo");

        }

        public override string ToString()
        {
            return $"Id de caravana: {_codigo} - Raza: {_raza} - Peso Actual:{_pesoActual} - Sexo: {_sexo}";
        }

        public void AgregarVacuna(Vacunacion a)
        {
            if (a == null) throw new Exception("Vacuna invalida");
            a.Validar();
            ValidarVacunaRepetida(a);
            _vacunaciones.Add(a);
        }

        public void ValidarVacunaRepetida(Vacunacion a)
        {
            foreach (Vacunacion v in _vacunaciones)
            {
                if (v.Vacuna.Equals(a.Vacuna)) throw new Exception("El animal ya tiene esa vacuna");
            }
        }

        public double CalcularCostoCrianza()
        {
            double costoCrianza;

            costoCrianza = _costoAdq + _costoAlim + (_vacunaciones.Count * 200);

            return costoCrianza;
        }

        public bool Equals(Animal? other)
        {
            return this._codigo.Equals(other._codigo);
        }

        /*public override bool Equals(object obj)
        {
            Animal a = obj as Animal;
            return a != null && this._codigo.Equals(a._codigo);
        }*/

        public abstract double PotencialDeVenta();

        public double PotencialPrecioFinal()
        {
            double final = this.CalcularCostoCrianza() - this.PotencialDeVenta();
            return final;
        }

        public abstract string GetTipo();

    }
}
