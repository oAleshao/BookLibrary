using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;
using static System.Reflection.Metadata.BlobBuilder;


// Создайте приложение для учёта книг. Необходимо хранить следующую информацию:

// Название книги
// ФИО автора
// Жанр книги
// Год выпуска

//Для хранения книг используйте класс LinkedList<T>.

//Приложение должно предоставлять такую функциональность:

// Добавление книг (по одной, массивом, списком)
// Вывод всего списка книг
// Вывод книги по номеру в списке
// Удаление книг
// Изменение информации о книгах (через индекс)
// Поиск книг по параметрам
// Вставка книги в начало списка
// Вставка книги в конец списка
// Вставка книги в определенную позицию
// Удаление книги из начала списка
// Удаление книги из конца списка
// Удаление книги из определенной позиции


// Создать меню/подменю пользователя

namespace all
{

    [DataContract]
    public class Book
    {
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Author { get; set; }
        [DataMember]
        public string Ganre { get; set; }
        [DataMember]
        public int date { get; set; }

        public Book() { }
        public Book(string title, string author, string ganre, int date)
        {
            this.Title = title;
            this.Author = author;
            this.Ganre = ganre;
            this.date = date;
        }

        public void Output()
        {
            Console.WriteLine($"----- {Title} -----");
            Console.WriteLine($"\t\t  Author: '{Author}'");
            Console.WriteLine($"\t\t  Ganre: '{Ganre}'");
            Console.WriteLine($"\t\t  Year: '{date}'\n");
        }

        public void Set()
        {
            Console.WriteLine("\n====== Добавить книгу =======");
            Console.Write("Введите название книги: ");
            Title = Console.ReadLine();
            Console.Write("Введите автора: ");
            Author = Console.ReadLine();
            Console.Write("Введите жанр: ");
            Ganre = Console.ReadLine();
            Console.Write("Введите год выпуска: ");
            date = int.Parse(Console.ReadLine());
        }


    }


    [DataContract]
    public class Library
    {
        [DataMember]
        private LinkedList<Book> books;
        public LinkedList<Book> Books
        {
            get { return books; }
            set { books = value; }
        }

        public Library()
        {
            books = new LinkedList<Book>();
        }
        public Library(LinkedList<Book> books)
        {
            Books = books;
            Books = books;
        }


        // Вывод полной книги
        public void OutputFull()
        {
            int number = 1;
            foreach (var item in books)
            {
                Console.Write("Книга #" + number + "\t");
                item.Output();
                number++;
            }
        }


        // Вывод только названия книги
        public void OutputCut()
        {
            int number = 1;
            foreach (var item in books)
            {
                Console.Write("Книга #" + number + "\t" + item.Title + "\n");
                number++;
            }
        }


        public void OutputBook()
        {
            Console.Write("Введите номер книги которую хотите просмотреть: ");
            int indx = Convert.ToInt32(Console.ReadLine());
            int help = 1;
            foreach (var item in books)
            {
                if (help == indx) 
                {
                    Console.Write("\t\t");
                    item.Output();
                    return;
                }
                help++;
            }
            Console.WriteLine("Книги с таким индексом нету");
        }

        // Добавляем книгу в начало
        public void AddFirst(Book book)
        {
            books.AddFirst(book);
        }


        // Добавляем книгу в конец
        public void AddLast(Book book)
        {
            books.AddLast(book);
        }


        // Добавляем книгу по индексу
        public void AddOnIndex(Book book)
        {
            this.OutputCut();
            Console.Write("Введите индекс книги: ");
            int indx = Convert.ToInt32(Console.ReadLine());
            LinkedList<Book> list = new LinkedList<Book>();
            int i = 0;
            foreach (var item in books)
            {
                if (i == indx - 1) list.AddLast(book);
                list.AddLast(item);
                i++;
            }
            books = list;
        }


        // Добавляем массив в начало
        public void AddFirstArr(Book[] ArrayBooks)
        {
            LinkedList<Book> list = new LinkedList<Book>();
            for (int i = 0; i < ArrayBooks.Length + 1; i++)
            {
                if (i == ArrayBooks.Length)
                {
                    foreach (var item in books)
                        list.AddLast(item);
                    continue;
                }
                list.AddLast(ArrayBooks[i]);
            }
            books = list;
        }


        // Добавляем массив в конец
        public void AddLastArr(Book[] ArrayBooks)
        {
            foreach (var item in ArrayBooks)
            {
                books.AddLast(item);
            }
        }


