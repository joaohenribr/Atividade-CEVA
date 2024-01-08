using ConsumindoApi.Entities;
using ConsumindoApi.Entities.Services;
using System.Runtime.CompilerServices;

namespace ConsumindoApi
{
    class Program
    {        
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Informe o número da viagem: ");
            string input = Console.ReadLine();

            if (input == "")
            {
                Console.WriteLine("Erro, digite o numero da viagem!");
            }
            else
            {
                switch (input[0])
                {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':

                        try
                        {
                            int numeroViagem = int.Parse(input);                            

                            if (numeroViagem == Valida());
                            {
                                ViagemServices viagemServices = new ViagemServices();                                
                                Viagems viagemEncontrada = await viagemServices.Integracao(numeroViagem);

                                if (!viagemEncontrada.Verificacao)
                                {
                                    Console.WriteLine("\nViagem encontrada!");
                                }
                                else
                                {
                                    Console.WriteLine("\nViagem não encontrada!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nViagem não encontrada!");
                            }
                            break;

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"{ex.Message} Digite apenas numeros!");
                        }

                        break;

                    default:
                        Console.WriteLine("\nApenas números são permitidos.");
                        break;
                }
            }            
        }
        public static void Valida(string[] input)
        {            
            int numeroViagem = int.Parse(input);
        }
    }
}