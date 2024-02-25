using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace RatServer.Core.Extensions
{
    public static class ModelStateExtension
    {
        public static Dictionary<string, List<string>> Errors(this ModelStateDictionary modelState)
        {
            return !modelState.IsValid
                ? modelState.ToDictionary(kvp => kvp.Key.ToCamelCase(),
                    kvp => kvp.Value
                        .Errors
                        .Select(e => e.ErrorMessage).ToArray())
                        .Where(m => m.Value.Any()).ToDictionary(x => x.Key, x => x.Value.ToList())
                : null;
        }

        public static Dictionary<string, List<string>> Errors(this ModelStateDictionary modelState, bool fixName)
        {
            return !modelState.IsValid
                ? modelState.ToDictionary(kvp => fixName ? kvp.Key.Replace("model.", string.Empty).ToCamelCase() : kvp.Key.ToCamelCase(),
                    kvp => kvp.Value
                        .Errors
                        .Select(e => string.IsNullOrWhiteSpace(e.ErrorMessage) ? "Invalid value entered." : e.ErrorMessage).ToArray())
                        .Where(m => m.Value.Any()).ToDictionary(x => x.Key, x => x.Value.ToList())
                : null;
        }
    }
}