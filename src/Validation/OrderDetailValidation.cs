using Recrovit.RecroGridFramework.Abstraction.Contracts.Services;
using Recrovit.RecroGridFramework.Abstraction.Contracts.UI;
using Recrovit.RecroGridFramework.Abstraction.Models;

namespace RGF.Demo.Northwind.Common.Validation;

public class OrderDetailValidation
{
    public static async Task<bool> ValidateAsync(RgfDynamicDictionary dataRec, IRgfFormValidationMessages validationMessages, IRecroDictService recroDict, string? fieldName = null)
    {
        bool valid = true;
        if (fieldName == null || fieldName.Equals("discount", StringComparison.OrdinalIgnoreCase) == true)
        {
            var discount = dataRec.GetItemData("discount").DoubleValue;
            if (discount != 0 && (discount < 0.01 || discount > 0.9))
            {
                valid = false;
                var errorMessage = await recroDict.GetItemAsync("OrderDetail.ValidationErrorMessage", "Discount");
                validationMessages.AddFieldErrorMessage("discount", errorMessage);
            }
        }
        return valid;
    }
}