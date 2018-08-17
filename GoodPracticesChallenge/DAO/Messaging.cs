using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodPracticesChallenge
{
	public class Messaging : IMessaging
	{
		public void DisplayMessage(string message)
		{
			Console.WriteLine(message);
		}
	}
}
