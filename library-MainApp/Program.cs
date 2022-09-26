using Library_AccessData;
using Library_Domain;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace library_MainApp
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            using (LibraryDbContext contex = new LibraryDbContext())
            {
                contex.Database.EnsureCreated();

                string contents = File.ReadAllText("default.json");
                var defaultusers = JsonSerializer.Deserialize<List<User>>(contents);

                using (var context = new LibraryDbContext())
                {

                    context.Users.AddRange(defaultusers);
                    context.SaveChanges();

                }
                string file = File.ReadAllText("books.json");
                var defaultbooks = JsonSerializer.Deserialize<List<Book>>(file);

                using (var context = new LibraryDbContext())
                {
                    context.Books.AddRange(defaultbooks);
                    context.SaveChanges();

                }
            }
            Console.Write(" enter username : ");
            string username=Console.ReadLine();
            Console.Write(" enter password : ");
            string password = Console.ReadLine();

           Login( username, password);
        }

        private static void Login(string username, string password)
        {
            using ( var context=new LibraryDbContext())
            {
                var users = context.Users.ToList();
                foreach (var user in users)
                {
                    if (user.UserName == username && user.Password == password)
                    {
                        Console.WriteLine("1:ViewBookDetail \n" +
                                          "2:ViewAllBooks \n" +
                                          "3:Removebook \n" +
                                          "4:ModifyBookData \n ");
                        int x = Convert.ToInt32(Console.ReadLine());

                        switch (x)
                        {
                            case 1: ViewBookDetail();break;
                            case 2: ViewAllBooks();break;
                            case 3: Removebook();break;
                            case 4: ModifyBookData(); break;
                            default: Console.WriteLine(" please choose from options"); break;
                                
                        }
                    }
                    



                }
                    
               
                    
            }
            
        }

        private static void ModifyBookData()
        {
            using (var context = new LibraryDbContext())
            {
                var book = context.Books.FirstOrDefault(b => b.Title == "data mining");
                book.Title = "networks";
                book.Price = 900;
                context.Books.Update(book); 
                context.SaveChanges();
                Console.WriteLine("update operation done");
            }
        }

        private static void Removebook()
        {
            using ( var context=new LibraryDbContext())
            {   var book= context.Books.FirstOrDefault(b =>b.Title == "java");
                context.Books.Remove(book);
                context.SaveChanges();
                Console.WriteLine("remove operation done");
            }
        }

        private static void ViewAllBooks()
        {
            int sum = 0;
            using(var context=new LibraryDbContext())
            { 
                var books = context.Books.ToList();
                context.SaveChanges();
                foreach (var book in books)
                {
                    Console.WriteLine("serialnumber :" + book.Id + "    " +
                                       "book name :" + book.Title + "  " +
                                       "book amount :" + book.Count);
                    sum+=book.Count;
                }
                Console.WriteLine( "all amount of books : "+sum);
            }
            
        }

        private static void ViewBookDetail()
        {
            using( var context=new LibraryDbContext())
            {
                var book = context.Books.FirstOrDefault(b => b.Title == "c++");
                          
                             Console.WriteLine("serialnumber: " + book.Id + "    " +
                                       "book name :" + book.Title + "  " +
                                       "price : "+ book.Price+" "+
                                       "book amount :" + book.Count);
            }

                
        }
    }
}