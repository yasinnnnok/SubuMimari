using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUBU.Models
{
	public class ControllerConstants
	{
		public class Route
		{
			public const string List = "List";
			public const string GetByName = "GetByName";
			public const string Create = "Create";
			public const string Update = "Update";
			public const string ListAll = "ListAll";
			public const string Find = "Find";
			public const string FindById = "FindById";
			public const string UpdateAlive = "UpdateAlive";
			public const string Remove = "Remove";
			public const string Delete = "Delete";
			public const string Login = "Login";
		}
		
		public class Params
		{
			public const string Id = "id";
			public const string Name = "name";
			public const string Keyname = "keyname";
		}
	}
}
