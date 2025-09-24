using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AndPar.Common
{
    public class Menu
    {
        public string? Option { get; set; }

        public void CreateMenu(Parking Park)
        {
            Console.WriteLine($"Digite o valor correspondente : " +
            "\n 1)Cadrastrar veículo " +
            "\n 2)Remover veículo " +
            "\n 3)Listar veículo " +
            "\n 4)Encerrar");
            Option = Console.ReadLine();
            this.SelectOption(this.Option,Park);

        }
        public void SelectOption(string? Option,Parking Park)
        {
            switch (Option)
            {
                case "1":
                    {
                        Park.AddVehicle();
                        break;
                    }
                case "2":
                    {
                        Park.RemoveVehicle(Park.Vehicles,Park);
                        break;
                    }
                case "3":
                    {
                        Park.ListVehicles();
                        break;
                    }
                case "4":
                    {
                        Environment.Exit(0);
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("!INVALID");
                        break;
                    }
            }
            this.CreateMenu(Park);
        }

    }
}