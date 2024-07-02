﻿using GymBrosTracker.Domain.Models.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GymBrosTracker.Domain.Models.Entity
{
    public class Image : IEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Exercise))]
        public int ExerciseId { get; set; }

        public required byte[] ImageBytes { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; } = [];

        #region Foreign models
        public Exercise? Exercise { get; set; }
        #endregion
    }
}
