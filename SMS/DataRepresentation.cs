/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// For parameters within the TPDUs, there are four ways of numeric representation: 
	/// Integer representation, Octet, SemiOctet and Alphanumeric representation
	/// </summary>
	public enum DataRepresentation
	{
		/// <summary>
		/// Integer
		/// </summary>
		Integer,
		/// <summary>
		/// A field which is octet represented, will always consist of a number of complete octets. Each
		/// octet within the field represents one decimal digit. The octets with the lowest octet numbers
		/// will contain the most significant decimal digits.
		/// </summary>
		Octet,
		/// <summary>
		/// A field which is SemiOctet represented, will consist of a number of complete octets and possibly 
		/// one half octet. Each half octet within the field represents one decimal digit. The octets with 
		/// the lowest octet numbers will contain the most significant decimal digits. Within one octet, the 
		/// half octet containing the bits with bit numbers 0 to 3, will represent the most significant digit.
		/// In the case where a SemiOctet represented field comprises an odd number of digits, the bits with 
		/// bit numbers 4 to 7 within the last octet are fill bits and shall always be set to (1111).
		/// </summary>
		SemiOctet,
		/// <summary>
		/// A field which uses AlphaNumeric representation will consist of a number of 7bit characters 
		/// represented as the default alphabet defined in GSM 03.38.
		/// </summary>
		AlphaNumeric
	}
}
