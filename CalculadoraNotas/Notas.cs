using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraNotas
{
    public class Notas
    {
        public string nombre
        {
            get; set;
        }
        public double porcentaje
        {
            get; set;
        }
        public double valor        {
            get; set;
        }
    public Notas(string nombre, double valor, double porcentaje)
        {
            this.nombre = nombre;
            this.valor = valor;
            this.porcentaje = (porcentaje /100);
        }
    }
}
