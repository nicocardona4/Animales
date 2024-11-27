using DOMINIO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class Vacunacion : IValidable
    {
        private Vacuna _vacuna;
        private DateTime _fchDada;
        private DateTime _fchVenc;

        public Vacunacion(Vacuna vacuna, DateTime fchDada, DateTime fchVenc)
        {
            _vacuna = vacuna;
            _fchDada = fchDada;
            _fchVenc = fchVenc;
        }

        public Vacuna Vacuna
        {
            get { return _vacuna; }
        }

        public DateTime FchDada
        {
            get { return _fchDada; }
        }

        public void Validar()
        {
            if (_vacuna == null) throw new Exception("La vacuna no puede ser nula");
            if (_fchDada > DateTime.Now) throw new Exception("La fecha de vacunación no es correcta");
            if (_fchDada > _fchVenc) throw new Exception("La fecha de vencimiento no es correcta");

        }
    }
}
