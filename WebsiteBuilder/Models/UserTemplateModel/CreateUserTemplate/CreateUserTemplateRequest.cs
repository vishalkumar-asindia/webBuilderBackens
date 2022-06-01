using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebsiteBuilder.Models.UserTemplateModel.CreateUserTemplate
{
    public class CreateUserTemplateRequest
    {
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhone { get; set; }
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
    }
}
