using Notas.calcular;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notas
{
    public partial class Form1 : Form
    {
        // Arreglo para almacenar hasta 1000 estudiantes.
        private Estudiante[] estudiantes;
        private int contadorEstudiantes;
        public Form1()
        {
            InitializeComponent();
            // Inicializamos el arreglo de estudiantes.
            estudiantes = new Estudiante[1000];
            contadorEstudiantes = 0; // Inicializamos el contador en 0.
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Obtenemos el nombre y la nota ingresados.
            string nombre = txtName.Text.Trim();
            double nota;

            // Validamos el nombre.
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("El nombre no puede estar vacío.");
                return;
            }

            // Validamos la nota.
            if (!double.TryParse(txtGrade.Text, out nota) || nota < 0 || nota > 100)
            {
                MessageBox.Show("Ingrese una nota válida (0 - 100).");
                return;
            }

            // Verificamos que no se exceda el límite de 1000 estudiantes.
            if (contadorEstudiantes >= 1000)
            {
                MessageBox.Show("Se ha alcanzado el número máximo de estudiantes (1000).");
                return;
            }

            // Agregamos el estudiante al arreglo.
            estudiantes[contadorEstudiantes] = new Estudiante(nombre, nota);
            contadorEstudiantes++;

            // Limpiamos los campos de texto.
            txtName.Clear();
            txtGrade.Clear();

            // Actualizamos el promedio y los primeros lugares.
            MostrarEstadisticas();
        }

        // Método para mostrar el promedio y los tres primeros lugares.
        private void MostrarEstadisticas()
        {
            if (contadorEstudiantes == 0)
            {
                MessageBox.Show("No hay estudiantes registrados.");
                return;
            }

            // Calculamos el promedio.
            double suma = 0;
            for (int i = 0; i < contadorEstudiantes; i++)
            {
                suma += estudiantes[i].Nota;
            }

            double promedio = suma / contadorEstudiantes;
            lblGrade.Text = "Promedio: " + promedio.ToString("F2");

            // Ordenamos los estudiantes por nota (descendente).
            Estudiante[] estudiantesOrdenados = new Estudiante[contadorEstudiantes];
            Array.Copy(estudiantes, estudiantesOrdenados, contadorEstudiantes);
            Array.Sort(estudiantesOrdenados, (a, b) => b.Nota.CompareTo(a.Nota));

            // Mostramos los tres primeros lugares.
            lblFirstPlace.Text = "1er Lugar: " + estudiantesOrdenados[0].Nombre + " - Nota: " + estudiantesOrdenados[0].Nota;
            lblSecondPlace.Text = (contadorEstudiantes > 1) ? "2do Lugar: " + estudiantesOrdenados[1].Nombre + " - Nota: " + estudiantesOrdenados[1].Nota : "2do Lugar: N/A";
            lblThirdPlace.Text = (contadorEstudiantes > 2) ? "3er Lugar: " + estudiantesOrdenados[2].Nombre + " - Nota: " + estudiantesOrdenados[2].Nota : "3er Lugar: N/A";
        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }
    }
}
