using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Centromedico.Database.DbModels
{
    public partial class token
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ClientId { get; set; }
        [Required]
        public string Value { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        [StringLength(450)]
        public string UserId { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime ExpiryTime { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(MyIdentityUser.tokens))]
        public virtual MyIdentityUser User { get; set; }
    }
}
