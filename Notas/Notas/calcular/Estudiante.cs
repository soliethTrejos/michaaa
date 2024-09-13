using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notas.calcular
{
    internal class Estudiante
    {
        // Propiedad para almacenar el nombre del estudiante.
        public string Nombre { get; set; }

        // Propiedad para almacenar la nota del estudiante.
        public double Nota { get; set; }

        // Constructor para inicializar un estudiante con su nombre y nota.
        public Estudiante(string nombre, double nota)
        {
            Nombre = nombre;
            Nota = nota;
        }
    }
}
