using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using PackageIO;
using PackageIO.Algorithms;
// using BL2Kit;

namespace B2Profile
{
    public enum DataType
    {
        Int32 = 1,
        String = 4,
        Single = 5,
        Binary = 6,
        Int8 = 8
    }

    public unsafe struct Entry
    {
        public uint ID;
        public uint Length;

		public byte StartByte;
		public byte EndByte;

        public DataType DataType;

        public byte[] Bin;
        public string String;
		public int Int32;
		public float Single;
		public byte Int8;

		public void SetBinData(byte[] bin)
		{
			if (DataType == DataType.Binary)
			{
				Bin = bin;

				return;
			}

			throw new Exception("Entry with ID " + ID + " is not a Binary entry!");
		}

		public void SetStringData(string str)
		{
			if (DataType == DataType.String)
			{
				String = str;

				return;
			}

			throw new Exception("Entry with ID " + ID + " is not a String entry!");
		}

		public void SetInt32Data(int int32)
		{
			if (DataType == DataType.Int32)
			{
				Int32 = int32;

				return;
			}

			throw new Exception("Entry with ID " + ID + " is not an Int32 entry!");
		}

		public void SetSingleData(float single)
		{
			if (DataType == DataType.Single)
			{
				Single = single;

				return;
			}

			throw new Exception("Entry with ID " + ID + " is not a Single entry!");
		}

		public void SetInt8Data(int int8)
		{
			if (DataType == DataType.Int8)
			{
				Int32 = int8;

				return;
			}

			throw new Exception("Entry with ID " + ID + " is not an Int8 entry!");
		}

		public byte[] GetBinData()
		{
			if (DataType == DataType.Binary)
			{
				return Bin;
			}

			throw new Exception("Entry with ID " + ID + " is not a Binary entry!");
		}

		public string GetStringData()
		{
			if (DataType == DataType.String)
			{
				return String;
			}

			throw new Exception("Entry with ID " + ID + " is not a String entry!");
		}

		public int GetInt32Data()
		{
			if (DataType == DataType.Int32)
			{
				return Int32;
			}

			throw new Exception("Entry with ID " + ID + " is not an Int32 entry!");
		}

		public float GetSingleData()
		{
			if (DataType == DataType.Single)
			{
				return Single;
			}

			throw new Exception("Entry with ID " + ID + " is not a Single entry!");
		}

		public byte GetInt8Data()
		{
			if (DataType == DataType.Int8)
			{
				return Int8;
			}

			throw new Exception("Entry with ID " + ID + " is not an Int8 entry!");
		}
    }

	public unsafe struct GoldenKeyEntry
	{
		public fixed byte Data[3];
	}

    class B2Profile
	{
		private Entry[] Entries;

		private GoldenKeyEntry[] GoldenKeyEntries;

		public int BadassRank;
		public int BadassTokens;
		public int BadassTokensUsed;
		public int BadassTokensEarned;
		public byte GoldenKeys;
		public int[] BonusStats;
		public double[] BonusStatsPercent;

		public B2Profile()
		{
			Array.Resize(ref Entries, 0);
			Array.Resize(ref GoldenKeyEntries, 0);

			BadassRank = 0;
			BadassTokens = 0;
			BadassTokensUsed = 0;
			BadassTokensEarned = 0;
			GoldenKeys = 0;
			Array.Resize(ref BonusStats, 0);
			Array.Resize(ref BonusStatsPercent, 0);
		}

		public bool Load(string path)
		{
			FileStream inputFile = File.OpenRead(path); // TODO exception handling

			BinaryReader inputFileStream = new BinaryReader(inputFile);

			inputFileStream.ReadBytes(20); // read SHA1 hash into nothing

			uint uncompressedSize = inputFileStream.ReadUInt32().Swap(); // Big Endian, so we need to swap it
			byte[] uncompressedBytes = new byte[uncompressedSize];

			uint compressedSize = (uint)inputFile.Length - 20 - sizeof(uint);
			byte[] compressedBytes = inputFileStream.ReadBytes((int)compressedSize);

			inputFileStream.Close(); // no longer needed at this point

			int actualUncompressedSize = (int)uncompressedSize;

			MiniLZO.ErrorCode result = MiniLZO.LZO.DecompressSafe(compressedBytes, 0, (int)compressedSize, uncompressedBytes, 0, ref actualUncompressedSize);

			if (result != MiniLZO.ErrorCode.Success)
			{
				Console.WriteLine("error: couldn't decompress " + path);

				return false;
			}

			FileStream decompressedFile = File.Create(path + ".dat");
			decompressedFile.Write(uncompressedBytes, 0, (int)uncompressedSize); // dump the file for debugging purposes
			decompressedFile.Close();

			LoadEntries(new Reader(new MemoryStream(uncompressedBytes), Endian.Big));

			return true;
		}

