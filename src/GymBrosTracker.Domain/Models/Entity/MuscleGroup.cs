using GymBrosTracker.Domain.Models.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace GymBrosTracker.Domain.Models.Entity
{
    public class MuscleGroup : IEntity
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; } = [];
        
        #region Foreign models
        public List<Exercise> Exercises { get; set; } = [];
        #endregion
    }
}
