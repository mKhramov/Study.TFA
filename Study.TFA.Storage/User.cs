﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Study.TFA.Storage
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        [MaxLength(20)]
        public string Login { get; set; }

        [InverseProperty(nameof(Topic.Auther))]
        public ICollection<Topic> Topics { get; set; }

        [InverseProperty(nameof(Comment.Auther))]
        public ICollection<Comment> Comments { get; set; }
    }
}