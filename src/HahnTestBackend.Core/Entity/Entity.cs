using System;
using System.ComponentModel.DataAnnotations;

namespace HahnTestBackend.Core.Entity
{
    public abstract class Entity : IEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }    
           
    }
}
