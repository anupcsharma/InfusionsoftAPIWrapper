using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CookComputing.XmlRpc;
using InfusionsoftCoreLibrary;
using InfusionsoftWeb.Models;



namespace InfusionsoftWeb.Controllers
{
	public class HomeController : Controller
	{
		private string DeveloperAppKey = "xxxxxx";
		private string DeveloperAppSecret = "yyyyyy";
		private const string AccessToken = "zzzzzz";

		private string CallbackUrl = "http://localhost:2412/home/callback";

		
		private const string ServiceUrl = "https://api.infusionsoft.com/crm/xmlrpc/v1";

		public ActionResult Index()
		{
			return View();
		}

		public ActionResult Authorize()
		{
			// Hard coded "scope=full" and "responseType=code" since they are the only supported options
			string authorizeUrlFormat =
				"https://signin.infusionsoft.com/app/oauth/authorize?scope=full&redirect_uri={0}&response_type=code&client_id={1}";

			// Url encode CallbackUrl
			return Redirect(string.Format(authorizeUrlFormat, Server.UrlEncode(CallbackUrl), DeveloperAppKey));
		}

		public ActionResult Callback(string code)
		{
			if (!string.IsNullOrEmpty(code))
			{
				string tokenUrl = "https://api.infusionsoft.com/token";

				// Hard coded "grant_type=authorization_code" since it is the only supported option
				string tokenDataFormat = "code={0}&client_id={1}&client_secret={2}&redirect_uri={3}&grant_type=authorization_code";

				HttpWebRequest request = HttpWebRequest.Create(tokenUrl) as HttpWebRequest;
				request.Method = "POST";
				request.KeepAlive = true;
				request.ContentType = "application/x-www-form-urlencoded";

				// Url encode CallbackUrl
				string dataString = string.Format(tokenDataFormat, code, DeveloperAppKey, DeveloperAppSecret,
					Server.UrlEncode(CallbackUrl));
				var dataBytes = Encoding.UTF8.GetBytes(dataString);
				using (Stream reqStream = request.GetRequestStream())
				{
					reqStream.Write(dataBytes, 0, dataBytes.Length);
				}

				string resultJSON = string.Empty;
				using (WebResponse response = request.GetResponse())
				{
					var sr = new StreamReader(response.GetResponseStream());
					resultJSON = sr.ReadToEnd();
					sr.Close();
				}

				var jsonSerializer = new JavaScriptSerializer();

				var tokenData = jsonSerializer.Deserialize<TokenData>(resultJSON);

				ViewData.Add("AccessToken", tokenData.Access_Token);
			}

			return View();
		}

		public ActionResult FindContact()
		{

			//var accessToken = Request.QueryString["AccessToken"];
			//var email = Request.QueryString["Email"];

			//var viewData = new List<ContactInfo>();

			//if (!string.IsNullOrEmpty(accessToken))
			//{
			//	var contactService = XmlRpcProxyGen.Create<IInfusionsoftAPI>();
			//	contactService.Url = "https://api.infusionsoft.com/crm/xmlrpc/v1?access_token=" + accessToken;

			//	var contacts = contactService.LookupByEmail(DeveloperAppKey, email, new[] { "Id", "FirstName", "LastName" });

			//	foreach (var contact in contacts)
			//	{
			//		viewData.Add(new ContactInfo { Id = (int)contact["Id"], FirstName = (string)contact["FirstName"], LastName = (string)contact["LastName"]});
			//	}

			//}

			
			var service = new InfusionsoftWebService(AccessToken, DeveloperAppKey, ServiceUrl);
			var client = service.Connect();
			//client.MethodListener = new NullMethodListener();

			const string email = "mad@max.com";
			var contacts = client.ContactService.FindByEmail(email, p => p.Include(c => c.Id)
				.Include(c => c.Email)
				.Include(c => c.FirstName)
				.Include(c => c.LastName)
				.Include(c => c.LeadSourceId)
				);

			//Email opt in
			var emailOptinResponse = client.EmailService.OptIn(email, "Customer email opt-in from booker");

			var emailOptOutResponse = client.EmailService.OptOut(email, "Customer email opt-out from booker");

			//var deleteRecordResponse = client.DataService.Delete("Contact", contacts.FirstOrDefault().Id);

			var viewData = new List<ContactInfo>();
			foreach (var contact in contacts)
			{
				viewData.Add(new ContactInfo {Id = contact.Id, FirstName = contact.FirstName, LastName = contact.LastName});
			}

			return View(viewData);
		}

