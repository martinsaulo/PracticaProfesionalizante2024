using Azure;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;
using System.Text.Json;

class Program
{
    static HttpClient client = new HttpClient();
    static async Task Main()
    {
        client.BaseAddress = new Uri("http://localhost:5245");
        bool flagFin = false;
        string? opcSeleccionada;
        

        while (!flagFin)
        {
            Console.Clear();
            ImprimirOpciones();
            Console.Write("\nOpción: ");
            opcSeleccionada = Console.ReadLine();
            

            switch (opcSeleccionada)
            {
                case "1":
                    //Agregar cliente
                    {
                        string? nombre, apellido, dni;
                        Console.Write("Ingrese el nombre: ");
                        nombre = Console.ReadLine();
                        Console.Write("Ingrese el apellido: ");
                        apellido = Console.ReadLine();
                        Console.Write("Ingrese el dni: ");
                        dni = Console.ReadLine();

                        var values = new Dictionary<string, string?>
                        {
                            { "dni", dni },
                            { "nombre", nombre },
                            { "apellido", apellido }
                        };

                        var json = JsonSerializer.Serialize(values);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = client.PostAsync("api/cliente", content);

                        if (response.IsCompletedSuccessfully)
                        {
                            Console.WriteLine("Cliente agregado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine(response.Result);
                        }
                    }
                    break;

                case "2":
                    // Agregar animal
                    {
                        string? nombre, raza, sexo;
                        int edad, idDuenio;
                        Console.Write("Ingrese el nombre: ");
                        nombre = Console.ReadLine();
                        Console.Write("Ingrese la raza: ");
                        raza = Console.ReadLine();
                        Console.Write("Ingrese el sexo: ");
                        sexo = Console.ReadLine();
                        Console.Write("Ingrese la edad: ");
                        edad = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el id del dueño: ");
                        idDuenio = int.Parse(Console.ReadLine());

                        var values = new Dictionary<string, object?>
                        {
                            { "nombre", nombre },
                            { "raza", raza },
                            { "sexo", sexo },
                            { "edad", edad },
                            { "duenioId", idDuenio },
                        };

                        var json = JsonSerializer.Serialize(values);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = client.PostAsync("api/animal", content);

                        if (response.IsCompletedSuccessfully)
                        {
                            Console.WriteLine("Cliente agregado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine(response.Result);
                        }
                    }
                    break;

                case "3":
                    {
                        //Consultar animal
                        int idAnimal;

                        Console.Write("Ingrese el id: ");
                        idAnimal = int.Parse(Console.ReadLine());

                        var response = await client.GetAsync($"api/animal/{idAnimal}");

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                        }
                        else
                        {
                            Console.WriteLine(response.RequestMessage);
                        }
                    }
                    break;

                case "4":
                    // Eliminar Animal
                    {
                        int idAnimal;
                        idAnimal = int.Parse(Console.ReadLine());

                        var response = await client.DeleteAsync($"api/animal/{idAnimal}");

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine(response.StatusCode);
                        }
                        else
                        {
                            Console.WriteLine(response.RequestMessage);
                        }
                    }
                    break;

                case "5":
                    //Editar animal
                    {
                        string? nombre, raza, sexo;
                        int edad, idDuenio, idAnimal;
                        Console.Write("Ingrese el id del animal: ");
                        idAnimal = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el nombre: ");
                        nombre = Console.ReadLine();
                        Console.Write("Ingrese la raza: ");
                        raza = Console.ReadLine();
                        Console.Write("Ingrese el sexo: ");
                        sexo = Console.ReadLine();
                        Console.Write("Ingrese la edad: ");
                        edad = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el id del dueño: ");
                        idDuenio = int.Parse(Console.ReadLine());

                        var values = new Dictionary<string, object?>
                        {
                            { "nombre", nombre },
                            { "raza", raza },
                            { "sexo", sexo },
                            { "edad", edad },
                            { "duenioId", idDuenio },
                        };

                        var json = JsonSerializer.Serialize(values);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = client.PutAsync($"api/animal/{idAnimal}", content);

                        if (response.IsCompletedSuccessfully)
                        {
                            Console.WriteLine("Cliente agregado correctamente.");
                        }
                        else
                        {
                            Console.WriteLine(response.Result);
                        }
                    }
                    break;

                case "6":
                    //Agregar atención
                    {
                        List<string> medicamentos;
                        string? motivo, tratamiento, fecha;
                        int? idAnimal;
                        Console.Write("Ingrese el motivo: ");
                        motivo = Console.ReadLine();
                        Console.Write("Ingrese el tratamiento: ");
                        tratamiento = Console.ReadLine();
                        Console.Write("Ingrese los medicamentos[separados por comas(,)]: ");
                        medicamentos = Console.ReadLine().Split(",").ToList();
                        Console.Write($"Ingrese la fecha [Hoy es: {DateTime.Now}]: ");
                        fecha = Console.ReadLine();
                        Console.Write("Ingrese el id del animal: ");
                        idAnimal = int.Parse(Console.ReadLine());

                        var values = new Dictionary<string, object?>
                        {
                            { "fecha", fecha },
                            { "motivo", motivo },
                            { "tratamiento", tratamiento },
                            { "medicamentos", medicamentos},
                            { "animalId", idAnimal }
                        };

                        var json = JsonSerializer.Serialize(values);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = client.PostAsync("api/atencion", content);

                        if (response.IsCompletedSuccessfully)
                        {
                            Console.WriteLine("Atencion agregada correctamente.");
                        }
                        else
                        {
                            Console.WriteLine(response.Result);
                        }
                    }
                    break;

                case "7":
                    {
                        //Consultar atención
                        int idAtencion;

                        Console.Write("Ingrese el id: ");
                        idAtencion = int.Parse(Console.ReadLine());

                        var response = await client.GetAsync($"api/atencion/{idAtencion}");

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                        }
                        else
                        {
                            Console.WriteLine(response.RequestMessage);
                        }
                    }
                    break;

                case "8":
                    //Consultar medicamentos
                    {
                        int idAtencion;

                        Console.Write("Ingrese el id: ");
                        idAtencion = int.Parse(Console.ReadLine());

                        var response = await client.GetAsync($"api/atencion/med/{idAtencion}");

                        if (response.IsSuccessStatusCode)
                        {
                            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                        }
                        else
                        {
                            Console.WriteLine(response.RequestMessage);
                        }
                    }
                    break;

                case "0":
                    flagFin = true;
                    break;

                default:
                    Console.WriteLine("\nOpcion invalida.");
                    break;
            }
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ReadKey();
        }
    }
    static void ImprimirOpciones()
    {
        Console.WriteLine("Clientes");
        Console.WriteLine("1. Crear cliente");
        Console.WriteLine("\nAnimales");
        Console.WriteLine("2. Crear animal");
        Console.WriteLine("3. Consultar animal");
        Console.WriteLine("4. Eliminar animal");
        Console.WriteLine("5. Editar animal");
        Console.WriteLine("\nAtenciones");
        Console.WriteLine("6. Crear atencion");
        Console.WriteLine("7. Consultar una atencion");
        Console.WriteLine("8. Consultar medicamentos");
        Console.WriteLine("\n0. Salir");
    }
}

