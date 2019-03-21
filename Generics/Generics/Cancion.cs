using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class Cancion
    {
        private int id;
        private string nombre;
        private int duracion;
        private string letra;
        private int albumID;
        public Cancion(int id2, string nombre2, int duracion2,string letra2, int albumID2 )
        {
            id = id2;
            nombre = nombre2;
            duracion = duracion2;
            letra = letra2;
            albumID = albumID2;
        }
        public Cancion()
        {

        }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public int ID { get { return id; } set { id = value; } }
        public int Duracion { get { return duracion; } set { duracion = value; } }
        public string Letra { get { return letra; } set { letra = value; } }
        public int AlbumID { get { return albumID; } set { albumID = value; } }
        public void mostrar()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("ID: "+ id);
            Console.WriteLine("Nombre: "+ nombre);
            Console.WriteLine("Duracion: " + duracion);
            Console.WriteLine("Letra: "+ letra);
            Console.WriteLine("AlbumID: "+ albumID);
            Console.WriteLine("-------------------------------------------------- \n");



        }


    }
}
