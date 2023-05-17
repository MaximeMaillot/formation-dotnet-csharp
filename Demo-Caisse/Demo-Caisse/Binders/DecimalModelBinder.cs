using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Globalization;

public class DecimalModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

        if (valueProviderResult == null)
        {
            return Task.CompletedTask;
        }

        var value = valueProviderResult.FirstValue;

        if (string.IsNullOrEmpty(value))
        {
            return Task.CompletedTask;
        }
        
        decimal myValue = 0;
        try
        {
            myValue = Convert.ToDecimal(value, CultureInfo.InvariantCulture);
            bindingContext.Result = ModelBindingResult.Success(myValue);
            return Task.CompletedTask;
        } catch (FormatException)
        {
            bindingContext.ModelState.TryAddModelError(
                                    bindingContext.ModelName,
                                    "Could not parse MyValue.");
            return Task.CompletedTask;
        }
    }
}