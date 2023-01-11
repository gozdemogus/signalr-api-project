using System;
namespace UpSchool_SignalR_Api.Models
{
	public class User
	{
		//bir kullanıcı sadece bir odada bulunabilir
		public int UserID { get; set; }
		public string Name { get; set; }
		public Room Room { get; set; }
	}
}

