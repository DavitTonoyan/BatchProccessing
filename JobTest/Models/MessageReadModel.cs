using BatchProccessing.Models;

namespace JobTest.Models;

public class MessageReadModel : ReadModel
{
    public int Id { get; set; } 

    public int FromMemberId { get; set; }

    public int ToMemberId { get; set; } 

    public string Text { get; set; }


    public override string ToString()
    {
        return $"{Id},{FromMemberId},{ToMemberId},{Text}";
    }
}
