using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hwless7
{
    struct planner
    {
        private record [] records;//массив для хранения данных
        int index;//количество элементов в массиве records
        string path;//путь к файлу
        
        //Конструктор ежедневника
        public planner(string path)
        {
            this.index = 0;
            this.records = new record[1];
            this.path = path;
        }

        /// <summary>
        /// Метод для просмотра ежедневника
        /// </summary>
        public void printPlanner()
        {
            foreach (record elem in this.records)
            {
                printRecord(elem);
            }
        }
        /// <summary>
        /// Метод для создания новой записи
        /// </summary>
        public void newRecord()
        {
            
            Console.WriteLine("Введите номер задачи:");
            int numberTask = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите описание задачи:");
            string Task = Console.ReadLine();

            Console.WriteLine("Введите срок исполнения в днях:");
            int dayTask = Convert.ToInt32(Console.ReadLine());

            record newRecord = new record(numberTask,Task,dayTask);

            addRecord(newRecord);
            
            Console.WriteLine("Ваша задача:");
            printRecord(newRecord);
            Console.WriteLine();
        }

        /// <summary>
        /// Метод для изменения размера массива records
        /// </summary>
        private void Resize(bool flag)
        {
            if (flag)
            {
                Array.Resize(ref records, this.records.Length * 2);
            }
            
        }

        /// <summary>
        /// Метод для добавления новой записи в массив записей
        /// </summary>
        /// <param name="newRecord"></param>
        private void addRecord(record newRecord)
        {
            this.Resize(index >= this.records.Length);
            this.records[index] = newRecord;
            index++;
        }

        /// <summary>
        /// Метод для вывода в консоль элементов records
        /// </summary>
        /// <param name="currentRecord">Передаем текущую запись</param>
        public void printRecord(record currentRecord)
        {
            Console.WriteLine("{0} {1} {2} {3} {4}",
                               currentRecord.Number,
                               currentRecord.RecordDateTime,
                               currentRecord.Message,
                               currentRecord.DoneDateTime,
                               currentRecord.Done);
        }

        /// <summary>
        /// Метод для выгрузки ежедневника
        /// </summary>
        public void exoprtPlanner()
        {
            File.Delete(path);
            using (StreamWriter sw = new StreamWriter("MyPlanner.txt"))
            {
                foreach (record elem in this.records)
                    sw.WriteLine("{0}, {1}, {2}, {3}, {4}",
                               elem.Number,
                               elem.RecordDateTime,
                               elem.Message,
                               elem.DoneDateTime,
                               elem.Done);
            }
            Console.WriteLine($"Экспорт ежедневника выполнен\n");
            
        }
        /// <summary>
        /// метод для вычисления срока исполнения в днях (countOfDay)
        /// </summary>
        /// <param name="record">дата записи</param>
        /// <param name="done">дата исполнения</param>
        /// <returns></returns>
        private int countTheDays(DateTime record, DateTime done)
        {
            return Convert.ToInt32((done - record).Days);
        }

        /// <summary>
        /// Метод для загрузки ежедневника
        /// </summary>
        public void getPlanner()
        {
            using (StreamReader sr = new StreamReader(this.path))
            {
                
                while (!sr.EndOfStream)
                {
                    
                    string[] currentPlannerRecord = sr.ReadLine().Split(',');
                    int numb = Convert.ToInt32(currentPlannerRecord[0]);
                    DateTime recordDate = Convert.ToDateTime(currentPlannerRecord[1]);
                    string message = currentPlannerRecord[2];
                    DateTime doneDate = Convert.ToDateTime(currentPlannerRecord[3]);
                    string doneStr = currentPlannerRecord[4];

                    bool done = true;

                    if (currentPlannerRecord[4].Trim().ToLower() == "false")
                    {
                        done = false;
                    }


                    int countOfDays = countTheDays(recordDate, doneDate);
                    
                    addRecord(new record(numb,recordDate,message,countOfDays,doneDate,done));

                }
            }

            foreach(record elem in this.records)
            {
                printRecord(elem);
            }

        }
        /// <summary>
        /// Метод для изменения записи
        /// </summary>
        public void modifyRecord()
        {
            Console.WriteLine("Выберите номер записи для изменения");
            int numberModifyRecord = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите тип изменения:\n1 - поставить отметку о выполнении;\n2 - изменить текст задания;\n3 - изменить срок исполнения");
            byte typeChange = Convert.ToByte(Console.ReadLine());

            switch (typeChange)
            {
                case 1:
                    {
                        for (int i = 0; i < this.records.Length; i++)
                        {
                            if (this.records[i].Number == numberModifyRecord)
                            {
                                this.records[i].Done = true;
                                Console.WriteLine("Отметка о выполнении поставлена!\n");
                                break;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Введите новый текст");
                        string newMessege = Console.ReadLine();
                        for (int i = 0; i < this.records.Length; i++)
                        {
                            if (this.records[i].Number == numberModifyRecord)
                            {
                                this.records[i].Message = newMessege;
                                Console.WriteLine("Текст задания исправлен!\n");
                                break;
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Введите новый срок в днях");
                        int newTime = Convert.ToInt32(Console.ReadLine());
                        for (int i = 0; i < this.records.Length; i++)
                        {
                            if (this.records[i].Number == numberModifyRecord)
                            {
                                this.records[i].CountOfDays = newTime;
                                this.records[i].DoneDateTime = this.records[i].RecordDateTime.AddDays(newTime);
                                Console.WriteLine("Срок исполнения исправлен!\n");
                                break;
                            }
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Вы ввели неверный номер");
                        break;
                    }
            }
        }

        /// <summary>
        /// Метод для удаления записи
        /// </summary>
        public void RemoveRecord()
        {
            
            Console.WriteLine("Введите номер записи для удаления");
            int numberForRemove = Convert.ToInt32(Console.ReadLine());

            

            for (int i = 0; i < this.records.Length; i++)
            {
                if (this.records[i].Number == numberForRemove)
                {
                    for (int j = i; j < this.records.Length - 1; j++)
                    {
                        this.records[j] = this.records[j + 1];
                    }
                    
                    break;
                }

            }                 

            Array.Resize(ref this.records, this.records.Length - 1);
            Console.WriteLine("Запись удалена!");
        }
        
        /// <summary>
        /// Метод для упорядочивания записей по выбранному полю
        /// </summary>
        public void OrderByField()
        {
            Console.WriteLine("Введите номер поля, по которуму будет произведено упорядочивание:\n1 - номер задания;\n2 - дата записи;\n3 - текст;\n4 - дата исполнения;\n5 - отметка о выполнении");
            byte numberChoose = Convert.ToByte(Console.ReadLine());
           
            switch (numberChoose)
            {
                case 1:
                    {
                        this.records = this.records.OrderBy(i => i.Number).ToArray();
                        break;
                    }
                case 2:
                    {
                        this.records = this.records.OrderBy(i => i.RecordDateTime).ToArray();
                        break;
                    }
                case 3:
                    {
                        this.records = this.records.OrderBy(i => i.Message).ToArray();
                        break;
                    }
                case 4:
                    {

                        this.records = this.records.OrderBy(i => i.DoneDateTime).ToArray();
                        break;
                    }
                case 5:
                    {
                        this.records = this.records.OrderBy(i => i.Done).ToArray();
                        break;
                    }
            }

                
        }

    }

}
