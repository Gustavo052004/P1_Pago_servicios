using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq.Expressions;
using System.Numerics;
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

		InicializarVectores(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2,
							 numeroCaja, tipoServicio, numeroFactura, montoPagar, montoComision,
							 montoDeducido, montoPagaCliente, vuelto,1,0);

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
							 montoDeducido, montoPagaCliente, vuelto,1,0);
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
						ModificarPagos(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2,
							 numeroCaja, tipoServicio, numeroFactura, montoPagar, montoComision,
							 montoDeducido, montoPagaCliente, vuelto);
						break;
					case 5:
						EliminarPagos(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2,
							 numeroCaja, tipoServicio, numeroFactura, montoPagar, montoComision,
							 montoDeducido, montoPagaCliente, vuelto);
						break;
					case 6:
						SubmenuReportes(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2,
							 numeroCaja, tipoServicio, numeroFactura, montoPagar, montoComision,
							 montoDeducido, montoPagaCliente, vuelto);
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

	private static void SubmenuReportes(int[] numeroPago, string[] fecha, string[] hora,
									string[] cedula, string[] nombre, string[] apellido1,
									string[] apellido2, int[] numeroCaja, int[] tipoServicio,
									string[] numeroFactura, decimal[] montoPagar,
									decimal[] montoComision, decimal[] montoDeducido,
									decimal[] montoPagaCliente, decimal[] vuelto)
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
						VerTodosLosPagos(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2, montoPagar,tipoServicio,numeroCaja);
						break;
					case 2:
						VerPagosPorTipoServicio(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2, montoPagar, tipoServicio,numeroCaja);
						break;
					case 3:
						VerPagosPorCodigoCaja(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2, montoPagar, tipoServicio, numeroCaja);
						break;
					case 4:
						VerDineroComisionadoPorServicios(numeroPago,tipoServicio,montoComision);
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
									decimal[] montoPagaCliente, decimal[] vuelto, int modo, int indice)
	{
		if(modo == 1)
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

		}else if(modo == 2)
		{
			numeroPago[indice] = -1;
			fecha[indice] = "inz";
			hora[indice] = "inz";
			cedula[indice] = "inz";
			nombre[indice] = "inz";
			apellido1[indice] = "inz";
			apellido2[indice] = "inz";
			numeroCaja[indice] = -1;
			tipoServicio[indice] = -1;
			numeroFactura[indice] = "inz";
			montoPagar[indice] = -1.00m;
			montoComision[indice] = -1.00m;
			montoDeducido[indice] = -1.00m;
			montoPagaCliente[indice] = -1.00m;
			vuelto[indice] = -1.00m;
		}


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

					if (EsCampoValido(entrada))
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

					if (EsCampoValido(entrada))
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

					if (EsCampoValido(entrada))
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
				switch (tipoServicio[indice])
				{
					case 1: // Recibo de electricidad
						comision = 0.04f; // 4%
						break;

					case 2: // Recibo telefónico
						comision = 0.055f; // 5.5%
						break;

					case 3: // Pago recibo de agua
						comision = 0.065f; // 6.5%
						break;

				}

				montoComision[indice] = montoPagar[indice] * Convert.ToDecimal(comision);

				montoDeducido[indice] = montoPagar[indice] - montoComision[indice];

				do
				{
					Limpiar();
					Console.WriteLine("");
					Console.WriteLine("Monto a pagar: "+ montoPagar[indice]);
					Console.WriteLine("");
					Console.Write("Digite el monto de pago :");
					string entrada = Console.ReadLine();

					if (ContieneSoloNumeros(entrada) && Convert.ToDecimal(entrada) >= montoPagar[indice] )
					{
						montoPagaCliente[indice] = Convert.ToDecimal(entrada);
						break;
					}


				} while (true);


				vuelto[indice] = montoPagaCliente[indice] - montoPagar[indice];

				MotrarInfo(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2,
								 numeroCaja, tipoServicio, numeroFactura, montoPagar, montoComision,
								 montoDeducido, montoPagaCliente, vuelto,indice, "Ingreso de datos",1);


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
						Limpiar();
						Console.WriteLine("Entrada inválida. Por favor, ingrese 'S' o 'N'.");
						Console.WriteLine("");
						MotrarInfo(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2,
								 numeroCaja, tipoServicio, numeroFactura, montoPagar, montoComision,
								 montoDeducido, montoPagaCliente, vuelto, indice, "Ingreso de datos", 1);
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
									decimal[] montoPagaCliente, decimal[] vuelto, int indice,string opcionmenunombre, int opcion)
	{
		if(opcion== 1)
		{
			Limpiar();
			Console.WriteLine("");
			Console.WriteLine("Sistema de Pago de Servicios Publicos");
			Console.WriteLine(opcionmenunombre);
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
		else if(opcion == 2)
		{
			Limpiar();
			Console.WriteLine("");
			Console.WriteLine("Sistema de Pago de Servicios Publicos");
			Console.WriteLine(opcionmenunombre);
			Console.WriteLine("");
			Console.WriteLine($"Numero de pago:		{numeroPago[indice],-10}");
			Console.WriteLine("");
			Console.WriteLine($"A-Fecha:             {fecha[indice],-9}          B-Hora:             {hora[indice],-10}");
			Console.WriteLine("");
			Console.WriteLine($"C-Cedula:             {cedula[indice],-10}          D-Nombre:           {nombre[indice],-10}");
			Console.WriteLine("");
			Console.WriteLine($"E-Apellido 1:         {apellido1[indice],-10}          F-Apellido 2:       {apellido2[indice],-10}");
			Console.WriteLine("");
			Console.WriteLine($"G-Tipo de Servicio    {tipoServicio[indice],-5}  [1-Electricidad 2-Telefono 3-Agua]");
			Console.WriteLine("");
			Console.WriteLine($"H-Numero de factura:  {numeroFactura[indice],10}          Monto Pagar:      {montoPagar[indice],10}");
			Console.WriteLine("");
			Console.WriteLine($"Comision autorizada:{montoComision[indice],10}          I-Paga con:         {montoPagaCliente[indice],10}");
			Console.WriteLine("");
			Console.WriteLine($"Monto deducido:     {montoDeducido[indice],10}          Vuelto:           {vuelto[indice],10}");
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine("S-Desea Continuar S/N ?");
		}


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
		int entrada;
		while (!ValidarEsNumero(out entrada))
		{
			Limpiar();
			Console.WriteLine("Por favor ingresa un número.");
			Console.WriteLine("");
			Console.WriteLine("Sistema de Pago de Servicios Publicos");
			Console.WriteLine("Consulta de datos");
			Console.WriteLine("");
			Console.WriteLine("");
			Console.Write("Numero de Pago: ");
		}
		bool encontrado = false;
		Console.WriteLine("");
		Console.WriteLine("");
		Console.WriteLine("");

        for (int i = 0; i < numeroPago.Length; i++)
        {
			if (numeroPago[i] == entrada )
			{
				encontrado = true;
                Console.WriteLine("Dato Encontrado Posición Vector " + i);
				Console.WriteLine("");
				Console.WriteLine("");
				Console.WriteLine("");
				Console.WriteLine("");
				Console.WriteLine("Presione cualquier tecla para ver registro...");
				Console.ReadKey();
				MotrarInfo(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2,
				 numeroCaja, tipoServicio, numeroFactura, montoPagar, montoComision,
				 montoDeducido, montoPagaCliente, vuelto, i, "Consulta de datos",1);
                Console.WriteLine("");
                Console.WriteLine("Presione cualquier tecla");
				Console.ReadKey();
				Limpiar();
			}
            else if(i == numeroPago.Length - 1 && encontrado == false)
			{
				Limpiar();
				Console.WriteLine("Pago no se encuentra Registrado");
			}
            
        }


    }



	private static void ModificarPagos(int[] numeroPago, string[] fecha, string[] hora,
									string[] cedula, string[] nombre, string[] apellido1,
									string[] apellido2, int[] numeroCaja, int[] tipoServicio,
									string[] numeroFactura, decimal[] montoPagar,
									decimal[] montoComision, decimal[] montoDeducido,
									decimal[] montoPagaCliente, decimal[] vuelto)
	{
		Limpiar();
		Console.WriteLine("");
		Console.WriteLine("Sistema de Pago de Servicios Publicos");
		Console.WriteLine("Modicar Pagos");
		Console.WriteLine("");
		Console.WriteLine("");
		Console.Write("Numero de Pago: ");
		int entrada;
		while(!ValidarEsNumero(out entrada))
		{
			Limpiar();
			Console.WriteLine("Por favor ingresa un número.");
			Console.WriteLine("");
			Console.WriteLine("Sistema de Pago de Servicios Publicos");
			Console.WriteLine("Modicar Pagos");
			Console.WriteLine("");
			Console.WriteLine("");
			Console.Write("Numero de Pago: ");
		}
		Console.WriteLine("");
		Console.WriteLine("");
		Console.WriteLine("");

		bool encontrado = false;

		for (int i = 0; i < numeroPago.Length; i++)
		{
			if (numeroPago[i] == entrada)
			{
				
				Console.WriteLine("Dato Encontrado Posición Vector " + i);
				Console.WriteLine("");
				Console.WriteLine("");
				Console.WriteLine("");
				Console.WriteLine("");
				Console.WriteLine("Presione cualquier tecla para ver registro...");
				Console.ReadKey();

				bool YoN = true;

				do
				
				{
					MotrarInfo(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2,
					numeroCaja, tipoServicio, numeroFactura, montoPagar, montoComision,
					montoDeducido, montoPagaCliente, vuelto, i, "Modicar Pagos", 2);
					Console.WriteLine("");
					Console.Write("Seleccione opcion a modificar: ");
					char entrada2;

					while (!ValidarCaracter(out entrada2))
					{
						Limpiar();
						Console.WriteLine("Opción no válida. Por favor, ingrese una sola letra.");
						Console.WriteLine("");
						MotrarInfo(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2,
						numeroCaja, tipoServicio, numeroFactura, montoPagar, montoComision,
						montoDeducido, montoPagaCliente, vuelto, i, "Modicar Pagos", 2);
						Console.WriteLine("");
						Console.Write("Seleccione opción a modificar: ");
					}

					switch (entrada2)
					{
						case 'A':
							Limpiar();
							string fechaEntrada;
							bool fechaValida = false;

							while (!fechaValida)
							{
								Console.WriteLine("");
								Console.WriteLine("Fecha");
                                Console.WriteLine("");
                                Console.Write("Digite la nueva fecha (dd/MM/yyyy): ");
								fechaEntrada = Console.ReadLine();

								// Verifica si la entrada es una fecha válida
								fechaValida = EsFechaValida(fechaEntrada);

								if (fechaValida)
								{
									fecha[i] = fechaEntrada;
                                    Console.WriteLine("");
                                    Console.WriteLine("La fecha fue modificada.");
								}
								else
								{
                                    Console.WriteLine("");
                                    Console.WriteLine("La fecha no es válida. Asegúrese de usar el formato dd/MM/yyyy.");
								}
							
							}

							break;

						case 'B':
							Limpiar();
							string horaEntrada;
							bool horaValida = false;

							while(!horaValida)
							{
								Console.WriteLine("");
								Console.WriteLine("Hora");
								Console.WriteLine("");
                                Console.Write("Digite la nueva hora hh:mm tt( a. m. | p. m. ): ");
								horaEntrada = Console.ReadLine();

								horaValida = EsHoraValida(horaEntrada);

								if(horaValida)
								{
									hora[i] = horaEntrada;
									Console.WriteLine("");
									Console.WriteLine("La hora fue modificada");
								}
								else
								{
									Console.WriteLine("");
									Console.WriteLine("La hora no es válida. Asegúrese de usar el formato (hh:mm tt).");
								}
                            }

							
							break;

						case 'C':
							do
							{
								Limpiar();
								Console.WriteLine("");
								Console.WriteLine("Cedula");
								Console.WriteLine("");
								Console.Write("Digite la cedula del cliente :");
								string entradaCedula = Console.ReadLine();

								if (ContieneSoloEspaciosOLetras(entradaCedula))
								{
									cedula[i] = entradaCedula;
									break;
								}


							} while (true);

							
							break;

						case 'D':
							do
							{
								Limpiar();
								Console.WriteLine("");
								Console.WriteLine("Nombre");
								Console.WriteLine("");
								Console.Write("Digite el nombre del cliente :");
								string entradaN = Console.ReadLine();

								if (EsCampoValido(entradaN))
								{
									nombre[i] = entradaN;
									break;
								}


							} while (true);
							
							break;

						case 'E':
							do
							{
								Limpiar();
								Console.WriteLine("");
								Console.WriteLine("Apellido 1");
								Console.WriteLine("");
								Console.Write("Digite el apellido 1 del cliente :");
								string entradaN = Console.ReadLine();

								if (EsCampoValido(entradaN))
								{
									apellido1[i] = entradaN;
									break;
								}


							} while (true);
							break;

						case 'F':
							do
							{
								Limpiar();
								Console.WriteLine("");
								Console.WriteLine("Apellido 2");
								Console.WriteLine("");
								Console.Write("Digite el apellido 2 del cliente :");
								string entradaN = Console.ReadLine();

								if (EsCampoValido(entradaN))
								{
									apellido2[i] = entradaN;
									break;
								}


							} while (true);
							break;

						case 'G':
							do
							{
								Limpiar();
								Console.WriteLine("");
								Console.WriteLine("Tipo de servicio");
								Console.WriteLine("");
								Console.WriteLine("Digite el tipo de servicio.");
								Console.WriteLine("");
								Console.WriteLine("[1-Electricidad 2-Telefono 3-Agua]");
								Console.WriteLine("");
								Console.Write("Opción :");
								string entradaT = Console.ReadLine();

								if (Contiene123(entradaT))
								{
									tipoServicio[i] = Convert.ToInt16(entradaT);

									float comision = 0;
									switch (tipoServicio[i])
									{
										case 1: // Recibo de electricidad
											comision = 0.04f; // 4%
											break;

										case 2: // Recibo telefónico
											comision = 0.055f; // 5.5%
											break;

										case 3: // Pago recibo de agua
											comision = 0.065f; // 6.5%
											break;

									}

									montoComision[i] = montoPagar[i] * Convert.ToDecimal(comision);

									montoDeducido[i] = montoPagar[i] - montoComision[i];

									vuelto[i] = montoPagaCliente[i] - montoPagar[i];

									break;
								}



							} while (true);

						break;

						case 'H':
							do
							{
								Limpiar();
								Console.WriteLine("");
								Console.WriteLine("Numero de factura");
								Console.WriteLine("");
								Console.Write("Digite el nuevo numero de factura :");
								string entradaNum = Console.ReadLine();

								if (ContieneSoloEspaciosOLetras(entradaNum))
								{
									numeroFactura[i] = entradaNum;
									break;
								}


							} while (true);

						break;

						case 'I':
							do
							{
								Limpiar();
								Console.WriteLine("");
								Console.WriteLine("Pago con");
								Console.WriteLine("");
								Console.WriteLine("Monto a pagar: " + montoPagar[i]);
								Console.WriteLine("");
								Console.Write("Digite el monto de pago :");
								string entradaP = Console.ReadLine();

								if (ContieneSoloNumeros(entradaP) && Convert.ToDecimal(entradaP) >= montoPagar[i])
								{
									montoPagaCliente[i] = Convert.ToDecimal(entradaP);
									break;
								}


							} while (true);


							vuelto[i] = montoPagaCliente[i] - montoPagar[i];

							break;

						case 'S':
							
							do
							{
								Limpiar();
								Console.Write("Desea Continuar S/N ?: ");
								string entradaYoN = Console.ReadLine();

								if (entradaYoN == "S" || entradaYoN == "s")
								{
									YoN = true;
									break;
								}
								else if (entradaYoN == "N" || entradaYoN == "n")
								{
									YoN = false;
									Limpiar();
									break;

								}
								else
								{
									Limpiar();
									Console.WriteLine("Entrada inválida. Por favor, ingrese 'S' o 'N'.");
									Console.WriteLine("");
									
								}

							} while (true);
							break;

						default:
							Limpiar();
							Console.WriteLine("Opción no valida");
							break;
					}

					if (!YoN)
					{
						break;
					}
				} while (true);

				encontrado = true;

				
			}
			else if (i == numeroPago.Length - 1 && encontrado == false )
			{
				Limpiar();
				Console.WriteLine("Pago no se encuentra Registrado");
			}

		}

	}


	private static void EliminarPagos(int[] numeroPago, string[] fecha, string[] hora,
									string[] cedula, string[] nombre, string[] apellido1,
									string[] apellido2, int[] numeroCaja, int[] tipoServicio,
									string[] numeroFactura, decimal[] montoPagar,
									decimal[] montoComision, decimal[] montoDeducido,
									decimal[] montoPagaCliente, decimal[] vuelto)
	{

		Limpiar();
		Console.WriteLine("");
		Console.WriteLine("Sistema de Pago de Servicios Publicos");
		Console.WriteLine("Eliminación de datos");
		Console.WriteLine("");
		Console.WriteLine("");
		Console.Write("Numero de Pago: ");
		int entrada;
		while (!ValidarEsNumero(out entrada))
		{
			Limpiar();
			Console.WriteLine("Por favor ingresa un número.");
			Console.WriteLine("");
			Console.WriteLine("Sistema de Pago de Servicios Publicos");
			Console.WriteLine("Eliminación de datos");
			Console.WriteLine("");
			Console.WriteLine("");
			Console.Write("Numero de Pago: ");
		}
		bool encontrado = false;
		bool YoN = false;
		Console.WriteLine("");
		Console.WriteLine("");
		Console.WriteLine("");

		for (int i = 0; i < numeroPago.Length; i++)
		{
			if (numeroPago[i] == entrada)
			{
				encontrado = true;

					Console.WriteLine("Dato Encontrado Posición Vector " + i);
					Console.WriteLine("");
					Console.WriteLine("");
					Console.WriteLine("");
					Console.WriteLine("");
					Console.WriteLine("Presione cualquier tecla para ver registro...");
					Console.ReadKey();
					MotrarInfo(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2,
							 numeroCaja, tipoServicio, numeroFactura, montoPagar, montoComision,
							 montoDeducido, montoPagaCliente, vuelto, i, "Eliminación de datos", 1);
					Console.WriteLine("");
				do
					{

						Console.Write("Esta seguro de eliminar el dato S/N ?: ");
						string entrada2 = Console.ReadLine();

						if (entrada2 == "S" || entrada2 == "s")
						{
							YoN = true;
							break;
						}
						else if (entrada2 == "N" || entrada2 == "n")
						{
							YoN = false;
							Limpiar();
							break;

						}
						else
						{
							Limpiar();
							Console.WriteLine("Entrada inválida. Por favor, ingrese 'S' o 'N'.");
							Console.WriteLine("");
							MotrarInfo(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2,
							numeroCaja, tipoServicio, numeroFactura, montoPagar, montoComision,
							 montoDeducido, montoPagaCliente, vuelto, i, "Eliminación de datos", 1);
							Console.WriteLine("");
					}

					} while (true);

					if (YoN)
					{
					InicializarVectores(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2,
						 numeroCaja, tipoServicio, numeroFactura, montoPagar, montoComision,
						 montoDeducido, montoPagaCliente, vuelto, 2, i);
					Limpiar();

					}



			}
			else if (i == numeroPago.Length - 1 && encontrado == false)
			{
				Limpiar();
				Console.WriteLine("Pago no se encuentra Registrado");
			}

		}

	}



	private static void VerTodosLosPagos(int[] numeroPago, string[] fecha, string[] hora,
									string[] cedula, string[] nombre, string[] apellido1,
									string[] apellido2, decimal[] montoPagar, int[] tipoServicio, int[] numeroCaja)
	{
		Limpiar();
		Console.WriteLine("Sistema Pago de Servicios Públicos");
		Console.WriteLine("Reporte Todos los Pagos");

        Console.WriteLine("");
		Console.WriteLine("");
		Mostrarinfosubmenu(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2, montoPagar, tipoServicio,numeroCaja, 1, 0,0);
		
        // Pie de página
        Console.WriteLine("Presione cualquier Tecla para continuar");
		Console.ReadKey();
		Limpiar();
	}
	private static void VerPagosPorTipoServicio(int[] numeroPago, string[] fecha, string[] hora,
									string[] cedula, string[] nombre, string[] apellido1,
									string[] apellido2, decimal[] montoPagar, int[] tipoServicio, int[] numeroCaja)
	{

		int opcionSeleccionada = 0;
		do
		{
			Limpiar();
			Console.WriteLine("Sistema Pago de Servicios Públicos");
			Console.WriteLine("Reporte Todos los Pagos por Tipo de Servicio");
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine(new string('=', 80));
			Console.WriteLine("Seleccione codigo de Servicio\t[1] Electricidad\t[2] Telefono\t[3] Agua\n");
			Console.WriteLine(new string('=', 80));
			Console.WriteLine("");
			Console.WriteLine("");
			Console.Write("Ingrese el código del servicio (1, 2, o 3): ");
			string entrada = Console.ReadLine();

			// Intentar convertir la entrada a un entero
			if (int.TryParse(entrada, out opcionSeleccionada))
			{
				// Verificar si la opción está en el rango válido
				if (opcionSeleccionada >= 1 && opcionSeleccionada <= 3)
				{
					Limpiar();
					Console.WriteLine("Sistema Pago de Servicios Públicos");
					Console.WriteLine("Reporte Todos los Pagos por Tipo de Servicio");
					Console.WriteLine("");
					Console.WriteLine("");
					Mostrarinfosubmenu(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2, montoPagar, tipoServicio,numeroCaja, 2, opcionSeleccionada,0);
					Console.WriteLine("Presione cualquier Tecla para continuar");
					Console.ReadKey();
					Limpiar();
					break;
				}
				else
				{
					Limpiar();
					Console.WriteLine("Opción no válida. Por favor, seleccione un número entre 1 y 3.");
					
				}
			}
			else
			{
				Limpiar();
				Console.WriteLine("Entrada no válida. Por favor ingrese un número.");
			}

		} while (true);



	}
	private static void VerPagosPorCodigoCaja(int[] numeroPago, string[] fecha, string[] hora,
									string[] cedula, string[] nombre, string[] apellido1,
									string[] apellido2, decimal[] montoPagar, int[] tipoServicio, int[] numeroCaja)
	{
		int opcionSeleccionada = 0;
		do
		{
			Limpiar();
			Console.WriteLine("Sistema Pago de Servicios Públicos");
			Console.WriteLine("Reporte Todos los Pagos por Codigo De Cajero");
			Console.WriteLine("");
			Console.WriteLine("");
			Console.WriteLine(new string('=', 80));
			Console.WriteLine("Seleccione codigo de Servicio\t[1] Caja#1\t[2] Caja#2\t[3] Caja#3\n");
			Console.WriteLine(new string('=', 80));
			Console.WriteLine("");
			Console.WriteLine("");
			Console.Write("Ingrese el código de caja (1, 2, o 3): ");
			string entrada = Console.ReadLine();

			// Intentar convertir la entrada a un entero
			if (int.TryParse(entrada, out opcionSeleccionada))
			{
				// Verificar si la opción está en el rango válido
				if (opcionSeleccionada >= 1 && opcionSeleccionada <= 3)
				{
					Limpiar();
					Console.WriteLine("Sistema Pago de Servicios Públicos");
					Console.WriteLine("Reporte Todos los Pagos por Codigo De Cajero");
					Console.WriteLine("");
					Console.WriteLine("");
					Mostrarinfosubmenu(numeroPago, fecha, hora, cedula, nombre, apellido1, apellido2, montoPagar, tipoServicio, numeroCaja,3 , 0,opcionSeleccionada);
					Console.WriteLine("Presione cualquier Tecla para continuar");
					Console.ReadKey();
					Limpiar();
					break;
				}
				else
				{
					Limpiar();
					Console.WriteLine("Opción no válida. Por favor, seleccione un número entre 1 y 3.");

				}
			}
			else
			{
				Limpiar();
				Console.WriteLine("Entrada no válida. Por favor ingrese un número.");
			}

		} while (true);
	}
	private static void VerDineroComisionadoPorServicios(int[] numeroPago, int[] tipoServicio, decimal[] montoComision)
	{
		Limpiar();
		Console.WriteLine("Reporte Dinero Comisionado - Desgloce por Tipo de Servicio\n");
        Console.WriteLine("");

		Console.WriteLine(new string('=', 60)); // Línea de separación
												// Encabezados de las columnas
		Console.WriteLine("{0,-15} {1,-20} {2,-15}", "ITEM", "Cant. Transacciones", "Total Comisionado");
		Console.WriteLine(new string('=', 60)); // Línea de separación

		byte contadorE = 0;
		byte contadorT = 0;
		byte contadorA = 0;

		decimal montototalE = 0;
		decimal montototalT = 0;
		decimal montototalA = 0;


		for (int i = 0; i < numeroPago.Length; i++)
        {
            if(numeroPago[i] != -1)
			{
				switch(tipoServicio[i])
				{
					case 1:
						contadorE++;
						montototalE += montoComision[i];
						break;

					case 2:
						contadorT++;
						montototalT += montoComision[i];
						break;

					case 3:
						contadorA++;
						montototalA += montoComision[i];
						break;
				}
			}
        }


        // Datos del reporte
        Console.WriteLine("{0,-15} {1,-20} {2,-15}", "1-Electricidad", contadorE, montototalE);
		Console.WriteLine("{0,-15} {1,-20} {2,-15}", "2-Telefono", contadorT, montototalT);
		Console.WriteLine("{0,-15} {1,-20} {2,-15}", "3-Agua", contadorA, montototalA);

		// Línea de separación
		Console.WriteLine(new string('-', 60));

		// Totales
		Console.WriteLine("{0,-15} {1,-20} {2,-15}", "Total", contadorA + contadorE + contadorT, montototalA + montototalE + montototalT);

		// Línea de separación
		Console.WriteLine(new string('=', 60));

		// Pie de página
		Console.WriteLine("\nPulse cualquier tecla para regresar al submenu de reportes");
		Console.ReadKey();
		Limpiar();
	}

	private static void Mostrarinfosubmenu(int[] numeroPago, string[] fecha, string[] hora,
									string[] cedula, string[] nombre, string[] apellido1,
									string[] apellido2, decimal[] montoPagar, int[] tipoServicio, int[] numeroCaja, int modo, int tipo_s , int n_Caja)
	{
		switch(modo)
		{
			case 1:

				Console.WriteLine("{0,-8} {1,-25} {2,-10} {3,-10} {4,-15} {5,-15} {6,-10}",
			"# Pago", "Fecha/Hora Pago", "Cedula", "Nombre", "Apellido1", "Apellido2", "Monto Recibido");
				Console.WriteLine(new string('=', 105)); // Línea de separación
				byte contador = 0;
				decimal montototal = 0;
				// Datos
				for (int i = 0; i < numeroPago.Length; i++)
				{
					if (numeroPago[i] != -1)
					{
						contador++;
						Console.WriteLine("{0,-8} {1,-25} {2,-10} {3,-10} {4,-15} {5,-15} {6,-10:N0}",
						numeroPago[i], fecha[i] + " " + hora[i], cedula[i], nombre[i], apellido1[i], apellido2[i], montoPagar[i]);
						montototal += montoPagar[i];
					}

				}

				// Totales
				Console.WriteLine(new string('-', 105));
				Console.WriteLine("{0,-33} {1,15}", "Total de Registros", contador);
				Console.WriteLine("{0,-33} {1,15:N0}", "Monto Total", montototal);
				Console.WriteLine("");
				Console.WriteLine("");

				break;


			case 2:
				Console.WriteLine("{0,-8} {1,-25} {2,-10} {3,-10} {4,-15} {5,-15} {6,-10}",
				"# Pago", "Fecha/Hora Pago", "Cedula", "Nombre", "Apellido1", "Apellido2", "Monto Recibido");
				Console.WriteLine(new string('=', 105)); // Línea de separación
				byte contador2 = 0;
				decimal montototal2 = 0;
				// Datos
				for (int i = 0; i < numeroPago.Length; i++)
				{
					if (numeroPago[i] != -1 && tipoServicio[i] == tipo_s)
					{
						contador2++;
						Console.WriteLine("{0,-8} {1,-25} {2,-10} {3,-10} {4,-15} {5,-15} {6,-10:N0}",
						numeroPago[i], fecha[i] + " " + hora[i], cedula[i], nombre[i], apellido1[i], apellido2[i], montoPagar[i]);
						montototal2 += montoPagar[i];
					}

				}

				// Totales
				Console.WriteLine(new string('-', 105));
				Console.WriteLine("{0,-33} {1,15}", "Total de Registros", contador2);
				Console.WriteLine("{0,-33} {1,15:N0}", "Monto Total", montototal2);
				Console.WriteLine("");
				Console.WriteLine("");
				break;

			case 3:

				Console.WriteLine("{0,-8} {1,-25} {2,-10} {3,-10} {4,-15} {5,-15} {6,-10}",
				"# Pago", "Fecha/Hora Pago", "Cedula", "Nombre", "Apellido1", "Apellido2", "Monto Recibido");
				Console.WriteLine(new string('=', 105)); // Línea de separación
				byte contador3 = 0;
				decimal montototal3 = 0;
				// Datos
				for (int i = 0; i < numeroPago.Length; i++)
				{
					if (numeroPago[i] != -1 && numeroCaja[i] == n_Caja)
					{
						contador3++;
						Console.WriteLine("{0,-8} {1,-25} {2,-10} {3,-10} {4,-15} {5,-15} {6,-10:N0}",
						numeroPago[i], fecha[i] + " " + hora[i], cedula[i], nombre[i], apellido1[i], apellido2[i], montoPagar[i]);
						montototal3 += montoPagar[i];
					}

				}

				// Totales
				Console.WriteLine(new string('-', 105));
				Console.WriteLine("{0,-33} {1,15}", "Total de Registros", contador3);
				Console.WriteLine("{0,-33} {1,15:N0}", "Monto Total", montototal3);
				Console.WriteLine("");
				Console.WriteLine("");

				break;

		}
	}

	private static bool ValidarEsNumero(out int resultado)
	{
		string dato = Console.ReadLine();
		return int.TryParse(dato, out resultado);
	}

	private static bool ValidarCaracter(out char result)
	{
		string input = Console.ReadLine().ToUpper();
		if (input.Length == 1 && Char.IsLetter(input[0]))
		{
			result = input[0];
			return true;
		}
		result = '\0'; // Carácter nulo si la entrada no es válida
		return false;
	}

	private static bool EsFechaValida(string fecha)
	{
		DateTime fechaConvertida;
		// Define el formato exacto esperado para la fecha
		string formato = "dd/MM/yyyy";

		// Intenta convertir el string de entrada al formato de fecha especificado
		// CultureInfo.InvariantCulture se usa para evitar problemas con la configuración regional
		bool esValido = DateTime.TryParseExact(fecha, formato, CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaConvertida);

		return esValido;
	}

	private static bool EsHoraValida(string hora)
	{
		DateTime horaConvertida;
		// Define el formato exacto esperado para la hora
		string formato = "hh:mm tt";

		// Intenta convertir el string de entrada al formato de hora especificado
		// CultureInfo.InvariantCulture se usa para evitar problemas con la configuración regional,
		// especialmente para el indicador AM/PM.
		bool esValido = DateTime.TryParseExact(hora, formato, new CultureInfo("es-ES"), DateTimeStyles.None, out horaConvertida);

		return esValido;
	}

	private static bool EsCampoValido(string campo)
	{
		// Verifica que el campo no esté vacío o solo contenga espacios
		if (string.IsNullOrWhiteSpace(campo))
		{
			return false;
		}

		// Utiliza una expresión regular para buscar espacios continuos
		// \s representa un carácter de espacio y {2,} indica dos o más ocurrencias
		if (Regex.IsMatch(campo, @"\s{2,}"))
		{
			return false;
		}

		return true;
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
		// Verifica que el string tenga exactamente un carácter
		if (numero.Length == 1)
		{
			// Verifica si el carácter es '1', '2', o '3'
			char caracter = numero[0];
			return caracter == '1' || caracter == '2' || caracter == '3';
		}

		// Retorna false si el string no tiene exactamente un carácter
		return false;
	}
	private static void Limpiar()
	{
		Console.Clear(); 
	}

}














