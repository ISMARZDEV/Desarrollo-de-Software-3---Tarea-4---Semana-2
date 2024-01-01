using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost; Database=BDProject; User Id=sa; Password=20186947Ismael";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            Console.WriteLine("Conexión exitosa");

            string salir = "N", empresa, articulo, estado;
            decimal precioDeLista, precioDeOferta;
            int cantidad;
            DateTime fechaInicioOferta, fechaFinOferta, fechaIngreso;

            while (salir == "N")
            {
                Console.Write("Empresa: ");
                empresa = Console.ReadLine();
                Console.Write("Articulo: ");
                articulo = Console.ReadLine();
                Console.Write("Precio de Lista: ");
                precioDeLista = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Precio de Oferta: ");
                precioDeOferta = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Cantidad: ");
                cantidad = Convert.ToInt32(Console.ReadLine());
                Console.Write("Fecha de Inicio de Oferta (YYYY-MM-DD): ");
                fechaInicioOferta = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Fecha de Fin de Oferta (YYYY-MM-DD): ");
                fechaFinOferta = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Fecha de Ingreso (YYYY-MM-DD HH:mm:ss): ");
                fechaIngreso = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Estado: ");
                estado = Console.ReadLine();

                // Usar el procedimiento almacenado para insertar oferta de Black Friday
                using (SqlCommand insertOfertaCommand = new SqlCommand("InsertarOfertaBlackFriday", connection))
                {
                    insertOfertaCommand.CommandType = CommandType.StoredProcedure;

                    insertOfertaCommand.Parameters.Add(new SqlParameter("@Empresa", empresa));
                    insertOfertaCommand.Parameters.Add(new SqlParameter("@Articulo", articulo));
                    insertOfertaCommand.Parameters.Add(new SqlParameter("@PrecioDeLista", precioDeLista));
                    insertOfertaCommand.Parameters.Add(new SqlParameter("@PrecioDeOferta", precioDeOferta));
                    insertOfertaCommand.Parameters.Add(new SqlParameter("@Cantidad", cantidad));
                    insertOfertaCommand.Parameters.Add(new SqlParameter("@FechaInicioOferta", fechaInicioOferta));
                    insertOfertaCommand.Parameters.Add(new SqlParameter("@FechaFinOferta", fechaFinOferta));
                    insertOfertaCommand.Parameters.Add(new SqlParameter("@FechaIngreso", fechaIngreso));
                    insertOfertaCommand.Parameters.Add(new SqlParameter("@Estado", estado));

                    insertOfertaCommand.ExecuteNonQuery();
                    Console.WriteLine("Oferta insertada exitosamente");

                    Console.WriteLine("¿Desea salir? (Y/N)");
                    salir = Console.ReadLine().ToUpper();
                }
            }
        }
    }
}
