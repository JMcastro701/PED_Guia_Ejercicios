using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formulario_ColaPrioridad
{
    public partial class FrmColaP : Form
    {
        private ColaPrioridad ColaPacientes;
            private int contadorPacientes;
        public FrmColaP()
        {
            InitializeComponent();
            ColaPacientes = new ColaPrioridad();
            contadorPacientes = 1;
                panel1.BackColor = Color.FromArgb(33, 76, 125);

                comboBoxEstado.Items.AddRange(new string[] { "Leve", "Estable", "Crítico" });
                    comboBoxEstado.SelectedIndex = 0;

                // Configuración de columnas del DataGridView
                dgvPacientes.Columns.Add("Numero", "Número de Paciente");
                    dgvPacientes.Columns.Add("Prioridad", "Prioridad");

                    // Opcional: Configuraciones visuales de dgvPacientes
                    dgvPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvPacientes.ReadOnly = true;
                         dgvPacientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validación: Que haya seleccionado un estado
            if (comboBoxEstado.SelectedItem == null)
            {
                MessageBox.Show("Por favor seleccione un estado para el paciente.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }

            // Obtenemos prioridad basada en el estado
                int prioridad = ObtenerPrioridad(comboBoxEstado.SelectedItem.ToString());

              // Encolamos el nuevo paciente
                ColaPacientes.Encolar(prioridad);

                 // Aumento del contador de pacientes
                    contadorPacientes++;

                  // Refresca la visualización de la cola
                    MostrarPacientes();
                        MessageBox.Show($"Paciente número {contadorPacientes - 1} agregado con prioridad {ObtenerNombrePrioridad(prioridad)}.", "Paciente Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void MostrarPacientes()
        {
            // Refresca los datos en el DataGridView usando el método MostrarCola
            ColaPacientes.MostrarCola(dgvPacientes);
        }

        private int ObtenerPrioridad(string estado)
        {
            switch (estado)
            {
                case "Crítico": return 1;
                    case "Estable": return 2;
                        case "Leve": return 3;
                             default: return 3;
            }
        }

        private string ObtenerNombrePrioridad(int prioridad)
        {
            switch (prioridad)
            {
                case 1: return "Crítico";
                    case 2: return "Estable";
                        case 3: return "Leve";
                            default: return "Desconocido";
            }
        }

        private void btnAtender_Click(object sender, EventArgs e)
        {
            // Desencolar paciente
            int numeroPaciente = ColaPacientes.Desencolar();

            if (numeroPaciente != -1)
            {
               // Actualiza el campo de texto con el paciente atendido y lo confirmamos mediante un mensaje
                textBoxAtendidos.Text = $"Numero de paciente atendido: {numeroPaciente}";
                    MostrarPacientes();
                
                MessageBox.Show($"El paciente número {numeroPaciente} ha sido atendido.", "Paciente Atendido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                textBoxAtendidos.Text = "No hay pacientes en espera.";
                    MessageBox.Show("No hay pacientes en espera para atender.", "Sin Pacientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ColaPacientes = new ColaPrioridad();
                contadorPacientes = 1;
                    dgvPacientes.Rows.Clear();
                        textBoxAtendidos.Clear();
                            comboBoxEstado.SelectedIndex = 0;
        }


    }
}
