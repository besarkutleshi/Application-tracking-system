using ATS.Application.Contracts.Infrastructure;
using ATS.Application.Models;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ATS.Application.Features.Email
{
    public class EmailSender : ISendEmail
	{
		private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmail(MailRequest mailRequest)
		{
			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(_configuration.GetValue<string>("EmailSettings:EmailSent"));
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));

			HttpResponseMessage response = await client.PostAsJsonAsync("/api/emails/single", mailRequest);

			return response != null ? true : false;
		}
	}
}
