using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent
{
    public class Repository
    {
        public void GetListOfCars()
        {
            string text = System.IO.File.ReadAllText("List.txt");
            string[] list = text.Split('\n');
            int NumberOfCars = list.Length;            
            Car[] cars = new Car[NumberOfCars];           
            for (int i = 0; i < NumberOfCars; i++) //весь список машин
            {              
                cars[i].name = list[i];
            }
            cars.Where(Rented => Rented.name.Contains("Rented")); //список свободных машин
                  
        }        
    }
}
