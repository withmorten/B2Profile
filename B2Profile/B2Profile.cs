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

    unsafe public struct Entry
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
				Length = (uint)bin.Length;

				return;
			}

			throw new Exception("Entry with ID " + ID + " is not a Binary entry!");
		}

		public void SetStringData(string str)
		{
			if (DataType == DataType.String)
			{
				String = str;
				Length = (uint)str.Length;

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

	unsafe public struct GoldenKeyEntry
	{
		private byte SourceID;
		private byte NumKeys;
		private byte NumKeysUsed;

		private bool Valid;

		public GoldenKeyEntry(byte id) : this()
		{
			SourceID = id;
		}

		public byte GetSourceID()
		{
			return SourceID;
		}

		public void SetNumKeys(byte b)
		{
			NumKeys = b;

			Valid = true;
		}

		public byte GetNumKeys()
		{
			return NumKeys;
		}

		public void SetNumKeysUsed(byte b)
		{
			NumKeysUsed = b;

			Valid = true;
		}

		public byte GetNumKeysUsed()
		{
			return NumKeysUsed;
		}

		public bool IsValid()
		{
			return Valid;
		}
	}

    public class Profile
	{
		private Entry[] Entries;

		private GoldenKeyEntry GoldenKeysPOPremierClub;
		private GoldenKeyEntry GoldenKeysTulip;
		private GoldenKeyEntry GoldenKeysShift;

		private int BadassRank;
		private int BadassTokensAvailable;
		private int BadassTokensEarned;
		private List<uint> BonusStats;
		private List<uint> NextBonusStats;

		public Profile()
		{
			Array.Resize(ref Entries, 0);

			GoldenKeysPOPremierClub = new GoldenKeyEntry(254);
			GoldenKeysTulip = new GoldenKeyEntry(173);
			GoldenKeysShift = new GoldenKeyEntry(0);

			BonusStats = new List<uint>();
			NextBonusStats = new List<uint>();
		}

		public Profile(string path, bool dumpUncompressed = false) : this()
		{
			Load(path, dumpUncompressed);
		}

		public bool Load(string path, bool dumpUncompressed = false)
		{
			// for security reasons, create a backup of the file upon loading
			File.Copy(path, path + ".bak", true);

			// open input file
			FileStream inputFile = File.OpenRead(path); // TODO exception handling
			BinaryReader inputFileStream = new BinaryReader(inputFile);

			// read SHA1 hash into nothing
			inputFileStream.ReadBytes(20);

			// prepare uncompressed data
			uint uncompressedSize = inputFileStream.ReadUInt32().Swap(); // bswap for Big Endian
			byte[] uncompressedBytes = new byte[uncompressedSize];

			// read the compressed data
			uint compressedSize = (uint)inputFile.Length - 20 - sizeof(uint);
			byte[] compressedBytes = inputFileStream.ReadBytes((int)compressedSize);

			// and close the inptut file, no longer needed at this point
			inputFileStream.Close();

			// decompress the data
			int actualUncompressedSize = (int)uncompressedSize;
			MiniLZO.ErrorCode result = MiniLZO.LZO.DecompressSafe(compressedBytes, 0, (int)compressedSize, uncompressedBytes, 0, ref actualUncompressedSize);

			if (result != MiniLZO.ErrorCode.Success)
			{
				Console.WriteLine("error: couldn't decompress " + path);

				return false;
			}

			// dump the file for debugging purposes
			if (dumpUncompressed == true)
			{
				FileStream decompressedFile = File.Create(path + ".bak.dat");
				decompressedFile.Write(uncompressedBytes, 0, (int)uncompressedSize);
				decompressedFile.Close();
			}

			// parse the entries
			LoadEntries(new Reader(new MemoryStream(uncompressedBytes), Endian.Big));

			// and store the relevant data in our class
			LoadEntryData();

			return true;
		}

		public bool Save(string path, bool dumpUncompressed = false)
		{
			// add our class data back to the entries
			SaveEntryData();

			// store entries and prepare the uncompressed data
			MemoryStream uncompressedStream = new MemoryStream();
			SaveEntries(new Writer(uncompressedStream, Endian.Big));

			// dump the file for debugging purposes
			if (dumpUncompressed == true)
			{
				FileStream uncompressedFile = File.Create(path + ".dat");
				uncompressedFile.Write(uncompressedStream.ToArray(), 0, (int)uncompressedStream.Length);
				uncompressedFile.Close();
			}

			// prepare the compressed data
			byte[] compressedBytes = new byte[uncompressedStream.Length];
			int actualCompressedLength = (int)uncompressedStream.Length;

			// LZO compress the data
			MiniLZO.LZO.Compress(uncompressedStream.ToArray(), 0, (int)uncompressedStream.Length, compressedBytes, 0, ref actualCompressedLength, new MiniLZO.CompressWorkBuffer());

			// prepare the hashed data (length + compressed data)
			int actualUncompressedLength = (int)uncompressedStream.Length;
			byte[] hashedData = BitConverter.GetBytes(actualUncompressedLength.Swap()); // bswap for Big Endian
			Array.Resize(ref hashedData, 4 + actualCompressedLength);
			Array.Copy(compressedBytes, 0, hashedData, 4, actualCompressedLength);

			// hash the data
			SHA1Managed sha1 = new SHA1Managed();
			byte[] hash = sha1.ComputeHash(hashedData);

			// create output file and writer
			FileStream outputFile = File.Create(path); // TODO exception handling
			BinaryWriter outputFileStream = new BinaryWriter(outputFile);

			// write SHA1 hash and hashed data
			outputFileStream.Write(hash);
			outputFileStream.Write(hashedData);

			// and close the file
			outputFileStream.Close();

			return true;
		}

		public void SetBadassRank(int i)
		{
			BadassRank = i;
		}

		public int GetBadassRank()
		{
			return BadassRank;
		}

		public void SetBadassTokensAvailable(int i)
		{
			BadassTokensAvailable = i;
		}

		public int GetBadassTokensAvailable()
		{
			return BadassTokensAvailable;
		}

		public void SetBadassTokensEarned(int i)
		{
			BadassTokensEarned = i;
		}

		public int GetBadassTokensEarned()
		{
			return BadassTokensEarned;
		}

		public int GetBadassTokensInvested()
		{
			int r = 0;

			for (int i = 0; i < NumBonusStats; i++)
			{
				r += (int)BonusStats[i];
			}

			return r;
		}

		public ref List<uint> GetBonusStats()
		{
			return ref BonusStats;
		}

		public ref List<uint> GetNextBonusStats()
		{
			return ref NextBonusStats;
		}

		public ref Entry GetEntryFromID(uint ID)
		{
			for (int i = 0; i < Entries.Length; i++)
			{
				if (Entries[i].ID == ID) return ref Entries[i];
			}

			throw new Exception("Entry with ID " + ID + " not found!");
		}

		public void ResetBonusStats()
		{
			for (int i = 0; i < NumBonusStats; i++)
			{
				BadassTokensAvailable += (int)BonusStats[i];

				if (BadassTokensAvailable > BadassTokensEarned) BadassTokensAvailable = BadassTokensEarned;

				BonusStats[i] = 0;
			}
		}

		public void EvenlyDistributeTokens()
		{
			ResetBonusStats();

			while (BadassTokensAvailable > 0)
			{
				for (int i = 0; i < NumBonusStats; i++)
				{
					if (BadassTokensAvailable == 0) break;

					BonusStats[i]++;

					BadassTokensAvailable--;
				}
			}
		}

		public void UnlockAllCustomizations()
		{
			byte[] customizationsBin = GetCustomizationsEntry().GetBinData();

			for (int i = 0; i < customizationsBin.Length; i++)
			{
				customizationsBin[i] = 255;
			}

			GetCustomizationsEntry().SetBinData(customizationsBin);
		}

		public void LockAllCustomizations()
		{
			byte[] customizationsBin = GetCustomizationsEntry().GetBinData();

			for (int i = 0; i < customizationsBin.Length; i++)
			{
				customizationsBin[i] = 0;
			}

			GetCustomizationsEntry().SetBinData(customizationsBin);
		}

		private static string Alphabet = "0123456789ABCDEFGHJKMNPQRSTVWXYZ";
		private static uint MagicNumber = 0x9A3652D9;

		private static List<uint> DecodeString(string code)
		{
			List<uint> list = new List<uint>();

			uint index = 0;
			uint value = MagicNumber;
			int shift = 0;

			for (int i = 0; i < code.Length; i++)
			{
				index = (uint)Alphabet.IndexOf(code[i]);

				value ^= index << shift;

				shift += 5;

				if (shift > 31)
				{
					list.Add(value);

					shift &= 7;
					value = (MagicNumber) ^ index >> 5 - shift;
				}
			}

			return list;
		}

		private static string EncodeString(List<uint> list)
		{
			String code = "";

			uint index = 0;
			int shift = 0;

			for (int i = 0; i < list.Count; i++)
			{
				uint value = list[i];

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

			return code;
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
					Entries[i].Length = reader.ReadUInt32();
					Entries[i].String = reader.ReadASCII((int)Entries[i].Length);

					break;
				case DataType.Single:
					Entries[i].Single = reader.ReadSingle();

					break;
				case DataType.Binary:
					Entries[i].Length = reader.ReadUInt32();
					Entries[i].Bin = reader.ReadBytes((int)Entries[i].Length, Endian.Little);

					break;
				case DataType.Int8:
					Entries[i].Int8 = reader.ReadByte();

					break;
				}

				Entries[i].EndByte = reader.ReadByte();
			}
		}

		private void SaveEntries(Writer writer)
		{
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
					writer.WriteUInt32(Entries[i].Length);
					writer.WriteASCII(Entries[i].String, (int)Entries[i].Length);

					break;
				case DataType.Single:
					writer.WriteSingle(Entries[i].Single);

					break;
				case DataType.Binary:
					writer.WriteUInt32(Entries[i].Length);
					writer.WriteBytes(Entries[i].Bin, (int)Entries[i].Length, Endian.Little);

					break;
				case DataType.Int8:
					writer.WriteByte(Entries[i].Int8);

					break;
				}

				writer.WriteByte(Entries[i].EndByte);
			}
		}

		private static int NumBonusStats = 14;
		private static int NumNextBonusStats = 5;

		private unsafe void LoadEntryData()
		{
			// the badass rank seems to be stored in two entries and the final result calculated like this
			BadassRank = (GetBadassRank1Entry().GetInt32Data() + GetBadassRank2Entry().GetInt32Data()) / 10;

			// the current badass tokens available to invest
			BadassTokensAvailable = GetBadassTokensEntry().GetInt32Data();

			// the badass tokens earned from increasing the badass rank
			BadassTokensEarned = GetBadassTokensEarnedEntry().GetInt32Data();

			// golden keys:
			// there can be any number of entries
			// only these 3 however, are written by the game
			// ID   0: shift keys (SHiFT)
			// ID 173: mechromancer dlc (Tulip)
			// ID 254: preorder keys (POPremierClub)
			if (GetGoldenKeysEntry().Length > 0)
			{
				byte[] goldenKeysBin = GetGoldenKeysEntry().GetBinData();

				int numKeyEntries = goldenKeysBin.Length / 3;

				// only get the 3 known entries - odd things happen if you have more than 999 (and who needs that anyway)
				for (int i = 0; i < numKeyEntries; i++)
				{
					byte sourceId = goldenKeysBin[0 + i * 3];
					byte numKeys = goldenKeysBin[1 + i * 3];
					byte numKeysUsed = goldenKeysBin[2 + i * 3];

					switch (sourceId)
					{
					case 254:
						GoldenKeysPOPremierClub.SetNumKeys(numKeys);
						GoldenKeysPOPremierClub.SetNumKeysUsed(numKeysUsed);

						break;
					case 173:
						GoldenKeysTulip.SetNumKeys(numKeys);
						GoldenKeysTulip.SetNumKeysUsed(numKeysUsed);

						break;
					case 0:
						GoldenKeysShift.SetNumKeys(numKeys);
						GoldenKeysShift.SetNumKeysUsed(numKeysUsed);

						break;
					}
				}
			}

			// the invested bonus tokens, always 14 statss, fixed order, very weird encoding
			if (GetBonusStatsEntry().Length > 0)
			{
				BonusStats = DecodeString(GetBonusStatsEntry().GetStringData());
			}
			else
			{
				for (int i = 0; i < NumBonusStats; i++)
				{
					BonusStats.Add(0);
				}
			}

			// the next bonus tokens you'll be offered, same indexes as the bonus stats list, very weird encoding
			if (GetNextBonusStatsEntry().Length > 0)
			{
				NextBonusStats = DecodeString(GetNextBonusStatsEntry().GetStringData());
			}
			else
			{
				Random random = new Random();

				for (int i = 0; i < NumNextBonusStats; i++)
				{
					uint nextBonusStat = (uint)random.Next(0, NumBonusStats);

					while (NextBonusStats.Contains(nextBonusStat) == true)
					{
						nextBonusStat = (uint)random.Next(0, NumBonusStats);
					}

					NextBonusStats.Add(nextBonusStat);
				}
			}
		}

		private unsafe void SaveEntryData()
		{
			// "split" the badass rank again ... no idea why this was done
			int badassRankData = (BadassRank * 10) / 2;
			GetBadassRank1Entry().SetInt32Data(badassRankData);
			GetBadassRank2Entry().SetInt32Data(badassRankData);

			GetBadassTokensEntry().SetInt32Data(BadassTokensAvailable);
			GetBadassTokensEarnedEntry().SetInt32Data(BadassTokensEarned);

			byte[] goldenKeysBin = new byte[0];
			int numKeyEntries = 0;

			if (GoldenKeysPOPremierClub.IsValid() == true)
			{
				Array.Resize(ref goldenKeysBin, goldenKeysBin.Length + 3);

				goldenKeysBin[0 + numKeyEntries * 3] = GoldenKeysPOPremierClub.GetSourceID();
				goldenKeysBin[1 + numKeyEntries * 3] = GoldenKeysPOPremierClub.GetNumKeys();
				goldenKeysBin[2 + numKeyEntries * 3] = GoldenKeysPOPremierClub.GetNumKeysUsed();

				numKeyEntries++;
			}

			if (GoldenKeysTulip.IsValid() == true)
			{
				Array.Resize(ref goldenKeysBin, goldenKeysBin.Length + 3);

				goldenKeysBin[0 + numKeyEntries * 3] = GoldenKeysTulip.GetSourceID();
				goldenKeysBin[1 + numKeyEntries * 3] = GoldenKeysTulip.GetNumKeys();
				goldenKeysBin[2 + numKeyEntries * 3] = GoldenKeysTulip.GetNumKeysUsed();

				numKeyEntries++;
			}

			if (GoldenKeysShift.IsValid() == true)
			{
				Array.Resize(ref goldenKeysBin, goldenKeysBin.Length + 3);

				goldenKeysBin[0 + numKeyEntries * 3] = GoldenKeysShift.GetSourceID();
				goldenKeysBin[1 + numKeyEntries * 3] = GoldenKeysShift.GetNumKeys();
				goldenKeysBin[2 + numKeyEntries * 3] = GoldenKeysShift.GetNumKeysUsed();

				numKeyEntries++;
			}

			GetGoldenKeysEntry().SetBinData(goldenKeysBin);

			if (BonusStats.Count == NumBonusStats)
			{
				GetBonusStatsEntry().SetStringData(EncodeString(BonusStats));
			}

			if (NextBonusStats.Count == NumNextBonusStats)
			{
				GetNextBonusStatsEntry().SetStringData(EncodeString(NextBonusStats));
			}
		}

		// String (Encoded)
		public ref Entry GetBonusStatsEntry()
		{
			return ref GetEntryFromID(143);
		}

		// String (Encoded)
		public ref Entry GetNextBonusStatsEntry()
		{
			return ref GetEntryFromID(164);
		}

		// Bin (GoldenKeyEntry)
		public ref Entry GetGoldenKeysEntry()
		{
			return ref GetEntryFromID(162);
		}

		// Int32
		public ref Entry GetBadassRank1Entry()
		{
			return ref GetEntryFromID(136);
		}

		// Int32
		public ref Entry GetBadassRank2Entry()
		{
			return ref GetEntryFromID(137);
		}

		// Int32
		public ref Entry GetBadassTokensEntry()
		{
			return ref GetEntryFromID(138);
		}

		// Int32
		public ref Entry GetBadassTokensEarnedEntry()
		{
			return ref GetEntryFromID(139);
		}

		// Bin
		public ref Entry GetCustomizationsEntry()
		{
			return ref GetEntryFromID(300);
		}

		public ref GoldenKeyEntry GetGoldenKeysPOPremierClubEntry()
		{
			return ref GoldenKeysPOPremierClub;
		}

		public ref GoldenKeyEntry GetGoldenKeysTulipEntry()
		{
			return ref GoldenKeysTulip;
		}

		public ref GoldenKeyEntry GetGoldenKeysShiftEntry()
		{
			return ref GoldenKeysShift;
		}

		public static int GetBadassRankFromTokens(uint t)
		{
			return (int)Math.Floor(Math.Pow(t, 1.8));
		}

		public static double GetBonusPercentFromTokens(uint t)
		{
			return Math.Round(Math.Pow(t, 0.75), 1);
		}

		public void SetMaximumHealthTokens(uint t)
		{
			BonusStats[0] = t;
		}

		public uint GetMaximumHealthTokens()
		{
			return BonusStats[0];
		}

		public double GetMaximumHealthBonus()
		{
			return Profile.GetBonusPercentFromTokens(BonusStats[0]);
		}

		public void SetShieldCapacityTokens(uint t)
		{
			BonusStats[1] = t;
		}

		public uint GetShieldCapacityTokens()
		{
			return BonusStats[1];
		}

		public double GetShieldCapacityBonus()
		{
			return Profile.GetBonusPercentFromTokens(BonusStats[1]);
		}

		public void SetShieldRechargeDelayTokens(uint t)
		{
			BonusStats[2] = t;
		}

		public uint GetShieldRechargeDelayTokens()
		{
			return BonusStats[2];
		}

		public double GetShieldRechargeDelayBonus()
		{
			return Profile.GetBonusPercentFromTokens(BonusStats[2]);
		}

		public void SetShieldRechargeRateTokens(uint t)
		{
			BonusStats[3] = t;
		}

		public uint GetShieldRechargeRateTokens()
		{
			return BonusStats[3];
		}

		public double GetShieldRechargeRateBonus()
		{
			return Profile.GetBonusPercentFromTokens(BonusStats[3]);
		}

		public void SetMeleeDamageTokens(uint t)
		{
			BonusStats[4] = t;
		}

		public uint GetMeleeDamageTokens()
		{
			return BonusStats[4];
		}

		public double GetMeleeDamageBonus()
		{
			return Profile.GetBonusPercentFromTokens(BonusStats[4]);
		}

		public void SetGrenadeDamageTokens(uint t)
		{
			BonusStats[5] = t;
		}

		public uint GetGrenadeDamageTokens()
		{
			return BonusStats[5];
		}

		public double GetGrenadeDamageBonus()
		{
			return Profile.GetBonusPercentFromTokens(BonusStats[5]);
		}

		public void SetGunAccuracyTokens(uint t)
		{
			BonusStats[6] = t;
		}

		public uint GetGunAccuracyTokens()
		{
			return BonusStats[6];
		}

		public double GetGunAccuracyBonus()
		{
			return Profile.GetBonusPercentFromTokens(BonusStats[6]);
		}

		public void SetGunDamageTokens(uint t)
		{
			BonusStats[7] = t;
		}

		public uint GetGunDamageTokens()
		{
			return BonusStats[7];
		}

		public double GetGunDamageBonus()
		{
			return Profile.GetBonusPercentFromTokens(BonusStats[7]);
		}

		public void SetFireRateTokens(uint t)
		{
			BonusStats[8] = t;
		}

		public uint GetFireRateTokens()
		{
			return BonusStats[8];
		}

		public double GetFireRateBonus()
		{
			return Profile.GetBonusPercentFromTokens(BonusStats[8]);
		}

		public void SetRecoilReductionTokens(uint t)
		{
			BonusStats[9] = t;
		}

		public uint GetRecoilReductionTokens()
		{
			return BonusStats[9];
		}

		public double GetRecoilReductionBonus()
		{
			return Profile.GetBonusPercentFromTokens(BonusStats[9]);
		}

		public void SetReloadSpeedTokens(uint t)
		{
			BonusStats[10] = t;
		}

		public uint GetReloadSpeedTokens()
		{
			return BonusStats[10];
		}

		public double GetReloadSpeedBonus()
		{
			return Profile.GetBonusPercentFromTokens(BonusStats[10]);
		}

		public void SetElementalEffectChanceTokens(uint t)
		{
			BonusStats[11] = t;
		}

		public uint GetElementalEffectChanceTokens()
		{
			return BonusStats[11];
		}

		public double GetElementalEffectChanceBonus()
		{
			return Profile.GetBonusPercentFromTokens(BonusStats[11]);
		}

		public void SetElementalEffectDamageTokens(uint t)
		{
			BonusStats[12] = t;
		}

		public uint GetElementalEffectDamageTokens()
		{
			return BonusStats[12];
		}

		public double GetElementalEffectDamageBonus()
		{
			return Profile.GetBonusPercentFromTokens(BonusStats[12]);
		}

		public void SetCriticalHitDamageTokens(uint t)
		{
			BonusStats[13] = t;
		}

		public uint GetCriticalHitDamageTokens()
		{
			return BonusStats[13];
		}

		public double GetCriticalHitDamageBonus()
		{
			return Profile.GetBonusPercentFromTokens(BonusStats[13]);
		}
	}
}
