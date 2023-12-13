using System.ComponentModel.DataAnnotations;

namespace TheSecretGarden.Enum
{
    public enum Status
    {
        [Display(Name = "On Hold")]
        OnHold = 1,
        Processing,
        Completed
    }
}
