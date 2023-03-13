public class Ticket
{
    public string ticketID {get; set; }
    public string sumry {get; set; }
    public string status {get; set;}
    public string priority {get; set;}
    public string sub {get; set;}
    public string assign {get; set;}
    public string watch {get; set;}

    public string display() {
        return $"Id: {ticketID}\nSummary: {sumry}\nStatus: {status}\nPriority: {priority}\nSubmitted by: {sub}\nAssigned by: {assign}\nPerson watching: {watch}";
    }
}
