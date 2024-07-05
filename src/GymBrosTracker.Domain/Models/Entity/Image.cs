using GymBrosTracker.Domain.Models.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymBrosTracker.Domain.Models.Entity
{
    public class Image : IEntity
    {
        [Key]
        public int Id { get; set; }

        public int ExerciseId { get; set; }

        public byte[] ImageBytes { get; set; } = null!;

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; } = [];

        #region Foreign models

        [ForeignKey(nameof(ExerciseId))]
        public Exercise? Exercise { get; set; }
        #endregion

        #region DTO models 
        public string ImageString
        {
            get
            {
                return string.Format($"data:image/bmp;base64,{Convert.ToBase64String(ImageBytes)}");
            }
        }
        #endregion
    }
}