        // Добавляем по индексу массив
        public void AddAfterArr(Book[] ArrayBooks)
        {
            this.OutputCut();
            LinkedList<Book> list = new LinkedList<Book>();
            Console.Write("Введите индекс книги: ");
            int indx = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            foreach (var item in books)
            {
                if (i == indx - 1)
                {
                    foreach (var book in ArrayBooks)
                        list.AddLast(book);
                }
                list.AddLast(item);
                i++;
            }
            books = list;
        }


        // Добавляем в начало список
        public void AddFirstList(List<Book> ListBooks)
        {
            LinkedList<Book> list = new LinkedList<Book>();
            foreach (var item in ListBooks)
            {
                list.AddLast(item);
            }
            foreach (var item in books)
            {
                list.AddLast(item);
            }
            books = list;
        }


        // Добавляем в конец список
        public void AddLastList(List<Book> ListBooks)
        {

            foreach (var item in ListBooks)
            {
                books.AddLast(item);
            }
        }


        // Добавляем по индексу список
        public void AddAfterList(List<Book> ListBooks)
        {
            this.OutputCut();
            LinkedList<Book> list = new LinkedList<Book>();
            Console.Write("Введите индекс книги: ");
            int indx = Convert.ToInt32(Console.ReadLine());
            int i = 0;
            foreach (var item in books)
            {
                if (i == indx - 1)
                {
                    foreach (var book in ListBooks)
                        list.AddLast(book);
                }
                list.AddLast(item);
                i++;
            }
            books = list;
        }


        // Удалить первую книгу
        public void RemoveFirst()
        {
            books.RemoveFirst();
        }


        // Удалить последнюю книгу
        public void RemoveLast()
        {
            books.RemoveLast();
        }


        // Удалить книгу по индексу
        public void RemoveInOndex()
        {
            this.OutputCut();
            Console.Write("Введите номер книги которую хотите удалить: ");
            int indx = Convert.ToInt32(Console.ReadLine());
            LinkedListNode<Book> node = books.First;
            for (int i = 1; i < indx; i++)
            {
                node = node.Next;
            }
            books.Remove(node);
        }


        // Изминение данных в книге
        public void ChangeData()
        {
            this.OutputCut();
            Console.Write("Введите номер книги которую хотите : ");
            int indx = Convert.ToInt32(Console.ReadLine());
            int help = 1;
            Book book = null;
            foreach (var item in books)
            {
                if(help == indx)
                {
                    book = item;
                    break;
                }
                help++;
            }
            if(book == null)
            {
                Console.WriteLine("Книги с таким номером в списке нету");
                return;
            }
            string temp;
            Console.WriteLine("нажмите Enter, если не хотите изменять данные");
            Console.Write("Введите новое название: ");
            temp = Console.ReadLine();
            if (temp != "") book.Title = temp;
            Console.Write("Введите нового автора: ");
            temp = Console.ReadLine();
            if (temp != "") book.Author = temp;
            Console.Write("Введите новый жанр: ");
            temp = Console.ReadLine();
            if (temp != "") book.Ganre = temp;
            Console.Write("Введите новый год выпуска: ");
            temp = Console.ReadLine();
            if (temp != "") book.date = int.Parse(temp);
        }

        public void Search((string? title, string? author, string? ganre, int? year) book)
        {
            var search = books.Where(x =>
            {
                return x.Title == (book.title ?? x.Title) &&
                 x.Author == (book.author ?? x.Author) &&
                 x.Ganre == (book.ganre ?? x.Ganre) &&
                 x.date == (book.year ?? x.date);
            });
            foreach (var item in search)
            {
                Console.Write("\t\t\t");
                item.Output();
            }
        }
    }




