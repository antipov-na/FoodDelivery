using CSharpFunctionalExtensions;

namespace Domain.Entities
{
    public class Image : Entity<string>
    {
        public string Url { get; set; }
    }
}
