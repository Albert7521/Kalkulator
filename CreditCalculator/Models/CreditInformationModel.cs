using System.ComponentModel.DataAnnotations;

namespace Kalkulator.Models
{
    public class CreditInformationModel
    {
        [Required(ErrorMessage = "Не указана сумма займа")]
        [RegularExpression(@"^[-+]?[0-9]*[.,]?[0-9]+(?:[eE][-+]?[0-9]+)?$", ErrorMessage = "Сумма займа должна быть числом")]
        [Range(1, 9999999999999, ErrorMessage = "Введите корректное число")]
        [Display(Name ="сумма займа")]
        public decimal Sum { get; set; }

        [Required (ErrorMessage = "Не указан срок займа")]
        [RegularExpression(@"[+-]?(?<!\.)\b[0-9]+\b(?!\.[0-9])", ErrorMessage = "Срок займа должен быть целым числом")]
        [Range(1, 1000, ErrorMessage = "Введите корректное число")]
        [Display(Name = "срок займа")]
        public int Time { get; set; }

        [Required (ErrorMessage = "Не указана ставка займа")]
        [RegularExpression(@"^[-+]?[0-9]*[.,]?[0-9]+(?:[eE][-+]?[0-9]+)?$", ErrorMessage = "Ставка займа должна быть числом")]
        [Range(1, 99, ErrorMessage = "Введите корректное число")]
        [Display(Name = "ставка займа")]
        public decimal Rate { get; set; }
    }
}
