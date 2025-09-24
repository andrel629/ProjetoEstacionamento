using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace AndPar.Common
{
    public class Parking
    {
        public double StartingPrice { get; set; }
        public double PricePerHour { get; set; }
        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

        public void AddVehicle()
        {
            Console.WriteLine("Digite a placa do veiculo: ");
            string? Plate = Console.ReadLine();

            if (Plate == "")
            {
                Console.WriteLine("Placa invalida");

            }
            else
            {
                DateTime StartTime = DateTime.Now;

                Vehicles.Add(new Vehicle { Plate = Plate, Staus = true, StartTime = StartTime, debt = StartingPrice, EndTime=StartTime });
                Console.WriteLine($"Veiculo {Plate} adicionado com sucesso");
            };
      
        }

        public void RemoveVehicle(List<Vehicle> vehicles,Parking Park)
        {
            Console.WriteLine($"Digite o veiculo a ser returado");
            string? Plate = Console.ReadLine();

            if (Plate != "")
            {
                DateTime InLive = DateTime.Now;
                int InLiveInt = InLive.TimeOfDay.Hours * 60 + InLive.TimeOfDay.Minutes;

                foreach (Vehicle Current in Vehicles)
                {
                    if (Plate == Current.Plate)
                    {
                        Current.EndTime = InLive;
                        Current.debt = Park.StartingPrice + Park.PricePerHour*(InLiveInt/60 - (Current.StartTime.TimeOfDay.Hours * 60 + Current.StartTime.TimeOfDay.Minutes)/60);
                        Console.WriteLine($" O carro {Current.Plate} deve pagar {Current.debt} ");
                        Vehicles.Remove(Current);
                        Console.WriteLine($" O carro {Current.Plate} Foi removido");
                        break;
                    }
                }
             }
            
        }

        public void ListVehicles()
        {
            DateTime InLive = DateTime.Now;

            int InLiveInt = InLive.TimeOfDay.Hours * 60 + InLive.TimeOfDay.Minutes;


            if (Vehicles.Count != 0)
            {

                foreach (Vehicle Current in Vehicles)
                {

                    int TimeTriveled = InLiveInt - (Current.StartTime.TimeOfDay.Hours * 60 + Current.StartTime.TimeOfDay.Minutes);
                    Current.debt = StartingPrice + PricePerHour * (TimeTriveled / 60);

                    if (Current.Staus)
                    {
                        Console.WriteLine($"Placa:{Current.Plate}, Valor a pagar R$;{Current.debt} > Entrada:{Current.StartTime} /Agora:{InLive}");
                    };

                };
            }
            else
            {
                Console.WriteLine("Não há veiculos no estacionamento.");
            };
        }


    };   
};