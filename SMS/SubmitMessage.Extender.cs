/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

using DC = sirius.GSM.Coding;

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// Submit Message
	/// </summary>
	public sealed partial class SubmitMessage
	{
		#region —— Ctor(New) ——

		/// <summary>
		/// 
		/// </summary>
		public SubmitMessage(GsmDataCoding coding, int port)
		{
			_Coding = coding;
			_DataHeaderIndication = DataHeaderIndication.Yes;
			_DataHeader = new DataHeader();
			{
				InfoElement.PortAddress elem = new InfoElement.PortAddress(InfoElement.AddressingScheme.TwoOctet)
				{
					SourcePort = (ushort)port,
					TargetPort = (ushort)port
				};
				_DataHeader.Add(elem);
			}

			_ProtocolIdentifier = new ProtocolIdentifier();
			_DataCodingScheme = new DataCodingScheme(coding);
			_ValidityPeriod = new ValidityPeriod(ValidityPeriodDuration.OneDay);
		}

		#endregion
	}
}
