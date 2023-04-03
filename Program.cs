// See https://aka.ms/new-console-template for more information
using NLog;
// See https://aka.ms/new-console-template for more information
string path = Directory.GetCurrentDirectory() + "\\nlog.config";

// create instance of Logger
var logger = LogManager.LoadConfiguration(path).GetCurrentClassLogger();
logger.Info("Program started");

string scrubbedFile = FileScruber.ScrubTickets("ticket.csv");
logger.Info(scrubbedFile);
TicketFile ticketFile = new TicketFile(scrubbedFile);
// string file = "ticket.csv";
string choice;

        do
        {
            Console.WriteLine("Ticket Data Storage");
            Console.WriteLine("1) Read data from file.");
            Console.WriteLine("2) Create file from data.");
            Console.WriteLine("3) Search ticket from file.");
            Console.WriteLine("Enter any other key to exit.");

            choice = Console.ReadLine();
            //logger.Info("User choise: {Choice}", choice);

            if (choice == "1")
            {
                if (File.Exists(scrubbedFile))
                {
                    StreamReader sr = new StreamReader(scrubbedFile);
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        //string to array
                        string[] arr = line.Split('|');
                        //display the array data
                        Console.WriteLine("Ticket ID: {0}, TIcket Summary: {1}, Ticket status: {2}, Ticket Priority: {3}, Ticket Submitter: {4}, Ticket assigned by: {5}, Watching the tickeet: {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);

                    }
                    sr.Close();
                    Console.WriteLine("Hi youve done it");
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                }
            }
            if (choice == "2")
            {
                StreamWriter sw = new StreamWriter(scrubbedFile);
                for (int i = 0; i < 7; i++)
                {
                    Console.WriteLine("Enter a ticket (Y/N)?");
                    string resp = Console.ReadLine().ToUpper();
                    //If response is not Y
                    if (resp != "Y") {break;}
                    //move to next question
                    Ticket ticket = new Ticket();
                    Console.WriteLine("Enter ticket ID");
                    ticket.ticketID = UInt64.Parse(Console.ReadLine());
                    //ticket summary
                    Console.WriteLine("Please write the ticket summary: ");
                    ticket.sumry = Console.ReadLine();
                    //ticket status
                    Console.WriteLine("Status of ticket (ongoing or resolved): ");
                    ticket.status = Console.ReadLine();
                    //ticket priority
                    Console.WriteLine("Priority of ticket: ");
                    ticket.priority = Console.ReadLine();
                    //submitter of ticket
                    Console.WriteLine("Who is submitting the ticket? ");
                    ticket.sub = Console.ReadLine();
                    //Assigned the ticket
                    Console.WriteLine("Who assigned the ticket?");
                    ticket.assign = Console.ReadLine();
                    //Watching?
                    Console.WriteLine("Who is watching the ticket?");
                    ticket.watch = Console.ReadLine();
                 Console.WriteLine(ticket.display);                    

                }
                sw.Close();
            }
            if(choice == "3")
            {
                Console.WriteLine("Search for ticket? (Y/N)");
                string resp = Console.ReadLine().ToUpper();

                if(resp != "Y") {break;}

                Console.WriteLine("Choose option to search from. (Status, priority, or submitter)");
                string option = Console.ReadLine().ToLower();

                if(option == "status")
                {
                    Console.WriteLine("Enter status of ticket: ");
                    string ticketStatus = Console.ReadLine();

                    var ticket = ticketFile.Tickets.Where(m => m.status.Contains(ticketStatus));
                    Console.WriteLine($"There are {ticket.Count()} tickets with status {ticketStatus}.");

                    foreach(Ticket g in ticket)
                    {
                        Console.WriteLine($"{g.ticketID}");
                    }
                }
            }
        } while(choice == "1" || choice == "2" || choice == "3");
        //logger.Info("Program ended");
