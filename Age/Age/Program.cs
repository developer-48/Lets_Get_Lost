using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Age
{
    class Program
    {
        static int Year(int year, int month)
        {
            switch(month)
            {
                case 1: return 31;
                case 2:
                    {
                        if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
                        {
                            return 29;
                        }
                        else return 28;
                    }
                case 3: return 31;
                case 4: return 30;
                case 5: return 31;
                case 6: return 30;
                case 7: return 31;
                case 8: return 31;
                case 9: return 30;
                case 10: return 31;
                case 11: return 30;
                case 12: return 31;
                default: return 0;
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Введите ФИО: ");
            string name = Console.ReadLine();
            Console.Write("Введите дату своего рождения(дд.мм.гггг): ");            
            string str = Console.ReadLine();
            Console.Write("Введите время своего рождения(чч:мм): ");
            string time = Console.ReadLine();
            int hour = int.Parse(time.Remove(2));
            int minutes = int.Parse(time.Remove(0, 3));
            string happydate = str; 
            str = str.Replace(".", "");            
            int day = 0, day2 = 0, resultday = 0;
            int month = 0, month2 = 0, resultmonth = 0;
            int year = 0, year2 = 0, resultyear = 0;
            int resultweek = 0;           
            day = int.Parse(str.Remove(2));            
            month = int.Parse(str.Remove(4).Remove(0, 2));            
            year = int.Parse(str.Remove(0, 4));
            string str2 = DateTime.Now.ToString();
            str2 = str2.Replace(".", "");
            str2 = str2.Remove(8);
            day2 = int.Parse(str2.Remove(2));            
            month2 = int.Parse(str2.Remove(4).Remove(0, 2));            
            year2 = int.Parse(str2.Remove(0, 4));
            resultyear = year2 - year-1;
            string time2 = DateTime.Now.ToString();
            time2 = time2.Remove(0, 11);
            time2 = time2.Remove(5);
            if (time2.Length < 5) time2.Insert(0, "0");
            int hour2 = int.Parse(time2.Remove(2));
            int minutes2 = int.Parse(time2.Remove(0, 3));
            int resulthour = 24 - hour + hour2;            
            int resultminutes = (24 * 60 - (hour * 60 + minutes) + hour2 * 60 + minutes2) % 60;
            if (minutes + minutes2 >= 60) resulthour++;
            if (year == year2)
            {
                for (int i = month; i <= month2; i++)
                {
                    if (i == month) resultday += Year(year, i) - day;
                    else
                    {
                        resultday += Year(year, i);
                        resultmonth++;
                    }
                }
            }
            else
            {
                resultday += Year(year, month) - day;
                for (int i = month+1; i <= 12; i++)
                {
                    resultday += Year(year, i);
                    resultmonth++;
                }
                resultday += day2;
                for (int i = 1; i < month2; i++)
                {
                    resultday += Year(year2, i);
                    resultmonth++;
                }
                for (int i = year+1; i < year2; i++)
                {
                    for (int j = 1; j <= 12; j++)
                    {
                        resultday += Year(i, j);
                        resultmonth++;
                    }
                }
            }           
            if (day2 >= day && month2 >= month)
            {
                resultmonth++;
                resultyear++;
            }            
            resultweek = resultday / 7;
            resulthour += (resultday-2) * 24;
            resultminutes += resulthour * 60;
            Console.WriteLine($"Вы: {name}.\nВы родились {happydate} в {time} \nВы прожили: \nВ годах: {resultyear}; \nВ месяцах: {resultmonth}; \nВ неделях: {resultweek}; \nВ днях: {resultday} \nВ часах: {resulthour}; \nВ минутах: {resultminutes}; \nВ секундах {resultminutes * 60}.");
        }
    }
}
