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
		public double[] BonusStats;

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
		}

		public bool Read(string path)
		{
			FileStream inputFile = File.OpenRead(path); // TODO exception handling

			// BinaryReader inputFileStream = new BinaryReader(inputFile, Encoding.ASCII, true);
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

			FileStream decompressedFile = File.OpenWrite(path + ".dat");
			decompressedFile.Write(uncompressedBytes, 0, (int)uncompressedSize); // dump the file for debugging purposes
			decompressedFile.Close();

			ReadEntries(new Reader(new MemoryStream(uncompressedBytes), Endian.Big));

			return true;
		}

		public bool Write(string path)
		{
			MemoryStream uncompressedStream = new MemoryStream();

			WriteEntries(new Writer(uncompressedStream, Endian.Big));

			FileStream uncompressedFile = File.OpenWrite(path + ".dat");
			uncompressedFile.Write(uncompressedStream.ToArray(), 0, (int)uncompressedStream.Length); // dump the file for debugging purposes
			uncompressedFile.Close();

			byte[] compressedBytes = new byte[uncompressedStream.Length];
			int actualCompressedLength = (int)uncompressedStream.Length;

			MiniLZO.LZO.Compress(uncompressedStream.ToArray(), 0, (int)uncompressedStream.Length, compressedBytes, 0, ref actualCompressedLength, new MiniLZO.CompressWorkBuffer());

			SHA1Managed sha1 = new SHA1Managed();
			byte[] hash = sha1.ComputeHash(compressedBytes, 0, actualCompressedLength);

			FileStream outputFile = File.OpenWrite(path); // TODO exception handling

			// BinaryWriter outputFileStream = new BinaryWriter(outputFile, Encoding.ASCII, true);
			BinaryWriter outputFileStream = new BinaryWriter(outputFile);

			outputFileStream.Write(hash); // write SHA1 hash

			int actualUncompressedLength = (int)uncompressedStream.Length;
			outputFileStream.Write(actualUncompressedLength.Swap());

			outputFileStream.Write(compressedBytes, 0, actualCompressedLength);

			outputFileStream.Close();

			return true;
		}

        private void ReadEntries(Reader reader)
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

		private void WriteEntries(Writer writer)
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

		private unsafe void LoadEntryData()
		{
			BadassRank = (GetBadassRank1Entry().GetInt32Data() + GetBadassRank2Entry().GetInt32Data()) / 10;
			BadassTokens = GetBadassTokensEntry().GetInt32Data();

			BadassTokensUsed = (int)Math.Round(Math.Pow(BadassRank, 1 / 1.8)) - BadassTokens; // floor or round? that is the question. seems to actually be round

			// Console.WriteLine("Test1: " + ((int)Math.Round(Math.Pow(11, 1.8))));
			// Console.WriteLine("Test2: " + ((int)Math.Floor(Math.Pow(11, 1.8))));
			// 
			// Console.WriteLine("Test3: " + ((int)Math.Round(Math.Pow(387, 1.8))));
			// Console.WriteLine("Test4: " + ((int)Math.Floor(Math.Pow(387, 1.8))));
			// 
			// Console.WriteLine("Test3: " + ((int)Math.Round(Math.Pow(386, 1.8))));
			// Console.WriteLine("Test4: " + ((int)Math.Floor(Math.Pow(386, 1.8))));

			Console.WriteLine("Test3: " + ((int)Math.Round(Math.Pow(74, 1 / 1.8))));
			Console.WriteLine("Test4: " + ((int)Math.Floor(Math.Pow(74, 1 / 1.8))));

			Console.WriteLine("Test3: " + ((int)Math.Round(Math.Pow(75, 1 / 1.8))));
			Console.WriteLine("Test4: " + ((int)Math.Floor(Math.Pow(75, 1 / 1.8))));

			GoldenKeys = 0;

			if (GetGoldenKeysEntry().Length > 0)
			{
				// Golden Keys hackiness, TODO understand

				byte[] goldenKeysBin = GetGoldenKeysEntry().GetBinData();

				int numKeyEntries = goldenKeysBin.Length / 3;
				Array.Resize(ref GoldenKeyEntries, numKeyEntries);

				// Console.WriteLine("numKeyEntries: " + numKeyEntries);

				// Console.Write("Golden Keys Bin Data: ");

				for (int i = 0; i < numKeyEntries; i++)
				{
					GoldenKeyEntries[i].Data[0] = goldenKeysBin[0 + i * 3];
					GoldenKeyEntries[i].Data[1] = goldenKeysBin[1 + i * 3];
					GoldenKeyEntries[i].Data[2] = goldenKeysBin[2 + i * 3];

					// Console.Write(GoldenKeyEntries[i].Data[0] + " " + GoldenKeyEntries[i].Data[1] + " " + GoldenKeyEntries[i].Data[2] + " ");
				}

				// Console.WriteLine();

				// Console.WriteLine();

				for (int i = 0; i < numKeyEntries; i++)
				{
					GoldenKeys += (byte)(GoldenKeyEntries[i].Data[1] - GoldenKeyEntries[i].Data[2]);

					// Console.WriteLine("numKeys: " + GoldenKeys);
				}

				// Console.WriteLine("finalNumKeys: " + GoldenKeys);

				// Console.WriteLine();
			}

			if (GetBonusStatsEntry().Length > 0)
			{
				Array.Resize(ref BonusStats, 14);

				string code = GetBonusStatsEntry().GetStringData();

				byte index;
				uint value = MagicNumber;
				int shift = 0;

				uint j = 0;

				for (int i = 0; i < code.Length; i++)
				{
					index = (byte)Alphabet.IndexOf(code[i]);

					value ^= (uint)(index << shift);

					shift += 5;

					if (shift > 31)
					{
						BonusStats[j++] = Math.Round(Math.Pow(value, 0.75), 1);

						shift &= 7;
						value = (uint)((MagicNumber) ^ index >> 5 - shift);
					}
				}
			}

			if (GetInterestingEntry().Length > 0)
			{
				string code = GetInterestingEntry().GetStringData();

				byte index;
				uint value = MagicNumber;
				int shift = 0;

				uint j = 0;

				for (int i = 0; i < code.Length; i++)
				{
					index = (byte)Alphabet.IndexOf(code[i]);

					value ^= (uint)(index << shift);

					shift += 5;

					if (shift > 31)
					{
						// BonusStats[j++] = Math.Round(Math.Pow(value, 0.75), 1);

						// Console.WriteLine(Math.Round(Math.Pow(value, 0.75), 1));
						Console.WriteLine(value);
						// Console.WriteLine();

						shift &= 7;
						value = (uint)((MagicNumber) ^ index >> 5 - shift);
					}
				}

				Console.WriteLine();
			}
		}

		private unsafe void SaveEntryData()
		{
			Entry goldenKeysEntry = GetGoldenKeysEntry(); // Bin
			Entry bonusStatsEntry = GetBonusStatsEntry(); // String
			Entry badassRankEntry1 = GetBadassRank1Entry(); // Int32
			Entry badassRankEntry2 = GetBadassRank2Entry(); // Int32
			Entry badassTokensEntry = GetBadassTokensEntry(); // Int32

			int badassRankData = (BadassRank * 10) / 2;

			badassRankEntry1.SetInt32Data(badassRankData);
			badassRankEntry2.SetInt32Data(badassRankData);
			badassTokensEntry.SetInt32Data(BadassTokens);

			if (GoldenKeys > 0)
			{
				// TODO investigate the two different values
				// idea: first value is for non shift codes, second is the real value
				// leave the first value untouched, increase the second value (if it exists, if not, touch the first value)
				// they may not exceed 255 in total
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

		// String (Encoded)
		public ref Entry GetInterestingEntry()
		{
			return ref GetFromID(164);
		}

		public void SetMaximumHealth(double d)
		{
			BonusStats[0] = d;
		}

		public double GetMaximumHealth()
		{
			return BonusStats[0];
		}

		public int GetMaximumHealthTokensInvested()
		{
			double d = GetMaximumHealth();



			return 0;
		}

		public void SetShieldCapacity(double d)
		{
			BonusStats[1] = d;
		}

		public double GetShieldCapacity()
		{
			return BonusStats[1];
		}

		public void SetShieldRechargeDelay(double d)
		{
			BonusStats[2] = d;
		}

		public double GetShieldRechargeDelay()
		{
			return BonusStats[2];
		}

		public void SetShieldRechargeRate(double d)
		{
			BonusStats[3] = d;
		}

		public double GetShieldRechargeRate()
		{
			return BonusStats[3];
		}

		public void SetMeleeDamage(double d)
		{
			BonusStats[4] = d;
		}

		public double GetMeleeDamage()
		{
			return BonusStats[4];
		}

		public void SetGrenadeDamage(double d)
		{
			BonusStats[5] = d;
		}

		public double GetGrenadeDamage()
		{
			return BonusStats[5];
		}

		public void SetGunAccuracy(double d)
		{
			BonusStats[6] = d;
		}

		public double GetGunAccuracy()
		{
			return BonusStats[6];
		}

		public void SetGunDamage(double d)
		{
			BonusStats[7] = d;
		}

		public double GetGunDamage()
		{
			return BonusStats[7];
		}

		public void SetFireRate(double d)
		{
			BonusStats[8] = d;
		}

		public double GetFireRate()
		{
			return BonusStats[8];
		}

		public void SetRecoilReduction(double d)
		{
			BonusStats[9] = d;
		}

		public double GetRecoilReduction()
		{
			return BonusStats[9];
		}

		public void SetReloadSpeed(double d)
		{
			BonusStats[10] = d;
		}

		public double GetReloadSpeed()
		{
			return BonusStats[10];
		}

		public void SetElementalEffectChance(double d)
		{
			BonusStats[11] = d;
		}

		public double GetElementalEffectChance()
		{
			return BonusStats[11];
		}

		public void SetElementalEffectDamage(double d)
		{
			BonusStats[12] = d;
		}

		public double GetElementalEffectDamage()
		{
			return BonusStats[12];
		}

		public void SetCriticalHitDamage(double d)
		{
			BonusStats[13] = d;
		}

		public double GetCriticalHitDamage()
		{
			return BonusStats[13];
		}
    }
}
