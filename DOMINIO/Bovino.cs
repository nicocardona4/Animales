using DOMINIO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class Bovino : Animal, IValidable
    {
        private TipoAlim _tipoAlim;
        private static double s_precioBovino = 1;

        public Bovino(TipoAlim tipoAlim, string codigo, Sexo sexo, string raza, DateTime fchNac, double costoAdq, double costoAlim, double pesoActual, bool hibrido) : base(codigo, sexo, raza, fchNac, costoAdq, costoAlim, pesoActual, hibrido)
        {
            _tipoAlim = tipoAlim;
        }

        public Bovino() : base()
        {

        }

        public TipoAlim TipoAlim
        {
            get {return _tipoAlim;}
            set { _tipoAlim = value;}
        }
        public double PrecioBovino
        {
            get { return s_precioBovino; }
            set { s_precioBovino = value; }
        }

        public void Validar()
        {
            if (_tipoAlim == null) throw new Exception("El tipo de alimento no puede ser nulo");
        }

        public override double PotencialDeVenta()
        {
            double precio = s_precioBovino * base.PesoActual;
            if (_tipoAlim == TipoAlim.Grano) precio *= 1.3;
            if (base.Sexo == Sexo.Hembra) precio *= 1.1;
            return precio;
        }

        public override string GetTipo()
        {
            return "Bovino";
        }
    }
}
