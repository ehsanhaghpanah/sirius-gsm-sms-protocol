/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// Numbering Plan Identification
	/// </summary>
	public enum NumberingPlan : byte
	{
		/// <summary>
		/// Unknown
		/// </summary>
		Unknown = (0x00),
		/// <summary>
		/// ISDN/Telephone numbering plan (E.164/E.163)
		/// </summary>
		IsdnOrTelephone = (0x01),
		/// <summary>
		/// Data numbering plan (X.121)
		/// </summary>
		Data = (0x03),
		/// <summary>
		/// Telex numbering plan
		/// </summary>
		Telex = (0x04),
		/// <summary>
		/// National numbering plan
		/// </summary>
		National = (0x08),
		/// <summary>
		/// Private numbering plan
		/// </summary>
		Private = (0x09),
		/// <summary>
		/// ERMES numbering plan (ETSI DE/PS 3 01-3)
		/// </summary>
		Ermes = (0x0a),
		/// <summary>
		/// Reserved for extension
		/// </summary>
		Reserved = (0x0f)
	}
}