		public bool Save(string path)
		{
			MemoryStream uncompressedStream = new MemoryStream();

			SaveEntries(new Writer(uncompressedStream, Endian.Big));

			FileStream uncompressedFile = File.Create(path + ".dat");
			uncompressedFile.Write(uncompressedStream.ToArray(), 0, (int)uncompressedStream.Length); // dump the file for debugging purposes
			uncompressedFile.Close();

			byte[] compressedBytes = new byte[uncompressedStream.Length];
			int actualCompressedLength = (int)uncompressedStream.Length;

			MiniLZO.LZO.Compress(uncompressedStream.ToArray(), 0, (int)uncompressedStream.Length, compressedBytes, 0, ref actualCompressedLength, new MiniLZO.CompressWorkBuffer());

			SHA1Managed sha1 = new SHA1Managed();
			byte[] hash = sha1.ComputeHash(compressedBytes, 0, actualCompressedLength);

			FileStream outputFile = File.Create(path); // TODO exception handling

			BinaryWriter outputFileStream = new BinaryWriter(outputFile);

			outputFileStream.Write(hash); // write SHA1 hash

			int actualUncompressedLength = (int)uncompressedStream.Length;
			outputFileStream.Write(actualUncompressedLength.Swap());

			outputFileStream.Write(compressedBytes, 0, actualCompressedLength);

			outputFileStream.Close();

			return true;
		}

        private void LoadEntries(Reader reader)
        {
			uint numEntries = reader.ReadUInt32();

			Array.Resize(ref Entries, (int)numEntries);

			for (uint i = 0; i < numEntries; i++)
			{

				Entries[i].StartByte = reader.ReadByte();

				Entries[i].ID = reader.ReadUInt32();
				Entries[i].DataType = (DataType)reader.ReadByte();

				switch (Entries[i].DataType)
				{
				case DataType.Int32:
					Entries[i].Int32 = reader.ReadInt32();

					break;
				case DataType.String:
					Entries[i].Length = (uint)reader.ReadInt32();
					Entries[i].String = reader.ReadASCII((int)Entries[i].Length);

					break;
				case DataType.Single:
					Entries[i].Single = reader.ReadSingle();

					break;
				case DataType.Binary:
					Entries[i].Length = (uint)reader.ReadInt32();
					Entries[i].Bin = reader.ReadBytes((int)Entries[i].Length, Endian.Little);

					break;
				case DataType.Int8:
					Entries[i].Int8 = reader.ReadByte();

					break;
				}

				Entries[i].EndByte = reader.ReadByte();
			}

			LoadEntryData();
		}

		private void SaveEntries(Writer writer)
		{
			SaveEntryData();

			writer.WriteUInt32((uint)Entries.Length);

			for (int i = 0; i < Entries.Length; i++)
			{
				writer.WriteByte(Entries[i].StartByte);

				writer.WriteUInt32(Entries[i].ID);
				writer.WriteByte((byte)Entries[i].DataType);

				switch (Entries[i].DataType)
				{
				case DataType.Int32:
					writer.WriteInt32(Entries[i].Int32);

					break;
				case DataType.String:
					writer.WriteInt32((int)Entries[i].Length);
					writer.WriteASCII(Entries[i].String, (int)Entries[i].Length);

					break;
				case DataType.Single:
					writer.WriteSingle(Entries[i].Single);

					break;
				case DataType.Binary:
					writer.WriteInt32((int)Entries[i].Length);
					writer.WriteBytes(Entries[i].Bin, (int)Entries[i].Length, Endian.Little);

					break;
				case DataType.Int8:
					writer.WriteByte(Entries[i].Int8);

					break;
				}

				writer.WriteByte(Entries[i].EndByte);
			}
		}

		private static string Alphabet = "0123456789ABCDEFGHJKMNPQRSTVWXYZ";
		private static uint MagicNumber = 0x9A3652D9;
		public static int NumBonusStats = 14;

