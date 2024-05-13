using System.Text;
using System.Text.Json; // Usado: JSONSerializer

// URL del API
string url = "https://petstore.swagger.io/v2/pet";

// Objeto JSON para enviar en el cuerpo del POST
string jsonContent = JsonSerializer.Serialize(new
{
    id = 1,
    title = "prueba",
    category = new
    {
        id = 0,
        name = "string"
    },
    name = "Blanco Mascota",
    status = "available"
});

// Crear el cliente HTTP
using (HttpClient client = new HttpClient())
{
    // Configurar las cabeceras del cliente
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

    // Configurar el contenido de la solicitud
    HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

    try
    {
        // Enviar la solicitud POST
        using HttpResponseMessage response = await client.PostAsync(url, content);

        // Leer y mostrar la respuesta
        string result = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode) // Devuelve algo si el codigo es correcto
        {
            Console.WriteLine($"{response.StatusCode} - Creado: {result}"/*, Formatting.Indented*/);
        }
        else
        {
            Console.WriteLine($"{response.StatusCode} - Fallido: {result}"/*, Formatting.Indented*/);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}