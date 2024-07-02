using System.ComponentModel.DataAnnotations;

namespace GymBrosTracker.Domain.Models.Entity.Base
{
    public interface IEntity
    {
        public int Id { get; set; }
    }
}
