using ATS.Application.Contracts.Infrastructure;
using ATS.Application.DTO_s.Administration.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ATS.Application.Features.Administration.Authentication.Configs
{
    public class TokenConfig : IToken
    {
		private readonly IConfiguration configuration;

        public TokenConfig(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerateToken(LoginResponseDTO loginResponse)
        {
			var secretBytes = Encoding.ASCII.GetBytes(configuration.GetValue<string>("tokenConfig:SecretKey"));

			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

			SymmetricSecurityKey key = new SymmetricSecurityKey(secretBytes);

			SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor()
			{
				Subject = GetClaims(loginResponse),
				//Expires = DateTime.Now.AddMinutes(2),
				SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
			};

			JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);

			return handler.WriteToken(token);
		}

		public string GenerateTokenEmailConfirmation(int userId, string email)
		{
			var secretBytes = Encoding.ASCII.GetBytes(configuration.GetValue<string>("tokenConfig:SecretKey"));

			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

			SymmetricSecurityKey key = new SymmetricSecurityKey(secretBytes);

			SecurityTokenDescriptor descriptor = new SecurityTokenDescriptor()
			{
				Expires = DateTime.Now.AddHours(1),
				Subject = new System.Security.Claims.ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.UserData, userId.ToString()),
					new Claim(ClaimTypes.Email, email)
				}),
				SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
			};

			JwtSecurityToken token = handler.CreateJwtSecurityToken(descriptor);

			return handler.WriteToken(token);
		}

		public ConfirmEmailTokenResponseDTO? ValidateToken(string token)
		{
			if (token == null)
				return null;

			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("tokenConfig:SecretKey"));
			try
			{
				tokenHandler.ValidateToken(token, new TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false,
					// set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
					ClockSkew = TimeSpan.Zero
				}, out SecurityToken validatedToken);

				var jwtToken = (JwtSecurityToken)validatedToken;
				var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "UserDate").Value);
				var email = jwtToken.Claims.First(x => x.Type == "Email").Value.ToString();

				// return user id from JWT token if validation successful
				return new ConfirmEmailTokenResponseDTO { Email = email, UserId = userId };	
			}
			catch
			{
				// return null if validation fails
				return null;
			}
		}


		private static ClaimsIdentity GetClaims(LoginResponseDTO user)
		{
			return new ClaimsIdentity(
				getClaims(user));

			Claim[] getClaims(LoginResponseDTO user)
			{
				List<Claim> claims = new List<Claim>();
				claims.Add(new Claim(ClaimTypes.Email, user.Username));
				new Claim(ClaimTypes.Name, user.Username);
				foreach (var item in user.Roles)
				{
					claims.Add(new Claim(ClaimTypes.Role, item.RoleName));
				}
				return claims.ToArray();
			}

		}
	}
}
