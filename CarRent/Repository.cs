using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CarRent
{
    public class Repository : IRepository
    { //журнал, в котором находятся все записи об арендах и методы работы с ним
        List<Car> Cars = new List<Car>();
        List<Car> DistinctCars = new List<Car>();
        string text = System.IO.File.ReadAllText("List.txt"); //получение записей из файла  
        public List<Car> GetListOfAvailableCars(DateTime SelectedDate1, DateTime SelectedDate2) 
        {          //метод создает список доступных автомобилей на выбранный промежуток дат для последующего вывода на экран
            
            string[] list = text.Split('\n');     
            foreach (var item in list)
            {
                if (!(item.Contains("Rented")))
                { //если данный автомобиль не имеет записей о бронировании совсем, то он добавляется в список, иначе происходит проверка
                    Cars.Add(new Car { name = item });
                }
                else
                { //в данном блоке идёт проверка на пересечение выбранных дат с датами уже имеющейся брони
                    string[] CarData = item.Split(';');
                    string[] CarAndUserName = CarData[0].Split('/');
                    string CarName = CarAndUserName[0];
                    string[] Dates = CarData[1].Split('-'); //получение промежутка дат, забронированного авто
                    DateTime Date1 = DateTime.Parse(Dates[0]);
                    DateTime Date2 = DateTime.Parse(Dates[1]);
                    if (((SelectedDate1 < Date1)&&(SelectedDate2 < Date1)) || ((SelectedDate1 > Date2)&&(SelectedDate2 > Date2)))
                    {
                        Cars.Add(new Car { name = CarName });
                    }
                }           
            }
            foreach (var item in Cars)
            { //здесь я пытался выпилить из названия тачки \r, который мешает мне жить
                item.name = item.name.Trim('\r');
            }
            IEnumerable<Car> distinctCars = Cars.Distinct(); //здесь я из списка удаляю повторяющиеся тачки т.к. записей на каждую тачку несколько, а тачка одна            
            DistinctCars = distinctCars.ToList();
            return DistinctCars;
        }
        public List<Car> GetListOfMyRents(string UserName)
        { //метод получает список броней для введенного имени пользователя
            List<Car> MyRents = new List<Car>();
            string[] list = text.Split('\n');
            foreach (var item in list)
            {
                if (item.Contains(UserName))
                {
                    MyRents.Add(new Car { name = item });
                }                
            }
            return MyRents;
        }
        public string[] GetListForSW()
        { //метод разбивает текст из файла на отдельные записи для последующей обработки
            string[] list = text.Split('\n');
            return list;
        }        
    }
}
