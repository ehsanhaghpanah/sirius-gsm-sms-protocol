/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// Number Type
	/// </summary>
	public enum NumberType : byte
	{
		/// <summary>
		/// Unknown
		/// </summary>
		Unknown = (0x00),
		/// <summary>
		/// International Number
		/// </summary>
		InternationalNumber = (0x10),
		/// <summary>
		/// National Number
		/// </summary>
		NationalNumber = (0x20),
		/// <summary>
		/// Network Specific Number
		/// </summary>
		NetworkSpecificNumber = (0x30),
		/// <summary>
		/// Subscriber Number
		/// </summary>
		SubscriberNumber = (0x40),
		/// <summary>
		/// Alphanumeric, (Coded according to GSM TS 03.38 7-bit default alphabet)
		/// </summary>
		Alphanumeric = (0x50),
		/// <summary>
		/// Abbreviated Number
		/// </summary>
		AbbreviatedNumber = (0x60),
		/// <summary>
		/// Reserved for Extension
		/// </summary>
		Reserved = (0x70),
	}
}