using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace My_Web_Project_LandMarks_.ModelBinder
{
    public class DecimalModelBinderProvider : IModelBinderProvider
    {

        /// <summary>
        /// Returns a model binder for decimal types.
        /// </summary>
        /// <param name="context">The context in which the model binder is being provided.</param>
        /// <returns>A DecimalModelBinder if the model type is decimal or nullable decimal; otherwise, null.</returns>
        public IModelBinder? GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(Decimal) || context.Metadata.ModelType == typeof(Decimal?))
            {
                return new DecimalModelBinder();
            }

            return null;
        }
    }
}
