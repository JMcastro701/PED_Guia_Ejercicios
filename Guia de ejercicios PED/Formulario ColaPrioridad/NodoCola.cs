using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formulario_ColaPrioridad
{
    class NodoCola
    {
        //Número único que identifica a cada paciente 
        private int numeroPaciente;
            //Dato de prioridad
            private int prioridad;
                //Siguiente nodo en la cola
                private NodoCola siguiente = null;

        public NodoCola(int nuevoNumero, int nuevaPrioridad)
        {
            numeroPaciente = nuevoNumero;
                prioridad = nuevaPrioridad;
        }

        public int NumeroPaciente
        {
            get { return numeroPaciente; }
        }

        public int Prioridad
        {
            get { return prioridad; }
        }

        public NodoCola Siguiente
        {
            get { return siguiente; }
                set { siguiente = value; }
        }

    }
}
