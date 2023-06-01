using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
			
public class Program
{
	
	    //Metodos para la administracion de usuarios
        //Estructuracion del diccionario donde se guardaran los usuarios del sistema
        static Dictionary<string, string> ListaDeUsuarios = new Dictionary<string, string>()
        {
            {"admin", "admin"} //El usuario arministrador es el que tiene por defecto el sistema
        };

        //Metodo para la creacion de nuevos usuarios al sistema
        static void CrearUsuario()
        {
            bool VariableBanderaParaRepetirElCiclo = true;
            do
            {
                Console.WriteLine("Escriba el nombre del usuario:");
                string nombreDeUsuarioNuevo = Console.ReadLine();
                //La siguiente sentencia anidada permite verificar si un usuario ya existe en el sistema
                if (ListaDeUsuarios.ContainsKey(nombreDeUsuarioNuevo))
                {
                    Console.WriteLine("No se puede guardar por que ya existe elija otro nombre.");
                    return;//Con este return se cierra este metod y se cancela la creacion del usuario respectivo
                }
                Console.WriteLine("Ingrese la contraseña del usuairo:");
                string claveDelNuevoUsurio = Console.ReadLine();
                ListaDeUsuarios[nombreDeUsuarioNuevo] = claveDelNuevoUsurio;
                Console.WriteLine("El usuario se ha creado exitosamente");
                Console.WriteLine("Deseas agregar un nuevo registro? s=si n=no");
                string decicionParaLaOperacion = Console.ReadLine();
                if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                {
                    VariableBanderaParaRepetirElCiclo = true;
                }
                if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }
            } while (VariableBanderaParaRepetirElCiclo == true);
        }

        //Metodo para eliminar usuarios del sistema
        static void EliminarUsuario()
        {
            Console.WriteLine("Escriba el nombre del usuario que sera eliminado:");
            string usuarioQueSeraEliminado = Console.ReadLine();

            if (ListaDeUsuarios.ContainsKey(usuarioQueSeraEliminado))
            {
                Console.WriteLine("Estas seguro de eliminar el registro? s=si n=no");
                string decicionParaLaOperacion = Console.ReadLine();
                if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                {
                    ListaDeUsuarios.Remove(usuarioQueSeraEliminado);
                    Console.WriteLine("El usuario se ha eliminado del sistema.");
                }
                if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                {
                    Console.WriteLine("No se eliminara el registro.");
                }                
            }
            else
            {
                Console.WriteLine("No se elimino el usuario por que no existe.");
            }
        }

        //Metodo para modificar datos de los usuarios del sistema
        static void ModificarUsuario()
        {
            bool VariableBanderaParaRepetirElCiclo = true;
            do
            {
                Console.WriteLine("Ingrese el nombre de usuario que desea actualizar:");
                string UsuarioQueSeraModificado = Console.ReadLine();

                if (ListaDeUsuarios.ContainsKey(UsuarioQueSeraModificado))
                {
                    Console.WriteLine("Ingrese el nuevo nick del usuario:");
                    string newUsername = Console.ReadLine();

                    if (ListaDeUsuarios.ContainsKey(newUsername))
                    {
                        Console.WriteLine("El nombre no se puede utilizar por que otro lo esta empleando se cancelara la modificacion.");
                        return;
                    }

                    Console.WriteLine("Ingrese la nueva clave del usuario:");
                    string newPassword = Console.ReadLine();

                    ListaDeUsuarios.Remove(UsuarioQueSeraModificado);
                    ListaDeUsuarios[newUsername] = newPassword;

                    Console.WriteLine("La modificacion se realizo con exito.");
                }
                else
                {
                    Console.WriteLine("El usuario no existe");
                }
                Console.WriteLine("Deseas seguir modificando registros? s=si n=no");
                string decicionParaLaOperacion = Console.ReadLine();
                if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                {
                    VariableBanderaParaRepetirElCiclo = true;
                }
                if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }
            } while (VariableBanderaParaRepetirElCiclo == true);
        }

        //Metodo para buscar datos de los usuario del sistema
        static void BuscarUsuario()
        {
            Console.WriteLine("Ingrese el nick del usuario :");
            string usuarioQueSeBuscara = Console.ReadLine();

            if (ListaDeUsuarios.ContainsKey(usuarioQueSeBuscara))
            {
                foreach (var variableDeRecorrido in ListaDeUsuarios)
                {
                    if (variableDeRecorrido.Key == usuarioQueSeBuscara)
                    {
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("Usuario: {0}", variableDeRecorrido.Key);
                        Console.WriteLine("Contraseña: {0}", variableDeRecorrido.Value);
                    }
                }
            }
            else
            {
                Console.WriteLine("El usuario no existe.");
            }
        }

        //Metodo para mostrar los usuarios registrados
        static void MostrarUsuariosRegistrados()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Usuarios registrados:");
            foreach (var variableDeRecorridoDeUsuarios in ListaDeUsuarios)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Usuario: {0}", variableDeRecorridoDeUsuarios.Key);
                Console.WriteLine("Contraseña: {0}", variableDeRecorridoDeUsuarios.Value);
            }
        }

        //Fin de los metodo para administrar los usuarios del sistema


        //Metodos para administrar clientes del sistema
        static Dictionary<string, Tuple<string, int, string>> ListaDeClientes = new Dictionary<string, Tuple<string, int, string>>();

        //Metodo para la creacion de nuevos clientes al sistema
        static void CrearCliente()
        {
            bool VariableBanderaParaRepetirElCiclo = true;
            do { 
                Console.WriteLine("Escriba el nit del cliente:");
                string nitDelCliente = Console.ReadLine();
                //La siguiente sentencia anidada permite verificar si un cliente ya existe en el sistema
                if (ListaDeUsuarios.ContainsKey(nitDelCliente))
                {
                    Console.WriteLine("No se puede guardar por que ya existe elija otro nombre.");
                    return;//Con este return se cierra este metod y se cancela la creacion del cliente respectivo
                }

                Console.WriteLine("Ingrese el nombre del cliente:");
                string nombreDelClientesNuevo = Console.ReadLine();
                Console.WriteLine("Ingrese el numero de telefono:");
                int telefonoDelCliente = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese la direccion:");
                string direccionDelCliente = Console.ReadLine();
            

                Tuple<string, int, string> objetoClienteConLosDatos = new Tuple<string, int, string>(nombreDelClientesNuevo, telefonoDelCliente, direccionDelCliente);

                ListaDeClientes[nitDelCliente] = objetoClienteConLosDatos;

                Console.WriteLine("El cliente se ha creado exitosamente");
                Console.WriteLine("Deseas agregar un nuevo registro? s=si n=no");
                string decicionParaLaOperacion = Console.ReadLine();
                if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }
                if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }
            } while (VariableBanderaParaRepetirElCiclo == true);
        }

        static void CrearClienteConParametro(string parametroNit)
        {
            bool VariableBanderaParaRepetirElCiclo = true;
            do { 
                string nitDelCliente = parametroNit;
                //La siguiente sentencia anidada permite verificar si un cliente ya existe en el sistema
                if (ListaDeUsuarios.ContainsKey(nitDelCliente))
                {
                    Console.WriteLine("No se puede guardar por que ya existe elija otro nombre.");
                    return;//Con este return se cierra este metod y se cancela la creacion del cliente respectivo
                }

                Console.WriteLine("Ingrese el nombre del cliente:");
                string nombreDelClientesNuevo = Console.ReadLine();
                Console.WriteLine("Ingrese el numero de telefono:");
                int telefonoDelCliente = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Ingrese la direccion:");
                string direccionDelCliente = Console.ReadLine();
            

                Tuple<string, int, string> objetoClienteConLosDatos = new Tuple<string, int, string>(nombreDelClientesNuevo, telefonoDelCliente, direccionDelCliente);

                ListaDeClientes[nitDelCliente] = objetoClienteConLosDatos;

                Console.WriteLine("El cliente se ha creado exitosamente");
                Console.WriteLine("Deseas agregar un nuevo registro? s=si n=no");
                string decicionParaLaOperacion = Console.ReadLine();
                if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }
                if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }
            } while (VariableBanderaParaRepetirElCiclo == true);
        }

        //Metodo para mostrar los clientes registrados
        static void MostrarClientes()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Usuarios registrados:");
            foreach (var variableDeRecorrido in ListaDeClientes)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Nombre: {0}", variableDeRecorrido.Key);
                Console.WriteLine("Telefono: {0}", variableDeRecorrido.Value.Item1);
                Console.WriteLine("Direccion: {0}", variableDeRecorrido.Value.Item2);
                Console.WriteLine("NIT: {0}", variableDeRecorrido.Value.Item3);
            }
        }
        //Fin de los metodo para administrar los clientes del sistema

        //Metodo para eliminar usuarios del sistema
        static void EliminarCliente()
        {
            Console.WriteLine("Escriba el nit del cliente que sera eliminado:");
            string clienteQueSeraEliminado = Console.ReadLine();

            if (ListaDeClientes.ContainsKey(clienteQueSeraEliminado))
            {
                Console.WriteLine("Estas seguro de eliminar el registro? s=si n=no");
                string decicionParaLaOperacion = Console.ReadLine();
                if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                {
                    ListaDeClientes.Remove(clienteQueSeraEliminado);
                    Console.WriteLine("El cliente se ha eliminado del sistema.");
                }
                if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                {
                    Console.WriteLine("No se eliminara el registro.");
                }
            }
            else
            {
                Console.WriteLine("No se elimino el cliente por que no existe.");
            }
        }

        //Metodo para modificar datos de los clientes del sistema
        static void ModificarCliente()
        {
            bool VariableBanderaParaRepetirElCiclo = true;
            do
            {
                Console.WriteLine("Ingrese el nit del cliente que desea actualizar:");
                string nitDelCliente = Console.ReadLine();

                if (ListaDeClientes.ContainsKey(nitDelCliente))
                {
                    Console.WriteLine("Ingrese los nuevos datos del usuario");
                    Console.WriteLine("Ingrese el nombre del cliente:");
                    string nombreDelCliente = Console.ReadLine();
                    Console.WriteLine("Ingrese el numero de telefono:");
                    int telefonoDelCliente = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese la direccion:");
                    string direccionDelCliente = Console.ReadLine();

                    ListaDeClientes.Remove(nitDelCliente);
                    Tuple<string, int, string> objetoClienteConLosDatos = new Tuple<string, int, string>(nombreDelCliente, telefonoDelCliente, direccionDelCliente);
                    ListaDeClientes[nitDelCliente] = objetoClienteConLosDatos;
                    Console.WriteLine("La modificacion se realizo con exito.");
                }
                else
                {
                    Console.WriteLine("El usuario no existe");
                }
                Console.WriteLine("Deseas seguir modificando registros? s=si n=no");
                string decicionParaLaOperacion = Console.ReadLine();
                if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                {
                    VariableBanderaParaRepetirElCiclo = true;
                }
                if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }
            } while (VariableBanderaParaRepetirElCiclo == true);
        }

        //Metodo para buscar datos de los clientes del sistema
        static void BuscarCliente()
        {
            Console.WriteLine("Ingrese el nit del cliente :");
            string clicenteQueSeBuscara = Console.ReadLine();
            
            if (ListaDeClientes.ContainsKey(clicenteQueSeBuscara))
            {
                foreach (var variableDeRecorrido in ListaDeClientes)
                {
                    if (variableDeRecorrido.Key == clicenteQueSeBuscara)
                    {
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("Nombre: {0}", variableDeRecorrido.Key);
                        Console.WriteLine("Telefono: {0}", variableDeRecorrido.Value.Item1);
                        Console.WriteLine("Direccion: {0}", variableDeRecorrido.Value.Item2);
                        Console.WriteLine("NIT: {0}", variableDeRecorrido.Value.Item3);
                    }
                }
            }
            else
            {
                Console.WriteLine("El cliente no existe.");
            }
        }
        //Fin metos para administrar clientes del sistema

        //Metodos para administrar productos del sistema
        static Dictionary<int, Tuple<string, string, decimal, int>> ListaDeProductos = new Dictionary<int, Tuple<string, string, decimal, int>>();

        //Metodo para extraer precio del producto
        static decimal ExtraerPrecioDeUnProducto(int parametroCodigo)
        {
            decimal precioActual = 0;
            if (ListaDeProductos.ContainsKey(parametroCodigo))
            {
                precioActual = ListaDeProductos[parametroCodigo].Item3;
            }
            return precioActual;
        }

        //Metodo para la creacion de nuevos productos al sistema
        static void CrearProducto()
        {
            bool VariableBanderaParaRepetirElCiclo = true;
            do
            {
                Console.WriteLine("Escriba el codigo del producto:");
                int codigoDelProducto = Convert.ToInt32(Console.ReadLine());
                //La siguiente sentencia anidada permite verificar si un cliente ya existe en el sistema
                if (ListaDeProductos.ContainsKey(codigoDelProducto))
                {
                    Console.WriteLine("No se puede guardar por que ya se esta utilizando el codigo en otro producto.");
                    return;//Con este return se cierra este metod y se cancela la creacion del cliente respectivo
                }

                Console.WriteLine("Ingrese el nombre del producto:");
                string nombreDelProducto = Console.ReadLine();
                Console.WriteLine("Ingrese la descripcion del producto:");
                string descripcionDelProducto = Console.ReadLine();
                Console.WriteLine("Ingrese el precio del producto:");
                decimal precioDelProducto = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Ingrese la cantidad del producto:");
                int cantidadDelProducto = Convert.ToInt32(Console.ReadLine());

                Tuple<string, string, decimal, int> objetoClienteConLosDatos = new Tuple<string, string, decimal, int>(nombreDelProducto, descripcionDelProducto, precioDelProducto, cantidadDelProducto);

                ListaDeProductos[codigoDelProducto] = objetoClienteConLosDatos;

                Console.WriteLine("El producto se ha creado exitosamente");
                Console.WriteLine("Deseas agregar un nuevo registro? s=si n=no");
                string decicionParaLaOperacion = Console.ReadLine();
                if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }
                if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }
            } while (VariableBanderaParaRepetirElCiclo == true);
        }

        //Metodo para mostrar los productos registrados
        static void MostrarProductos()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Productos registrados:");
            foreach (var variableDeRecorrido in ListaDeProductos)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Codigo: {0}", variableDeRecorrido.Key);
                Console.WriteLine("Nombre: {0}", variableDeRecorrido.Value.Item1);
                Console.WriteLine("Descripcion: {0}", variableDeRecorrido.Value.Item2);
                Console.WriteLine("Precio: {0}", variableDeRecorrido.Value.Item3);
                Console.WriteLine("Cantidad: {0}", variableDeRecorrido.Value.Item4);
            }
        }

        //Metodo para eliminar productos del sistema
        static void EliminarProducto()
        {
            Console.WriteLine("Escriba el codigo del producto:");
            int codigoDelProducto = Convert.ToInt32(Console.ReadLine());

            if (ListaDeProductos.ContainsKey(codigoDelProducto))
            {
                Console.WriteLine("Estas seguro de eliminar el registro? s=si n=no");
                string decicionParaLaOperacion = Console.ReadLine();
                if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                {
                    ListaDeProductos.Remove(codigoDelProducto);
                    Console.WriteLine("El producto se ha eliminado del sistema.");
                }
                if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                {
                    Console.WriteLine("No se eliminara el registro.");
                }
            }
            else
            {
                Console.WriteLine("No se elimino el producto por que no existe.");
            }
        }

        //Metodo para modificar datos de los productos del sistema
        static void ModificarProducto()
        {
            bool VariableBanderaParaRepetirElCiclo = true;
            do
            {
                Console.WriteLine("Escriba el codigo del producto:");
                int codigoDelProducto = Convert.ToInt32(Console.ReadLine());

                if (ListaDeProductos.ContainsKey(codigoDelProducto))
                {
                    Console.WriteLine("Ingrese el nombre del producto:");
                    string nombreDelProducto = Console.ReadLine();
                    Console.WriteLine("Ingrese la descripcion del producto:");
                    string descripcionDelProducto = Console.ReadLine();
                    Console.WriteLine("Ingrese el precio del producto:");
                    decimal precioDelProducto = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Ingrese la cantidad del producto:");
                    int cantidadDelProducto = Convert.ToInt32(Console.ReadLine());

                    ListaDeProductos.Remove(codigoDelProducto);

                    Tuple<string, string,  decimal, int> nuevosDatosDelProducto = new Tuple<string, string, decimal, int>(nombreDelProducto, descripcionDelProducto, precioDelProducto, cantidadDelProducto);
                    ListaDeProductos[codigoDelProducto] = nuevosDatosDelProducto;
                    Console.WriteLine("La modificacion se realizo con exito.");
                }
                else
                {
                    Console.WriteLine("El producto no existe");
                }
                Console.WriteLine("Deseas seguir modificando registros? s=si n=no");
                string decicionParaLaOperacion = Console.ReadLine();
                if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                {
                    VariableBanderaParaRepetirElCiclo = true;
                }
                if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }
            } while (VariableBanderaParaRepetirElCiclo == true);
        }

        //Metodo para aumentar productos del sistema
        static void AumentarProducto()
        {
            bool VariableBanderaParaRepetirElCiclo = true;
            do
            {
                Console.WriteLine("Escriba el codigo del producto:");
                int codigoDelProducto = Convert.ToInt32(Console.ReadLine());

                if (ListaDeProductos.ContainsKey(codigoDelProducto))
                {
                    Console.WriteLine("Ingrese la cantidad del producto:");
                    int cantidadDelProducto = Convert.ToInt32(Console.ReadLine());

                    string nombreActual = ListaDeProductos[codigoDelProducto].Item1;
                    string descripcionActua = ListaDeProductos[codigoDelProducto].Item2;
                    decimal precioActual = ListaDeProductos[codigoDelProducto].Item3;
                    int cantidadActual = ListaDeProductos[codigoDelProducto].Item4;
                    int nuevaCantidad = cantidadDelProducto + cantidadActual;

                    ListaDeProductos.Remove(codigoDelProducto);

                    Tuple<string, string, decimal, int> nuevosDatosDelProducto = new Tuple<string, string, decimal, int>(nombreActual, descripcionActua, precioActual, nuevaCantidad);
                    ListaDeProductos[codigoDelProducto] = nuevosDatosDelProducto;
                    Console.WriteLine("La operacion se realizo con exito.");
                }
                else
                {
                    Console.WriteLine("El producto no existe");
                }
                Console.WriteLine("Deseas seguir agregando existencias de productos? s=si n=no");
                string decicionParaLaOperacion = Console.ReadLine();
                if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                {
                    VariableBanderaParaRepetirElCiclo = true;
                }
                if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }
            } while (VariableBanderaParaRepetirElCiclo == true);
        }

        //Metodo para reducir productos del sistema
        static void ReducirProducto()
        {
            bool VariableBanderaParaRepetirElCiclo = true;
            do
            {
                Console.WriteLine("Escriba el codigo del producto:");
                int codigoDelProducto = Convert.ToInt32(Console.ReadLine());

                if (ListaDeProductos.ContainsKey(codigoDelProducto))
                {
                    Console.WriteLine("Ingrese la cantidad del producto:");
                    int cantidadDelProducto = Convert.ToInt32(Console.ReadLine());

                    string nombreActual = ListaDeProductos[codigoDelProducto].Item1;
                    string descripcionActua = ListaDeProductos[codigoDelProducto].Item2;
                    decimal precioActual = ListaDeProductos[codigoDelProducto].Item3;
                    int cantidadActual = ListaDeProductos[codigoDelProducto].Item4;
                    if (cantidadActual >= cantidadDelProducto)
                    {
                        int nuevaCantidad = cantidadActual - cantidadDelProducto;
                        ListaDeProductos.Remove(codigoDelProducto);
                        Tuple<string, string, decimal, int> nuevosDatosDelProducto = new Tuple<string, string, decimal, int>(nombreActual, descripcionActua, precioActual, nuevaCantidad);
                        ListaDeProductos[codigoDelProducto] = nuevosDatosDelProducto;
                        Console.WriteLine("La operacion se realizo con exito.");
                    }
                    else
                    {
                        Console.WriteLine("La cantidad el producto es insuficiente.");
                    }
                }
                else
                {
                    Console.WriteLine("El producto no existe");
                }
                Console.WriteLine("Deseas seguir restando existencias de productos? s=si n=no");
                string decicionParaLaOperacion = Console.ReadLine();
                if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                {
                    VariableBanderaParaRepetirElCiclo = true;
                }
                if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }
            } while (VariableBanderaParaRepetirElCiclo == true);
        }

        //Metodo para reducir productos del sistema con parametro
        static bool ReducirProductoConParametro(int parametroCodigo, int parametroCantidad)
        {
            bool VariableBanderaParaRepetirElCiclo = true;
            do
            {
                int codigoDelProducto = parametroCodigo;

                if (ListaDeProductos.ContainsKey(codigoDelProducto))
                {
                    int cantidadDelProducto = parametroCantidad;

                    string nombreActual = ListaDeProductos[codigoDelProducto].Item1;
                    string descripcionActua = ListaDeProductos[codigoDelProducto].Item2;
                    decimal precioActual = ListaDeProductos[codigoDelProducto].Item3;
                    int cantidadActual = ListaDeProductos[codigoDelProducto].Item4;
                    if (cantidadActual >= cantidadDelProducto)
                    {
                        int nuevaCantidad = cantidadActual - cantidadDelProducto;
                        ListaDeProductos.Remove(codigoDelProducto);
                        Tuple<string, string, decimal, int> nuevosDatosDelProducto = new Tuple<string, string, decimal, int>(nombreActual, descripcionActua, precioActual, nuevaCantidad);
                        ListaDeProductos[codigoDelProducto] = nuevosDatosDelProducto;
                        Console.WriteLine("La operacion se realizo con exito.");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("La cantidad el producto es insuficiente.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("El producto no existe");
                    return false;
                }
                Console.WriteLine("Deseas seguir restando existencias de productos? s=si n=no");
                string decicionParaLaOperacion = Console.ReadLine();
                if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                {
                    VariableBanderaParaRepetirElCiclo = true;
                }
                if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }
            } while (VariableBanderaParaRepetirElCiclo == true);
        }

        //Metodo para modificar cantidad de productos del sistema
        static void ModificarCantidadDeProducto()
        {
            bool VariableBanderaParaRepetirElCiclo = true;
            do
            {
                Console.WriteLine("Escriba el codigo del producto:");
                int codigoDelProducto = Convert.ToInt32(Console.ReadLine());

                if (ListaDeProductos.ContainsKey(codigoDelProducto))
                {
                    Console.WriteLine("Ingrese la nueva cantidad del producto:");
                    int cantidadDelProducto = Convert.ToInt32(Console.ReadLine());

                    string nombreActual = ListaDeProductos[codigoDelProducto].Item1;
                    string descripcionActua = ListaDeProductos[codigoDelProducto].Item2;
                    decimal precioActual = ListaDeProductos[codigoDelProducto].Item3;

                    ListaDeProductos.Remove(codigoDelProducto);

                    Tuple<string, string, decimal, int> nuevosDatosDelProducto = new Tuple<string, string, decimal, int>(nombreActual, descripcionActua, precioActual, cantidadDelProducto);
                    ListaDeProductos[codigoDelProducto] = nuevosDatosDelProducto;
                    Console.WriteLine("La operacion se realizo con exito.");
                }
                else
                {
                    Console.WriteLine("El producto no existe");
                }
                Console.WriteLine("Deseas seguir modificando existencias de productos? s=si n=no");
                string decicionParaLaOperacion = Console.ReadLine();
                if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                {
                    VariableBanderaParaRepetirElCiclo = true;
                }
                if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }
            } while (VariableBanderaParaRepetirElCiclo == true);
        }

        //Metodo para buscar datos de los productos del sistema
        static void BuscarProducto()
        {
            Console.WriteLine("Ingrese el codigo del producto :");
            int codigoDelProducto = Convert.ToInt32(Console.ReadLine());

            if (ListaDeProductos.ContainsKey(codigoDelProducto))
            {
                foreach (var variableDeRecorrido in ListaDeProductos)
                {
                    if (variableDeRecorrido.Key == codigoDelProducto)
                    {
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("Codigo: {0}", variableDeRecorrido.Key);
                        Console.WriteLine("Nombre: {0}", variableDeRecorrido.Value.Item1);
                        Console.WriteLine("Descripcion: {0}", variableDeRecorrido.Value.Item2);
                        Console.WriteLine("Precio: {0}", variableDeRecorrido.Value.Item3);
                        Console.WriteLine("Cantidad: {0}", variableDeRecorrido.Value.Item4);
                    }
                }
            }
            else
            {
                Console.WriteLine("El cliente no existe.");
            }
        }
        //Fin metos para administrar productos del sistema

        //Variable para controlar los numeros correlativos de las ventas
        static int NumeroCorrelativoDeVentas = 0;

        //Metodos para administrar ventas o pedidos del sistema
        static Dictionary<int, Tuple<int, int, decimal, bool>> ListaDeVentas = new Dictionary<int, Tuple<int, int, decimal, bool>>();

        //Metodo para calcular el numero correlativo de ventas
        static void CalcularCorrelativoDeVentas()
        {
            foreach (var variableDeRecorrido in ListaDeVentas)
            {
                NumeroCorrelativoDeVentas++;
            }
        }

        //Metodo para extraer la sumatoria total de una venta
        static decimal ExtraerSubTotalDeVenta(int parametroCodigo)
        {
            decimal precioActual = 0;
            if (ListaDeVentas.ContainsKey(parametroCodigo))
            {
                precioActual = ListaDeVentas[parametroCodigo].Item3;
            }
            return precioActual;
        }

        //Metodo para la creacion de nuevos productos al sistema
        static void CrearVenta()
        {
            bool VariableBanderaParaRepetirElCiclo = true;
            do
            {
                Console.WriteLine("Para terminar la venta ingresa un 0 para salir y finalizar la venta");
                Console.WriteLine("Ingrese el codigo del producto:");
                int codigoDelProducto = Convert.ToInt32(Console.ReadLine());

                if (codigoDelProducto == 0)
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }

                //La siguiente sentencia anidada permite verificar si un producto ya existe en el sistema
                if (ListaDeProductos.ContainsKey(codigoDelProducto))
                {

                    decimal precioDelProductoElegido = ExtraerPrecioDeUnProducto(codigoDelProducto);
                    decimal subTotalDelPedido = 0;

                    Console.WriteLine("Ingrese la cantidad del producto:");
                    int cantidadDelProducto = Convert.ToInt32(Console.ReadLine());

                    subTotalDelPedido=precioDelProductoElegido*cantidadDelProducto;

                    if (ReducirProductoConParametro(codigoDelProducto, cantidadDelProducto) == true)
                    {
                        Tuple<int, int, decimal, bool> objetoDeDatos = new Tuple<int, int, decimal, bool>(codigoDelProducto, cantidadDelProducto, subTotalDelPedido, false);
                        ListaDeVentas[NumeroCorrelativoDeVentas] = objetoDeDatos;
                        NumeroCorrelativoDeVentas++;
                    }
                    if (ReducirProductoConParametro(codigoDelProducto, cantidadDelProducto) == false)
                    {
                        Console.WriteLine("El producto es insuficiente o no existe, intentelo de nuevo.");
                    }
                    if (ListaDeProductos.ContainsKey(codigoDelProducto) == false)
                    {
                        Console.WriteLine("el producto no existe vuelva a intentarlo.");
                    }

                    Console.WriteLine("Deseas agregar un nuevo registroa la venta? s=si n=no");
                    string decicionParaLaOperacion = Console.ReadLine();
                    if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                    {
                        VariableBanderaParaRepetirElCiclo = false;
                    }
                    if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                    {
                        VariableBanderaParaRepetirElCiclo = false;
                    }
                }
            } while (VariableBanderaParaRepetirElCiclo == true);
        }

        //Metodo para modificar datos de los productos del sistema
        static void ModificarVenta()
        {
            bool VariableBanderaParaRepetirElCiclo = true;
            do
            {
                Console.WriteLine("Escriba el codigo o Id de la venta:");
                int codigoDeLaVenta = Convert.ToInt32(Console.ReadLine());

                if (ListaDeVentas.ContainsKey(codigoDeLaVenta))
                {

                    Console.WriteLine("Ingrese el codigo del producto:");
                    int codigoDelProducto = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingrese la cantidad del producto:");
                    int cantidadDelProducto = Convert.ToInt32(Console.ReadLine());
                    decimal subTotalDelPedido = ExtraerPrecioDeUnProducto(codigoDelProducto)*cantidadDelProducto;

                    ListaDeVentas.Remove(codigoDeLaVenta);

                    Tuple<int, int, decimal, bool> objetoDeDatos = new Tuple<int, int, decimal, bool>(codigoDelProducto, cantidadDelProducto, subTotalDelPedido, false);
                    ListaDeVentas[codigoDeLaVenta] = objetoDeDatos;
                    Console.WriteLine("La modificacion se realizo con exito.");
                }
                else
                {
                    Console.WriteLine("El producto no existe");
                }
                Console.WriteLine("Deseas seguir modificando registros? s=si n=no");
                string decicionParaLaOperacion = Console.ReadLine();
                if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                {
                    VariableBanderaParaRepetirElCiclo = true;
                }
                if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }
            } while (VariableBanderaParaRepetirElCiclo == true);
        }

        //Metodo para eliminar productos del sistema
        static void EliminarVenta()
        {
            Console.WriteLine("Escriba el codigo o Id de la venta:");
            int codigoDeLaVenta = Convert.ToInt32(Console.ReadLine());

            if (ListaDeProductos.ContainsKey(codigoDeLaVenta))
            {
                Console.WriteLine("Estas seguro de eliminar el registro? s=si n=no");
                string decicionParaLaOperacion = Console.ReadLine();
                if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                {
                    ListaDeProductos.Remove(codigoDeLaVenta);
                    Console.WriteLine("Se ha eliminado del sistema.");
                }
                if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                {
                    Console.WriteLine("No se eliminara el registro.");
                }
            }
            else
            {
                Console.WriteLine("No se elimino la venta por que no existe.");
            }
        }

        //Metodo para mostrar las ventas
        static void MostrarVentas()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Productos registrados:");
            foreach (var variableDeRecorrido in ListaDeProductos)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Codigo venta: {0}", variableDeRecorrido.Key);
                Console.WriteLine("Codigo producto: {0}", variableDeRecorrido.Value.Item1);
                Console.WriteLine("Cantidad del producto: {0}", variableDeRecorrido.Value.Item2);
                Console.WriteLine("Estado de la venta false=sin facturar true=facturado: {0}", variableDeRecorrido.Value.Item3);
            }
        }

        //Metodo para buscar ventas
        static void BuscarVentas()
        {
            Console.WriteLine("Ingrese el codigo de la venta :");
            int codigoDeLaVenta = Convert.ToInt32(Console.ReadLine());

            if (ListaDeVentas.ContainsKey(codigoDeLaVenta))
            {
                foreach (var variableDeRecorrido in ListaDeVentas)
                {
                    if (variableDeRecorrido.Key == codigoDeLaVenta)
                    {
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("Codigo venta: {0}", variableDeRecorrido.Key);
                        Console.WriteLine("Codigo producto: {0}", variableDeRecorrido.Value.Item1);
                        Console.WriteLine("Cantidad del producto: {0}", variableDeRecorrido.Value.Item2);
                        Console.WriteLine("Estado de la venta false=sin facturar true=facturado: {0}", variableDeRecorrido.Value.Item3);
                    }
                }
            }
            else
            {
                Console.WriteLine("El cliente no existe.");
            }
        }

        //Metodo para facturar una venta o pedido
        static void FacturarVentaOPedido(int parametroCodigo)
        {
            bool VariableBanderaParaRepetirElCiclo = true;
            do
            {
                int codigoDeLaVenta = parametroCodigo;

                if (ListaDeVentas.ContainsKey(codigoDeLaVenta))
                {

                    int codigoDelProducto = ListaDeVentas[codigoDeLaVenta].Item1;
                    int cantidadDelProducto = ListaDeVentas[codigoDeLaVenta].Item2;
                    decimal subTotalDelPedido = ListaDeVentas[codigoDeLaVenta].Item3;

                    ListaDeVentas.Remove(codigoDeLaVenta);

                    Tuple<int, int, decimal, bool> objetoDeDatos = new Tuple<int, int, decimal, bool>(codigoDelProducto, cantidadDelProducto, subTotalDelPedido, true);
                    ListaDeVentas[codigoDeLaVenta] = objetoDeDatos;
                }
                else
                {
                    Console.WriteLine("El producto no existe");
                }
                Console.WriteLine("Deseas seguir modificando registros? s=si n=no");
                string decicionParaLaOperacion = Console.ReadLine();
                if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                {
                    VariableBanderaParaRepetirElCiclo = true;
                }
                if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }
            } while (VariableBanderaParaRepetirElCiclo == true);
        }

        //Fin metos para administrar ventas del sistema

        //Variable para controlar los numeros correlativos de las ventas
        static int NumeroCorrelativoDeFacturas = 0;

        //Metodos para administrar ventas o pedidos del sistema
        static Dictionary<int, Tuple<string, int, decimal>> ListaDeFacturas = new Dictionary<int, Tuple<string, int, decimal>>();

        //Metodo para calcular el numero correlativo de ventas
        static void CalcularCorrelativoDeFacturas()
        {
            foreach (var variableDeRecorrido in ListaDeFacturas)
            {
                NumeroCorrelativoDeFacturas++;
            }
        }

        //Metodo para crear una factura
        static void CrearFacturacion()
        {
            bool VariableBanderaParaRepetirElCiclo = true;
            do
            {
                Console.WriteLine("Para terminar la venta ingresa un 0 para salir y finalizar la venta");
                Console.WriteLine("Ingrese el codigo o id del pedido o de la venta:");
                int codigoDelPedido = Convert.ToInt32(Console.ReadLine());

                if (codigoDelPedido == 0)
                {
                    VariableBanderaParaRepetirElCiclo = false;
                }

                //La siguiente sentencia anidada permite verificar si un producto ya existe en el sistema
                if (ListaDeFacturas.ContainsKey(codigoDelPedido))
                {
                    //Sacar el precio del producto
                    FacturarVentaOPedido(codigoDelPedido);
                    decimal totalDeLaVenta = ExtraerSubTotalDeVenta(codigoDelPedido);
                    Console.WriteLine("Ingrese el nit del cliente:");
                    string nitDelCliente = Console.ReadLine();
                    CrearClienteConParametro(nitDelCliente);

                    decimal descuento=0, totalConDescuento=0, IVA=0;

                    IVA=totalDeLaVenta*0.12m;
                    if(totalDeLaVenta>=1 && totalDeLaVenta<=100){
                        descuento=totalDeLaVenta*0.05m;
                    }
                    if(totalDeLaVenta>=101 && totalDeLaVenta<=200){
                        descuento=totalDeLaVenta*0.07m;
                    }
                    if(totalDeLaVenta>=201){
                        descuento=totalDeLaVenta*0.10m;
                    }

                    totalConDescuento=(totalDeLaVenta-(descuento+IVA));

                    Console.WriteLine("-----------------------------------------");
                    Console.WriteLine("Resultados de la facturacion");
                    Console.WriteLine("El descuento es de: {0}", descuento);
                    Console.WriteLine("El IVA es de: {0}", IVA);
                    Console.WriteLine("El total sin descuento es de: {0}", totalDeLaVenta);
                    Console.WriteLine("El total con descuento es de: {0}", totalConDescuento);


                    Tuple<string, int, decimal> objetoDeDatos = new Tuple<string, int, decimal>(nitDelCliente, codigoDelPedido, totalConDescuento);
                    ListaDeFacturas[NumeroCorrelativoDeFacturas] = objetoDeDatos;
                    NumeroCorrelativoDeFacturas++;

                    Console.WriteLine("Deseas seguir facturando pedidos? s=si n=no");
                    string decicionParaLaOperacion = Console.ReadLine();
                    if (decicionParaLaOperacion == "s" || decicionParaLaOperacion == "S")
                    {
                        VariableBanderaParaRepetirElCiclo = false;
                    }
                    if (decicionParaLaOperacion == "n" || decicionParaLaOperacion == "N")
                    {
                        VariableBanderaParaRepetirElCiclo = false;
                    }
                }
            } while (VariableBanderaParaRepetirElCiclo == true);
        }
        //Fin metodos para administrar facturaciones

        //Metodo para mostrar facturas
        static void MostrarFacturas()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Facturas registradas:");
            foreach (var variableDeRecorrido in ListaDeProductos)
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Codigo de la factura: {0}", variableDeRecorrido.Key);
                Console.WriteLine("Nit del cliente: {0}", variableDeRecorrido.Value.Item1);
                Console.WriteLine("Codigo de la venta o pedido: {0}", variableDeRecorrido.Value.Item2);
                Console.WriteLine("total: {0}", variableDeRecorrido.Value.Item3);
            }
        }

        //Metodo para buscar facturas
        static void BuscarFacturas()
        {
            Console.WriteLine("Ingrese el codigo de la factura :");
            int codigoDeLaFactura = Convert.ToInt32(Console.ReadLine());

            if (ListaDeVentas.ContainsKey(codigoDeLaFactura))
            {
                foreach (var variableDeRecorrido in ListaDeVentas)
                {
                    if (variableDeRecorrido.Key == codigoDeLaFactura)
                    {
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("Codigo de la factura: {0}", variableDeRecorrido.Key);
                        Console.WriteLine("Nit del cliente: {0}", variableDeRecorrido.Value.Item1);
                        Console.WriteLine("Codigo de la venta o pedido: {0}", variableDeRecorrido.Value.Item2);
                        Console.WriteLine("total: {0}", variableDeRecorrido.Value.Item3);
                    }
                }
            }
            else
            {
                Console.WriteLine("El cliente no existe.");
            }
        }

        //Fin metodos para administrar facturaciones

        //Metodos para la validacion de los usuarios
        static bool validadUsuario(string parametroUsuario, string parametroClave) {
            if (ListaDeUsuarios.ContainsKey(parametroUsuario)&&ListaDeUsuarios.ContainsValue(parametroClave))
            {
                return true;
            }
            else {
                return false;
            }
        }
        //Fin de los metodos para la validacion de usuarios

        //Metodo para el catalogo de usuarios
        static void MenuCalalogoUsuarios()
        {
            //Variable paracontrolar el ciclo del menu catalogos
            bool variableBanderaParaRepetirElCicloDelMenu = true;
            //Variable para capturar la opcion deseada en el menu
            int opcionDelMenu = 0;
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Menu usuarios");
                Console.WriteLine("1-Agregar");
                Console.WriteLine("2-Modificar");
                Console.WriteLine("3-Eliminar");
                Console.WriteLine("4-Mostrar todos los registros");
                Console.WriteLine("5-Buscar");
                Console.WriteLine("6- salir");
                opcionDelMenu = Convert.ToInt32(Console.ReadLine());
                switch (opcionDelMenu)
                {
                    case 1:
                        CrearUsuario();
                        break;
                    case 2:
                        ModificarUsuario();
                        break;
                    case 3:
                        EliminarUsuario();
                        break;
                    case 4:
                        MostrarUsuariosRegistrados();
                        break;
                    case 5:
                        BuscarUsuario();
                        break;
                    case 6:
                        variableBanderaParaRepetirElCicloDelMenu = false;
                        break;
                    default:
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("La opcion ingresada no existe");
                        Console.WriteLine("--------------------------------------");
                        break;
                }
            } while (variableBanderaParaRepetirElCicloDelMenu == true);
        }

        //metodo para el catalogo de clientes
        static void MenuCalalogoClientes()
        {
            //Variable paracontrolar el ciclo del menu catalogos
            bool variableBanderaParaRepetirElCicloDelMenu = true;
            //Variable para capturar la opcion deseada en el menu
            int opcionDelMenu = 0;
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Menu clientes");
                Console.WriteLine("1-Agregar");
                Console.WriteLine("2-Modificar");
                Console.WriteLine("3-Eliminar");
                Console.WriteLine("4-Mostrar todos los registros");
                Console.WriteLine("5-Buscar");
                Console.WriteLine("6- salir");
                opcionDelMenu = Convert.ToInt32(Console.ReadLine());
                switch (opcionDelMenu)
                {
                    case 1:
                        CrearCliente();
                        break;
                    case 2:
                        ModificarCliente();
                        break;
                    case 3:
                        EliminarCliente();
                        break;
                    case 4:
                        MostrarClientes();
                        break;
                    case 5:
                        BuscarCliente();
                        break;
                    case 6:
                        variableBanderaParaRepetirElCicloDelMenu = false;
                        break;
                    default:
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("La opcion ingresada no existe");
                        Console.WriteLine("--------------------------------------");
                        break;
                }
            } while (variableBanderaParaRepetirElCicloDelMenu == true);
        }

        //metodo para el catalogo de productos
        static void MenuCalalogoProductos()
        {
            //Variable paracontrolar el ciclo del menu catalogos
            bool variableBanderaParaRepetirElCicloDelMenu = true;
            //Variable para capturar la opcion deseada en el menu
            int opcionDelMenu = 0;
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Menu productos");
                Console.WriteLine("1-Agregar");
                Console.WriteLine("2-Modificar");
                Console.WriteLine("3-Eliminar");
                Console.WriteLine("4-Mostrar todos los registros");
                Console.WriteLine("5-Buscar");
                Console.WriteLine("6- salir");
                opcionDelMenu = Convert.ToInt32(Console.ReadLine());
                switch (opcionDelMenu)
                {
                    case 1:
                        CrearProducto();
                        break;
                    case 2:
                        ModificarProducto();
                        break;
                    case 3:
                        EliminarProducto();
                        break;
                    case 4:
                        MostrarProductos();
                        break;
                    case 5:
                        BuscarProducto();
                        break;
                    case 6:
                        variableBanderaParaRepetirElCicloDelMenu = false;
                        break;
                    default:
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("La opcion ingresada no existe");
                        Console.WriteLine("--------------------------------------");
                        break;
                }
            } while (variableBanderaParaRepetirElCicloDelMenu == true);
        }

        //Metodo para el menu de catalogos
        static void MenuCalalogos() {
            //Variable paracontrolar el ciclo del menu catalogos
            bool variableBanderaParaRepetirElCicloDelMenu = true;
            //Variable para capturar la opcion deseada en el menu
            int opcionDelMenu = 0;
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Menu catalogos");
                Console.WriteLine("Seleccione el catalogo que necesite administrar");
                Console.WriteLine("1-Usuarios");
                Console.WriteLine("2-Clientes");
                Console.WriteLine("3-Productos");
                Console.WriteLine("4-Ventas o pedidos");
                Console.WriteLine("5-Facturaciones");
                Console.WriteLine("6-Salir");
                opcionDelMenu = Convert.ToInt32(Console.ReadLine());
                switch (opcionDelMenu)
                {
                    case 1:
                        MenuCalalogoUsuarios();
                        break;
                    case 2:
                        MenuCalalogoClientes();
                        break;
                    case 3:
                        MenuCalalogoProductos();
                        break;
                    case 4:
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("catalogo ventas o pedidos");
                        Console.WriteLine("--------------------------------------");
                        break;
                    case 5:
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("catalogo facturaciones");
                        Console.WriteLine("--------------------------------------");
                        break;
                    case 6:
                        variableBanderaParaRepetirElCicloDelMenu = false;
                        break;
                    default:
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("La opcion ingresada no existe");
                        Console.WriteLine("--------------------------------------");
                        break;
                }
            } while (variableBanderaParaRepetirElCicloDelMenu == true);
        }

        //Metodo para menu inventarios
        static void MenuInventarios()
        {
            //Variable paracontrolar el ciclo del menu catalogos
            bool variableBanderaParaRepetirElCicloDelMenu = true;
            //Variable para capturar la opcion deseada en el menu
            int opcionDelMenu = 0;
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Menu inventarios");
                Console.WriteLine("1-Agregar mas productos");
                Console.WriteLine("2-Restar productos");
                Console.WriteLine("3-Actualizar solo cantidad de productos");
                Console.WriteLine("4-Consultar mostrar los productos");
                Console.WriteLine("5-salir");
                opcionDelMenu = Convert.ToInt32(Console.ReadLine());
                switch (opcionDelMenu)
                {
                    case 1:
                        AumentarProducto();
                        break;
                    case 2:
                        ReducirProducto();
                        break;
                    case 3:
                        ModificarCantidadDeProducto();
                        break;
                    case 4:
                        SubInventariosBuscarProductos();
                        break;
                    case 5:
                        variableBanderaParaRepetirElCicloDelMenu = false;
                        break;
                    default:
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("La opcion ingresada no existe");
                        Console.WriteLine("--------------------------------------");
                        break;
                }
            } while (variableBanderaParaRepetirElCicloDelMenu == true);
        }

        //metodo para el ventas
        static void MenuVentas()
        {
            //Variable paracontrolar el ciclo del menu catalogos
            bool variableBanderaParaRepetirElCicloDelMenu = true;
            //Variable para capturar la opcion deseada en el menu
            int opcionDelMenu = 0;
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Menu ventas");
                Console.WriteLine("1-Agregar");
                Console.WriteLine("2-Modificar");
                Console.WriteLine("3-Eliminar");
                Console.WriteLine("4-Mostrar todos los registros");
                Console.WriteLine("5-Buscar");
                Console.WriteLine("6- salir");
                opcionDelMenu = Convert.ToInt32(Console.ReadLine());
                switch (opcionDelMenu)
                {
                    case 1:
                        CrearVenta();
                        break;
                    case 2:
                        ModificarVenta();
                        break;
                    case 3:
                        EliminarVenta();
                        break;
                    case 4:
                        MostrarVentas();
                        break;
                    case 5:
                        BuscarVentas();
                        break;
                    case 6:
                        variableBanderaParaRepetirElCicloDelMenu = false;
                        break;
                    default:
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("La opcion ingresada no existe");
                        Console.WriteLine("--------------------------------------");
                        break;
                }
            } while (variableBanderaParaRepetirElCicloDelMenu == true);
        }

        //metodo para la facturacion
        static void MenuFacturacion()
        {
            //Variable paracontrolar el ciclo del menu catalogos
            bool variableBanderaParaRepetirElCicloDelMenu = true;
            //Variable para capturar la opcion deseada en el menu
            int opcionDelMenu = 0;
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Menu ventas");
                Console.WriteLine("1-Agregar");
                Console.WriteLine("2-Mostrar facturas");
                Console.WriteLine("3-Buscar facturas");
                Console.WriteLine("4- salir");
                opcionDelMenu = Convert.ToInt32(Console.ReadLine());
                switch (opcionDelMenu)
                {
                    case 1:
                        CrearFacturacion();
                        break;
                    case 2:
                        MostrarFacturas();
                        break;
                    case 3:
                        BuscarFacturas();
                        break;
                    case 4:
                        variableBanderaParaRepetirElCicloDelMenu = false;
                        break;
                    default:
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("La opcion ingresada no existe");
                        Console.WriteLine("--------------------------------------");
                        break;
                }
            } while (variableBanderaParaRepetirElCicloDelMenu == true);
        }
        //Metodo para menu inventarios
        static void SubInventariosBuscarProductos()
        {
            //Variable paracontrolar el ciclo del menu catalogos
            bool variableBanderaParaRepetirElCicloDelMenu = true;
            //Variable para capturar la opcion deseada en el menu
            int opcionDelMenu = 0;
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Menu inventarios");
                Console.WriteLine("1-Buscar un producto especifico");
                Console.WriteLine("2-Mostrar todos los productos");
                Console.WriteLine("3-salir");
                opcionDelMenu = Convert.ToInt32(Console.ReadLine());
                switch (opcionDelMenu)
                {
                    case 1:
                        BuscarProducto();
                        break;
                    case 2:
                        MostrarProductos();
                        break;
                    case 3:
                        variableBanderaParaRepetirElCicloDelMenu = false;
                        break;
                    default:
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("La opcion ingresada no existe");
                        Console.WriteLine("--------------------------------------");
                        break;
                }
            } while (variableBanderaParaRepetirElCicloDelMenu == true);
        }

        //Metodo para el menu principal del programa
        static void MenuPrincipalDelPrograma()
        {
            //Variable paracontrolar el ciclo del menu principal
            bool variableBanderaParaRepetirElCicloDelMenu = true;
            //Variable para capturar la opcion deseada en el menu
            int opcionDelMenu = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Menu principal");
                Console.WriteLine("1-Catalogos(Esta opcion permite crear, modificar, eliminar y buscar registros)");
                Console.WriteLine("2-Inventarios(permite agregar, actualizar, consultar productos)");
                Console.WriteLine("3-Ventas(permite agregar, actualizar, consultar pedidos o ventas)");
                Console.WriteLine("4-Facturacion(permite finalizar una venta o pedido)");
                Console.WriteLine("5-Cerrar sesion");
                opcionDelMenu = Convert.ToInt32(Console.ReadLine());
                switch (opcionDelMenu)
                {
                    case 1:
                        MenuCalalogos();
                    break;
                    case 2:
                        MenuInventarios();
                    break;
                    case 3:
                        MenuVentas();
                    break;
                    case 4:
                        MenuFacturacion();
                    break;
                    case 5:
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("Se ha finalizado la sesion del usuario");
                        Console.WriteLine("--------------------------------------");
                        variableBanderaParaRepetirElCicloDelMenu = false;
                    break;
                    default:
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("La opcion ingresada no existe");
                        Console.WriteLine("--------------------------------------");
                    break;
                }
            } while (variableBanderaParaRepetirElCicloDelMenu == true); //Fin del while que repite el menu principal
        }
	
	public static void Main()
	{
		    //Iniciamos el calculo de los numeros correlativos de ventas
            CalcularCorrelativoDeVentas();
            //Variable para controlar el ciclo de acceso al sistema
            bool variableBanderaParaRepetirElCicloDeValidacionDeUsuario = false;
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Inicio de sesion");
            do
            {
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Ingrese el usuario");
                string variableValidarUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese la contraseña");
                string variableValidarClave = Console.ReadLine();
                if (validadUsuario(variableValidarUsuario, variableValidarClave))
                {
                    Console.WriteLine("El usuaario ingresado es valido");
                    MenuPrincipalDelPrograma();
                }
                else
                {
                    Console.WriteLine("no tienes acceso al sistema");
                }
            } while (variableBanderaParaRepetirElCicloDeValidacionDeUsuario == false); //Fin del while que crea el ciclo repetitivo para realizar intentos de acceso al sistema
	}
}