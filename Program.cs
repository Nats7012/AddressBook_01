using _02_AddressBook.Interfaces;
using _02_AddressBook.Models;
using _02_AddressBook.Services;
using System.Net.Http.Headers;

internal class Program
{
        static void Main ()

        {

            IMenuService menuService = new MenuService();


            do
            {
                Console.Clear();
                Console.WriteLine("---- ADDRESS BOOK ----");
                Console.WriteLine("1. Create new contact");
                Console.WriteLine("2. Show all contacts");
                Console.WriteLine("3. Search for a contact");
                Console.WriteLine("4. Update a contact");
                Console.WriteLine("5. Delete a contact");
                Console.WriteLine("6. Exit application");
                Console.WriteLine(); // Lägger en tom Console.WriteLine så det blir ett mellanrum, för utseendet.
                Console.Write("Choose one option: ");

                var contact = new Contact();

                var option = Console.ReadLine();

                if (string.IsNullOrEmpty(option)) // Användaren måste skriva in nån av valet som står ovanför.
                {
                    Console.WriteLine("You need to choose one option.");
                    Console.ReadKey();
                }
                else
                {
                    switch (option)
                    {
                        case "1":
                            Console.Clear();
                            Console.WriteLine("---- CREATE A NEW CONTACT ----");
                            Console.WriteLine();

                            Console.Write("First name: ");
                            contact.FirstName = Console.ReadLine();

                            Console.Write("Last name: ");
                            contact.LastName = Console.ReadLine();

                            Console.Write("Street name: ");
                            contact.StreetName = Console.ReadLine();

                            Console.Write("Postal code: ");
                            contact.PostalCode = Console.ReadLine();

                            Console.Write("City: ");
                            contact.City = Console.ReadLine();

                            menuService.Create(contact);

                            Console.WriteLine();
                            Console.WriteLine("Contact is now added.");

                            break;

                        case "2":
                            Console.Clear();
                            Console.WriteLine("---- SHOW ALL CONTACTS ----");
                            Console.WriteLine();

                            foreach (var clist in menuService.GetAll()) // clist betyder "contact list" eftersom, contact var redan upptaget.
                            {
                                Console.WriteLine($"Name: {clist.FullName}");
                                Console.WriteLine();
                                Console.WriteLine($"Address: {clist.Address}");
                                Console.WriteLine();
                                Console.WriteLine($"ID nr: {clist.Id}");
                                Console.WriteLine("--------------------------------------------------------------");
                                Console.WriteLine();
                            }
                            Console.ReadKey();

                            break;


                        case "3":
                            Console.Clear();
                            Console.WriteLine("---- SEARCH FOR A CONTACT");
                            Console.WriteLine();
                            Console.Write("Contact ID: ");
                            Console.WriteLine();

                            contact = menuService.Get(Guid.Parse(Console.ReadLine())); //Letar efter kontakten genom ID och skriver sedan ut informationen.

                            Console.WriteLine($"Name: {contact.FullName}");
                            Console.WriteLine();
                            Console.WriteLine($"Address: {contact.Address}");
                            Console.WriteLine();
                            Console.WriteLine($"ID nr: {contact.Id}");
                            Console.WriteLine("--------------------------------------------------------------");
                            Console.WriteLine();
                            break;

                        case "4":
                            Console.Clear();
                            Console.WriteLine("---- UPDATE A CONTACT ----");
                            Console.WriteLine();

                            Console.Write("Contact ID: ");

                            contact = menuService.Update(Console.ReadLine());

                            menuService.Update(Console.ReadLine); //Uppdaterar kontakten.


                            Console.ReadKey();

                            break;

                        case "5":
                            try
                            {
                                Console.Clear();
                                Console.WriteLine("---- DELETE A CONTACT ----");
                                Console.WriteLine();

                                Console.Write("Contact ID: ");
                                var _contacts = Guid.Parse(Console.ReadLine());

                                menuService.Delete(_contacts); // skickar min kontakt till menuService för att kunna radera den.


                            }
                            catch
                            {       //Skriver in ett ID som inte existerar eller något annat så kommer detta upp.
                                Console.WriteLine("Invaldid ID!"); 
                                Console.ReadKey();
                            }
                            break;

                        case "6":
                            Environment.Exit(0);
                            break;

                    }
                }
                Console.ReadKey();

            }
            while (true);
        }
  
}