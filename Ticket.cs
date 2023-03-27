public  class Ticket
{
    public string ticketID {get; set; }
    public string sumry {get; set; }
    public string status {get; set;}
    public string priority {get; set;}
    public string sub {get; set;}
    public string assign {get; set;}
    public string watch {get; set;}
    public List<String> severity {get; set;}

    public Ticket() 
    {
        severity = new List<string>();
    }

    public virtual string display() {
        return $"Id: {ticketID}\nSummary: {sumry}\nStatus: {status}\nPriority: {priority}\nSubmitted by: {sub}\nAssigned by: {assign}\n Person watching: {watch}\nSeverity: {string.Join(", ",severity)}";
    }
}
public class Enhancements : Ticket {
  public string software {get; set;}
  public string cost {get; set;}
  public string reason {get; set;}
  public string estimate {get; set;}


  public override string display() {
    return $"Id: {ticketID}\nSummary: {sumry}\nStatus: {status}\nPriority: {priority}\nSubmitted by: {sub}\nAssigned by: {assign}\nPerson Watching: {watch}\nSeverity: {string.Join(", ",severity)}\nSoftware: {software}\nCost: {cost}\nReason: {reason}\nEsstimate: {estimate}";
  }
  
}
public class Tasks : Ticket {
    public string projectName {get; set;}
    public string dueDate {get; set;}

    public override string display()
    {
        return $"Id: {ticketID}\nSummary: {sumry}\nStatus: {status}\nPriority: {priority}\nSubmitted by: {sub}\nAssigned by: {assign}\nPerson Watching: {watch}\nProject Name: {projectName}\nDue date: {dueDate}";
    }
}
