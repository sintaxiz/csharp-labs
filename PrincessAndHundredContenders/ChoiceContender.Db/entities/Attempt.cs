using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChoiceContender.Db.entities;

[Table("attempt")]
public class Attempt : BaseEntity
{
    [StringLength(64)]
    public string Name { get; set; }
    
    public int Count { get; set; }

    //[Timestamp] public byte[] Timestamp { get; set; }

    public List<Contender> Contenders { get; set; } = new List<Contender>();
}