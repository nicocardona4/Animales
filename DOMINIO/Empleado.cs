using DOMINIO.Interfaces;


namespace DOMINIO
{
    public abstract class Empleado : IValidable , IEquatable<Empleado>
    {
        private string _email;
        private string _password;
        private string _nombre;
        private DateTime _fchIngreso;

        public Empleado(string email, string password, string nombre, DateTime fchIngreso)
        {
            _email = email;
            _password = password;
            _nombre = nombre;
            _fchIngreso = fchIngreso;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(_email)) throw new Exception("El email no puede ser vacío ni nulo");
            if (string.IsNullOrEmpty(_password)) throw new Exception("La contraseña no puede ser vacía ni nula");
            if (string.IsNullOrEmpty(_nombre)) throw new Exception("El nombre no puede ser vacío ni nulo");
            if (_fchIngreso > DateTime.Now) throw new Exception("La fecha de ingreso no puede ser mayor al día de hoy");
        }

        public bool Equals(Empleado? other)
        {
            return this._email.Equals(other._email);
        }

        public string Email
        {
            get { return _email; }
        }
        public string Password
        {
            get { return _password; }
        }

        public string Nombre
        {
            get { return _nombre; }
        }

        public DateTime FchIngreso
        {
            get { return _fchIngreso; }
        }
        public abstract string GetTipo();

    }
}
