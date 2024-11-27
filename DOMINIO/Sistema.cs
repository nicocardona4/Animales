using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOMINIO
{
    public class Sistema
    {

        private List<Empleado> _empleados = new List<Empleado>();
        private List<Potrero> _potreros = new List<Potrero>();
        private List<Animal> _animales = new List<Animal>();
        private List<Vacuna> _vacunas = new List<Vacuna>();



        private static Sistema s_instancia;

        private Sistema()
        {
            RealizarPrecargas();
        }


        public static Sistema Instancia
        {
            get
            {
                if (s_instancia == null) s_instancia = new Sistema();
                return s_instancia;
            }
        }

        public List<Animal> Animales
        {
            get { return _animales; }
        }
        public List<Vacuna> Vacunas
        {
            get { return _vacunas; }
        }

        public List<Potrero> Potreros
        {
            get { return _potreros; }
        }
        public List<Empleado> Empleados
        {
            get { return _empleados; }
        }

        //metodos de alta en el sistema
        public void AltaPotrero(Potrero p)
        {
            if (p == null) throw new Exception("El potrero no puede ser nulo");
            p.Validar();
            _potreros.Add(p);
        }


        public void AltaEmpleado(Empleado e)
        {
            if (e == null) throw new Exception("El empleado no puede ser nulo");
            e.Validar();
            if (_empleados.Contains(e)) throw new Exception("El empleado ya se encuentra registrado");
            _empleados.Add(e);
        }

        public void AltaAnimal(Animal a)
        {
            if (a == null) throw new Exception("El animal no puede ser nulo");
            a.Validar();
            if (_animales.Contains(a)) throw new Exception("Ya hay un animal con esa caravana");
            _animales.Add(a);

        }

        public void AltaVacuna(Vacuna v)
        {
            if (v == null) throw new Exception("La vacuna no puede ser nula");
            v.Validar();
            _vacunas.Add(v);
        }

        public void RealizarPrecargas()
        {
            PrecargarEmpleados();
            PrecargarTareas();
            PrecargarVacunas();
            PrecargarAnimales();
            PrecargarVacunaciones();
            PrecargarPotreros();
            PrecargarAnimalesAPotreros();

        }
        public void PrecargarEmpleados()
        {
            Capataz capataz1 = new Capataz(3, "cap1@cap.com", "cap1", "Juan", new DateTime(2023, 1, 15));
            Capataz capataz2 = new Capataz(7, "cap2@email.com", "password", "Maria", new DateTime(2022, 6, 10));
            Peon peon1 = new Peon(true, "peon1@peon.com", "peon1", "Peón 1", new DateTime(2023, 5, 15));
            Peon peon2 = new Peon(false, "peon2@example.com", "password2", "Peón 2", new DateTime(2023, 6, 20));
            Peon peon3 = new Peon(false, "peon3@example.com", "password3", "Peón 3", new DateTime(2023, 7, 10));
            Peon peon4 = new Peon(true, "peon4@example.com", "password4", "Peón 4", new DateTime(2023, 8, 5));
            Peon peon5 = new Peon(false, "peon5@example.com", "password5", "Peón 5", new DateTime(2023, 9, 15));
            Peon peon6 = new Peon(false, "peon6@example.com", "password6", "Peón 6", new DateTime(2023, 10, 20));
            Peon peon7 = new Peon(true, "peon7@example.com", "password7", "Peón 7", new DateTime(2023, 11, 10));
            Peon peon8 = new Peon(false, "peon8@example.com", "password8", "Peón 8", new DateTime(2023, 12, 5));
            Peon peon9 = new Peon(true, "peon9@example.com", "password9", "Peón 9", new DateTime(2024, 1, 15));
            Peon peon10 = new Peon(false, "peon10@example.com", "password10", "Peón 10", new DateTime(2024, 2, 20));
            AltaEmpleado(capataz1);
            AltaEmpleado(capataz2);
            AltaEmpleado(peon1);
            AltaEmpleado(peon2);
            AltaEmpleado(peon3);
            AltaEmpleado(peon4);
            AltaEmpleado(peon5);
            AltaEmpleado(peon6);
            AltaEmpleado(peon7);
            AltaEmpleado(peon8);
            AltaEmpleado(peon9);
            AltaEmpleado(peon10);
        }
        public void PrecargarTareas()
        {
            Tarea t1 = new Tarea("Alimentar ganado ovino", new DateTime(2024, 8, 25), true, new DateTime(2024, 8, 26), "El suministro de alimentos estaba bajo y algunos animales quedaron sin comer.");
            Tarea t2 = new Tarea("Vacunar ganado ovino", new DateTime(2024, 8, 26), false, new DateTime(2024, 8, 27), "El suministro de alimentos estaba bajo y algunos animales quedaron sin comer.");
            Tarea t3 = new Tarea("Revisar cercas", new DateTime(2024, 8, 27), true, new DateTime(2024, 8, 28), "El suministro de alimentos estaba bajo y algunos animales quedaron sin comer.");
            Tarea t4 = new Tarea("Reparar bebederos", new DateTime(2024, 8, 28), false, new DateTime(2024, 8, 29), "Uno de los bebederos estaba roto y el ganado no pudo beber agua.");
            Tarea t5 = new Tarea("Alimentar ganado bovino", new DateTime(2024, 8, 29), true, new DateTime(2024, 8, 30), "Hubo problemas con la refrigeración de las vacunas y no pudimos administrarlas correctamente.");
            Tarea t6 = new Tarea("Vacunar ganado bovino", new DateTime(2024, 8, 30), false, new DateTime(2024, 9, 1), "Hubo problemas con la refrigeración de las vacunas y no pudimos administrarlas correctamente.");
            Tarea t7 = new Tarea("Pastoreo rotativo", new DateTime(2024, 8, 1), true, new DateTime(2024, 8, 2), "La puerta del corral estaba desencajada y algunos animales escaparon.");
            Tarea t8 = new Tarea("Mantenimiento de infraestructura", new DateTime(2024, 8, 2), false, new DateTime(2024, 8, 3), "La puerta del corral estaba desencajada y algunos animales escaparon.");
            Tarea t9 = new Tarea("Control de malezas", new DateTime(2024, 8, 3), true, new DateTime(2024, 8, 4), "La puerta del corral estaba desencajada y algunos animales escaparon.");
            Tarea t10 = new Tarea("Inspección sanitaria", new DateTime(2024, 8, 4), false, new DateTime(2024, 8, 5), "La puerta del corral estaba desencajada y algunos animales escaparon.");
            Tarea t11 = new Tarea("Conteo de cabezas de ganado", new DateTime(2024, 8, 5), true, new DateTime(2024, 8, 6), "La puerta del corral estaba desencajada y algunos animales escaparon.");
            Tarea t12 = new Tarea("Reporte de actividades diarias", new DateTime(2024, 8, 6), false, new DateTime(2024, 8, 7), "El suministro de alimentos estaba bajo y algunos animales quedaron sin comer.");
            Tarea t13 = new Tarea("Revisión de equipamiento", new DateTime(2024, 8, 7), true, new DateTime(2024, 8, 8), "La puerta del corral estaba desencajada y algunos animales escaparon.");
            Tarea t14 = new Tarea("Supervisión de pastizales", new DateTime(2024, 8, 8), false, new DateTime(2024, 8, 9), "Hubo problemas con la refrigeración de las vacunas y no pudimos administrarlas correctamente.");
            Tarea t15 = new Tarea("Capacitación en técnicas de manejo", new DateTime(2024, 8, 9), true, new DateTime(2024, 8, 10), "El suministro de alimentos estaba bajo y algunos animales quedaron sin comer.");
            Tarea t16 = new Tarea("Podar árboles en cercanías", new DateTime(2024, 8, 10), false, new DateTime(2024, 8, 11), "Los árboles estaban obstruyendo el acceso a las instalaciones.");
            Tarea t17 = new Tarea("Reparación de alambrado perimetral", new DateTime(2024, 8, 11), true, new DateTime(2024, 8, 12), "Varios tramos del alambrado estaban caídos.");
            Tarea t18 = new Tarea("Revisión de sistema de riego", new DateTime(2024, 8, 12), false, new DateTime(2024, 8, 13), "El sistema de riego presentaba pérdidas de agua.");
            Tarea t19 = new Tarea("Mantenimiento de maquinaria agrícola", new DateTime(2024, 8, 13), true, new DateTime(2024, 8, 14), "Algunas máquinas presentaban fallos mecánicos.");
            Tarea t20 = new Tarea("Control de plagas en cultivos", new DateTime(2024, 8, 14), false, new DateTime(2024, 8, 15), "Se detectaron signos de infestación de insectos.");
            Tarea t21 = new Tarea("Fumigación de granero", new DateTime(2024, 8, 15), true, new DateTime(2024, 8, 16), "Se encontraron plagas en los granos almacenados.");
            Tarea t22 = new Tarea("Desmalezado de campos", new DateTime(2024, 8, 16), false, new DateTime(2024, 8, 17), "La maleza estaba afectando el crecimiento de los cultivos.");
            Tarea t23 = new Tarea("Control de enfermedades en ganado ovino", new DateTime(2024, 8, 17), true, new DateTime(2024, 8, 18), "Se detectaron signos de enfermedad en algunos animales.");
            Tarea t24 = new Tarea("Reparación de vallas de contención", new DateTime(2024, 8, 18), false, new DateTime(2024, 8, 19), "Las vallas estaban dañadas por el clima adverso.");
            Tarea t25 = new Tarea("Alimentación suplementaria de ganado bovino", new DateTime(2024, 8, 19), true, new DateTime(2024, 8, 20), "Se necesitaba un suplemento nutricional debido a la sequía.");
            Tarea t26 = new Tarea("Monitoreo de nivel de agua en reservorio", new DateTime(2024, 8, 20), false, new DateTime(2024, 8, 21), "El nivel de agua estaba disminuyendo rápidamente.");
            Tarea t27 = new Tarea("Inspección de equipos de ordeño", new DateTime(2024, 8, 21), true, new DateTime(2024, 8, 22), "Se encontraron fallos en algunos equipos de ordeño.");
            Tarea t28 = new Tarea("Revisión de cercas eléctricas", new DateTime(2024, 8, 22), false, new DateTime(2024, 8, 23), "Se detectaron problemas de funcionamiento en las cercas eléctricas.");
            Tarea t29 = new Tarea("Podar árboles frutales", new DateTime(2024, 8, 23), true, new DateTime(2024, 8, 24), "Los árboles frutales necesitaban una poda de mantenimiento.");
            Tarea t30 = new Tarea("Mantenimiento de sistema de drenaje", new DateTime(2024, 8, 24), false, new DateTime(2024, 8, 25), "El sistema de drenaje estaba obstruido por hojas y residuos.");
            Tarea t31 = new Tarea("Limpieza de establos", new DateTime(2024, 8, 25), true, new DateTime(2024, 8, 26), "Los establos necesitaban una limpieza a fondo.");
            Tarea t32 = new Tarea("Desinfección de bebederos", new DateTime(2024, 8, 26), false, new DateTime(2024, 8, 27), "Los bebederos estaban contaminados y necesitaban desinfección.");
            Tarea t33 = new Tarea("Revisión de sistemas de ventilación", new DateTime(2024, 8, 27), true, new DateTime(2024, 8, 28), "Los sistemas de ventilación estaban obstruidos y necesitaban limpieza.");
            Tarea t34 = new Tarea("Inspección de estructuras de galpones", new DateTime(2024, 8, 28), false, new DateTime(2024, 8, 29), "Se encontraron grietas en las estructuras de los galpones.");
            Tarea t35 = new Tarea("Control de malezas en pastizales", new DateTime(2024, 8, 29), true, new DateTime(2024, 8, 30), "Las malezas estaban afectando el crecimiento del pasto.");
            Tarea t36 = new Tarea("Monitoreo de calidad del agua de riego", new DateTime(2024, 8, 30), false, new DateTime(2024, 8, 31), "Se detectaron niveles altos de minerales en el agua de riego.");
            Tarea t37 = new Tarea("Fertilización de campos de cultivo", new DateTime(2024, 8, 31), true, new DateTime(2024, 9, 1), "Los campos necesitaban fertilización para mejorar la producción.");
            Tarea t38 = new Tarea("Reparación de sistemas de iluminación", new DateTime(2024, 9, 1), false, new DateTime(2024, 9, 2), "Los sistemas de iluminación estaban defectuosos y necesitaban reparación.");
            Tarea t39 = new Tarea("Control de enfermedades en ganado bovino", new DateTime(2024, 9, 2), true, new DateTime(2024, 9, 3), "Se detectaron signos de enfermedad en el ganado bovino.");
            Tarea t40 = new Tarea("Reparación de techos de galpones", new DateTime(2024, 9, 3), false, new DateTime(2024, 9, 4), "Los techos de los galpones estaban filtrando agua y necesitaban reparación.");
            Tarea t41 = new Tarea("Revisión de sistemas de seguridad", new DateTime(2024, 9, 4), true, new DateTime(2024, 9, 5), "Los sistemas de seguridad estaban obsoletos y necesitaban actualización.");
            Tarea t42 = new Tarea("Podar setos y arbustos", new DateTime(2024, 9, 5), false, new DateTime(2024, 9, 6), "Los setos y arbustos estaban descontrolados y necesitaban poda.");
            Tarea t43 = new Tarea("Limpieza de canales de riego", new DateTime(2024, 9, 6), true, new DateTime(2024, 9, 7), "Los canales de riego estaban obstruidos y necesitaban limpieza.");
            Tarea t44 = new Tarea("Revisión de sistemas de alimentación", new DateTime(2024, 9, 7), false, new DateTime(2024, 9, 8), "Los sistemas de alimentación presentaban fallos y necesitaban reparación.");
            Tarea t45 = new Tarea("Desmalezado de áreas recreativas", new DateTime(2024, 9, 8), true, new DateTime(2024, 9, 9), "Las áreas recreativas estaban invadidas por maleza y necesitaban limpieza.");
            Tarea t46 = new Tarea("Control de temperatura en incubadoras", new DateTime(2024, 9, 9), false, new DateTime(2024, 9, 10), "La temperatura en las incubadoras estaba fluctuando y necesitaba control.");
            Tarea t47 = new Tarea("Inspección de sistemas de riego por goteo", new DateTime(2024, 9, 10), true, new DateTime(2024, 9, 11), "Se detectaron fugas en los sistemas de riego por goteo.");
            Tarea t48 = new Tarea("Mantenimiento de equipos de ordeño", new DateTime(2024, 9, 11), false, new DateTime(2024, 9, 12), "Los equipos de ordeño necesitaban limpieza y lubricación.");
            Tarea t49 = new Tarea("Control de malezas acuáticas", new DateTime(2024, 9, 12), true, new DateTime(2024, 9, 13), "Las malezas acuáticas estaban obstruyendo los canales de riego.");
            Tarea t50 = new Tarea("Desinfección de instalaciones de reproducción", new DateTime(2024, 9, 13), false, new DateTime(2024, 9, 14), "Las instalaciones de reproducción estaban contaminadas y necesitaban desinfección.");
            Tarea t51 = new Tarea("Reparación de vías de acceso", new DateTime(2024, 9, 14), true, new DateTime(2024, 9, 15), "Las vías de acceso estaban deterioradas y necesitaban reparación.");
            Tarea t52 = new Tarea("Fumigación de almacén de granos", new DateTime(2024, 9, 15), false, new DateTime(2024, 9, 16), "Se detectaron plagas en el almacén de granos y necesitaba fumigación.");
            Tarea t53 = new Tarea("Monitoreo de calidad del aire", new DateTime(2024, 9, 16), true, new DateTime(2024, 9, 17), "Se necesitaba monitorear la calidad del aire para garantizar la salud del ganado.");
            Tarea t54 = new Tarea("Revisión de cercas de seguridad", new DateTime(2024, 9, 17), false, new DateTime(2024, 9, 18), "Las cercas de seguridad estaban dañadas y necesitaban reparación.");
            Tarea t55 = new Tarea("Desmalezado de caminos internos", new DateTime(2024, 9, 18), true, new DateTime(2024, 9, 19), "Los caminos internos estaban obstruidos por la maleza y necesitaban desmalezado.");
            Tarea t56 = new Tarea("Inspección de sistemas de enfriamiento", new DateTime(2024, 9, 19), false, new DateTime(2024, 9, 20), "Los sistemas de enfriamiento estaban funcionando incorrectamente y necesitaban revisión.");
            Tarea t57 = new Tarea("Control de humedad en almacenamiento de granos", new DateTime(2024, 9, 20), true, new DateTime(2024, 9, 21), "La humedad en el almacenamiento de granos estaba causando deterioro y necesitaba control.");
            Tarea t58 = new Tarea("Mantenimiento de sistemas de comunicación", new DateTime(2024, 9, 21), false, new DateTime(2024, 9, 22), "Los sistemas de comunicación estaban fallando y necesitaban mantenimiento.");
            Tarea t59 = new Tarea("Reparación de corrales de engorde", new DateTime(2024, 9, 22), true, new DateTime(2024, 9, 23), "Los corrales de engorde estaban deteriorados y necesitaban reparación.");
            Tarea t60 = new Tarea("Desmalezado de áreas de esparcimiento", new DateTime(2024, 9, 23), false, new DateTime(2024, 9, 24), "Las áreas de esparcimiento estaban invadidas por la maleza y necesitaban desmalezado.");
            Tarea t61 = new Tarea("Control de calidad de forraje", new DateTime(2024, 9, 24), true, new DateTime(2024, 9, 25), "Se necesitaba evaluar la calidad del forraje para determinar su idoneidad para el ganado.");
            Tarea t62 = new Tarea("Fumigación de instalaciones de reproducción", new DateTime(2024, 9, 25), false, new DateTime(2024, 9, 26), "Se detectaron plagas en las instalaciones de reproducción y necesitaban fumigación.");
            Tarea t63 = new Tarea("Monitoreo de calidad del suelo", new DateTime(2024, 9, 26), true, new DateTime(2024, 9, 27), "Se necesitaba monitorear la calidad del suelo para garantizar una producción adecuada.");
            Tarea t64 = new Tarea("Revisión de sistemas de iluminación exterior", new DateTime(2024, 9, 27), false, new DateTime(2024, 9, 28), "Los sistemas de iluminación exterior estaban fallando y necesitaban revisión.");
            Tarea t65 = new Tarea("Desinfección de equipos de ordeño", new DateTime(2024, 9, 28), true, new DateTime(2024, 9, 29), "Los equipos de ordeño estaban contaminados y necesitaban desinfección.");
            Tarea t66 = new Tarea("Reparación de instalaciones de almacenamiento", new DateTime(2024, 9, 29), false, new DateTime(2024, 9, 30), "Las instalaciones de almacenamiento estaban dañadas y necesitaban reparación.");
            Tarea t67 = new Tarea("Control de malezas en bordes de campos", new DateTime(2024, 9, 30), true, new DateTime(2024, 10, 1), "Las malezas en los bordes de los campos estaban invadiendo los cultivos y necesitaban control.");
            Tarea t68 = new Tarea("Mantenimiento de sistemas de seguridad", new DateTime(2024, 10, 1), false, new DateTime(2024, 10, 2), "Los sistemas de seguridad necesitaban mantenimiento preventivo.");
            Tarea t69 = new Tarea("Revisión de sistemas de regadío por aspersión", new DateTime(2024, 10, 2), true, new DateTime(2024, 10, 3), "Los sistemas de regadío por aspersión presentaban fugas y necesitaban revisión.");
            Tarea t70 = new Tarea("Podar árboles frutales", new DateTime(2024, 10, 3), false, new DateTime(2024, 10, 4), "Los árboles frutales necesitaban una poda de mantenimiento.");
            Tarea t71 = new Tarea("Limpieza de canales de desagüe", new DateTime(2024, 10, 4), true, new DateTime(2024, 10, 5), "Los canales de desagüe estaban obstruidos y necesitaban limpieza.");
            Tarea t72 = new Tarea("Reparación de sistemas de ventilación en establos", new DateTime(2024, 10, 5), false, new DateTime(2024, 10, 6), "Los sistemas de ventilación en los establos estaban averiados y necesitaban reparación.");
            Tarea t73 = new Tarea("Control de enfermedades en ganado ovino", new DateTime(2024, 10, 6), true, new DateTime(2024, 10, 7), "Se detectaron signos de enfermedad en el ganado ovino.");
            Tarea t74 = new Tarea("Fumigación de campos de cultivo", new DateTime(2024, 10, 7), false, new DateTime(2024, 10, 8), "Se detectaron plagas en los campos de cultivo y necesitaban fumigación.");
            Tarea t75 = new Tarea("Monitoreo de calidad del agua de riego", new DateTime(2024, 10, 8), true, new DateTime(2024, 10, 9), "Se necesitaba monitorear la calidad del agua de riego para garantizar la salud de los cultivos.");
            Tarea t76 = new Tarea("Revisión de cercas eléctricas", new DateTime(2024, 10, 9), false, new DateTime(2024, 10, 10), "Las cercas eléctricas necesitaban inspección y mantenimiento.");
            Tarea t77 = new Tarea("Desmalezado de áreas recreativas", new DateTime(2024, 10, 10), true, new DateTime(2024, 10, 11), "Las áreas recreativas estaban invadidas por la maleza y necesitaban desmalezado.");
            Tarea t78 = new Tarea("Inspección de estructuras de galpones", new DateTime(2024, 10, 11), false, new DateTime(2024, 10, 12), "Las estructuras de los galpones necesitaban inspección para detectar posibles daños.");
            Tarea t79 = new Tarea("Control de malezas en pastizales", new DateTime(2024, 10, 12), true, new DateTime(2024, 10, 13), "Las malezas en los pastizales estaban afectando la calidad del forraje y necesitaban control.");
            Tarea t80 = new Tarea("Mantenimiento de sistemas de riego", new DateTime(2024, 10, 13), false, new DateTime(2024, 10, 14), "Los sistemas de riego necesitaban mantenimiento preventivo para evitar fallos durante la temporada de cultivo.");
            Tarea t81 = new Tarea("Reparación de sistemas de alimentación", new DateTime(2024, 10, 14), true, new DateTime(2024, 10, 15), "Los sistemas de alimentación presentaban fallos y necesitaban reparación.");
            Tarea t82 = new Tarea("Control de enfermedades en ganado bovino", new DateTime(2024, 10, 15), false, new DateTime(2024, 10, 16), "Se detectaron signos de enfermedad en el ganado bovino y se necesitaba control veterinario.");
            Tarea t83 = new Tarea("Limpieza de establos", new DateTime(2024, 10, 16), true, new DateTime(2024, 10, 17), "Los establos necesitaban una limpieza a fondo para garantizar la salud del ganado.");
            Tarea t84 = new Tarea("Desinfección de bebederos", new DateTime(2024, 10, 17), false, new DateTime(2024, 10, 18), "Los bebederos estaban contaminados y necesitaban desinfección.");
            Tarea t85 = new Tarea("Revisión de sistemas de iluminación", new DateTime(2024, 10, 18), true, new DateTime(2024, 10, 19), "Los sistemas de iluminación necesitaban inspección para detectar fallos.");
            Tarea t86 = new Tarea("Podar árboles en cercanías", new DateTime(2024, 10, 19), false, new DateTime(2024, 10, 20), "Los árboles cercanos a las instalaciones necesitaban poda para evitar obstrucciones.");
            Tarea t87 = new Tarea("Reparación de alambrado perimetral", new DateTime(2024, 10, 20), true, new DateTime(2024, 10, 21), "El alambrado perimetral necesitaba reparaciones para evitar intrusiones de animales salvajes.");
            Tarea t88 = new Tarea("Revisión de sistema de riego", new DateTime(2024, 10, 21), false, new DateTime(2024, 10, 22), "El sistema de riego necesitaba inspección para detectar posibles fugas.");
            Tarea t89 = new Tarea("Mantenimiento de maquinaria agrícola", new DateTime(2024, 10, 22), true, new DateTime(2024, 10, 23), "La maquinaria agrícola necesitaba mantenimiento preventivo para garantizar su correcto funcionamiento.");
            Tarea t90 = new Tarea("Control de plagas en cultivos", new DateTime(2024, 10, 23), false, new DateTime(2024, 10, 24), "Se detectaron plagas en los cultivos y se necesitaba fumigación.");
            Tarea t91 = new Tarea("Fumigación de granero", new DateTime(2024, 10, 24), true, new DateTime(2024, 10, 25), "El granero necesitaba fumigación para evitar la proliferación de insectos.");
            Tarea t92 = new Tarea("Desmalezado de campos", new DateTime(2024, 10, 25), false, new DateTime(2024, 10, 26), "Los campos necesitaban desmalezado para mejorar la productividad del ganado.");
            Tarea t93 = new Tarea("Control de enfermedades en ganado ovino", new DateTime(2024, 10, 26), true, new DateTime(2024, 10, 27), "Se detectaron signos de enfermedad en el ganado ovino y se necesitaba control veterinario.");
            Tarea t94 = new Tarea("Reparación de vallas de contención", new DateTime(2024, 10, 27), false, new DateTime(2024, 10, 28), "Las vallas de contención necesitaban reparación para evitar accidentes.");
            Tarea t95 = new Tarea("Alimentación suplementaria de ganado bovino", new DateTime(2024, 10, 28), true, new DateTime(2024, 10, 29), "El ganado bovino necesitaba alimentación suplementaria debido a la sequía.");
            Tarea t96 = new Tarea("Monitoreo de nivel de agua en reservorio", new DateTime(2024, 10, 29), false, new DateTime(2024, 10, 30), "El nivel de agua en el reservorio necesitaba monitoreo para garantizar el suministro adecuado.");
            Tarea t97 = new Tarea("Inspección de equipos de ordeño", new DateTime(2024, 10, 30), true, new DateTime(2024, 10, 31), "Los equipos de ordeño necesitaban inspección para detectar posibles fallos.");
            Tarea t98 = new Tarea("Revisión de cercas eléctricas", new DateTime(2024, 10, 31), false, new DateTime(2024, 11, 1), "Las cercas eléctricas necesitaban revisión para garantizar su correcto funcionamiento.");
            Tarea t99 = new Tarea("Podar árboles frutales", new DateTime(2024, 11, 1), true, new DateTime(2024, 11, 2), "Los árboles frutales necesitaban poda para promover un crecimiento saludable.");
            Tarea t100 = new Tarea("Mantenimiento de sistema de drenaje", new DateTime(2024, 11, 2), false, new DateTime(2024, 11, 3), "El sistema de drenaje necesitaba mantenimiento para evitar inundaciones.");
            Tarea t101 = new Tarea("Limpieza de establos", new DateTime(2024, 11, 3), true, new DateTime(2024, 11, 4), "Los establos necesitaban limpieza para garantizar la salud del ganado.");
            Tarea t102 = new Tarea("Desinfección de bebederos", new DateTime(2024, 11, 4), false, new DateTime(2024, 11, 5), "Los bebederos estaban contaminados y necesitaban desinfección.");
            Tarea t103 = new Tarea("Revisión de sistemas de ventilación", new DateTime(2024, 11, 5), true, new DateTime(2024, 11, 6), "Los sistemas de ventilación necesitaban inspección para detectar posibles obstrucciones.");
            Tarea t104 = new Tarea("Podar árboles en cercanías", new DateTime(2024, 11, 6), false, new DateTime(2024, 11, 7), "Los árboles cercanos a las instalaciones necesitaban poda para evitar obstrucciones.");
            Tarea t105 = new Tarea("Reparación de alambrado perimetral", new DateTime(2024, 11, 7), true, new DateTime(2024, 11, 8), "El alambrado perimetral necesitaba reparación para garantizar la seguridad del recinto.");
            Tarea t106 = new Tarea("Revisión de sistema de riego", new DateTime(2024, 11, 8), false, new DateTime(2024, 11, 9), "El sistema de riego necesitaba inspección para detectar posibles fugas.");
            Tarea t107 = new Tarea("Mantenimiento de maquinaria agrícola", new DateTime(2024, 11, 9), true, new DateTime(2024, 11, 10), "La maquinaria agrícola necesitaba mantenimiento preventivo para garantizar su correcto funcionamiento.");
            Tarea t108 = new Tarea("Control de plagas en cultivos", new DateTime(2024, 11, 10), false, new DateTime(2024, 11, 11), "Se detectaron plagas en los cultivos y se necesitaba fumigación.");
            Tarea t109 = new Tarea("Fumigación de granero", new DateTime(2024, 11, 11), true, new DateTime(2024, 11, 12), "El granero necesitaba fumigación para evitar la proliferación de insectos.");
            Tarea t110 = new Tarea("Desmalezado de campos", new DateTime(2024, 11, 12), false, new DateTime(2024, 11, 13), "Los campos necesitaban desmalezado para mejorar la productividad del ganado.");
            Tarea t111 = new Tarea("Control de enfermedades en ganado ovino", new DateTime(2024, 11, 13), true, new DateTime(2024, 11, 14), "Se detectaron signos de enfermedad en el ganado ovino y se necesitaba control veterinario.");
            Tarea t112 = new Tarea("Reparación de vallas de contención", new DateTime(2024, 11, 14), false, new DateTime(2024, 11, 15), "Las vallas de contención necesitaban reparación para evitar accidentes.");
            Tarea t113 = new Tarea("Alimentación suplementaria de ganado bovino", new DateTime(2024, 11, 15), true, new DateTime(2024, 11, 16), "El ganado bovino necesitaba alimentación suplementaria debido a la sequía.");
            Tarea t114 = new Tarea("Monitoreo de nivel de agua en reservorio", new DateTime(2024, 11, 16), false, new DateTime(2024, 11, 17), "El nivel de agua en el reservorio necesitaba monitoreo para garantizar el suministro adecuado.");
            Tarea t115 = new Tarea("Inspección de equipos de ordeño", new DateTime(2024, 11, 17), true, new DateTime(2024, 11, 18), "Los equipos de ordeño necesitaban inspección para detectar posibles fallos.");
            Tarea t116 = new Tarea("Revisión de cercas eléctricas", new DateTime(2024, 11, 18), false, new DateTime(2024, 11, 19), "Las cercas eléctricas necesitaban revisión para garantizar su correcto funcionamiento.");
            Tarea t117 = new Tarea("Podar árboles frutales", new DateTime(2024, 11, 19), true, new DateTime(2024, 11, 20), "Los árboles frutales necesitaban poda para promover un crecimiento saludable.");
            Tarea t118 = new Tarea("Mantenimiento de sistema de drenaje", new DateTime(2024, 11, 20), false, new DateTime(2024, 11, 21), "El sistema de drenaje necesitaba mantenimiento para evitar inundaciones.");
            Tarea t119 = new Tarea("Limpieza de establos", new DateTime(2024, 11, 21), true, new DateTime(2024, 11, 22), "Los establos necesitaban limpieza para garantizar la salud del ganado.");
            Tarea t120 = new Tarea("Desinfección de bebederos", new DateTime(2024, 11, 22), false, new DateTime(2024, 11, 23), "Los bebederos estaban contaminados y necesitaban desinfección.");
            Tarea t121 = new Tarea("Revisión de sistemas de ventilación", new DateTime(2024, 11, 23), true, new DateTime(2024, 11, 24), "Los sistemas de ventilación necesitaban inspección para detectar posibles obstrucciones.");
            Tarea t122 = new Tarea("Podar árboles en cercanías", new DateTime(2024, 11, 24), false, new DateTime(2024, 11, 25), "Los árboles cercanos a las instalaciones necesitaban poda para evitar obstrucciones.");
            Tarea t123 = new Tarea("Reparación de alambrado perimetral", new DateTime(2024, 11, 25), true, new DateTime(2024, 11, 26), "El alambrado perimetral necesitaba reparación para garantizar la seguridad del recinto.");
            Tarea t124 = new Tarea("Revisión de sistema de riego", new DateTime(2024, 11, 26), false, new DateTime(2024, 11, 27), "El sistema de riego necesitaba inspección para detectar posibles fugas.");
            Tarea t125 = new Tarea("Mantenimiento de maquinaria agrícola", new DateTime(2024, 11, 27), true, new DateTime(2024, 11, 28), "La maquinaria agrícola necesitaba mantenimiento preventivo para garantizar su correcto funcionamiento.");
            Tarea t126 = new Tarea("Control de plagas en cultivos", new DateTime(2024, 11, 28), false, new DateTime(2024, 11, 29), "Se detectaron plagas en los cultivos y se necesitaba fumigación.");
            Tarea t127 = new Tarea("Fumigación de granero", new DateTime(2024, 11, 29), true, new DateTime(2024, 11, 30), "El granero necesitaba fumigación para evitar la proliferación de insectos.");
            Tarea t128 = new Tarea("Desmalezado de campos", new DateTime(2024, 11, 30), false, new DateTime(2024, 12, 1), "Los campos necesitaban desmalezado para mejorar la productividad del ganado.");
            Tarea t129 = new Tarea("Control de enfermedades en ganado ovino", new DateTime(2024, 12, 1), true, new DateTime(2024, 12, 2), "Se detectaron signos de enfermedad en el ganado ovino y se necesitaba control veterinario.");
            Tarea t130 = new Tarea("Reparación de vallas de contención", new DateTime(2024, 12, 2), false, new DateTime(2024, 12, 3), "Las vallas de contención necesitaban reparación para evitar accidentes.");
            Tarea t131 = new Tarea("Alimentación suplementaria de ganado bovino", new DateTime(2024, 12, 3), true, new DateTime(2024, 12, 4), "El ganado bovino necesitaba alimentación suplementaria debido a la sequía.");
            Tarea t132 = new Tarea("Monitoreo de nivel de agua en reservorio", new DateTime(2024, 12, 4), false, new DateTime(2024, 12, 5), "El nivel de agua en el reservorio necesitaba monitoreo para garantizar el suministro adecuado.");
            Tarea t133 = new Tarea("Inspección de equipos de ordeño", new DateTime(2024, 12, 5), true, new DateTime(2024, 12, 6), "Los equipos de ordeño necesitaban inspección para detectar posibles fallos.");
            Tarea t134 = new Tarea("Revisión de cercas eléctricas", new DateTime(2024, 12, 6), false, new DateTime(2024, 12, 7), "Las cercas eléctricas necesitaban revisión para garantizar su correcto funcionamiento.");
            Tarea t135 = new Tarea("Podar árboles frutales", new DateTime(2024, 12, 7), true, new DateTime(2024, 12, 8), "Los árboles frutales necesitaban poda para promover un crecimiento saludable.");
            Tarea t136 = new Tarea("Mantenimiento de sistema de drenaje", new DateTime(2024, 12, 8), false, new DateTime(2024, 12, 9), "El sistema de drenaje necesitaba mantenimiento para evitar inundaciones.");
            Tarea t137 = new Tarea("Limpieza de establos", new DateTime(2024, 12, 9), true, new DateTime(2024, 12, 10), "Los establos necesitaban limpieza para garantizar la salud del ganado.");
            Tarea t138 = new Tarea("Desinfección de bebederos", new DateTime(2024, 12, 10), false, new DateTime(2024, 12, 11), "Los bebederos estaban contaminados y necesitaban desinfección.");
            Tarea t139 = new Tarea("Revisión de sistemas de ventilación", new DateTime(2024, 12, 11), true, new DateTime(2024, 12, 12), "Los sistemas de ventilación necesitaban inspección para detectar posibles obstrucciones.");
            Tarea t140 = new Tarea("Podar árboles en cercanías", new DateTime(2024, 12, 12), false, new DateTime(2024, 12, 13), "Los árboles cercanos a las instalaciones necesitaban poda para evitar obstrucciones.");
            Tarea t141 = new Tarea("Reparación de alambrado perimetral", new DateTime(2024, 12, 13), true, new DateTime(2024, 12, 14), "El alambrado perimetral necesitaba reparación para garantizar la seguridad del recinto.");
            Tarea t142 = new Tarea("Revisión de sistema de riego", new DateTime(2024, 12, 14), false, new DateTime(2024, 12, 15), "El sistema de riego necesitaba inspección para detectar posibles fugas.");
            Tarea t143 = new Tarea("Mantenimiento de maquinaria agrícola", new DateTime(2024, 12, 15), true, new DateTime(2024, 12, 16), "La maquinaria agrícola necesitaba mantenimiento preventivo para garantizar su correcto funcionamiento.");
            Tarea t144 = new Tarea("Control de plagas en cultivos", new DateTime(2024, 12, 16), false, new DateTime(2024, 12, 17), "Se detectaron plagas en los cultivos y se necesitaba fumigación.");
            Tarea t145 = new Tarea("Fumigación de granero", new DateTime(2024, 12, 17), true, new DateTime(2024, 12, 18), "El granero necesitaba fumigación para evitar la proliferación de insectos.");
            Tarea t146 = new Tarea("Desmalezado de campos", new DateTime(2024, 12, 18), false, new DateTime(2024, 12, 19), "Los campos necesitaban desmalezado para mejorar la productividad del ganado.");
            Tarea t147 = new Tarea("Control de enfermedades en ganado ovino", new DateTime(2024, 12, 19), true, new DateTime(2024, 12, 20), "Se detectaron signos de enfermedad en el ganado ovino y se necesitaba control veterin.");
            Tarea t148 = new Tarea("Reparación de vallas de contención", new DateTime(2024, 12, 20), false, new DateTime(2024, 12, 21), "Las vallas de contención necesitaban reparación para evitar accidentes.");
            Tarea t149 = new Tarea("Alimentación suplementaria de ganado bovino", new DateTime(2024, 12, 21), true, new DateTime(2024, 12, 22), "El ganado bovino necesitaba alimentación suplementaria debido a la sequía.");
            Tarea t150 = new Tarea("Monitoreo de nivel de agua en reservorio", new DateTime(2024, 12, 22), false, new DateTime(2024, 12, 23), "El nivel de agua en el reservorio necesitaba monitoreo para garantizar el suministro adecuado.");

            AgregarTareaAPeon("peon1@peon.com", t1);
            AgregarTareaAPeon("peon1@peon.com", t2);
            AgregarTareaAPeon("peon1@peon.com", t3);
            AgregarTareaAPeon("peon1@peon.com", t4);
            AgregarTareaAPeon("peon1@peon.com", t5);
            AgregarTareaAPeon("peon1@peon.com", t6);
            AgregarTareaAPeon("peon1@peon.com", t7);
            AgregarTareaAPeon("peon1@peon.com", t8);
            AgregarTareaAPeon("peon1@peon.com", t9);
            AgregarTareaAPeon("peon1@peon.com", t10);
            AgregarTareaAPeon("peon1@peon.com", t11);
            AgregarTareaAPeon("peon1@peon.com", t12);
            AgregarTareaAPeon("peon1@peon.com", t13);
            AgregarTareaAPeon("peon1@peon.com", t14);
            AgregarTareaAPeon("peon1@peon.com", t15);

            AgregarTareaAPeon("peon2@example.com", t31);
            AgregarTareaAPeon("peon2@example.com", t32);
            AgregarTareaAPeon("peon2@example.com", t33);
            AgregarTareaAPeon("peon2@example.com", t34);
            AgregarTareaAPeon("peon2@example.com", t35);
            AgregarTareaAPeon("peon2@example.com", t36);
            AgregarTareaAPeon("peon2@example.com", t37);
            AgregarTareaAPeon("peon2@example.com", t38);
            AgregarTareaAPeon("peon2@example.com", t39);
            AgregarTareaAPeon("peon2@example.com", t40);
            AgregarTareaAPeon("peon2@example.com", t41);
            AgregarTareaAPeon("peon2@example.com", t42);
            AgregarTareaAPeon("peon2@example.com", t43);
            AgregarTareaAPeon("peon2@example.com", t44);
            AgregarTareaAPeon("peon2@example.com", t45);

            AgregarTareaAPeon("peon3@example.com", t46);
            AgregarTareaAPeon("peon3@example.com", t47);
            AgregarTareaAPeon("peon3@example.com", t48);
            AgregarTareaAPeon("peon3@example.com", t49);
            AgregarTareaAPeon("peon3@example.com", t50);
            AgregarTareaAPeon("peon3@example.com", t51);
            AgregarTareaAPeon("peon3@example.com", t52);
            AgregarTareaAPeon("peon3@example.com", t53);
            AgregarTareaAPeon("peon3@example.com", t54);
            AgregarTareaAPeon("peon3@example.com", t55);
            AgregarTareaAPeon("peon3@example.com", t56);
            AgregarTareaAPeon("peon3@example.com", t57);
            AgregarTareaAPeon("peon3@example.com", t58);
            AgregarTareaAPeon("peon3@example.com", t59);
            AgregarTareaAPeon("peon3@example.com", t60);

            AgregarTareaAPeon("peon4@example.com", t61);
            AgregarTareaAPeon("peon4@example.com", t62);
            AgregarTareaAPeon("peon4@example.com", t63);
            AgregarTareaAPeon("peon4@example.com", t64);
            AgregarTareaAPeon("peon4@example.com", t65);
            AgregarTareaAPeon("peon4@example.com", t66);
            AgregarTareaAPeon("peon4@example.com", t67);
            AgregarTareaAPeon("peon4@example.com", t68);
            AgregarTareaAPeon("peon4@example.com", t69);
            AgregarTareaAPeon("peon4@example.com", t70);
            AgregarTareaAPeon("peon4@example.com", t71);
            AgregarTareaAPeon("peon4@example.com", t72);
            AgregarTareaAPeon("peon4@example.com", t73);
            AgregarTareaAPeon("peon4@example.com", t74);
            AgregarTareaAPeon("peon4@example.com", t75);

            AgregarTareaAPeon("peon5@example.com", t76);
            AgregarTareaAPeon("peon5@example.com", t77);
            AgregarTareaAPeon("peon5@example.com", t78);
            AgregarTareaAPeon("peon5@example.com", t79);
            AgregarTareaAPeon("peon5@example.com", t80);
            AgregarTareaAPeon("peon5@example.com", t81);
            AgregarTareaAPeon("peon5@example.com", t82);
            AgregarTareaAPeon("peon5@example.com", t83);
            AgregarTareaAPeon("peon5@example.com", t84);
            AgregarTareaAPeon("peon5@example.com", t85);
            AgregarTareaAPeon("peon5@example.com", t86);
            AgregarTareaAPeon("peon5@example.com", t87);
            AgregarTareaAPeon("peon5@example.com", t88);
            AgregarTareaAPeon("peon5@example.com", t89);
            AgregarTareaAPeon("peon5@example.com", t90);

            AgregarTareaAPeon("peon6@example.com", t16);
            AgregarTareaAPeon("peon6@example.com", t17);
            AgregarTareaAPeon("peon6@example.com", t18);
            AgregarTareaAPeon("peon6@example.com", t19);
            AgregarTareaAPeon("peon6@example.com", t20);
            AgregarTareaAPeon("peon6@example.com", t21);
            AgregarTareaAPeon("peon6@example.com", t22);
            AgregarTareaAPeon("peon6@example.com", t23);
            AgregarTareaAPeon("peon6@example.com", t24);
            AgregarTareaAPeon("peon6@example.com", t25);
            AgregarTareaAPeon("peon6@example.com", t26);
            AgregarTareaAPeon("peon6@example.com", t27);
            AgregarTareaAPeon("peon6@example.com", t28);
            AgregarTareaAPeon("peon6@example.com", t29);
            AgregarTareaAPeon("peon6@example.com", t30);

            AgregarTareaAPeon("peon7@example.com", t91);
            AgregarTareaAPeon("peon7@example.com", t92);
            AgregarTareaAPeon("peon7@example.com", t93);
            AgregarTareaAPeon("peon7@example.com", t94);
            AgregarTareaAPeon("peon7@example.com", t95);
            AgregarTareaAPeon("peon7@example.com", t96);
            AgregarTareaAPeon("peon7@example.com", t97);
            AgregarTareaAPeon("peon7@example.com", t98);
            AgregarTareaAPeon("peon7@example.com", t99);
            AgregarTareaAPeon("peon7@example.com", t100);
            AgregarTareaAPeon("peon7@example.com", t101);
            AgregarTareaAPeon("peon7@example.com", t102);
            AgregarTareaAPeon("peon7@example.com", t103);
            AgregarTareaAPeon("peon7@example.com", t104);
            AgregarTareaAPeon("peon7@example.com", t105);

            AgregarTareaAPeon("peon8@example.com", t106);
            AgregarTareaAPeon("peon8@example.com", t107);
            AgregarTareaAPeon("peon8@example.com", t108);
            AgregarTareaAPeon("peon8@example.com", t109);
            AgregarTareaAPeon("peon8@example.com", t110);
            AgregarTareaAPeon("peon8@example.com", t111);
            AgregarTareaAPeon("peon8@example.com", t112);
            AgregarTareaAPeon("peon8@example.com", t113);
            AgregarTareaAPeon("peon8@example.com", t114);
            AgregarTareaAPeon("peon8@example.com", t115);
            AgregarTareaAPeon("peon8@example.com", t115);
            AgregarTareaAPeon("peon8@example.com", t117);
            AgregarTareaAPeon("peon8@example.com", t118);
            AgregarTareaAPeon("peon8@example.com", t119);
            AgregarTareaAPeon("peon8@example.com", t120);

            AgregarTareaAPeon("peon9@example.com", t121);
            AgregarTareaAPeon("peon9@example.com", t122);
            AgregarTareaAPeon("peon9@example.com", t123);
            AgregarTareaAPeon("peon9@example.com", t124);
            AgregarTareaAPeon("peon9@example.com", t125);
            AgregarTareaAPeon("peon9@example.com", t126);
            AgregarTareaAPeon("peon9@example.com", t127);
            AgregarTareaAPeon("peon9@example.com", t128);
            AgregarTareaAPeon("peon9@example.com", t129);
            AgregarTareaAPeon("peon9@example.com", t130);
            AgregarTareaAPeon("peon9@example.com", t131);
            AgregarTareaAPeon("peon9@example.com", t132);
            AgregarTareaAPeon("peon9@example.com", t133);
            AgregarTareaAPeon("peon9@example.com", t134);
            AgregarTareaAPeon("peon9@example.com", t135);

            AgregarTareaAPeon("peon10@example.com", t136);
            AgregarTareaAPeon("peon10@example.com", t137);
            AgregarTareaAPeon("peon10@example.com", t138);
            AgregarTareaAPeon("peon10@example.com", t139);
            AgregarTareaAPeon("peon10@example.com", t140);
            AgregarTareaAPeon("peon10@example.com", t141);
            AgregarTareaAPeon("peon10@example.com", t142);
            AgregarTareaAPeon("peon10@example.com", t143);
            AgregarTareaAPeon("peon10@example.com", t144);
            AgregarTareaAPeon("peon10@example.com", t145);
            AgregarTareaAPeon("peon10@example.com", t146);
            AgregarTareaAPeon("peon10@example.com", t147);
            AgregarTareaAPeon("peon10@example.com", t148);
            AgregarTareaAPeon("peon10@example.com", t149);
            AgregarTareaAPeon("peon10@example.com", t150);

        }
        public void PrecargarVacunas()
        {
            Vacuna v1 = new Vacuna("Clostridium Perfringens Tipo C y D", "Vacuna para la prevención de enterotoxemias en ovinos y bovinos", "Clostridium Perfringens");
            Vacuna v2 = new Vacuna("Carbunclo Bacteridiano", "Vacuna para la prevención del carbunclo bacteridiano en ovinos y bovinos", "Bacillus anthracis");
            Vacuna v3 = new Vacuna("Peste de los pequeños rumiantes (PPR)", "Vacuna para la prevención de la peste de los pequeños rumiantes en ovinos", "Virus de la PPR");
            Vacuna v4 = new Vacuna("Pasteurelosis Neumónica", "Vacuna para la prevención de la pasteurelosis neumónica en bovinos", "Pasteurella multocida");
            Vacuna v5 = new Vacuna("Clostridium Chauvoei", "Vacuna para la prevención del pié de hueso en bovinos", "Clostridium Chauvoei");
            Vacuna v6 = new Vacuna("Clostridium Perfringens Tipo B", "Vacuna para la prevención de la enterotoxemia en ovinos", "Clostridium Perfringens");
            Vacuna v7 = new Vacuna("Brucelosis Bovina", "Vacuna para la prevención de la brucelosis en bovinos", "Brucella abortus");
            Vacuna v8 = new Vacuna("Mycoplasma bovis", "Vacuna para la prevención de la enfermedad respiratoria en bovinos", "Mycoplasma bovis");
            Vacuna v9 = new Vacuna("Enfermedad de la lengua azul", "Vacuna para la prevención de la enfermedad de la lengua azul en ovinos", "Virus de la lengua azul");
            Vacuna v10 = new Vacuna("Fiebre Aftosa", "Vacuna para la prevención de la fiebre aftosa en bovinos", "Virus de la fiebre aftosa");
            AltaVacuna(v1);
            AltaVacuna(v2);
            AltaVacuna(v3);
            AltaVacuna(v4);
            AltaVacuna(v5);
            AltaVacuna(v6);
            AltaVacuna(v7);
            AltaVacuna(v8);
            AltaVacuna(v9);
            AltaVacuna(v10);

        }
        public void PrecargarVacunaciones()
        {
            Vacunacion av1 = new Vacunacion(ObtenerVacunaPorNombre("Clostridium Perfringens Tipo C y D"), new DateTime(2023, 04, 15), new DateTime(2024, 04, 15));
            Vacunacion av2 = new Vacunacion(ObtenerVacunaPorNombre("Enfermedad de la lengua azul"), new DateTime(2023, 03, 22), new DateTime(2024, 03, 22));
            Vacunacion av3 = new Vacunacion(ObtenerVacunaPorNombre("Peste de los pequeños rumiantes (PPR)"), new DateTime(2023, 05, 10), new DateTime(2024, 05, 10));
            Vacunacion av4 = new Vacunacion(ObtenerVacunaPorNombre("Clostridium Chauvoei"), new DateTime(2023, 02, 28), new DateTime(2024, 02, 28));
            Vacunacion av5 = new Vacunacion(ObtenerVacunaPorNombre("Enfermedad de la lengua azul"), new DateTime(2023, 06, 05), new DateTime(2024, 06, 05));
            Vacunacion av6 = new Vacunacion(ObtenerVacunaPorNombre("Clostridium Chauvoei"), new DateTime(2023, 01, 12), new DateTime(2024, 01, 12));
            Vacunacion av7 = new Vacunacion(ObtenerVacunaPorNombre("Pasteurelosis Neumónica"), new DateTime(2023, 08, 20), new DateTime(2024, 08, 20));
            Vacunacion av8 = new Vacunacion(ObtenerVacunaPorNombre("Clostridium Chauvoei"), new DateTime(2023, 07, 03), new DateTime(2024, 07, 03));
            Vacunacion av9 = new Vacunacion(ObtenerVacunaPorNombre("Carbunclo Bacteridiano"), new DateTime(2023, 09, 18), new DateTime(2024, 09, 18));
            Vacunacion av10 = new Vacunacion(ObtenerVacunaPorNombre("Pasteurelosis Neumónica"), new DateTime(2023, 10, 30), new DateTime(2024, 10, 30));
            Vacunacion av11 = new Vacunacion(ObtenerVacunaPorNombre("Clostridium Perfringens Tipo C y D"), new DateTime(2023, 11, 14), new DateTime(2024, 11, 14));
            Vacunacion av12 = new Vacunacion(ObtenerVacunaPorNombre("Clostridium Perfringens Tipo B"), new DateTime(2023, 12, 25), new DateTime(2024, 12, 25));
            Vacunacion av13 = new Vacunacion(ObtenerVacunaPorNombre("Peste de los pequeños rumiantes (PPR)"), new DateTime(2023, 01, 06), new DateTime(2024, 01, 06));
            Vacunacion av14 = new Vacunacion(ObtenerVacunaPorNombre("Brucelosis Bovina"), new DateTime(2023, 02, 17), new DateTime(2024, 02, 17));
            Vacunacion av15 = new Vacunacion(ObtenerVacunaPorNombre("Clostridium Perfringens Tipo B"), new DateTime(2023, 03, 29), new DateTime(2024, 03, 29));
            Vacunacion av16 = new Vacunacion(ObtenerVacunaPorNombre("Fiebre Aftosa"), new DateTime(2023, 04, 20), new DateTime(2024, 04, 20));
            Vacunacion av17 = new Vacunacion(ObtenerVacunaPorNombre("Clostridium Perfringens Tipo B"), new DateTime(2023, 05, 02), new DateTime(2024, 05, 02));
            Vacunacion av18 = new Vacunacion(ObtenerVacunaPorNombre("Carbunclo Bacteridiano"), new DateTime(2023, 06, 14), new DateTime(2024, 06, 14));
            Vacunacion av19 = new Vacunacion(ObtenerVacunaPorNombre("Brucelosis Bovina"), new DateTime(2023, 07, 26), new DateTime(2024, 07, 26));
            Vacunacion av20 = new Vacunacion(ObtenerVacunaPorNombre("Fiebre Aftosa"), new DateTime(2023, 08, 07), new DateTime(2024, 08, 07));
            Vacunar("O0000001", av1);
            Vacunar("B0000001", av2);
            Vacunar("O0000002", av3);
            Vacunar("B0000001", av4);
            Vacunar("B0000002", av5);
            Vacunar("B0000003", av6);
            Vacunar("O0000003", av7);
            Vacunar("B0000004", av8);
            Vacunar("O0000004", av9);
            Vacunar("O0000005", av10);
            Vacunar("O0000006", av11);
            Vacunar("B0000005", av12);
            Vacunar("B0000006", av13);
            Vacunar("B0000007", av14);
            Vacunar("O0000007", av15);
            Vacunar("O0000008", av16);
            Vacunar("B0000009", av17);
            Vacunar("O0000008", av18);
            Vacunar("B0000008", av19);
            Vacunar("B0000009", av20);
        }

        public void Vacunar(string caravana, Vacunacion vacunacion)
        {
            if (vacunacion == null) throw new Exception("La vacunacion no puede ser nula");
            if (string.IsNullOrEmpty(caravana)) throw new Exception("La caravana no puede ser nula");
            if (vacunacion.FchDada > DateTime.Now) throw new Exception("La fecha no puede ser mayor a hoy");
            Animal a = ObtenerAnimalPorCaravana(caravana);
            if (a == null) throw new Exception("No se encontró el animal");
            a.AgregarVacuna(vacunacion);
        }
        public void PrecargarAnimales()
        {
            Animal o1 = new Ovino(4.5, "O0000001", Sexo.Macho, "Merino", new DateTime(2019, 05, 10), 300, 150, 100, false);
            Animal o2 = new Ovino(5.2, "O0000002", Sexo.Hembra, "Rambouillet", new DateTime(2018, 08, 15), 350, 180, 120, false);
            Animal o3 = new Ovino(4.8, "O0000003", Sexo.Macho, "Corriedale", new DateTime(2020, 03, 20), 320, 160, 110, true);
            Animal o4 = new Ovino(5.5, "O0000004", Sexo.Hembra, "Dorper", new DateTime(2017, 10, 25), 380, 200, 130, false);
            Animal o5 = new Ovino(4.2, "O0000005", Sexo.Macho, "Suffolk", new DateTime(2019, 12, 01), 290, 140, 95, false);
            Animal o6 = new Ovino(4.9, "O0000006", Sexo.Hembra, "Romney", new DateTime(2018, 06, 28), 330, 170, 115, false);
            Animal o7 = new Ovino(4.6, "O0000007", Sexo.Macho, "Targhee", new DateTime(2020, 02, 14), 310, 155, 105, false);
            Animal o8 = new Ovino(5.0, "O0000008", Sexo.Hembra, "Lincoln", new DateTime(2016, 09, 30), 360, 190, 125, false);
            Animal o9 = new Ovino(4.0, "O0000009", Sexo.Macho, "Columbia", new DateTime(2019, 07, 05), 280, 130, 90, true);
            Animal o10 = new Ovino(5.7, "O0000010", Sexo.Hembra, "Hampshire", new DateTime(2017, 04, 18), 370, 195, 135, false);
            Animal o11 = new Ovino(4.3, "O0000011", Sexo.Macho, "Merino", new DateTime(2018, 11, 22), 300, 150, 100, false);
            Animal o12 = new Ovino(5.0, "O0000012", Sexo.Hembra, "Rambouillet", new DateTime(2019, 01, 07), 340, 175, 120, false);
            Animal o13 = new Ovino(4.7, "O0000013", Sexo.Macho, "Corriedale", new DateTime(2017, 08, 12), 320, 160, 110, true);
            Animal o14 = new Ovino(5.3, "O0000014", Sexo.Hembra, "Dorper", new DateTime(2018, 05, 30), 380, 200, 130, false);
            Animal o15 = new Ovino(4.1, "O0000015", Sexo.Macho, "Suffolk", new DateTime(2018, 03, 10), 290, 140, 95, false);
            Animal b1 = new Bovino(TipoAlim.Grano, "B0000001", Sexo.Macho, "Angus", new DateTime(2019, 05, 10), 500, 200, 350, false);
            Animal b2 = new Bovino(TipoAlim.Pastura, "B0000002", Sexo.Hembra, "Hereford", new DateTime(2018, 08, 15), 600, 250, 420, false);
            Animal b3 = new Bovino(TipoAlim.Grano, "B0000003", Sexo.Macho, "Limousin", new DateTime(2020, 03, 20), 550, 220, 380, true);
            Animal b4 = new Bovino(TipoAlim.Pastura, "B0000004", Sexo.Hembra, "Charolais", new DateTime(2017, 10, 25), 700, 300, 480, false);
            Animal b5 = new Bovino(TipoAlim.Grano, "B0000005", Sexo.Macho, "Simmental", new DateTime(2019, 12, 01), 480, 180, 320, false);
            Animal b6 = new Bovino(TipoAlim.Pastura, "B0000006", Sexo.Hembra, "Angus", new DateTime(2018, 06, 28), 620, 280, 440, false);
            Animal b7 = new Bovino(TipoAlim.Grano, "B0000007", Sexo.Macho, "Hereford", new DateTime(2020, 02, 14), 530, 230, 360, false);
            Animal b8 = new Bovino(TipoAlim.Pastura, "B0000008", Sexo.Hembra, "Limousin", new DateTime(2016, 09, 30), 720, 320, 500, false);
            Animal b9 = new Bovino(TipoAlim.Grano, "B0000009", Sexo.Macho, "Charolais", new DateTime(2019, 07, 05), 470, 190, 310, true);
            Animal b10 = new Bovino(TipoAlim.Pastura, "B0000010", Sexo.Hembra, "Simmental", new DateTime(2017, 04, 18), 650, 280, 460, false);
            Animal b11 = new Bovino(TipoAlim.Grano, "B0000011", Sexo.Macho, "Angus", new DateTime(2018, 11, 22), 520, 210, 330, false);
            Animal b12 = new Bovino(TipoAlim.Pastura, "B0000012", Sexo.Hembra, "Hereford", new DateTime(2019, 01, 07), 630, 260, 400, false);
            Animal b13 = new Bovino(TipoAlim.Grano, "B0000013", Sexo.Macho, "Limousin", new DateTime(2017, 08, 12), 580, 240, 390, true);
            Animal b14 = new Bovino(TipoAlim.Pastura, "B0000014", Sexo.Hembra, "Charolais", new DateTime(2018, 05, 30), 680, 300, 470, false);
            Animal b15 = new Bovino(TipoAlim.Grano, "B0000015", Sexo.Macho, "Simmental", new DateTime(2018, 03, 10), 490, 200, 350, false);
            Animal b16 = new Bovino(TipoAlim.Grano, "B0000016", Sexo.Macho, "Simmental", new DateTime(2018, 03, 10), 490, 200, 350, false);
            Animal o16 = new Ovino(5.3, "O0000016", Sexo.Hembra, "Dorper", new DateTime(2018, 05, 30), 380, 200, 130, false);

            AltaAnimal(o1);
            AltaAnimal(o2);
            AltaAnimal(o3);
            AltaAnimal(o4);
            AltaAnimal(o5);
            AltaAnimal(o6);
            AltaAnimal(o7);
            AltaAnimal(o8);
            AltaAnimal(o9);
            AltaAnimal(o10);
            AltaAnimal(o11);
            AltaAnimal(o12);
            AltaAnimal(o13);
            AltaAnimal(o14);
            AltaAnimal(o15);
            AltaAnimal(b1);
            AltaAnimal(b2);
            AltaAnimal(b3);
            AltaAnimal(b4);
            AltaAnimal(b5);
            AltaAnimal(b6);
            AltaAnimal(b7);
            AltaAnimal(b8);
            AltaAnimal(b9);
            AltaAnimal(b10);
            AltaAnimal(b11);
            AltaAnimal(b12);
            AltaAnimal(b13);
            AltaAnimal(b14);
            AltaAnimal(b15);
            AltaAnimal(o16);
            AltaAnimal(b16);


        }
        public void PrecargarPotreros()
        {
            Potrero p1 = new Potrero("Pasto alto y suave, sin relieve", 10.5, 5);
            Potrero p2 = new Potrero("Terreno con leve inclinación, algunos árboles dispersos", 8.2, 40);
            Potrero p3 = new Potrero("Área con relieve montañoso, abundante vegetación", 15.7, 70);
            Potrero p4 = new Potrero("Pasto verde y denso, terreno llano", 12.0, 60);
            Potrero p5 = new Potrero("Zona con lagos y ríos, variada vegetación", 20.3, 90);
            Potrero p6 = new Potrero("Pastizales secos, terreno plano", 9.8, 45);
            Potrero p7 = new Potrero("Terreno con abundantes rocas y arbustos", 7.5, 35);
            Potrero p8 = new Potrero("Pasto con hierbas altas, relieve plano", 11.2, 55);
            Potrero p9 = new Potrero("Área con zonas pantanosas, vegetación diversa", 18.6, 80);
            Potrero p10 = new Potrero("Pasto verde, suelo fértil", 14.5, 65);
            Potrero p11 = new Potrero("Terreno rocoso, escasa vegetación", 6.3, 30);
            Potrero p12 = new Potrero("Pastizales secos y duros, con algunas lomas", 8.9, 40);
            Potrero p13 = new Potrero("Área con terreno pantanoso, arbustos dispersos", 16.8, 75);
            Potrero p14 = new Potrero("Pasto con malezas, suelo poco fértil", 10.0, 50);
            Potrero p15 = new Potrero("Pastizales con desniveles, cerca de un río", 13.2, 60);
            AltaPotrero(p1);
            AltaPotrero(p2);
            AltaPotrero(p3);
            AltaPotrero(p4);
            AltaPotrero(p5);
            AltaPotrero(p6);
            AltaPotrero(p7);
            AltaPotrero(p8);
            AltaPotrero(p9);
            AltaPotrero(p10);
            AltaPotrero(p11);
            AltaPotrero(p12);
            AltaPotrero(p13);
            AltaPotrero(p14);
            AltaPotrero(p15);
        }

        private void PrecargarAnimalesAPotreros()
        {
            AgregarAnimalAPotrero(1, "O0000001");
            AgregarAnimalAPotrero(3, "O0000002");
            AgregarAnimalAPotrero(5, "O0000003");
            AgregarAnimalAPotrero(9, "O0000004");
            AgregarAnimalAPotrero(2, "O0000005");
            AgregarAnimalAPotrero(4, "O0000006");
            AgregarAnimalAPotrero(8, "O0000007");
            AgregarAnimalAPotrero(1, "O0000008");
            AgregarAnimalAPotrero(7, "O0000009");
            AgregarAnimalAPotrero(7, "O0000010");
            AgregarAnimalAPotrero(3, "O0000011");
            AgregarAnimalAPotrero(1, "O0000012");
            AgregarAnimalAPotrero(5, "O0000013");
            AgregarAnimalAPotrero(2, "O0000014");
            AgregarAnimalAPotrero(9, "O0000015");
            AgregarAnimalAPotrero(7, "B0000001");
            AgregarAnimalAPotrero(3, "B0000002");
            AgregarAnimalAPotrero(1, "B0000003");
            AgregarAnimalAPotrero(6, "B0000004");
            AgregarAnimalAPotrero(5, "B0000005");
            AgregarAnimalAPotrero(9, "B0000006");
            AgregarAnimalAPotrero(3, "B0000007");
            AgregarAnimalAPotrero(2, "B0000008");
            AgregarAnimalAPotrero(4, "B0000009");
            AgregarAnimalAPotrero(8, "B0000010");
            AgregarAnimalAPotrero(5, "B0000011");
            AgregarAnimalAPotrero(7, "B0000012");
            AgregarAnimalAPotrero(3, "B0000013");
            AgregarAnimalAPotrero(1, "B0000014");
            AgregarAnimalAPotrero(2, "B0000015");
        }

        public Vacunacion AltaVacunacion(Vacuna v)
        {
            Vacunacion vc = new Vacunacion(v, DateTime.Now, DateTime.Now.AddYears(1));
            return vc;
        }

        public Animal ObtenerAnimalPorCaravana(string codigo)
        {
            Animal buscado = null;
            int i = 0;
            while (i < _animales.Count && buscado == null)
            {
                if (_animales[i].Codigo == codigo) buscado = _animales[i];
                i++;
            }
            return buscado;
        }

        public Vacuna ObtenerVacunaPorNombre(string nombre)
        {
            Vacuna buscada = null;
            int i = 0;
            while (i < _vacunas.Count && buscada == null)
            {
                if (_vacunas[i].Nombre == nombre) buscada = _vacunas[i];
                i++;
            }
            return buscada;
        }
        public Empleado ObtenerPeonPorEmail(string mail)
        {
            Empleado buscado = null;
            int i = 0;
            while (i < _empleados.Count && buscado == null)
            {
                if (_empleados[i].Email == mail) buscado = _empleados[i];
                i++;
            }
            return buscado;
        }

        public void AgregarTareaAPeon(string mail, Tarea t)
        {
            if (string.IsNullOrEmpty(mail)) throw new Exception("El mail no puede ser nulo");
            if (t == null) throw new Exception("No se encontro la tarea");
            Empleado p = ObtenerPeonPorEmail(mail);
            if (p == null) throw new Exception("No se encontró el peón");
            Peon p1 = p as Peon;
            p1.AltaTarea(t);
        }

        //metodo que devuelve un potrero segun su id
        public Potrero ObtenerPotreroPorId(int id)
        {
            Potrero buscado = null;
            int i = 0;
            while (i < _potreros.Count && buscado == null)
            {
                if (_potreros[i].Id == id) buscado = _potreros[i];
                i++;
            }
            return buscado;
        }


        public void AgregarAnimalAPotrero(int id, string caravana)
        {
            if (caravana == null) throw new Exception("No se encontró la caravana");
            if (id < 1) throw new Exception("Id no es correcto");
            Potrero p = ObtenerPotreroPorId(id);
            if (p == null) throw new Exception("No se encontró el potrero");
            Animal a = ObtenerAnimalPorCaravana(caravana);
            if (!p.HayLugar()) throw new Exception("No hay lugar disponible en el potrero");
            p.AgregarAnimalAPotrero(a);

        }

        //metodo que devuelve una lista de potreros con mayor area y capacidad que la que recibe por parametro
        public List<Potrero> PotrerosPorHectYCap(double hect, int cap)
        {
            List<Potrero> buscados = new List<Potrero>();

            foreach (Potrero p in _potreros)
            {
                if (p.Hect > hect && p.Capacidad > cap) buscados.Add(p);
            }
            return buscados;
        }

        public double ActualizarPrecioPorKgLana(double p)
        {
            double precio = Ovino.Precio;
            double nuevoPrecio = p;
            if ((nuevoPrecio < 0)) throw new Exception("El precio no puede ser negativo");
            Ovino.CambiarPrecioBase(nuevoPrecio);
            return nuevoPrecio;
        }

        public Empleado Login(string usuario, string password)
        {
            Empleado buscado = null;
            int i = 0;
            while (buscado == null && i < _empleados.Count)
            {
                Empleado e = _empleados[i];
                if (e.Email == usuario && e.Password == password) buscado = e;
                i++;
            }

            return buscado;
        }

        public List<Animal> AnimalPorPesoYTipo (double peso, string tipo)
        {
            List <Animal> buscados = new List<Animal> ();
            foreach (Animal a in _animales)
            {
                if (a.GetTipo() == tipo && a.PesoActual > peso ) buscados.Add(a);
            }
            return buscados;
        }


    }
}
