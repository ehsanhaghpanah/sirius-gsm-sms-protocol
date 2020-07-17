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
	public abstract partial class Message
	{
		#region Propertys

		/// <summary>
		///
		/// </summary>
		public abstract byte[] Data { get; set; }

		/// <summary>
		///
		/// </summary>
		public virtual int[] Length
		{
			get { return (null); }
		}

		#endregion

		#region Functions

		/// <summary>
		///
		/// </summary>
		public virtual string[] ToPDU()
		{
			return (null);
		}

		#endregion
	}
}