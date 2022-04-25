using Microsoft.IdentityModel.Tokens;
using System;
using System.Threading.Tasks;

namespace CrossCutting.Identity.Authorization
{
    public class JwtIssuerOptions
    {
        public string Issuer { get; set; }
        public string Subject { get; set; } 
        public string Audience { get; set; }
        public DateTime Expiration => IssuedAt.Add(ValidFor);
        public DateTime NotBefore => DateTime.UtcNow;
        public DateTime IssuedAt => DateTime.UtcNow;  //
        public TimeSpan ValidFor { get; set; } = TimeSpan.FromMinutes(120);
        public Func<Task<string>> JtiGenerator => () => Task.FromResult(Guid.NewGuid().ToString()); //
        public SigningCredentials SigningCredentials { get; set; }
    }
}

/* jwt Detalhes do Token
    4.1.1.  "iss" (Issuer)          Claim - The "iss" (issuer) claim identifies the principal that issued the JWT.
    4.1.2.  "sub" (Subject)         Claim - The "sub" (subject) claim identifies the principal that is the subject of the JWT.
    4.1.3.  "aud" (Audience)        Claim - The "aud" (audience) claim identifies the recipients that the JWT is intended for.
    4.1.4.  "exp" (Expiration Time) Claim - The "exp" (expiration time) claim identifies the expiration time on or after which the JWT MUST NOT be accepted for processing.
    4.1.5.  "nbf" (Not Before)      Claim - The "nbf" (not before) claim identifies the time before which the JWT MUST NOT be accepted for processing.
    4.1.6.  "iat" (Issued At)       Claim - The "iat" (issued at) claim identifies the time at which the JWT was issued.

    Set the timespan the token will be valid for (default is 120 min)
    The signing key to use when generating tokens.
    "jti" (JWT ID) Claim (default ID is a GUID)
*/