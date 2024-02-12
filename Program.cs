using System.ComponentModel;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
	private static void Main(string[] args)
	{
		//Declaracion de Vectores
		int[] numeroPago = new int[10];
		string[] fecha = new string[10];
		string[] hora = new string[10];
		string[] cedula = new string[10];
		string[] nombre = new string[10];
		string[] apellido1 = new string[10];
		string[] apellido2 = new string[10];
		int[] numeroCaja = new int[10];
		int[] tipoServicio = new int[10];
		string[] numeroFactura = new string[10];
		decimal[] montoPagar = new decimal[10];
		decimal[] montoComision = new decimal[10];
		decimal[] montoDeducido = new decimal[10];
		decimal[] montoPagaCliente = new decimal[10];
		decimal[] vuelto = new decimal[10];



		Limpiar();
		int opcion;

		do
		{
			MostrarMenuPrincipal();
			Console.WriteLine("");
			Console.Write("Seleccione una opción: ");
			if (int.TryParse(Console.ReadLine(), out opcion))
			{
				switch (opcion)
				{
					case 1:
						InicializarVectores(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2,
							 numeroCaja, tipoServicio, numeroFactura, montoPagar, montoComision,
							 montoDeducido, montoPagaCliente, vuelto);
						break;
					case 2:
						RealizarPagos(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2,
							 numeroCaja, tipoServicio, numeroFactura, montoPagar, montoComision,
							 montoDeducido, montoPagaCliente, vuelto);
						break;
					case 3:
						ConsultarPagos(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2,
							 numeroCaja, tipoServicio, numeroFactura, montoPagar, montoComision,
							 montoDeducido, montoPagaCliente, vuelto);
						
						break;
					case 4:
						//ModificarPagos();
						break;
					case 5:
						//EliminarPagos();
						break;
					case 6:
						SubmenuReportes();
						break;
					case 7:
						Console.WriteLine("");
						Console.WriteLine("Saliendo del programa. ¡Hasta luego!");
						break;
					default:
						Limpiar();
						Console.WriteLine("");
						Console.WriteLine("Opción no válida. Por favor, elija nuevamente.");
						break;
				}
			}
			else
			{
				Limpiar();
				Console.WriteLine("");
				Console.WriteLine("Entrada no válida. Por favor, elija nuevamente.");
			}

		} while (opcion != 7);
	}

	private static void MostrarMenuPrincipal()
	{
		
		Console.WriteLine("");
		Console.WriteLine("Sistema de Pago de Servicios Publicos");
		Console.WriteLine("");
		Console.WriteLine("Menú Principal");
		Console.WriteLine("");
		Console.WriteLine("1. Inicializar Vectores");
		Console.WriteLine("2. Realizar Pagos");
		Console.WriteLine("3. Consultar Pagos");
		Console.WriteLine("4. Modificar Pagos");
		Console.WriteLine("5. Eliminar Pagos");
		Console.WriteLine("6. Submenú Reportes");
		Console.WriteLine("7. Salir");
	}

	private static void SubmenuReportes()
	{
		Limpiar();

		int opcionReporte;

		do
		{
			MostrarSubmenuReportes();
			Console.WriteLine("");
			Console.Write("Seleccione una opción de reporte: ");
			if (int.TryParse(Console.ReadLine(), out opcionReporte))
			{
				switch (opcionReporte)
				{
					case 1:
						//VerTodosLosPagos();
						break;
					case 2:
						//VerPagosPorTipoServicio();
						break;
					case 3:
						//VerPagosPorCodigoCaja();
						break;
					case 4:
						//VerDineroComisionadoPorServicios();
						break;
					case 5:
						Console.WriteLine("");
						Console.WriteLine("Regresando al Menú Principal");
						break;
					default:
						Limpiar();
						Console.WriteLine("");
						Console.WriteLine("Opción no válida. Por favor, elija nuevamente.");
						break;
				}
			}
			else
			{
				Console.WriteLine("");
				Console.WriteLine("Entrada no válida. Por favor, elija nuevamente.");
			}

		} while (opcionReporte != 5);
		Limpiar();
	}

	
	private static void MostrarSubmenuReportes()
	{
		Console.WriteLine("");
		Console.WriteLine("Sistema de Pago de Servicios Publicos");
		Console.WriteLine("");
		Console.WriteLine("Submenú Reportes");
		Console.WriteLine("");
		Console.WriteLine("1. Ver todos los Pagos");
		Console.WriteLine("2. Ver Pagos por tipo de Servicio");
		Console.WriteLine("3. Ver Pagos por código de caja");
		Console.WriteLine("4. Ver Dinero Comisionado por servicios");
		Console.WriteLine("5. Regresar al Menú Principal");
	}

	private static void InicializarVectores(int[] numeroPago, string[] fecha, string[] hora,
									string[] cedula, string[] nombre, string[] apellido1,
									string[] apellido2, int[] numeroCaja, int[] tipoServicio,
									string[] numeroFactura, decimal[] montoPagar,
									decimal[] montoComision, decimal[] montoDeducido,
									decimal[] montoPagaCliente, decimal[] vuelto)
	{
		for (int i = 0; i < numeroPago.Length; i++)
		{
			numeroPago[i] = -1;
			fecha[i] = "inz";
			hora[i] = "inz";
			cedula[i] = "inz";
			nombre[i] = "inz";
			apellido1[i] = "inz";
			apellido2[i] = "inz";
			numeroCaja[i] = -1;
			tipoServicio[i] = -1;
			numeroFactura[i] = "inz";
			montoPagar[i] = -1.00m;
			montoComision[i] = -1.00m;
			montoDeducido[i] = -1.00m;
			montoPagaCliente[i] = -1.00m;
			vuelto[i] = -1.00m;
		}
		Limpiar();
		Console.WriteLine("");
		Console.WriteLine("Vectores inicializados correctamente.");

	}

	private static void RealizarPagos(int[] numeroPago, string[] fecha, string[] hora,
									string[] cedula, string[] nombre, string[] apellido1,
									string[] apellido2, int[] numeroCaja, int[] tipoServicio,
									string[] numeroFactura, decimal[] montoPagar,
									decimal[] montoComision, decimal[] montoDeducido,
									decimal[] montoPagaCliente, decimal[] vuelto)
	{
		Limpiar();

		do
		{
			bool YoN;
			int indice = EncontrarCampoVacio(numeroPago);

			if (indice != -2)
			{


				numeroPago[indice] = indice + 1;


				fecha[indice] = DateTime.Today.ToString("dd/MM/yyyy");  // para mostrar la fecha
				hora[indice] = DateTime.Now.ToString("hh:mm tt");

				do
				{
					Limpiar();
					Console.WriteLine("");
					Console.Write("Digite la cedula del cliente :");
					string entrada = Console.ReadLine();

					if(ContieneSoloEspaciosOLetras(entrada))
					{
						cedula[indice] = entrada;
						break;
					}
				

				} while (true);

				do
				{
					Limpiar();
					Console.WriteLine("");
					Console.Write("Digite el nombre del cliente :");
					string entrada = Console.ReadLine();

					if (entrada != "")
					{
						nombre[indice] = entrada;
						break;
					}


				} while (true);

				do
				{
					Limpiar();
					Console.WriteLine("");
					Console.Write("Digite el apellido 1 del cliente :");
					string entrada = Console.ReadLine();

					if (entrada != "")
					{
						apellido1[indice] = entrada;
						break;
					}


				} while (true);

				do
				{
					Limpiar();
					Console.WriteLine("");
					Console.Write("Digite el apellido 2 del cliente :");
					string entrada = Console.ReadLine();

					if (entrada != "")
					{
						apellido2[indice] = entrada;
						break;
					}


				} while (true);


				Random random = new Random();

				numeroCaja[indice] = random.Next(1, 3);

				do
				{
					Limpiar();
					Console.WriteLine("Digite el tipo de servicio.");
					Console.WriteLine("");
					Console.WriteLine("[1-Electricidad 2-Telefono 3-Agua]");
					Console.WriteLine("");
					Console.Write("Opción :");
					string entrada = Console.ReadLine();

					if (Contiene123(entrada))
					{
						tipoServicio[indice] = Convert.ToInt16(entrada);
						break;
					}


				} while (true);

				numeroFactura[indice] = random.Next(10000, 100000).ToString();
				montoPagar[indice] = random.Next(5000, 100000);

				float comision = 0;
				switch(tipoServicio[indice])
				{
					case 1:
						comision = 0.04f;
						break;

					case 2:
						comision = 0.55f;
						break;

					case 3:
						comision = 0.65f;
						break;

				}

				montoComision[indice] = montoPagar[indice] * Convert.ToDecimal(comision);

				montoDeducido[indice] = montoPagar[indice] - montoComision[indice];

				do
				{
					Limpiar();
					Console.WriteLine("");
					Console.WriteLine("Monto a pagar: "+ montoDeducido[indice]);
					Console.WriteLine("");
					Console.Write("Digite el monto de pago :");
					string entrada = Console.ReadLine();

					if (ContieneSoloNumeros(entrada) && Convert.ToDecimal(entrada) >= montoDeducido[indice] )
					{
						montoPagaCliente[indice] = Convert.ToDecimal(entrada);
						break;
					}


				} while (true);


				vuelto[indice] = montoPagaCliente[indice] - montoDeducido[indice];

				MotrarInfo(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2,
								 numeroCaja, tipoServicio, numeroFactura, montoPagar, montoComision,
								 montoDeducido, montoPagaCliente, vuelto,indice, "Ingreso de datos");


				do
				{
					Console.Write("Desea Continuar S/N ?: ");
					string entrada = Console.ReadLine();

					if (entrada == "S" || entrada == "s")
					{
						YoN = true;
						break;
					}
					else if (entrada == "N" || entrada == "n")
					{
						YoN = false;
						Limpiar();
						break;
						
					}
					else
					{
						Console.WriteLine("Entrada inválida. Por favor, ingrese 'S' o 'N'.");
					}

				} while (true);
				
				if(YoN == false)
				{
					break;
				}
			}
			else
			{
				Limpiar();
				Console.WriteLine("");
				Console.WriteLine("Vectores llenos.");
				break;
			}

		} while (true);

	}

	private static void MotrarInfo(int[] numeroPago, string[] fecha, string[] hora,
									string[] cedula, string[] nombre, string[] apellido1,
									string[] apellido2, int[] numeroCaja, int[] tipoServicio,
									string[] numeroFactura, decimal[] montoPagar,
									decimal[] montoComision, decimal[] montoDeducido,
									decimal[] montoPagaCliente, decimal[] vuelto, int indice,string opcionmenu)
	{
		Limpiar();
		Console.WriteLine("");
		Console.WriteLine("Sistema de Pago de Servicios Publicos");
		Console.WriteLine(opcionmenu);
		Console.WriteLine("");
		Console.WriteLine($"Numero de pago:		{numeroPago[indice],-10}");
		Console.WriteLine("");
		Console.WriteLine($"Fecha:             {fecha[indice],-9}          Hora:             {hora[indice],-10}");
		Console.WriteLine("");
		Console.WriteLine($"Cedula:             {cedula[indice],-10}          Nombre:           {nombre[indice],-10}");
		Console.WriteLine("");
		Console.WriteLine($"Apellido 1:         {apellido1[indice],-10}          Apellido 2:       {apellido2[indice],-10}");
		Console.WriteLine("");
		Console.WriteLine($"Tipo de Servicio    {tipoServicio[indice],-5}  [1-Electricidad 2-Telefono 3-Agua]");
        Console.WriteLine("");
		Console.WriteLine($"Numero de factura:  {numeroFactura[indice],10}          Monto Pagar:      {montoPagar[indice],10}");
        Console.WriteLine("");
		Console.WriteLine($"Comision autorizada:{montoComision[indice],10}          Paga con:         {montoPagaCliente[indice],10}");
		Console.WriteLine("");
		Console.WriteLine($"Monto deducido:     {montoDeducido[indice],10}          Vuelto:           {vuelto[indice],10}");
		Console.WriteLine("");
		Console.WriteLine("");

	}

	private static void ConsultarPagos(int[] numeroPago, string[] fecha, string[] hora,
									string[] cedula, string[] nombre, string[] apellido1,
									string[] apellido2, int[] numeroCaja, int[] tipoServicio,
									string[] numeroFactura, decimal[] montoPagar,
									decimal[] montoComision, decimal[] montoDeducido,
									decimal[] montoPagaCliente, decimal[] vuelto)
	{
		Limpiar();
		Console.WriteLine("");
		Console.WriteLine("Sistema de Pago de Servicios Publicos");
		Console.WriteLine("Consulta de datos");
        Console.WriteLine("");
		Console.WriteLine("");
		Console.Write("Numero de Pago: ");
		int entrada =  Convert.ToInt16(Console.ReadLine());
		Console.WriteLine("");
		Console.WriteLine("");
		Console.WriteLine("");

        for (int i = 0; i < numeroPago.Length; i++)
        {
			if (numeroPago[i] == entrada )
			{
                Console.WriteLine("Dato Encontrado Posición Vector " + i);
				Console.WriteLine("");
				Console.WriteLine("");
				Console.WriteLine("");
				Console.WriteLine("");
				Console.WriteLine("Presione cualquier tecla para ver registro...");
				Console.ReadKey();
				MotrarInfo(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2,
				 numeroCaja, tipoServicio, numeroFactura, montoPagar, montoComision,
				 montoDeducido, montoPagaCliente, vuelto, i, "Consulta de datos");
                Console.WriteLine("");
                Console.WriteLine("Presione cualquier tecla");
				Console.ReadKey();
				Limpiar();
			}
            else if(i == numeroPago.Length)
			{
				Limpiar();
				Console.WriteLine("Pago no se encuentra Registrado");
			}
            
        }


    }






	private static int EncontrarCampoVacio(int[] vector)
	{
		for (int i = 0; i < vector.Length; i++)
		{
			if (vector[i] == -1)
			{
				return i; // Devuelve el índice del campo vacío
			}
		}
		return -2; // Devuelve -2 si no se encontraron campos vacíos
	}
	private static bool ContieneSoloEspaciosOLetras(string texto)
	{
		// Patrón para buscar espacios en blanco o letras
		string patron = @"^[^\s\p{L}]+$";

		// Comprueba si el texto coincide con el patrón
		return Regex.IsMatch(texto, patron);
	}
	private static bool ContieneSoloNumeros(string texto)
	{
		// Patrón para validar solo números
		string patron = @"^\d+$";

		// Verificar si la cadena coincide con el patrón
		return Regex.IsMatch(texto, patron);
	}
	private static bool Contiene123(string numero)
	{
		return numero.Contains("1") || numero.Contains("2") || numero.Contains("3");
	}
	private static void Limpiar()
	{
		Console.Clear(); 
	}

}














