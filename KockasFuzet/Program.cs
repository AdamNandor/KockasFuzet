using KockasFuzet.Controllers;
using KockasFuzet.Models;
using KockasFuzet.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KockasFuzet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool kilep = false;
            while (!kilep)
            {
                Console.Clear();
                Console.WriteLine("1. Adott szolgáltató kiírása");
                Console.WriteLine("2. Szolgáltatók kiírása");
                Console.WriteLine("3. Szolgáltató felvitele");
                Console.WriteLine("4. Számla felvitele");
                Console.WriteLine("5. Számla módosítása");
                Console.WriteLine("6. Számla törlése");
                Console.WriteLine("7. Kilépés");
                string valasz = Console.ReadLine();

                switch (valasz)
                {
                    case "1":
                        Szolgaltato probaSzolgaltato = new Szolgaltato()
                        {
                            RovidNev = "ABC",
                            Nev = "Helyi kis abc",
                            Ugyfelszolgalat = "Miskolc, Kamra köz 3"
                        };
                        new SzolgaltatoView().ShowSzolgaltato(probaSzolgaltato);
                        break;
                    case "2":
                        List<Szolgaltato> listaAdatbazisbol = new SzolgaltatoController().GetSzolgaltatoList();
                        new SzolgaltatoView().ShowSzolgaltatoList(listaAdatbazisbol);
                        Console.WriteLine("Nyomj meg egy gombot a visszatéréshez...");
                        Console.ReadKey();
                        break;
                    case "3":
                        new SzolgaltatoView().CreateView();
                        break;
                    case "4":
                        new SzamlaView().CreateSzamlaView();
                        break;
                    case "5":
                        Szamla szamla = new Szamla();

                        szamla.Id = int.Parse(Console.ReadLine());

                        string eredmeny = new SzamlaController().UpdateSzamla(szamla);
                        Console.WriteLine(eredmeny);
                        break;
                    case "6":
                        Console.WriteLine("Adja meg az azonosítót:");
                        int id = int.Parse(Console.ReadLine());
                        new SzamlaController().DeleteSzamla(id);
                        break;
                    case "7":
                        kilep = true;
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
