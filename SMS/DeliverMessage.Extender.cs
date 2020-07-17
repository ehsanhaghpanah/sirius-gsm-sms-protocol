/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// Deliver Message
	/// </summary>
	public sealed partial class DeliverMessage
	{
		#region Propertys

		/// <summary>
		///
		/// </summary>
		public override DataHeader DataHeader
		{
			get
			{
				return (_DataHeader);
			}
		}

		#endregion
	}
}
