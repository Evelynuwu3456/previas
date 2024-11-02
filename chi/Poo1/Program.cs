using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Poo1.Program;

namespace Poo1
{
    class Program
    {
        public static void Main(string[] ars)
        {
            // Crear algunas personas
            Persona persona1 = new Persona("Juan", "Perez", 20);
            Persona persona2 = new Persona("Ana", "Gomez", 15);

            // Crear una dirección para la casa
            Direccion direccionCasa = new Direccion("Av.jujuy", 742,"C.A.B.A","Balvanera");

            // Crear una casa y agregar habitantes
            Casa casa = new Casa(5, "Azul", direccionCasa);
            casa.Habitantes.Add(persona1);
            casa.Habitantes.Add(persona2);

            // Describir la casa y presentar a los habitantes
            Console.WriteLine("Descripción dela casa:");
            Console.WriteLine(casa.DescribirCasa());
            Console.WriteLine("Presentación de los habitantes de la casa:");
            casa.PresentarHabitantes();
            Console.WriteLine("Habitantes mayores de edad:");
            casa.PresentarMayoresDeEdad();

            // Crear una cuenta bancaria
            CuentaBancaria cuenta = new CuentaBancaria(persona1, 1000m);
            Console.WriteLine("Cuenta bancaria: ");
            cuenta.Depositar(200m);
            cuenta.Retirar(150m);
            Console.WriteLine("Saldo actual: " + cuenta.ObtenerSaldo());

            // Crear productos y un carrito de compras
            Console.WriteLine("Carrito de compras: ");
            Producto producto1 = new Producto("Manzana", 1.5m, 10);
            producto1.MostrarInformacion();
            Producto producto2 = new Producto("Pan", 0.8m, 5);
            producto2.MostrarInformacion();
            CarritoDeCompras carrito = new CarritoDeCompras();
            carrito.AgregarProducto(producto1);
            carrito.AgregarProducto(producto2);
            Console.WriteLine("Total del carrito: " + carrito.CalcularTotal());

            // Crear un empleado
            Empleado empleado = new Empleado("Pedro", "Gonzalez", 30, "Gerente", 3000m);
            empleado.AumentarSalario(10);
            Console.WriteLine($"Nuevo salario de {empleado.Nombre}: {empleado.Salario}");

            Estudiante estudiante = new Estudiante("Maria", "Lopez", 20, "Ingeniería", 9.0m);
            estudiante.ActualizarPromedio(9.5m);
            estudiante.MostrarInformacion();
            Console.WriteLine($"Nuevo promedio de {estudiante.Nombre}: {estudiante.Promedio}");
            

            // Crear una biblioteca y realizar préstamos
            Biblioteca biblioteca = new Biblioteca();
            Libro libro1 = new Libro("Cien Años de Soledad", "Gabriel Garcia Marquez");
            Socio socio = new Socio("Carlos", "Garcia", 25);

            biblioteca.AgregarLibro(libro1);
            biblioteca.PrestarLibro(libro1, socio);
            biblioteca.DevolverLibro(libro1, socio);

            Console.ReadLine();
        }



        public class Persona
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public int Edad { get; set; }
            public const int MAYORIA_DE_EDAD = 18;

            public Persona(string nombre, string apellido, int edad)
            {
                Nombre = nombre;
                Apellido = apellido;
                Edad = edad;
            }

            public void Presentarse()
            {
                Console.WriteLine($"Hola, soy {Nombre} {Apellido}");
            }

            public bool EsMayorDeEdad()
            {
                return Edad >= MAYORIA_DE_EDAD;
            }
        }

        public class Casa
        {
            public int Capacidad { get; set; }
            public string ColorExterior { get; set; }
            public Direccion Direccion { get; set; }
            public List<Persona> Habitantes { get; set; }

            public Casa(int capacidad, string colorExterior, Direccion direccion)
            {
                Capacidad = capacidad;
                ColorExterior = colorExterior;
                Direccion = direccion;
                Habitantes = new List<Persona>();
            }

            public string DescribirCasa()
            {
                return $"La casa tiene capacidad para {Capacidad} personas y es de color {ColorExterior}.";
            }

            public void PresentarHabitantes()
            {
                foreach (var habitante in Habitantes)
                {
                    habitante.Presentarse();
                }
            }

            public void PresentarMayoresDeEdad()
            {
                foreach (var habitante in Habitantes)
                {
                    if (habitante.EsMayorDeEdad())
                    {
                        habitante.Presentarse();
                    }
                }
            }
        }

        public class Direccion
        {
            public string Calle { get; set; }
            public int Altura { get; set; }
            public string Ciudad { get; set; }
            public string Barrio { get; set; }

            public Direccion(string calle, int altura, string ciudad, string barrio)
            {
                Calle = calle;
                Altura = altura;
                Ciudad = ciudad;
                Barrio = barrio;
            }

