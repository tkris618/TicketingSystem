using NLog;

public class TicketFile
{
    public string filePath {get; set;}

    public List<Ticket> Tickets {get; set;}

    private static NLog.Logger logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
    public TicketFile(string TicketFilePath)
    {
        filePath = TicketFilePath;
        Tickets = new List<Ticket>();

        //populate list with data
        try
        {
            StreamReader sr = new StreamReader(filePath);
            while (!sr.EndOfStream)
            {
                Ticket ticket = new Ticket();
                string line = sr.ReadLine();

                int idx = line.IndexOf('"');
                if (idx  == -1)
                {
                    string[] ticketDetails = line.Split(',');
                    ticket.ticketID = UInt64.Parse(ticketDetails[0]);
                    ticket.sumry = ticketDetails[1];
                    ticket.status = ticketDetails[2];                        
                    ticket.priority = ticketDetails[3];
                    ticket.sub = ticketDetails[4];
                    ticket.assign = ticketDetails[5];
                    ticket.watch = ticketDetails[6];
                }
                else {
                    ticket.ticketID = UInt64.Parse(line.Substring(0, idx -1));

                    line = line.Substring(idx);
                    idx = line.LastIndexOf('"');
                    ticket.sumry = line.Substring(0, idx + 1);
                    line = line.Substring(idx + 2);
                    string[] details = line.Split(',');
                    ticket.status = details[0];
                    ticket.priority = details[1];
                    ticket.sub = details[2];
                    ticket.assign = details[3];
                    ticket.watch = details[4];
                }
                Tickets.Add(ticket);
            }
            sr.Close();
            logger.Info("Tickets in file {count}", Tickets.Count);

        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
        }
    }

    public void AddTicket(Ticket ticket)
    {
        try 
        {
            ticket.ticketID = Tickets.Max(m => m.ticketID) + 1;

            string sumry = ticket.sumry.IndexOf(',') != -1 || ticket.sumry.IndexOf('"') != -1 ? $"\"{ticket.sumry}\"" : ticket.sumry;
            StreamWriter sw = new StreamWriter(filePath, true);

            sw.WriteLine($"{ticket.ticketID}, {sumry},{ticket.assign},{ticket.sub},{ticket.watch},{ticket.status},{ticket.priority}");
            sw.Close();

            Tickets.Add(ticket);

            logger.Info("TIcket id {Id} added", ticket.ticketID);
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
        }
    }
}