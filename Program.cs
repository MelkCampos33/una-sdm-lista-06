using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Digite o nome do Pokémon: ");
        string nome = Console.ReadLine().ToLower();

        string url = $"https://pokeapi.co/api/v2/pokemon/{nome}";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var pokemon = JsonSerializer.Deserialize<Pokemon>(json);

                Console.WriteLine("\nDados do Pokémon:");
                Console.WriteLine("Id: " + pokemon.id);
                Console.WriteLine("Nome: " + pokemon.name);
                Console.WriteLine("Altura: " + pokemon.height);
                Console.WriteLine("Peso: " + pokemon.weight);
            }
            catch
            {
                Console.WriteLine("Pokémon não encontrado.");
            }
        }
    }
}
