using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hwless7
{
    class Program
    {
        static byte choose()
        {
            Console.WriteLine($"Выберите действие:\n1 - загрузить ежедневник;\n2 - посмотреть ежедневник;\n3 - добавить запись;\n4 - редактировать запись;" +
                              $"\n5 - удалить запись;\n6 - выгрузить ежедневник;\n7 - сортировать по выбранному полю\n8 - выйти");
            byte action = Convert.ToByte(Console.ReadLine());
            byte answer = 7;
            switch (action)
            {
                case 1:
                    {
                        Console.WriteLine("Вы выбрали загрузить ежедневник");
                        answer = 1;
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Вы выбрали посмотреть ежедневник");
                        answer = 2;
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Вы выбрали добавить запись");
                        answer = 3;
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Вы выбрали редактировать запись");
                        answer = 4;
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Вы выбрали удалить запись");
                        answer = 5;
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Вы выбрали выгрузить ежедневник");
                        answer = 6;
                        break;
                    }
                case 7:
                    {
                        Console.WriteLine("Вы выбрали упорядочить по выбранному полю");
                        break;
                    }
                case 8:
                    {
                        Console.WriteLine("Вы выбрали выйти");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Выбранного вами действия не существует!");
                        break;
                    }
            }
            return answer;

        }
        static void Main(string[] args)
        {
            int result;
            string path = "MyPlanner.txt";
            planner myPlanner = new planner(path);
            

            do
            {
                
                switch (result = choose())
                {
                    case 1:
                        {
                            myPlanner.getPlanner();
                            break;
                        }
                    case 2:
                        {
                            myPlanner.printPlanner();                            
                            break;
                        }
                    case 3:
                        {
                            myPlanner.newRecord();
                            break;
                        }
                    case 4:
                        {
                            myPlanner.modifyRecord();
                            break;
                        }
                    case 5:
                        {
                            myPlanner.RemoveRecord();
                            break;
                        }
                    case 6:
                        {
                            myPlanner.exoprtPlanner();
                            break;
                        }
                    case 7:
                        {
                            myPlanner.OrderByField();
                            break;
                        }
                }


            } while (result != 8);
            
            Console.ReadLine();
            
           
        }
    }
}
/// Разработать ежедневник.
/// В ежедневнике реализовать возможность 
/// - создания
/// - удаления
/// - реактирования 
/// записей
/// 
/// В отдельной записи должно быть не менее пяти полей
/// 
/// Реализовать возможность 
/// - Загрузки даннах из файла
/// - Выгрузки даннах в файл
/// - Добавления данных в текущий ежедневник из выбранного файла
/// - Импорт записей по выбранному диапазону дат
/// - Упорядочивания записей ежедневника по выбранному полю