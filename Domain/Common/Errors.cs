using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    internal class Errors<T>
    {
        internal static Error Validation(string description, [CallerMemberName] string callerMemberName = "")
        {
            return Validation(typeof(T), description, callerMemberName);
        }

        internal static Error Validation(Type type, string description, [CallerMemberName] string callerMemberName = "")
        {
            return Error.Validation(
                code: $"{typeof(T).Name}.{callerMemberName}",
                description: description);
        }


        internal Error NotFound(string description, [CallerMemberName] string callerMemberName = "")
        {
            return NotFound(typeof(T), description, callerMemberName);
        }

        internal static Error NotFound(Type type, string description, [CallerMemberName] string callerMemberName = "")
        {
            return Error.NotFound(
                code: $"{type.Name}.{callerMemberName}",
                description: description);
        }


        internal static Error Conflict(string description, [CallerMemberName] string callerMemberName = "")
        {
            return Conflict(typeof(T), description, callerMemberName);
        }

        internal static Error Conflict(Type type, string description, [CallerMemberName] string callerMemberName = "")
        {
            return Error.Conflict(
                code: $"{typeof(T).Name}.{callerMemberName}",
                description: description);
        }
    }
}
