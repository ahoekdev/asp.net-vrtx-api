namespace api.DTOs
{
    public class RefreshTokenRequestDto
    {
        public Guid UserId { get; set; }

        public required string RefreshToken { get; set; }
    }
}