using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CarRent
{
    public class Service 
    { //сервис для взаимодействия пользователя с журналом и выполняющий основные действия программы
        
        IRepository rep;        
        public Service(IRepository r1)
        {
            rep = r1;
        }         
        public string RentCar(int id, DateTime SelectedDate1, DateTime SelectedDate2)
        { //метод создает текст об успешном бронировании авто для вывода в диалоговое окно
            List<Car> AvailableCars = new List<Car>(); //коллекция доступных автомобилей
            AvailableCars = rep.GetListOfAvailableCars(SelectedDate1, SelectedDate2);
            string TextForRenting = AvailableCars[id].name + " Rented";            
            return TextForRenting;
        }
        public List<Car> PrintAvailableCars(DateTime SelectedDate1, DateTime SelectedDate2)
        { //метод получающий список доступных автомобилей из журнала
            return rep.GetListOfAvailableCars(SelectedDate1, SelectedDate2);
        }
        public void MakeNoteForRepository(string SelectedCar, string UserName, DateTime SelectedDate1, DateTime SelectedDate2)
        { //метод, создающий запись в журнале о бронировании авто
            StreamWriter sw = new StreamWriter("List.txt");
            string[] list = rep.GetListForSW();
            foreach (var item in list)
            {
                if (item.Contains(SelectedCar))
                { //формирование записи
                    sw.WriteLine(item + "\r\n" + SelectedCar + " /" + " Rented " + "by " + UserName + ";" + SelectedDate1 + "-" + SelectedDate2);
                }
                else
                {
                    sw.WriteLine(item);
                }

            }
            
            sw.Close();            
        }
        public List<Car> PrintMyRents(string UserName)
        { //метод, получающий список броней определенного пользователя из журнала
            return rep.GetListOfMyRents(UserName);
        }
        public void DeleteRent(string UserName, string SelectedCar)
        { //метод, удаляющий запись в журнале
            StreamWriter sw = new StreamWriter("List.txt");
            string[] list = rep.GetListForSW();
            foreach (var item in list)
            {
                if (item.Contains(UserName) && item.Contains(SelectedCar))
                {
                    
                }
                else
                {
                    sw.WriteLine(item);
                }
            }
            sw.Close();
        }
    }
}
