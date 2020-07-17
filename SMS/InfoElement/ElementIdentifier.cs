/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

namespace sirius.GSM.Protocols.SMS.InfoElement
{
	/// <summary>
	/// Element Identifier
	/// </summary>
	public enum ElementIdentifier : byte
	{
		/// <summary>
		/// Concatenated Short Messages
		/// </summary>
		ConcatenatedShortMessage = 0x00,
		/// <summary>
		/// Special SMS Message Indication
		/// </summary>
		SpecialShortMessage = 0x01,
		/// <summary>
		/// Reserved
		/// </summary>
		Reserved = 0x02,
		/// <summary>
		/// Application Port Addressing Scheme, 8 bit Address
		/// </summary>
		PortAddressing8bitScheme = 0x04,
		/// <summary>
		/// Application Port Addressing Scheme, 16 bit Address
		/// </summary>
		PortAddressing16bitScheme = 0x05,
	}
}
