/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// The Tp-User-Data-Header-Indicator is a 1-bit field, located within bit b[6] of the first octet 
	/// of Sms-Submit and Sms-Deliver PDUs.
	/// </summary>
	public enum DataHeaderIndication : byte
	{
		/// <summary>
		/// The Tp-User-Data field contains only the Short Message
		/// </summary>
		No = 0x00,
		/// <summary>
		/// The beginning of the Tp-User-Data field contains a Header in addition to the Short Message
		/// </summary>
		Yes = 0x40,
	}
}