		private unsafe void LoadEntryData()
		{
			BadassRank = (GetBadassRank1Entry().GetInt32Data() + GetBadassRank2Entry().GetInt32Data()) / 10;
			BadassTokens = GetBadassTokensEntry().GetInt32Data();
			BadassTokensEarned = GetBadassTokensEarnedEntry().GetInt32Data(); // This value is WRONG! It gets rounded instead of floored
			// BadassTokensUsed = BadassTokensEarned - BadassTokens;

			BadassTokensUsed = (int)Math.Floor(Math.Pow(BadassRank, 1 / 1.8)) - BadassTokens; // floor or round? that is the question. seems to actually be round

			// Console.WriteLine("Test1: " + ((int)Math.Round(Math.Pow(11, 1.8))));
			// Console.WriteLine("Test2: " + ((int)Math.Floor(Math.Pow(11, 1.8))));
			// 
			// Console.WriteLine("Test3: " + ((int)Math.Round(Math.Pow(387, 1.8))));
			// Console.WriteLine("Test4: " + ((int)Math.Floor(Math.Pow(387, 1.8))));
			// 
			// Console.WriteLine("Test3: " + ((int)Math.Round(Math.Pow(386, 1.8))));
			// Console.WriteLine("Test4: " + ((int)Math.Floor(Math.Pow(386, 1.8))));

			// Console.WriteLine("Test3: " + ((int)Math.Round(Math.Pow(74, 1 / 1.8))));
			// Console.WriteLine("Test4: " + ((int)Math.Floor(Math.Pow(74, 1 / 1.8))));
			// 
			// Console.WriteLine("Test3: " + ((int)Math.Round(Math.Pow(75, 1 / 1.8))));
			// Console.WriteLine("Test4: " + ((int)Math.Floor(Math.Pow(75, 1 / 1.8))));

			GoldenKeys = 0;

			if (GetGoldenKeysEntry().Length > 0)
			{
				// Golden Keys hackiness, TODO understand

				byte[] goldenKeysBin = GetGoldenKeysEntry().GetBinData();

				int numKeyEntries = goldenKeysBin.Length / 3;
				Array.Resize(ref GoldenKeyEntries, numKeyEntries);

				for (int i = 0; i < numKeyEntries; i++)
				{
					GoldenKeyEntries[i].Data[0] = goldenKeysBin[0 + i * 3];
					GoldenKeyEntries[i].Data[1] = goldenKeysBin[1 + i * 3];
					GoldenKeyEntries[i].Data[2] = goldenKeysBin[2 + i * 3];
				}

				for (int i = 0; i < numKeyEntries; i++)
				{
					GoldenKeys += (byte)(GoldenKeyEntries[i].Data[1] - GoldenKeyEntries[i].Data[2]);
				}
			}

			if (GetBonusStatsEntry().Length > 0)
			{
				Array.Resize(ref BonusStats, NumBonusStats);
				Array.Resize(ref BonusStatsPercent, NumBonusStats);

				string code = GetBonusStatsEntry().GetStringData();

				uint index = 0;
				uint value = MagicNumber;
				int shift = 0;

				uint j = 0;

				for (int i = 0; i < code.Length; i++)
				{
					index = (uint)Alphabet.IndexOf(code[i]);

					value ^= index << shift;

					shift += 5;

					if (shift > 31)
					{
						Console.WriteLine(value);

						BonusStats[j] = (int)value;
						BonusStatsPercent[j] = Math.Round(Math.Pow(BonusStats[j], 0.75), 1);
						j++;

						shift &= 7;
						value = (MagicNumber) ^ index >> 5 - shift;
					}
				}
			}
		}

		private unsafe void SaveEntryData()
		{
			int badassRankData = (BadassRank * 10) / 2;

			GetBadassRank1Entry().SetInt32Data(badassRankData);
			GetBadassRank2Entry().SetInt32Data(badassRankData);
			GetBadassTokensEntry().SetInt32Data(BadassTokens);
			GetBadassTokensEarnedEntry().SetInt32Data(BadassTokensEarned);

			if (GoldenKeys > 0)
			{
				// TODO investigate the two different values
				// idea: first value is for non shift codes, second is the real value
				// leave the first value untouched, increase the second value (if it exists, if not, touch the first value)
				// they may not exceed 255 in total
			}

			if (BonusStatsPercent.Length == NumBonusStats)
			{
				string code = "";

				uint index = 0;
				int shift = 0;

				for (int i = 0; i < NumBonusStats; i++)
				{
					// uint value = (uint)Math.Round(Math.Pow(BonusStatsPercent[i], 1 / 0.75));
					uint value = (uint)BonusStats[i];

					value ^= MagicNumber;

					if (shift > 0)
					{
						index = ((index | (value << shift)) & 0x1F);
						shift = 5 - shift;

						code += Alphabet[(int)index];
					}

					for (; shift < 28; shift += 5)
					{
						index = ((value >> shift) & 0x1F);

						code += Alphabet[(int)index];
					}

					index = value >> shift;
					shift = 32 - shift;
				}

				if (shift > 0)
				{
					code += Alphabet[(int)index];
				}

				GetBonusStatsEntry().SetStringData(code);

				Console.WriteLine(code);
			}
		}

