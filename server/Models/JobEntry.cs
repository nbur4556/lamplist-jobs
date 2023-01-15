namespace server.Models;

public class JobEntry
{
  public string Company { get; set; }
  public string? Contact { get; set; }
  public int? Interest { get; set; }
  public string? Posting { get; set; }

  //? Can we use named parameters here?
  public JobEntry(
    string company,
    string? contact = null,
    int? interest = null,
    string? posting = null
  )
  {
    Company = company;
    Contact = contact;
    Interest = interest;
    Posting = posting;
  }
}