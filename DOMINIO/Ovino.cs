using DOMINIO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class Ovino : Animal, IValidable
    {
        private double _pesoLana;
        private static double s_precioKgLana = 1;
        private static double s_precioOvino = 1;

        public Ovino(double pesoLana, string codigo, Sexo sexo, string raza, DateTime fchNac, double costoAdq, double costoAlim, double pesoActual, bool hibrido) : base(codigo, sexo, raza, fchNac, costoAdq, costoAlim, pesoActual, hibrido)
        {
            _pesoLana = pesoLana;
        }

        public static double Precio
        {
            get { return s_precioKgLana; }
        }

        public void Validar()
        {
            if (_pesoLana < 0) throw new Exception("El peso de la lana no puede ser negativo");
        }

        public static void CambiarPrecioBase(double nuevoPrecioBase)
        {
            if (nuevoPrecioBase < 0) throw new Exception("El precio no puede ser negativo");

            s_precioKgLana = nuevoPrecioBase;
        }

        public override double PotencialDeVenta()
        {
            double precio = _pesoLana * s_precioKgLana + (s_precioOvino * base.PesoActual);
            if (base.Hibrido) precio *= 0.95;
            return precio;
        }

        public override string GetTipo()
        {
            return "Ovino";
        }
    }
}
