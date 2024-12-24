using Microsoft.AspNetCore.Mvc;
using Library.Extenstions.ErrorOr;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace API.Common
{
    [ApiController]
    public class ApiController : ControllerBase
    {

        protected IActionResult Problem(List<Error> errors)
        {
            if (errors.Count is 0)
            {
                return Problem();
            }

            if (errors.All(error => error.Type is ErrorType.Validation))
            {
                return ValidationProblem(errors);
            }

            Error worstError = GetWorstError(errors);

            return Problem(worstError);
        }

        private static Error GetWorstError(List<Error> errors)
        {
            if (errors.FirstOrDefault(ErrorType.Unauthorized) is Error errUnauthorized)
                return errUnauthorized;

            if (errors.FirstOrDefault(ErrorType.Forbidden) is Error errForbidden)
                return errForbidden;

            if (errors.FirstOrDefault(ErrorType.NotFound) is Error errNotFound)
                return errNotFound;

            if (errors.FirstOrDefault(ErrorType.Conflict) is Error errConflict)
                return errConflict;

            if (errors.FirstOrDefault(ErrorType.Validation) is Error errValidation)
                return errValidation;

            return errors.First();
        }

        private static bool Has(List<Error> errors, ErrorType errorType)
        {
            return errors.Any(error => error.Type == errorType);
        }

        protected IActionResult Problem(Error error)
        {
            int statusCode = error.Type switch
            {
                ErrorType.Unauthorized => StatusCodes.Status401Unauthorized,
                ErrorType.Forbidden => StatusCodes.Status403Forbidden,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError,
            };

            return Problem(statusCode: statusCode, detail: error.Description);
        }

        protected IActionResult ValidationProblem(List<Error> errors)
        {
            ModelStateDictionary modelStateDictionary = new();

            foreach (Error error in errors)
            {
                modelStateDictionary.AddModelError(
                    error.Code,
                    error.Description);
            }

            return ValidationProblem(modelStateDictionary);
        }
    }
}
