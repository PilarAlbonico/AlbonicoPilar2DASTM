using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio02
{
    public class Serie
    {
        public string Nombre { get; set; }
        public int Temporadas { get; set; }
        public int Episodios { get; set; }
        public double Duracion { get; set; }
        public double Ranking { get; set; }
        public string Genero { get; set; }
        public string Director { get; set; }

        public Serie(string nombre, int temporadas, int episodios, double duracion, double ranking, string genero, string director)
        {
            Nombre = nombre;
            Temporadas = temporadas;
            Episodios = episodios;
            Duracion = duracion;
            Ranking = ranking;
            Genero = genero;
            Director = director;
        }

        public override string ToString()
        {
            return $"{Nombre} | T: {Temporadas}, E: {Episodios}, Dur: {Duracion}min, Rank: {Ranking}, {Genero}, Dir: {Director}";
        }
    }
}
