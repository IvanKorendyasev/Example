using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRent
{
    public interface IRepository
    { //интерфейс журнала. Создан для возможного обновления программы и изменения алгоритмов его методов
        List<Car> GetListOfAvailableCars(DateTime SelectedDate1, DateTime SelectedDate2);
        List<Car> GetListOfMyRents(string UserName);
        string[] GetListForSW();
    }
}
