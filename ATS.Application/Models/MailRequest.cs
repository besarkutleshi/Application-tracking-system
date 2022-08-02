
namespace ATS.Application.Models
{
    public class MailRequest
	{
		public MailRequest(string from, string to, string subject, string htmlBody, int applicationId, string mailType)
		{
			this.from = from;
			this.to = to;
			this.subject = subject;
			this.htmlBody = htmlBody;
			this.applicationId = applicationId;
			this.mailType = mailType;
		}

		public string from { get; set; }
		public string to { get; set; }
		public string subject { get; set; }
		public string htmlBody { get; set; }
		public int applicationId { get; set; }
		public string mailType { get; set; }
	}
}
