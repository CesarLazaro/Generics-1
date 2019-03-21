using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Generics
{

    class Program
    {
        static void Main(string[] args)
        {
            List<Cancion> canciones = new List<Cancion>();
            /* Cancion c1 = new Cancion(1,"When i gone",4.20,"Aqui va la letra que no quiero poner",1);
             Cancion c2 = new Cancion(2, "Rap God", 6.00, "Aqui va la letra que no quiero poner x2", 2);
             canciones.Add(c1);
             canciones.Add(c2);*/
            int menu = 0, salir = 0 ;
            do
            {
                Console.Clear();
                Console.WriteLine("ELIGE LA OPCION QUE PREFIERAS");
                Console.WriteLine("1.AGREGAR CANCION A LA LISTA");
                Console.WriteLine("2.MOSTRAR CANCIONES DE LA LISTA");
                Console.WriteLine("3.MOSTRAR CANCIONES DE LA BD");
                Console.WriteLine("4.BUSCAR CANCIONES DE LA LISTA");
                Console.WriteLine("5.SALIR");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Dame id de cancion que quieras");
                        string id = Console.ReadLine();
                        Cancion c = SQL(id);
                        canciones.Add(c);
                        break;
                    case 2:
                        Console.Clear();
                        foreach (Cancion temporal in canciones)
                        {
                            temporal.mostrar();

                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        SQL2();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Dame id a buscar");
                        int busqueda = Convert.ToInt32(Console.ReadLine());
                        var consulta = canciones.Where(a => a.ID == busqueda);
                        foreach (var con in consulta)
                        {
                            con.mostrar();
                        }
                        Console.ReadKey();
                        break;
                    case 5:
                        salir = 5;
                        break;
                    default:
                        Console.WriteLine("NUMERO ERRONEO INGRESA OTRO");
                        break;
                }
            } while (salir!=5);
        }
        private static Cancion SQL (string id)
        {
            Cancion temporal = new Cancion();
            string comando = "SELECT * FROM SONG WHERE ID=" + id;
            SqlConnection conexion = new SqlConnection("server=HGDLAPLAZAROCA\\SQLEXPRESS ; database=SPOTIFY2 ; integrated security = true");
            conexion.Open();
            SqlCommand command = new SqlCommand(comando, conexion);
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                temporal = new Cancion(Convert.ToInt32(reader.GetValue(0)), Convert.ToString(reader.GetValue(1)), Convert.ToInt32(reader.GetValue(2)),
                Convert.ToString(reader.GetValue(3)), Convert.ToInt32(reader.GetValue(4)));
            }
            return temporal;
           conexion.Close();
        }
        private static void SQL2()
        {
            string comando = "SELECT * FROM SONG";
            SqlConnection conexion = new SqlConnection("server=HGDLAPLAZAROCA\\SQLEXPRESS ; database=SPOTIFY2 ; integrated security = true");
            conexion.Open();
            SqlCommand command = new SqlCommand(comando, conexion);
            SqlDataReader reader = command.ExecuteReader();
            int c = 0;
            while (reader.Read())
            {

                while (c < reader.FieldCount)
                {
                    Console.Write(reader.GetValue(c) + "   ");
                    c++;
                }
                Console.Write("\n");
                c = 0;
            }
            conexion.Close();
            Console.ReadKey();
        }
    }
}
