namespace DatabaseLayout.Models;

public class Note
{
    public int Id { get; private set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public User User { get; set; }
}