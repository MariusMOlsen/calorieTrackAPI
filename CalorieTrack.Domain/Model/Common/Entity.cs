using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CalorieTrack.Domain.Model.Common.Interfaces;

namespace CalorieTrack.Domain.Model.Common;

public abstract class Entity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Guid { get; private set; }

    protected readonly List<IDomainEvent> _domainEvents = [];

    protected Entity(Guid id) => Guid = id;

    public List<IDomainEvent> PopDomainEvents()
    {
        var copy = _domainEvents.ToList();

        _domainEvents.Clear();

        return copy;
    }

    protected Entity()
    {
    }
}