		public ref Entry GetFromID(uint ID)
		{
			for (int i = 0; i < Entries.Length; i++)
			{
				if (Entries[i].ID == ID) return ref Entries[i];
			}

			throw new Exception("Entry with ID " + ID + " not found!");
		}

		// String (Encoded)
		public ref Entry GetBonusStatsEntry()
		{
			return ref GetFromID(143);
		}

		// Bin (Array)
		public ref Entry GetGoldenKeysEntry()
		{
			return ref GetFromID(162);
		}

		// Int32
		public ref Entry GetBadassRank1Entry()
		{
			return ref GetFromID(136);
		}

		// Int32
		public ref Entry GetBadassRank2Entry()
		{
			return ref GetFromID(137);
		}

		// Int32
		public ref Entry GetBadassTokensEntry()
		{
			return ref GetFromID(138);
		}

		// Int32
		public ref Entry GetBadassTokensEarnedEntry()
		{
			return ref GetFromID(139);
		}

		// Bin
		public ref Entry GetCustomizationsEntry()
		{
			return ref GetFromID(300);
		}

		public void SetMaximumHealth(double d)
		{
			BonusStatsPercent[0] = d;
		}

		public double GetMaximumHealth()
		{
			return BonusStatsPercent[0];
		}

		public void SetShieldCapacity(double d)
		{
			BonusStatsPercent[1] = d;
		}

		public double GetShieldCapacity()
		{
			return BonusStatsPercent[1];
		}

		public void SetShieldRechargeDelay(double d)
		{
			BonusStatsPercent[2] = d;
		}

		public double GetShieldRechargeDelay()
		{
			return BonusStatsPercent[2];
		}

		public void SetShieldRechargeRate(double d)
		{
			BonusStatsPercent[3] = d;
		}

		public double GetShieldRechargeRate()
		{
			return BonusStatsPercent[3];
		}

		public void SetMeleeDamage(double d)
		{
			BonusStatsPercent[4] = d;
		}

		public double GetMeleeDamage()
		{
			return BonusStatsPercent[4];
		}

		public void SetGrenadeDamage(double d)
		{
			BonusStatsPercent[5] = d;
		}

		public double GetGrenadeDamage()
		{
			return BonusStatsPercent[5];
		}

		public void SetGunAccuracy(double d)
		{
			BonusStatsPercent[6] = d;
		}

		public double GetGunAccuracy()
		{
			return BonusStatsPercent[6];
		}

		public void SetGunDamage(double d)
		{
			BonusStatsPercent[7] = d;
		}

		public double GetGunDamage()
		{
			return BonusStatsPercent[7];
		}

		public void SetFireRate(double d)
		{
			BonusStatsPercent[8] = d;
		}

		public double GetFireRate()
		{
			return BonusStatsPercent[8];
		}

		public void SetRecoilReduction(double d)
		{
			BonusStatsPercent[9] = d;
		}

		public double GetRecoilReduction()
		{
			return BonusStatsPercent[9];
		}

		public void SetReloadSpeed(double d)
		{
			BonusStatsPercent[10] = d;
		}

		public double GetReloadSpeed()
		{
			return BonusStatsPercent[10];
		}

		public void SetElementalEffectChance(double d)
		{
			BonusStatsPercent[11] = d;
		}

		public double GetElementalEffectChance()
		{
			return BonusStatsPercent[11];
		}

		public void SetElementalEffectDamage(double d)
		{
			BonusStatsPercent[12] = d;
		}

		public double GetElementalEffectDamage()
		{
			return BonusStatsPercent[12];
		}

		public void SetCriticalHitDamage(double d)
		{
			BonusStatsPercent[13] = d;
		}

		public double GetCriticalHitDamage()
		{
			return BonusStatsPercent[13];
		}
    }
}
