/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// The TP-Validity-Period comprises 1 octet in integer representation, giving the length of the 
	/// validity period, counted from when the Sms-Submit is received by the Service Center (SC).
	/// Duration = (TP-Validity-Period + 1) * (5 minutes)
	/// </summary>
	public sealed class ValidityPeriod
	{
		private ValidityPeriodDuration _Duration;

		public ValidityPeriod(ValidityPeriodDuration duration)
		{
			_Duration = duration;
		}

		#region Propertys

		/// <summary>
		///
		/// </summary>
		public ValidityPeriodDuration Duration
		{
			get { return (_Duration); }
			set 
			{
				_Duration = value;
			}
		}

		#endregion

		#region Functions

		/// <summary>
		///
		/// </summary>
		public string ToPDU()
		{
			return (((byte)(_Duration)).ToString("X2"));
		}

		#endregion
	}
}
