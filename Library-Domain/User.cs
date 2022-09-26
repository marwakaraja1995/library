namespace Library_Domain
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; } 
        public string Password { get; set; }    
        public List<Book> Books { get; set; }   = new List<Book>(); 

    }
}