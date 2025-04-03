using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace My_Web_Project_LandMarks_.ModelBinder
{
    public class DecimalModelBinder : IModelBinder
    {

        /// <summary>
        /// Custom method to replace "," with "." and vice versa for successful model validation.
        /// </summary>
        /// <param name="bindingContext">The context in which the model binding occurs.</param>
        /// <returns>A completed task indicating the model binding process is finished.</returns>
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            // Retrieve the value from the value provider
            ValueProviderResult resultValue = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            // Check if the value is not empty or null
            if (resultValue != ValueProviderResult.None && !string.IsNullOrEmpty(resultValue.FirstValue))
            {
                decimal actualResult = 0m;
                bool isSuccess = false;

                try
                {
                    // Replace "." and "," with the current culture's decimal separator
                    string decimalValue = resultValue.FirstValue;
                    decimalValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    decimalValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    // Convert the value to a decimal
                    actualResult = Convert.ToDecimal(decimalValue, CultureInfo.CurrentCulture);
                    isSuccess = true;
                }
                catch (FormatException fex)
                {
                    // Add a model state error if the conversion fails
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fex, bindingContext.ModelMetadata);
                }

                // Set the binding result if the conversion is successful
                if (isSuccess)
                {
                    bindingContext.Result = ModelBindingResult.Success(actualResult);
                }
            }

            return Task.CompletedTask;
        }
    }
}