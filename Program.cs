using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B2Profile
{
	class Program
	{
		static int Main(string[] args)
		{
			B2Profile profile = new B2Profile();

			if (profile.Read("profile1.bin") == false)
			{
				return 1;
			}

			if (profile.Write("profile2.bin") == false)
			{
				return 1;
			}

			return 0;
		}
	}
}
