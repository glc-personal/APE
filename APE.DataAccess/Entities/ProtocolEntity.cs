using APE.Core.Implementation;
using System;
using System.ComponentModel.DataAnnotations;

namespace APE.DataAccess.Entities
{
    public class ProtocolEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public UserEntity Author { get; set; }
        [Required]
        public DateTime DateCreatedOn { get; set; }
        [Required]
        public string Version { get; set; }
        public string MongoDbStepsId { get; set; }

    }
}
