using System.ComponentModel.DataAnnotations;

namespace TheSecretGarden.Enum
{
    public enum BookCategory
    {
        Fiction = 1,

        [Display(Name = "Non-Fiction")]
        NonFiction,

        [Display(Name = "Limited Edition")]
        LimitedEdition
    }
}
