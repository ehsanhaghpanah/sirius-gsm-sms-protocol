/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// Tp-Reject-Duplicates. The Reject Duplicates is a 1-bit field, located within bit b[2] of the first 
	/// octet of Submit SMS PDU.
	/// </summary>
	public enum RejectDuplicates : byte
	{
		/// <summary>
		/// Instruct the Service Center (SC) to accept a Submit SMS for a Short Message (SM) still held 
		/// in the SC which has the same Tp-Message-Reference and the same Tp-Destination-Address 
		/// Destination Address as a previously submitted SM from the same Originating Address (OA).
		/// </summary>
		No = 0x00,
		/// <summary>
		/// Instruct the Service Center (SC) to reject an Sms-Submit for a Short Message (SM) still 
		/// held in the SC which has the same Tp-Message-Reference and the same Tp-Destination-Address 
		/// Destination Address as the previously submitted SM from the same Originating Address (OA). 
		/// In this case an appropriate Tp-Failure-Cause value will be returned in the Sms-Submit-Report.
		/// </summary>
		Yes = 0x04,
	}
}
