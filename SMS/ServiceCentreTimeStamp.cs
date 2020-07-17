/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

using System;

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	///
	/// </summary>
	public sealed class ServiceCentreTimeStamp
	{
		private readonly DateTime _TimeDate;

		public ServiceCentreTimeStamp(string data)
		{
			if (data.Length != 14)
				throw new ArgumentException();

			int Dy = int.Parse(data.Substring(1, 1) + data.Substring(0, 1));
			data = data.Substring(2);

			int Dm = int.Parse(data.Substring(1, 1) + data.Substring(0, 1));
			data = data.Substring(2);

			int Dd = int.Parse(data.Substring(1, 1) + data.Substring(0, 1));
			data = data.Substring(2);

			int Th = int.Parse(data.Substring(1, 1) + data.Substring(0, 1));
			data = data.Substring(2);

			int Tm = int.Parse(data.Substring(1, 1) + data.Substring(0, 1));
			data = data.Substring(2);

			int Ts = int.Parse(data.Substring(1, 1) + data.Substring(0, 1));
			
			_TimeDate = new DateTime(Dy + 2000, Dm, Dd, Th, Tm, Ts);
		}

		#region Propertys

		/// <summary>
		///
		/// </summary>
		public DateTime TimeDate
		{
			get { return (_TimeDate); }
		}

		#endregion

		#region Functions

		#endregion
	}
}
