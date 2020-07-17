/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// GSM Short Message (SM) Message Type, The Tp-Message-Type-Indicator is a 2-bit field, 
	/// located within bits b[1] and b[0] of the first octet of all PDUs.
	/// </summary>
	public enum MessageTypeIndication : byte
	{
		/// <summary>
		/// Sms-Deliver (in the direction Service Center (SC) to Mobile Station (MS))
		/// </summary>
		Deliver = 0x00,
		/// <summary>
		/// Sms-Deliver-Report (in the direction Mobile Station (MS) to Service Center (SC))
		/// </summary>
		DeliverReport = 0x00,
		/// <summary>
		/// Sms-Status-Report (in the direction Service Center (SC) to Mobile Station (MS))
		/// </summary>
		StatusReport = 0x02,
		/// <summary>
		/// Sms-Command (in the direction Mobile Station (MS) to Service Center (SC))
		/// </summary>
		Command = 0x02,
		/// <summary>
		/// Sms-Submit (in the direction Mobile Station (MS) to Service Center (SC))
		/// </summary>
		Submit = 0x01,
		/// <summary>
		/// Sms-Submit-Report (in the direction Service Center (SC) to Mobile Station (MS))
		/// </summary>
		SubmitReport = 0x01,
		/// <summary>
		/// Reserved
		/// </summary>
		Reserved = 0x03,
	}
}