/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// Tp-Validity-Period-Format. The Validity Period Format is a 2-bit field, located within bits b[4] 
	/// and b[3] of the first octet of Submit SMS PDU.
	/// </summary>
	public enum ValidityPeriodFormat : byte
	{
		/// <summary>
		/// Validity Period field is not present
		/// </summary>
		None = 0x00,
		/// <summary>
		/// Validity Period field is present, Relative Format
		/// </summary>
		Relative = 0x10,
		/// <summary>
		/// Validity Period field is present, Enhanced Format
		/// </summary>
		Enhanced = 0x08,
		/// <summary>
		/// Validity Period field is present, Absolute Format
		/// </summary>
		Absolute = 0x18,
	}
}
