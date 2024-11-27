using DOMINIO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class Capataz : Empleado, IValidable
    {
        private double _perACargo;

        public Capataz(double perACargo, string email, string password, string nombre, DateTime fchIngreso) : base(email, password, nombre, fchIngreso)
        {
            _perACargo = perACargo;
        }

        public void Validar()
        {
            if (_perACargo < 0) throw new Exception("El número no es válido");
        }

        public override string GetTipo()
        {
            return "Capataz";
        }
    }
}
