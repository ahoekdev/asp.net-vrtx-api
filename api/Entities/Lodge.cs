

namespace api.Entities
{
    public class Lodge
    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Country { get; set; }
    }
}