/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// The TP-More-Messages-to-Send is a 1-bit field, located within bit b[2] of the first octet of 
	/// Sms-Deliver and Sms-Status-Report PDUs. In the case of Sms-Status-Report this parameter refers 
	/// to messages waiting for the mobile to which the status report is sent. The term message in 
	/// this context refers to Sms Messages or status reports.
	/// </summary>
	public enum MoreMessagesToSend : byte
	{
		/// <summary>
		/// More messages are waiting for the MS in this SC
		/// </summary>
		Yes = 0x00,
		/// <summary>
		/// No more messages are waiting for the MS in this SC
		/// </summary>
		No = 0x04,
	}
}
