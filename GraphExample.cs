using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

/*********
Spēlētājam ir 1000 sākuma fuel.

Tad, kad spēlētājs aizbrauc uz kādu planētu, tad tiek 
iztērēts benzīns ar formulu (Distance * 0.8)

Katrai planētai ir distance, kas abos virzienos ir vienāda 
(Šeit var hardkodēt gan turp Vertice, gan atpakaļ 
Vertice Distance)

Tad, kad benzīns ir tukšs, tad spēlētājam beidzas spēle
un tas tiek paziņots.

Papildus 3 cepumus var iegūt uzprogrammējot to, 
ka spēles beigās paziņo spēlētāja veikto ceļu, 
kur spēlētājs bijis. (Padomājiet, kāda datu struktūra šeit der)
**********/

namespace DataStructures
{
    public class Node
    {
        public string Name { get; set; }
        public List<Vertices> Vertices { get; set; }
    }

    public class Vertices
    {

        public Node StartNode { get; set; }
        public Node EndNode { get; set; }
        public int Distance { get; set; }
    }

    public class GraphExample
    {
        
        private Node CurrentPlanet { get; set; }
        private Node Planet1 = new Node() { Name = "ZULU" };
        private Node Planet2 = new Node() { Name = "KILO" };
        private Node Planet3 = new Node() { Name = "DELTA" };
        private Node Planet4 = new Node() { Name = "ECHO" };

        public bool GameOver = false;
        private int Fuel { get; set; } = 1000;
        private int TravelledDistance { get; set; } = 0;
        private List<Node> Journey { get; set; } = new List<Node>();

        public GraphExample()
        {
            Planet1.Vertices = new List<Vertices>() {
                new Vertices()
                {
                    StartNode = Planet1,
                    EndNode = Planet2,
                    Distance = 300,
                },
                new Vertices()
                {
                    StartNode= Planet1,
                    EndNode = Planet3,
                    Distance = 500,
                },
            };

            Planet2.Vertices = new List<Vertices>() {
                new Vertices()
                {
                    StartNode = Planet2,
                    EndNode = Planet3,
                    Distance = 200,
                },
                new Vertices()
                {
                    StartNode= Planet2,
                    EndNode = Planet1,
                    Distance = 300,
                },
            };

            Planet3.Vertices = new List<Vertices>() {
                new Vertices()
                {
                    StartNode = Planet3,
                    EndNode = Planet2,
                    Distance = 200,
                },
                new Vertices()
                {
                    StartNode = Planet3,
                    EndNode = Planet1,
                    Distance = 500,
                },
                new Vertices()
                {
                    StartNode = Planet3,
                    EndNode = Planet4,
                    Distance = 150,
                },
            };
            Planet4.Vertices = new List<Vertices>() {
                new Vertices()
                {
                    StartNode= Planet4,
                    EndNode = Planet3,
                    Distance = 150,
                },
            };
        }

        public void StartGame()
        {
            CurrentPlanet = Planet1;
            Journey.Add(CurrentPlanet);
            Console.WriteLine($"Hei, tu atrodies uz {CurrentPlanet.Name}!");
            Console.WriteLine($"Tev ir {Fuel} benzīna kannas. Katra gaismas gada pārvarēšana patērē 0,8 kannas benzīna...");
            Console.WriteLine();
        }

        public void GetDestinations()
        {
            

            Console.WriteLine("Tev pieejamās planētas: ");
            var j = 97;
            foreach (var vertice in CurrentPlanet.Vertices)
            {
                Console.WriteLine("     " + (char)j + ") " + vertice.Distance + " gaismas gadi ==> " + vertice.EndNode.Name);
                j++;
            }
            Console.WriteLine();
            Console.Write("Kur lidosi? ");
        }

        public void GoTo(string v)
        {
            Console.WriteLine();
            Vertices selectedVertice = CurrentPlanet.Vertices
                .FirstOrDefault(x => x.EndNode.Name == v);

            if (selectedVertice != null)
            {
                int fuelNeeded = (int)(selectedVertice.Distance * 0.8);
                if (Fuel >= fuelNeeded)
                {
                    Fuel -= fuelNeeded;
                    CurrentPlanet = selectedVertice.EndNode;
                    Journey.Add(CurrentPlanet);
                    TravelledDistance += selectedVertice.Distance;

                    Console.WriteLine($"Aizbrauci uz {CurrentPlanet.Name}. Atlikušais benzīns: {Fuel}");
                    if (Fuel == 0) { EndGame(); }
                }
                else
                {
                    EndGame();
                }
            }
            else
            {
                Console.WriteLine("NEDERĪGA IZVĒLE");
            }
        }

        private void EndGame()
        {
            GameOver = true;
            Console.WriteLine($"Spēle beigusies! Tev ir beidzies benzīns un tu esi iesprūdis uz planētas {CurrentPlanet.Name}!");
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Tu kopumā nolidoji {TravelledDistance} gaismas gadus. Iespaidīgi! ");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("Tava ceļojuma vēsture:");
            var i = 1;
            foreach (var planet in Journey)
            {
                Console.WriteLine($" {i}) {planet.Name}");
                i++;
            }
            Console.WriteLine("---------------------------------------------------");

        }
    }
}