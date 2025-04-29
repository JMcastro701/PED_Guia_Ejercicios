using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario_ColaPrioridad
{
    class ColaPrioridad
    {
        private NodoCola frente;
            private int contadorPacientes = 0;

        public void Encolar(int prioridad)
        {
            contadorPacientes++;
                NodoCola nuevoNodo = new NodoCola(contadorPacientes, prioridad);

            if (frente == null || prioridad < frente.Prioridad)
            {
                //Colocamos nuevo nodo en la primera posición
                nuevoNodo.Siguiente = frente;
                    frente = nuevoNodo;
            }
            else
            {
                //Buscamos la posición en la que insertar el nuevo nodo
                NodoCola actual = frente;
                    while (actual.Siguiente != null && actual.Siguiente.Prioridad <= prioridad)
                    {
                        actual = actual.Siguiente;
                    }

                    nuevoNodo.Siguiente = actual.Siguiente;
                        actual.Siguiente = nuevoNodo;
            }
        }

        public int Desencolar()
        {
            if (frente == null)
                //Regresamos valor que representará un error
                return -1;
                    //Guardamos número del paciente a desencolar
                        int numeroPaciente = frente.NumeroPaciente;

                        //Desconectamos nodo de la cola
                            frente = frente.Siguiente;

                            //Retornamos número del paciente que es desencolado
                                return numeroPaciente;
        }

        public void MostrarCola(DataGridView dgvOutput)
        {
            dgvOutput.Rows.Clear();
                dgvOutput.Columns.Clear();
                    dgvOutput.Columns.Add("numeroPaciente", "Número de Paciente");
                        dgvOutput.Columns.Add("prioridad", "Prioridad");

                    NodoCola actual = frente;
                        while (actual != null)
                        {
                            dgvOutput.Rows.Add(actual.NumeroPaciente, actual.Prioridad);
                            actual = actual.Siguiente;
                        }
        }

    }
}
