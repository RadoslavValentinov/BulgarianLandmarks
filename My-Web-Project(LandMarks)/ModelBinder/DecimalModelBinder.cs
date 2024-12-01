using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Globalization;

namespace My_Web_Project_LandMarks_.ModelBinder
{
    public class DecimalModelBinder : IModelBinder
    {
        /// <summary>
        /// Custom method to replace "," with "." and vice versa for successful model validation
        /// </summary>
        /// <param name="bindingContext"></param>
        /// <returns>Task is complete </returns>
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult resultValue = bindingContext.ValueProvider
                .GetValue(bindingContext.ModelName);

            if (resultValue != ValueProviderResult.None && !string.IsNullOrEmpty(resultValue.FirstValue))
            {
                decimal actualResult = 0m;
                bool isSuccess = false;


                try
                {
                    string decimalValue = resultValue.FirstValue;
                    decimalValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    decimalValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    actualResult = Convert.ToDecimal(decimalValue, CultureInfo.CurrentCulture);
                    isSuccess = true;
                }
                catch (FormatException fex)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, fex, bindingContext.ModelMetadata);
                }

                if (isSuccess)
                {
                    bindingContext.Result = ModelBindingResult.Success(actualResult);
                }
            }

            return Task.CompletedTask;
        }
    }
}
