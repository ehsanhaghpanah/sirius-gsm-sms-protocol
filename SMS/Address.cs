/**
 * Copyright (C) Ehsan Haghpanah, 2010.
 * All rights reserved.
 * Ehsan Haghpanah, (github.com/ehsanhaghpanah)
 */

using System;
using System.Text;

namespace sirius.GSM.Protocols.SMS
{
	/// <summary>
	/// Address
	/// </summary>
	public sealed class Address
	{
		private readonly NumberType _NumberType;
		private readonly NumberingPlan _NumberingPlan;
		private readonly DataRepresentation _Representation;
		private readonly string _Number;

		/// <summary>
		/// Encode
		/// </summary>
		public Address(DataRepresentation representation, NumberType numberType, NumberingPlan numberingPlan, string number)
		{
			if (!IsNumber(number))
				throw new ArgumentException();

			if (!((representation == DataRepresentation.Octet) || (representation == DataRepresentation.SemiOctet)))
				throw new ArgumentException();

			_Representation = representation;
			_NumberType = numberType;
			_NumberingPlan = numberingPlan;
			_Number = number;
		}

		/// <summary>
		/// Decode
		/// </summary>
		public Address(DataRepresentation representation, string data)
		{
			if (!IsParsable(data))
				throw new ArgumentException();

			if (!((representation == DataRepresentation.Octet) || (representation == DataRepresentation.SemiOctet)))
				throw new ArgumentException();

			_Representation = representation;

			data = data.ToUpper();

			byte l = byte.Parse(data.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
			byte h = byte.Parse(data.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);

			_NumberType = (NumberType)((0x70) & h);
			_NumberingPlan = (NumberingPlan)((0x0f) & h);

			string number;

			if (_Representation == DataRepresentation.Octet)
				number = data.Substring(4, (l - 1) * 2);
			else
				number = data.Substring(4, l);

			for (int i = 0; i < number.Length; i += 2)
				_Number += number.Substring(i + 1, 1) + number.Substring(i, 1);

			if (_Number.EndsWith("F"))
				_Number = _Number.Substring(0, _Number.Length - 1);

			if (_NumberType == NumberType.InternationalNumber)
				_Number = "+" + _Number;
		}

		#region Propertys

		/// <summary>
		/// Data Representation
		/// </summary>
		public DataRepresentation Representation
		{
			get { return (_Representation); }
		}

		/// <summary>
		/// Number Type
		/// </summary>
		public NumberType NumberType
		{
			get { return (_NumberType); }
		}

		/// <summary>
		/// Numbering Plan
		/// </summary>
		public NumberingPlan NumberingPlan
		{
			get { return (_NumberingPlan); }
		}

		/// <summary>
		/// Number
		/// </summary>
		public string Number
		{
			get { return (_Number); }
		}

		/// <summary>
		///
		/// </summary>
		public int Length
		{
			get
			{
				string t = _Number;

				if (t.StartsWith("+"))
					t = t.Substring(1);

				//
				// note:
				if ((t.Length % 2) != 0)
					t += "0";

				if (_Representation == DataRepresentation.Octet)
					return ((t.Length / 2) + 1);

				return (t.Length);
			}
		}

		#endregion

		#region Functions

		/// <summary>
		///
		/// </summary>
		public string ToPDU()
		{
			string t = _Number;
			string r = string.Empty;

			if (t.StartsWith("+"))
				t = t.Substring(1);

			//
			// note:
			if ((t.Length % 2) != 0)
				t += "0";

			byte h = (byte)(0x80 + (int)_NumberType + (int)_NumberingPlan);
			byte l;

			if (_Representation == DataRepresentation.Octet)
				l = (byte)((t.Length / 2) + 1);
			else
				l = (byte)(t.Length);

			for (int i = 0; i < t.Length; i += 2)
				r += t.Substring(i + 1, 1) + t.Substring(i, 1);

			return (l.ToString("X2") + h.ToString("X2") + r);
		}

		/// <summary>
		///
		/// </summary>
		public static bool IsNumber(string number)
		{
			if (number.StartsWith("+"))
				number = number.Substring(1);

			if (number.Length == 0)
				return (false);

			byte[] bytes = Encoding.ASCII.GetBytes(number);

			for (int i = 0; i < bytes.Length; i++)
				if (!((((byte)'0') <= bytes[i]) && (bytes[i] <= ((byte)'9'))))
					return (false);

			return (true);
		}

		/// <summary>
		///
		/// </summary>
		public static bool IsParsable(string data)
		{
			byte[] bytes = Encoding.ASCII.GetBytes(data);

			for (int i = 0; i < bytes.Length; i++)
			{
				bool check = false;
				check = check || (((byte)'0') <= bytes[i]) && (bytes[i] <= ((byte)'9'));
				check = check || (((byte)'A') <= bytes[i]) && (bytes[i] <= ((byte)'F'));
				check = check || (((byte)'a') <= bytes[i]) && (bytes[i] <= ((byte)'f'));
				if (!check)
					return (false);
			}

			return (true);
		}

		#endregion
	}
}