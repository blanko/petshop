using System.Text;

// URL del API
string url = "https://petstore.swagger.io/v2/pet";

// Objeto JSON para enviar en el cuerpo del POST
string jsonContent = @"
{
    ""id"": 0,
    ""category"": {
        ""id"": 0,
        ""name"": ""string""
    },
    ""name"": ""Blanco Mascota"",
    ""photoUrls"": [
        ""string""
    ],
    ""tags"": [
        {
            ""id"": 0,
            ""name"": ""string""
        }
    ],
    ""status"": ""available""
}";

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
        HttpResponseMessage response = await client.PostAsync(url, content);

        // Leer y mostrar la respuesta
        string result = await response.Content.ReadAsStringAsync();
        Console.WriteLine(result);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error: " + ex.Message);
    }
}