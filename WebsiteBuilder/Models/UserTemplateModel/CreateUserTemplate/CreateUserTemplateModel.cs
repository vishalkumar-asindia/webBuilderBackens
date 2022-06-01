using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Models.UserTemplateModel.CreateUserTemplate
{

    [Table("user")]
    public class CreateUserTemplateModel
    {
        [Key]
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhone { get; set; }
        public int? TemplateId { get; set; }
        public DateTime? CreatedTime { get; set; } = DateTime.Now;
        public DateTime? ModifiedTime { get; set; }

    }

    [Table("usertemplate")]
    public class TemplateModel
    {
        [Key]
        public int Id { get; set; }
        public string? DomainName { get; set; }
        public string? HeaderType { get; set; }
        public string? PrimaryColor { get; set; }
        public string? SecondaryColor { get; set; }
        public string? TextColor { get; set; }
        public string? HeaderContent { get; set; }
        public string? BodyType { get; set; }
        public string? BodyContaint { get; set; }
        public string? WebsiteInformation { get; set; }
        public string? FaceBook { get; set; }
        public string? YouTube { get; set; }
        public string? Instagram { get; set; }
        public string? Twitter { get; set; }
        public DateTime? CreationTime { get; set; } = DateTime.Now;
        public DateTime? ModifiedTime { get; set; }

    }
}
