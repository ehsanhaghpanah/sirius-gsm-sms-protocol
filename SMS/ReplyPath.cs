/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// The Tp-Reply-Path is a 1-bit field, located within bit b[7] of the first octet of 
	/// Sms-Submit and Sms-Deliver PDUs.
	/// </summary>
	public enum ReplyPath : byte
	{
		/// <summary>
		/// Tp-Reply-Path parameter is not set in Sms-Submit and Sms-Deliver
		/// </summary>
		No = 0x00,
		/// <summary>
		/// Tp-Reply-Path parameter is set in Sms-Submit and Sms-Deliver
		/// </summary>
		Yes = 0x80,
	}
}