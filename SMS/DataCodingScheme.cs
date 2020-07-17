/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

using System;

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// The TP-Data-Coding-Scheme parameter serves the purposes indicated in GSM 03.38.
	/// It consists of one octet.
	/// </summary>
	public sealed class DataCodingScheme
	{
		private byte _IsTextCompressed = 0x00;
		private GsmDataCoding _MessageCoding;

		public DataCodingScheme(GsmDataCoding messageCoding)
		{
			_MessageCoding = messageCoding;
		}

		public DataCodingScheme(string data)
		{
			switch (data.ToUpper())
			{
				case "00":
					{
						_MessageCoding = GsmDataCoding.GsmDefault;
						return;
					}
				case "F5":
					{
						_MessageCoding = GsmDataCoding.Ascii;
						return;
					}
				case "08":
					{
						//
						// note:
						// In some cases this pdu refers to unicode messages (deliver-message: sms, 16-bit,manual)
						_MessageCoding = GsmDataCoding.Unicode;
						//_MessageCoding = GsmDataCoding.GsmDefault;
						return;
					}
				case "11":
					{
						//
						// note:
						_MessageCoding = GsmDataCoding.GsmDefault;
						return;
					}
				case "04":
					{
						//
						// Not sure if it is true.
						// a message was sent from a j2me app to modem.
						// message was binary-message BUT with no port assigned.
						// BIZZARE : MoreMessagesToSend is true in this case.
						_MessageCoding = GsmDataCoding.Ascii;
						return;
					}
				default:
					{
						throw new NotSupportedException();
					}
			}
		}

		#region Propertys

		/// <summary>
		/// Coding Group, Functionality related to usage of bits 3–0.
		/// bit 7, Coding Group, Functionality related to usage of bits 3-0.
		/// bit 6, Coding Group, Functionality related to usage of bits 3-0.
		/// bit 5, Indicates that text is uncompressed.
		/// bit 4, if it is 0 then it indicates that bits 1 and 0 have no message class meaning.
		/// </summary>
		public byte CodingGroup
		{
			get 
			{
				switch (_MessageCoding)
				{
					case GsmDataCoding.Ascii:
						{
							return (0xf0);
						}
					case GsmDataCoding.GsmDefault:
						{
							return (0x00);
						}
					default:
						{
							throw new NotSupportedException();
						}
				}
			}
			set 
			{
				throw new NotSupportedException();
			}
		}

		/// <summary>
		/// bit 5, Indicates that text is uncompressed.
		/// </summary>
		public bool IsTextCompressed
		{
			get 
			{
				if (_IsTextCompressed == 0x00)
					return (false);
				else
					return (true);
			}
			set 
			{
				throw new NotSupportedException();

				//if (value)
				//     _IsTextCompressed = 0x10;
				//else
				//     _IsTextCompressed = 0x00;
			}
		}

		/// <summary>
		/// bit 3,2;
		/// 7-bit message; 0x00.
		/// 8-bit data; 0x04.
		/// </summary>
		public GsmDataCoding MessageCoding
		{
			get { return (_MessageCoding); }
			set
			{
				_MessageCoding = value;
			}
		}

		/// <summary>
		/// bit 1,0.
		/// 0x01; Class 1, default meaning: ME-specific.
		/// 0x00; No meaning, indicated by bit 4.
		/// </summary>
		public byte MessageClass
		{
			get 
			{
				throw new NotSupportedException();
			}
			set 
			{
				throw new NotSupportedException();
			}
		}

		#endregion

		#region Functions

		/// <summary>
		///
		/// </summary>
		public string ToPDU()
		{
			switch (_MessageCoding)
			{
				case GsmDataCoding.Ascii:
					{
						return ("F5");
					}
				case GsmDataCoding.GsmDefault:
					{
						return ("00");
					}
				default:
					{
						throw new NotSupportedException();
					}
			}
		}

		#endregion
	}
}