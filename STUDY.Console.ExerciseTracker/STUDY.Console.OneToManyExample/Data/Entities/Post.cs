namespace STUDY.Console.OneToManyExample.Data.Entities;
public class Post
{
    public Post() 
    {
        Comments = new HashSet<Comment>();
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public ICollection<Comment> Comments { get; set; }
}
