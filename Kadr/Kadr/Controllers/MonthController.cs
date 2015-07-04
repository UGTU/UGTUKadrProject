using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Kadr.Controllers
{
        
    class MonthController
    {
        private const int LastMonth = 12, FirstMonth = 1;

        private static MonthController instance;

        private MonthController() 
        {
        }


        /// <summary>
        /// Получает единственный экземпляр контроллера
        /// </summary>
        public static MonthController Instance
        {
            get
            {
                if (instance == null)
                    instance = new MonthController();
                return instance;
            }
        }

        public string GetMonthName(int MonthNumber)
        {
            if ((MonthNumber < FirstMonth) || (MonthNumber > LastMonth))
                return "";

            switch(MonthNumber)
            {
                case 1:
                    return "Январь";
                case 2:
                    return "Февраль";
                case 3:
                    return "Март";
                case 4:
                    return "Апрель";
                case 5:
                    return "Май";
                case 6:
                    return "Июнь";
                case 7:
                    return "Июль";
                case 8:
                    return "Август";
                case 9:
                    return "Сентябрь";
                case 10:
                    return "Октябрь";
                case 11:
                    return "Ноябрь";
                case 12:
                    return "Декабрь";
                default:
                    return "";
            }
        }

        public int GetMonthNumber(string MonthName)
        {
            /*if ((MonthNumber < 1) || (MonthNumber>12))
                throw new ArgumentOutOfRangeException("Месяц табеля.");*/

            switch (MonthName)
            {
                case "Январь":
                    return 1;
                case "Февраль":
                    return 2;
                case "Март":
                    return 3;
                case "Апрель":
                    return 4;
                case "Май":
                    return 5;
                case "Июнь":
                    return 6;
                case "Июль":
                    return 7;
                case "Август":
                    return 8;
                case "Сентябрь":
                    return 9;
                case "Октябрь":
                    return 10;
                case "Ноябрь":
                    return 11;
                case "Декабрь":
                    return 12;
                default:
                    return -1;
            }
        }

        public int GetNextMonth(int CurrentMonth)
        {
            if ((CurrentMonth < FirstMonth) || (CurrentMonth > LastMonth))
                throw new ArgumentOutOfRangeException("Месяц табеля.");

            if (CurrentMonth == LastMonth)
                return FirstMonth;
            else
                return CurrentMonth + 1;
        }

        public int GetNextMonthsYear(int CurrentMonth, int CurrentYear)
        {
            if ((CurrentMonth < FirstMonth) || (CurrentMonth > LastMonth))
                throw new ArgumentOutOfRangeException("Месяц табеля.");

            if (CurrentMonth == LastMonth)
                return CurrentYear + 1;
            else
                return CurrentYear;

        }

        public ArrayList GetMonthsList()
        {
            /*if ((MonthNumber < 1) || (MonthNumber>12))
                throw new ArgumentOutOfRangeException("Месяц табеля.");*/

            ArrayList res = new ArrayList();
            for (int MonthNumber = 1; MonthNumber <= 12; MonthNumber++)
            {
                res.Add(GetMonthName(MonthNumber));
            }
            return res;
        }
    }
}
