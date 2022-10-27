using System.ComponentModel.DataAnnotations.Schema;

namespace ChoiceContender.Db.entities;

[Table("contender")]
public class Contender : BaseEntity
{
    public string Name { get; set; }
    public int Rating { get; set; }
}