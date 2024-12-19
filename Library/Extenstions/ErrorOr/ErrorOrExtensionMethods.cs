using ErrorOr;

namespace Library.Extenstions.ErrorOr
{
    public static class ErrorOrExtensionMethods
    {
        public static Error? FirstOrDefault(this List<Error> errorOrs, ErrorType type)
        {
            foreach (Error error in errorOrs)
            {
                if (error.Type == type)
                {
                    return error;
                }
            }

            return default;
        }
    }
}
