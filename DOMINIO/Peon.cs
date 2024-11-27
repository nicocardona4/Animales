using DOMINIO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class Peon : Empleado, IValidable
    {
        private bool _residente;
        private List<Tarea> _tareas = new List<Tarea>();

        public Peon(bool residente, string email, string password, string nombre, DateTime fchIngreso) : base(email, password, nombre, fchIngreso)
        {
            _residente = residente;
        }

        public void Validar()
        {

        }

        public void AltaTarea(Tarea t)
        {
            if (t == null) throw new Exception("La tarea no puede ser nula");
            t.Validar();
            _tareas.Add(t);
        }
        public override string GetTipo()
        {
            return "Peon";
        }

        public List<Tarea> Tareas
        {
            get { return _tareas; }
        }

        public Tarea ObtenerTareaPorId(int id)
        {
            Tarea buscada = null;
            int i = 0;
            while(i < _tareas.Count && buscada == null)
            {
                if (_tareas[i].Id == id) buscada = _tareas[i];
                i++;
            }

            return buscada;
        }
    }
}