    internal class Program
    {
        // Узнаем откуда и куда будем добавлять/удалять 
        static int HowAddOrDel(bool temp)
        {
            if (temp) Console.WriteLine("Добавить:");
            else Console.WriteLine("Удалить");
            Console.WriteLine("1) начало");
            Console.WriteLine("2) конец");
            Console.WriteLine("3) по индексу");
            Console.Write("Выберите действие: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            if (choice != 1 && choice != 2 && choice != 3) choice = 1;
            return choice;

        }

        static (string? title, string? author, string? ganre, int? year) Filter()
        {
            string? title = null;
            string? author = null;
            string? ganre = null;
            int? year = null;
            string? temp;
            Console.WriteLine("\tПоиск книг\n   Enter - пропустить поле");
            Console.Write("\tВведите название: ");
            temp = Console.ReadLine();
            if (temp != "") title = temp;

            Console.Write("\tВведите автора: ");
            temp = Console.ReadLine();
            if(temp != "") author = temp;

            Console.Write("\tВведите жанр: ");
            temp = Console.ReadLine();
            if(temp != "") ganre = temp;

            Console.Write("\tВведите год выпуска: ");
            int help;
            int.TryParse(Console.ReadLine(), out help);
            if(help != 0) year = help;

            return (title, author, ganre, year);
        }


        static void Main(string[] args)
        {
            FileStream file;
            DataContractJsonSerializer json;
            Library library = new Library();
            library.AddLast(new Book("Programing C#", "Jim Karter", "Programing", 2005));
            library.AddLast(new Book("Любимая", "Морган Райс", "Роман", 2014));
            library.AddLast(new Book("White Fang", "Jack London ", "Tale", 1946));
            bool flag = false;
            int choose = 0;
            do
            {
                if (flag) Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("1) Добавить книгу");
                Console.WriteLine("2) Добавить книги массивом");
                Console.WriteLine("3) Добавить книги списком");
                Console.WriteLine("4) Показать все книги");
                Console.WriteLine("5) Показать книгу за индексом");
                Console.WriteLine("6) Изменить информацию о книге");
                Console.WriteLine("7) Найти книгу");
                Console.WriteLine("8) Удалить книгу");
                Console.WriteLine("9) Внести в базу");
                Console.WriteLine("10) Записать из базы");
                Console.WriteLine("0) Выход");
                Console.ForegroundColor = ConsoleColor.White;
                try
                {
                    Console.Write("Выберите действие: ");
                    choose = int.Parse(Console.ReadLine());
                    switch (choose)
                    {
                        case 0: return;
                        case 1:
                            {
                                Book book = new Book();
                                book.Set();
                                choose = HowAddOrDel(true);
                                if (choose == 1) library.AddFirst(book);
                                else if (choose == 2) library.AddLast(book);
                                else if (choose == 3) library.AddOnIndex(book);
                                break;
                            }
                        case 2:
                            {
                                Console.Write("Введите кол-во книг: ");
                                int count = Convert.ToInt32(Console.ReadLine());
                                Book[] ArrayBooks = new Book[count];
                                for (int i = 0; i < count; i++)
                                {
                                    ArrayBooks[i] = new Book();
                                    ArrayBooks[i].Set();
                                }
                                choose = HowAddOrDel(true);
                                if (choose == 1) library.AddFirstArr(ArrayBooks);
                                else if (choose == 2) library.AddLastArr(ArrayBooks);
                                else if (choose == 3) library.AddAfterArr(ArrayBooks);
                                break;
                            }
                        case 3:
                            {
                                Console.Write("Введите кол-во книг: ");
                                int count = Convert.ToInt32(Console.ReadLine());
                                List<Book> list = new List<Book>();
                                for (int i = 0; i < count; i++)
                                {
                                    Book book = new Book();
                                    book.Set();
                                    list.Add(book);
                                }
                                choose = HowAddOrDel(true);
                                if (choose == 1) library.AddFirstList(list);
                                else if (choose == 2) library.AddLastList(list);
                                else if (choose == 3) library.AddAfterList(list);
                                break;
                            }
                        case 4:
                            {
                                library.OutputFull();
                                break;
                            }
                        case 5:
                            {
                                library.OutputBook();
                                break;
                            }
                        case 6:
                            {
                                library.ChangeData();
                                break;
                            }
                        case 7:
                            {
                                library.Search(Filter());
                                break;
                            }
                        case 8:
                            {
                                choose = HowAddOrDel(false);
                                if (choose == 1) library.RemoveFirst();
                                else if (choose == 2) library.RemoveLast();
                                else if (choose == 3) library.RemoveInOndex();
                                break;
                            }
                        case 9:
                            {
                                file = new FileStream("books.json", FileMode.Create);
                                json = new DataContractJsonSerializer(typeof(Library));
                                json.WriteObject(file, library);
                                file.Close();
                                break;
                            }
                        case 10:
                            {
                                try
                                {
                                    file = new FileStream("books.json", FileMode.Open);
                                    json = new DataContractJsonSerializer(typeof(Library));
                                    library = (Library)json.ReadObject(file);
                                    file.Close();
                                }
                                catch(Exception ex)
                                {
                                    Console.WriteLine("Не удалось обратится к базе или она в данный момент не доступна");
                                }
                                break;
                            }
                    }
                }
                catch (Exception ex) { Console.Clear(); }
                Console.Write("Нажмите любую клавишу..."); Console.ReadLine();
                flag = true;

            } while (choose != 0) ;
        }



       
    }
}