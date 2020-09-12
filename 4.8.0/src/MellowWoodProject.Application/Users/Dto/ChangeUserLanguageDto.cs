using System.ComponentModel.DataAnnotations;

namespace MellowWoodProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}