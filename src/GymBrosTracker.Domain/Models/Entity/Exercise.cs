﻿using GymBrosTracker.Domain.Models.Entity.Base;
using System.ComponentModel.DataAnnotations;

namespace GymBrosTracker.Domain.Models.Entity
{
    public class Exercise : IEntity
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateDate { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; } = [];

        #region Foreign models
        public List<MuscleGroup> MuscleGroups { get; set; } = [];
        public List<Workout> Workouts { get; set; } = [];

        public Image? Image { get; set; }
        #endregion
    }
}
