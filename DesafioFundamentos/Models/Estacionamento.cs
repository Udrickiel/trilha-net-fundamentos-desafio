using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();
        private List<(string placa, DateTime entrada, DateTime? saida)> registros = new List<(string placa, DateTime entrada, DateTime? saida)>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            if(precoInicial <0 || precoPorHora <0)
            {
                throw new ArgumentException("Valor digitado invalido, verifique e tente novamente!");
            }
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string placa;
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            placa = Console.ReadLine();
            placa = placa.ToUpper();
            
            if (veiculos.Contains(placa))
            {
                Console.WriteLine("Veiculo já está estacionado");
            }
            else
            {   
                veiculos.Add(placa);
                Console.WriteLine("Veiculo adicionado com sucesso");
            }
            registros.Add((placa, DateTime.Now, null));
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            decimal valorTotal = 0;
            int horas = 0;
            string removerCarro = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == removerCarro.ToUpper()))
            {
                while(true)
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado: ");
                    string input =Console.ReadLine();
                    
                    if (int.TryParse(input, out horas))
                    {
                        if (horas < 0)
                        {
                            Console.WriteLine("Valor invalido!");
                            continue;
                        }
                        break;
                    }
                    else 
                    {
                        Console.WriteLine("Digite um valor valido!");
                    }
                   
        
                }    
                valorTotal = precoInicial + precoPorHora * horas;
                veiculos.Remove(removerCarro);

                Console.WriteLine($"O veículo {removerCarro} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
            var registro = registros.FirstOrDefault(r => r.placa == removerCarro.ToUpper());
            if (registro != null)
            {
                registro.saida = DateTime.Now;
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
            
                for(int i = 0; i < veiculos.Count; i++)
                {
                    Console.WriteLine($"{veiculos[i]}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
        public void listaTotalDia()
        {
            
        }
    }
}
