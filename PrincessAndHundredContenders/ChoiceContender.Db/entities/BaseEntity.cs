using System.ComponentModel.DataAnnotations;

namespace ChoiceContender.Db.entities;

public abstract class BaseEntity
{
    [Key] public Guid Id { get; set; }
}