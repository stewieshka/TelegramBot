using ErrorOr;

namespace Domain.Common.Errors;

public static partial class Errors
{
    public static class Person
    {
        public static Error PersonNotFound => Error.NotFound(
            code: "Person.NotFound",
            description: "Person was not found");
    }
}