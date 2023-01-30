﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
string file = "ticket.txt";
string choice;
        do
        {
            Console.WriteLine("1) Read data from file.");
            Console.WriteLine("2) Create file from data.");
            Console.WriteLine("Enter any other key to exit.");

            choice = Console.ReadLine();

            if (choice == "1")
            {
                if (File.Exists(file))
                {
                    StreamReader sr = new StreamReader(file);
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
            else if (choice == "2")
            {
                StreamWriter sw = new StreamWriter(file);
                for (int i = 0; i < 7; i++)
                {
                    Console.WriteLine("Enter a ticket (Y/N)?");
                    string resp = Console.ReadLine().ToUpper();
                    //If response is not Y
                    if (resp != "Y") {break;}
                    //move to next question
                    Console.WriteLine("Enter ticket ID");
                    string id = Console.ReadLine();
                    //ticket summary
                    Console.WriteLine("Please write the ticket summary: ");
                    string sumry = Console.ReadLine();
                    //ticket status
                    Console.WriteLine("Status of ticket (ongoing or resolved): ");
                    string status = Console.ReadLine();
                    //ticket priority
                    Console.WriteLine("Priority of ticket: ");
                    string priority = Console.ReadLine();
                    //submitter of ticket
                    Console.WriteLine("Who is submitting the ticket? ");
                    string sub = Console.ReadLine();
                    //Assigned the ticket
                    Console.WriteLine("Who assigned the ticket?");
                    string assign = Console.ReadLine();
                    //Watching?
                    Console.WriteLine("Who is watching the ticket?");
                    string watch = Console.ReadLine();
                    sw.WriteLine("{0}|{1}|{2}|{3}|{4}|{5}|{6}", id, sumry, status, priority, sub, assign, watch);

                }
                sw.Close();
            }
        } while(choice == "1" || choice == "2");
