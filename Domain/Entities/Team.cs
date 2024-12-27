namespace Domain.Entities;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate  { get; set; }
    public int HackatonId { get; set; }
    public Hackaton Hackaton { get; set; }
    public List<Participant> Participants { get; set; }
}