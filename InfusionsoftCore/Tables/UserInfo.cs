using CookComputing.XmlRpc;

namespace InfusionsoftCoreLibrary
{
	[XmlRpcMissingMapping(MappingAction.Ignore)]
	public class UserInfo : Table
	{
		[Access(Access.All)]
		[XmlRpcMember("appUrl")]
		public string AppUrl { get; set; }

		[Access(Access.All)]
		[XmlRpcMember("localUserId")]
		public int? LocalUserId { get; set; }

		[Access(Access.All)]
		[XmlRpcMember("globalUserId")]
		public int? GlobalUserId { get; set; }

		[Access(Access.All)]
		[XmlRpcMember("casUsername")]
		public string CasUserName { get; set; }

		[Access(Access.All)]
		[XmlRpcMember("appAlias")]
		public string AppAlias { get; set; }

		[Access(Access.All)]
		[XmlRpcMember("displayName")]
		public string DisplayName { get; set; }
	}
}