            public int ObtenerCodigoPostal()
            {
                return Altura * Calle.Length;
            }
        }

        public class CuentaBancaria
        {
            public Persona Titular { get; set; }
            private decimal Saldo { get; set; }

            public CuentaBancaria(Persona titular, decimal saldoInicial)
            {
                Titular = titular;
                Saldo = saldoInicial;
            }

            public void Depositar(decimal monto)
            {
                if (monto > 0)
                {
                    Saldo += monto;
                    Console.WriteLine($"Se ha depositado: {monto:C}");
                }
            }

            public void Retirar(decimal monto)
            {
                if (monto > 0 && Saldo >= monto)
                {
                    Saldo -= monto;
                    Console.WriteLine($"Se ha retirado: {monto:C}"); //mensaje de retiro de deniro
                }
                else
                {
                    Console.WriteLine("Retiro fallido: saldo insuficiente o monto no válido."); // mensaje de error
                }
            }

            public decimal ObtenerSaldo()
            {
                return Saldo;
            }
        }

        public class Producto
        {
            public string Nombre { get; set; }
            public decimal Precio { get; set; }
            public int CantidadDisponible { get; set; }

            public Producto(string nombre, decimal precio, int cantidadDisponible)
            {
                Nombre = nombre;
                Precio = precio;
                CantidadDisponible = cantidadDisponible;
            }

            public void AjustarPrecio(decimal nuevoPrecio)
            {
                Precio = nuevoPrecio;
            }

            public void AjustarCantidadDisponible(int nuevaCantidad)
            {
                CantidadDisponible = nuevaCantidad;
            }

            public void MostrarInformacion()
            {
                Console.WriteLine($"Producto: {Nombre}, Precio: {Precio:C}, Cantidad disponible: {CantidadDisponible}");
            }
        }

        public class CarritoDeCompras
        {
            private List<Producto> Productos { get; set; }

            public CarritoDeCompras()
            {
                Productos = new List<Producto>();
            }

            public void AgregarProducto(Producto producto)
            {
                Productos.Add(producto);
            }

            public void EliminarProducto(Producto producto)
            {
                Productos.Remove(producto);
            }

            public void VaciarCarrito()
            {
                Productos.Clear();
            }

            public decimal CalcularTotal()
            {
                decimal total = 0;
                foreach (var producto in Productos)
                {
                    total += producto.Precio * producto.CantidadDisponible;
                }
                return total;
            }
        }

        public class Empleado : Persona
        {
            public string Puesto { get; set; }
            public decimal Salario { get; set; }

            public Empleado(string nombre, string apellido, int edad, string puesto, decimal salario)
                : base(nombre, apellido, edad)
            {
                Puesto = puesto;
                Salario = salario;
            }

            public void AumentarSalario(decimal porcentaje)
            {
                Salario += Salario * porcentaje / 100;
            }
        }

        public class Estudiante : Persona
        {
            public string Carrera { get; set; }
            public decimal Promedio { get; set; }

            public Estudiante(string nombre, string apellido, int edad, string carrera, decimal promedio)
                : base(nombre, apellido, edad)
            {
                Carrera = carrera;
                Promedio = promedio;
            }

            public void ActualizarPromedio(decimal nuevoPromedio)
            {
                Promedio = nuevoPromedio;
            }
            public void MostrarInformacion()
            {
                Console.WriteLine($"Estudiante: {Nombre} {Apellido}, Carrera: {Carrera}, Promedio: {Promedio:F2}");
            }
        }

        public class Biblioteca
        {
            private List<Libro> Libros { get; set; }
            private List<Socio> Socios { get; set; }

            public Biblioteca()
            {
                Libros = new List<Libro>();
                Socios = new List<Socio>();
            }

            public void AgregarLibro(Libro libro)
            {
                Libros.Add(libro);
            }

            public void PrestarLibro(Libro libro, Socio socio)
            {
                if (Libros.Contains(libro) && Socios.Contains(socio))
                {
                    Console.WriteLine($"{libro.Titulo} ha sido prestado a {socio.Nombre} {socio.Apellido}");
                    Libros.Remove(libro);
                }
            }

            public void DevolverLibro(Libro libro, Socio socio)
            {
                Libros.Add(libro);
                Console.WriteLine($"{libro.Titulo} ha sido devuelto por {socio.Nombre} {socio.Apellido}");
            }
        }

        public class Libro
        {
            public string Titulo { get; set; }
            public string Autor { get; set; }

            public Libro(string titulo, string autor)
            {
                Titulo = titulo;
                Autor = autor;
            }
        }

        public class Socio : Persona
        {
            public Socio(string nombre, string apellido, int edad) : base(nombre, apellido, edad)
            {
            }
        }

    }
}

