using UTMMAX.Domain.Entities.User;

namespace UTMMAX.Domain.Entities;

public class RefreshTokenEntity : BaseEntity
{
    public         string     RefreshToken { get; set; }
    public         int        UserId       { get; set; }
    public virtual UserEntity UserEntity   { get; set; }
    public         DateTime   ExpiresTime  { get; set; }
}