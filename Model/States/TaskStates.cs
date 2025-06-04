using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Domain;

namespace Model.States
{
    public enum TaskStates
    {
        // Явно укажем числа для удобства
        Назначена = 0,
        Выполняется = 1,
        Приостановлена = 2,
        Завершена = 3
    }
}
