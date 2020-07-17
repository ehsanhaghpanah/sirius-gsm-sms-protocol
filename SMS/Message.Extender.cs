/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// Message
	/// </summary>
	public abstract partial class Message
	{
		#region Propertys

		/// <summary>
		///
		/// </summary>
		public virtual DataHeader DataHeader
		{
			get { return (null); }
		}

		#endregion
	}
}
