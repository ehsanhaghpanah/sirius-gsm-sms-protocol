/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

namespace sirius.GSM.Protocols.SMS.InfoElement
{
	/// <summary>
	/// Information Element Interface
	/// </summary>
	public interface IInformationElement
	{
		/// <summary>
		///
		/// </summary>
		ElementIdentifier Identifier
		{
			get;
		}

		/// <summary>
		/// Information Element Data Length
		/// Information Element Data Actual Length is equal to Information Element Length + 2
		/// </summary>
		byte Length
		{
			get;
		}

		/// <summary>
		///
		/// </summary>
		byte[] Data
		{
			get;
		}

		/// <summary>
		///
		/// </summary>
		string ToPDU();
	}
}
