using System;
using System.CodeDom;
using System.Net.Sockets;

namespace SimpleLibrary
{
    public class Book : IComparable
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string Publisher { get; set; }

        public Book() // First Counstroctor
        {
        }

        public Book(int _id, string _name, string _isbn, string _author, int _year,
            string _publisher) //Second Constructor
        {
            Id = _id;
            Name = _name;
            ISBN = _isbn;
            Author = _author;
            Year = _year;
            Publisher = _publisher;
        }



        //Method

        public override string ToString()
        {
            return (
                $"ID:{this.Id}\nName:{this.Name}\nISBN:{this.ISBN}\nAuthor:{this.Author}\nDate:{this.Year}\nPublisher:{this.Publisher}\n-------------------------"
            );
        }

        public override int GetHashCode()
        {
            return $"{Id}".GetHashCode();
        }

        public int CompareTo(object obj)
        {
            var item = obj as Book;
            if (item != null)
            {
                var idCompare = this.Id.CompareTo(item.Id);
                if (idCompare == 0)
                {
                    return this.ISBN.CompareTo(item.ISBN);
                }
            }

            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            var item = obj as Book;
            if (item == null)
                return false;
            return this.Id == item.Id;
        }
    }
}