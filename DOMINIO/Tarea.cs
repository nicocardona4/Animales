using DOMINIO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class Tarea : IValidable, IComparable<Tarea>, IEquatable<Tarea>
    {
        private static int s_ultId = 1;
        private int _id;
        private string _desc;
        private DateTime _fchRealizacion;
        private bool _completada;
        private DateTime _fchCierre;
        private string _comentario;

        public Tarea(string desc, DateTime fchRealizacion, bool completada, DateTime fchCierre, string comentario)
        {
            _id = s_ultId;
            s_ultId++;
            _desc = desc;
            _fchRealizacion = fchRealizacion;
            _completada = completada;
            _fchCierre = fchCierre;
            _comentario = comentario;
        }

        public Tarea()
        {
            this._id =s_ultId++;

        }

        public void Validar()
        {
            //if (string.IsNullOrEmpty(_desc)) throw new Exception("La descripción no puede ser vacía ni nula");
            //if (_fchRealizacion < DateTime.Today) throw new Exception("La fecha a realizar la tarea no puede ser menor a hoy");



        }

        public int CompareTo(Tarea? other)
        {
            return this._fchRealizacion.CompareTo(other._fchRealizacion);
        }

        public string Desc
        {
            get { return _desc; }
            set { _desc = value; }
        }
        public string Comentario
        {
            get { return _comentario; }
            set { _comentario = value; }
        }
        public DateTime FchRealizacion
        {
            get { return _fchRealizacion; }
            set { _fchRealizacion = value;}
        }
        public DateTime FchCierre
        {
            get { return _fchCierre; }
            set {  _fchCierre = value;}
        }

        public int Id
        {
            get { return _id; }
        }

        public bool Completada
        {
            get { return _completada; }
            set { _completada = value; }
        }

        public void FinalizarTarea(string comentario)
        {
            if (string.IsNullOrEmpty(comentario)) throw new Exception("El comentario no puede ser vacío");
            _completada = true;
            _comentario = comentario;
        }

        public bool Equals(Tarea other)
        {
            return this._id == other._id;
        }

        /*public override string ToString()
        {
            return $"{_id}";
        }*/

    }
}
