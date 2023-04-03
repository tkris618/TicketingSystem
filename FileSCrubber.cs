using NLog;

public static class FileScruber
{
    private static NLog.Logger logger = LogManager.LoadConfiguration(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();

    public static string ScrubTickets(string readFile)
    {
        try
        {
            string ext = readFile.Split('.').Last();
            string writeFile = readFile.Replace(ext, $"scrubbed.{ext}");
            if (File.Exists(writeFile))
            {
                logger.Info("File already scrubbed");
            }
            else
            {
                //File has not been scrubbed
                logger.Info("File scrub started");
                //open write fie
                StreamWriter sw = new StreamWriter(writeFile);
                //open read file
                StreamReader sr = new StreamReader(readFile);
                //remove column headers
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                        //create instance of Ticket Class
                        Ticket ticket = new Ticket();
                        string line = sr.ReadLine();

                        int idx = line.IndexOf('"');
                        if(idx == -1)
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
                        sw.WriteLine($"{ticket.ticketID},{ticket.sumry},{ticket.status},{ticket.priority},{ticket.sub},{ticket.assign},{ticket.watch}");
                }
                sw.Close();
                sr.Close();
                logger.Info("File scrub ended");
            }
            return writeFile;
        }
        catch (Exception ex)
        {
            logger.Error(ex.Message);
        }
        return "";
    }
}
