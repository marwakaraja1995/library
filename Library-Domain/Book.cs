using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }    
        public double Price { get; set; }   
        public int Count { get; set; }   = 0;
        public List<User> Users { get; set; }= new List<User>();    
    }
}
