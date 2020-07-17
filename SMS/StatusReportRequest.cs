/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// Tp-Status-Report-Request.
	/// The Status Report Request is a 1-bit field, located within bit b[5] of the first octet of 
	/// Submit SMS and Command SMS PDUs.
	/// </summary>
	public enum StatusReportRequest : byte
	{
		/// <summary>
		/// A status report is not requested.
		/// </summary>
		No = 0x00,
		/// <summary>
		/// A status report is requested.
		/// </summary>
		Yes = 0x20,
	}
}
