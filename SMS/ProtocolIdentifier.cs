/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

using System;

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// The TP-Protocol-Identifier parameter serves the purposes indicated in GSM 03.40. It consists 
	/// of one octet. Parameter identifying the above layer protocol, if any.
	/// </summary>
	public sealed class ProtocolIdentifier
	{
		public ProtocolIdentifier()
		{
		}

		public ProtocolIdentifier(string data)
		{
			if (data != "00")
				throw new NotSupportedException();
		}

		#region Propertys

		#endregion

		#region Functions

		/// <summary>
		/// Note that for the straightforward case of simple MS-to-SC short message transfer, the 
		/// TP-Protocol-Identifier is set to the value 00.
		/// </summary>
		public string ToPDU()
		{
			return ("00");
		}

		#endregion
	}
}