		[HttpGet]
		public ActionResult CreateContact()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateContact( ContactInfo contactInfo)
		{
			if (ModelState.IsValid)
			{
				var service = InfusionsoftWebService().Connect();
				
			//var result = service.ContactService.Add(setter =>
			//{
			//	setter.Set(c => c.FirstName, contactInfo.FirstName);
			//	setter.Set(c => c.LastName, contactInfo.LastName);
			//	setter.Set(c => c.Email, contactInfo.Email);
			//	setter.Set(c => c.Address2Street1, contactInfo.Address);
			//	setter.Set(c => c.City, contactInfo.City);
			//	setter.Set(c => c.ZipFour1, contactInfo.Zipcode);
			//	setter.Set(c => c.Phone1, contactInfo.PhoneNumber);
			//}
			//);

				var result = service.ContactService.AddWithDupCheck(setter =>
				{
					setter.Set(c => c.FirstName, contactInfo.FirstName);
						setter.Set(c => c.LastName, contactInfo.LastName);
						setter.Set(c => c.Email, contactInfo.Email);
						setter.Set(c => c.Address2Street1, contactInfo.Address);
						setter.Set(c => c.City, contactInfo.City);
						setter.Set(c => c.ZipFour1, contactInfo.Zipcode);
						setter.Set(c => c.Phone1, contactInfo.PhoneNumber);
				}, DupCheckType.EmailAndName);

				return View();
			}
			return View();
		}

		[HttpPost]
		public ActionResult UpdateContact(ContactInfo contactInfo)
		{
			if (ModelState.IsValid)
			{
				var service = InfusionsoftWebService().Connect();

				//var result = service.ContactService.Add(setter =>
				//{
				//	setter.Set(c => c.FirstName, contactInfo.FirstName);
				//	setter.Set(c => c.LastName, contactInfo.LastName);
				//	setter.Set(c => c.Email, contactInfo.Email);
				//	setter.Set(c => c.Address2Street1, contactInfo.Address);
				//	setter.Set(c => c.City, contactInfo.City);
				//	setter.Set(c => c.ZipFour1, contactInfo.Zipcode);
				//	setter.Set(c => c.Phone1, contactInfo.PhoneNumber);
				//}
				//);

				var contact = service.ContactService.FindByEmail("gary@cooper.com", p =>
									p.Include(c => c.Id)
									.Include(c => c.Email)
									.Include(c => c.FirstName)
									.Include(c => c.LeadSourceId));
				var enumerable = contact as Contact[] ?? contact.ToArray();
				int externalCustomerID = 0;
				if (contact != null && enumerable.Any())
				{
					var customer = enumerable.FirstOrDefault(c => c.FirstName == "Gary");
					if (customer != null && customer.Id > 0)
						externalCustomerID = customer.Id;
				}

				if (externalCustomerID > 0)
				{
					var result = service.ContactService.Update(externalCustomerID, setter =>
					{
						setter.Set(c => c.FirstName, contactInfo.FirstName);
						setter.Set(c => c.LastName, contactInfo.LastName);
						setter.Set(c => c.Email, contactInfo.Email);
						setter.Set(c => c.Address2Street1, contactInfo.Address);
						setter.Set(c => c.City, contactInfo.City);
						setter.Set(c => c.ZipFour1, contactInfo.Zipcode);
						setter.Set(c => c.Phone1, contactInfo.PhoneNumber);
					});
				}
				

				return View();
			}
			return View();
		}

		
		private InfusionsoftWebService InfusionsoftWebService()
		{
			var service = new InfusionsoftWebService(AccessToken, DeveloperAppKey, ServiceUrl);
			return service;
		}


		//Infusionsoft API
        public interface IInfusionsoftAPI : IXmlRpcProxy
        {
            [XmlRpcMethod("ContactService.findByEmail")]
            XmlRpcStruct[] LookupByEmail(string key, string email, string[] selectedFields);
        }

    }
}
