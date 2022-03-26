using Domain.App.Identity;

namespace PublicApi.DTO.v1;

public class JwtResponse
{
    public Guid Id { get; set; } = default!;

    public string Token { get; set; } = default!;
    public string Firstname { get; set; } = default!;
    public string Lastname { get; set; } = default!;
}
