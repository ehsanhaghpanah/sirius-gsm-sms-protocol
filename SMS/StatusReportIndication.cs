/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// Tp-Status-Report-Indication.
	/// The Status Report Indication is a 1-bit field, located within bit b[5] of the first octet of 
	/// Deliver SMS PDU.
	/// </summary>
	public enum StatusReportIndication : byte
	{
		/// <summary>
		/// A status report will not be returned to the Short Message Entity (SME).
		/// </summary>
		No = 0x00,
		/// <summary>
		/// A status report will be returned to the Short Message Entity (SME).
		/// </summary>
		Yes = 0x20,
	}
}
