using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Lawrence.Tsuro.TechTest.Services.DataTransferObjects;

namespace Lawrence.Tsuro.TechTest.Console
{
    public class CustomValidator
    {
        public static void ValidateJsonCsvAddressesReaderDtos(object model)
        {
            var context           = new ValidationContext(model, null, null);
            var validationResults = new List<ValidationResult>();

            var valid = Validator.TryValidateObject(model, context, validationResults, true);

            if (!valid)
            {
                foreach (var validationResult in validationResults)
                {
                    System.Console.WriteLine("{0}", validationResult.ErrorMessage);
                }
            }
        }
    }
}