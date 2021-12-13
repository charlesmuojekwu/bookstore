using System.ComponentModel.DataAnnotations;

namespace bookstoreproject.Helpers
{
    public class MyCustomValidationAttributes : ValidationAttribute
    {
        public MyCustomValidationAttributes(string text)
        {
            Text = text;
        }
        public string Text { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                string bookName = value.ToString();
                if (bookName.Contains(Text))
                {
                    return ValidationResult.Success;
                }
                
            }

            return new ValidationResult(ErrorMessage ?? "Value is not valid");

            //return base.IsValid(value, validationContext);
        }
    }
}
