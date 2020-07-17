/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	///
	/// </summary>
	public enum ValidityPeriodDuration : byte
	{
		/// <summary>
		/// (0x0b = 11)
		/// Duration = (ValidityPeriodDuration + 1) * (5 minute)
		/// </summary>
		OneHour = 0x0b,
		/// <summary>
		/// (0x1d = 29)
		/// Duration = (ValidityPeriodDuration + 1) * (5 minute)
		/// </summary>
		ThreeHours = 0x1d,
		/// <summary>
		/// (0x47 = 71)
		/// Duration = (ValidityPeriodDuration + 1) * (5 minute)
		/// </summary>
		SixHours = 0x47,
		/// <summary>
		/// (0x8f = 143)
		/// Duration = (ValidityPeriodDuration + 1) * (5 minute)
		/// </summary>
		TwelveHours = 0x8f,
		/// <summary>
		/// (0xa7 = 167)
		/// </summary>
		OneDay = 0xa7,
		/// <summary>
		/// (0xc4 = 196)
		/// </summary>
		OneWeek = 0xc4,
		/// <summary>
		/// (0xff = 255)
		/// </summary>
		Maximum = 0xff,
	}
}
