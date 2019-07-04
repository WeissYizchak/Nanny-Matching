using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PLWPF
{
	[Serializable]
	public	class PlException : Exception
	{
		public PlException() : base() { }
		public PlException(string message) : base(message) { }
		public PlException(string message, Exception inner) : base(message, inner) { }
		protected PlException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
