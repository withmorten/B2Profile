using System;
using System.IO;
using System.Collections.Generic;
using System.Security.Cryptography;
using PackageIO;

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

		public long Offset;

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
		public static class BonusStatID
		{
			public const int MaximumHealth = 0;
			public const int ShieldCapacity = 1;
			public const int ShieldRechargeDelay = 2;
			public const int ShieldRechargeRate = 3;
			public const int MeleeDamage = 4;
			public const int GrenadeDamage = 5;
			public const int GunAccuracy = 6;
			public const int GunDamage = 7;
			public const int FireRate = 8;
			public const int RecoilReduction = 9;
			public const int ReloadSpeed = 10;
			public const int ElementalEffectChance = 11;
			public const int ElementalEffectDamage = 12;
			public const int CriticalHitDamage = 13;
		}

		public enum EntryID : uint
		{
			NumProfileSaved = 27, // Int32
			FOV = 129, // Int32
			ClaptrapsStathSlot1 = 130, // Bin
			ClaptrapsStathSlot2 = 131, // Bin
			ClaptrapsStathSlot3 = 132, // Bin
			ClaptrapsStathSlot4 = 133, // Bin
			BadassRank1 = 136, // Int32
			BadassRank2 = 137, // Int32
			BadassTokens = 138, // Int32
			BadassTokensEarned = 139, // Int32
			BonusStats = 143, // String (Encoded)
			GoldenKeys = 162, // Bin (GoldenKeyEntry)
			NextBonusStats = 164, // String (Encoded)
			Customizations = 300, // Bin
		}

		private Entry[] Entries;

		public const int MaxGoldenKeys = 255;
		public const int MaxGoldenKeysTotal = MaxGoldenKeys * 3;

		public GoldenKeyEntry GoldenKeysPOPremierClub;
		public GoldenKeyEntry GoldenKeysTulip;
		public GoldenKeyEntry GoldenKeysShift;

		public long BadassRank;
		public int BadassTokensAvailable;
		public int BadassTokensEarned;

		public const int NumBonusStats = 14;
		public const int NumNextBonusStats = 5;

		public List<uint> BonusStats;
		public List<uint> NextBonusStats;

		public List<bool> IgnoreBonusStats;

		public bool IsPreSequel = false;

		public Profile()
		{
			Array.Resize(ref Entries, 0);

			GoldenKeysPOPremierClub = new GoldenKeyEntry(254);
			GoldenKeysTulip = new GoldenKeyEntry(173);
			GoldenKeysShift = new GoldenKeyEntry(0);

			BonusStats = new List<uint>();
			NextBonusStats = new List<uint>();

			IgnoreBonusStats = new List<bool>(NumBonusStats);

			for (int i = 0; i < NumBonusStats; i++)
			{
				IgnoreBonusStats.Add(false);
			}
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

		public int GetBadassTokensInvested()
		{
			int t = 0;

			for (int i = 0; i < NumBonusStats; i++)
			{
				t += (int)BonusStats[i];
			}

			return t;
		}

		public ref Entry GetEntry(uint ID)
		{
			for (int i = 0; i < Entries.Length; i++)
			{
				if (Entries[i].ID == ID) return ref Entries[i];
			}

			throw new Exception("Entry with ID " + ID + " not found!");
		}

		public ref Entry GetEntry(EntryID ID)
		{
			return ref GetEntry(((uint)ID));
		}

		public void ResetBonusStats()
		{
			for (int i = 0; i < Profile.NumBonusStats; i++)
			{
				if (IgnoreBonusStats[i] == false)
				{
					BadassTokensAvailable += (int)BonusStats[i];

					if (BadassTokensAvailable > BadassTokensEarned) BadassTokensAvailable = BadassTokensEarned;

					BonusStats[i] = 0;
				}
			}
		}

		public void EvenlyDistributeTokens()
		{
			// to prevent an infinite loop, check if every stat is ignored first

			bool allIsIgnored = true;

			for (int i = 0; i < Profile.NumBonusStats; i++)
			{
				if (IgnoreBonusStats[i] == false) allIsIgnored = false;
			}

			if (allIsIgnored == true) return;

			while (BadassTokensAvailable > 0)
			{
				for (int i = 0; i < Profile.NumBonusStats; i++)
				{
					if (BadassTokensAvailable == 0) break;

					if (IgnoreBonusStats[i] == false)
					{
						BonusStats[i]++;

						BadassTokensAvailable--;
					}
				}
			}
		}

		public void UnlockAllCustomizations()
		{
			Entry customizationsEntry = GetEntry(EntryID.Customizations);
			byte[] customizationsBin = customizationsEntry.GetBinData();

			for (int i = 0; i < customizationsBin.Length; i++)
			{
				customizationsBin[i] = byte.MaxValue;
			}

			customizationsEntry.SetBinData(customizationsBin);
		}

		public void LockAllCustomizations()
		{
			Entry customizationsEntry = GetEntry(EntryID.Customizations);
			byte[] customizationsBin = customizationsEntry.GetBinData();

			for (int i = 0; i < customizationsBin.Length; i++)
			{
				customizationsBin[i] = byte.MinValue;
			}

			customizationsEntry.SetBinData(customizationsBin);
		}

		private static string Alphabet = "0123456789ABCDEFGHJKMNPQRSTVWXYZ";
		private static uint MagicNumber = 0x9A3652D9;

		private static List<uint> DecodeString(string code)
		{
			List<uint> list = new List<uint>();

			uint index = 0;
			uint value = Profile.MagicNumber;
			int shift = 0;

			for (int i = 0; i < code.Length; i++)
			{
				index = (uint)Profile.Alphabet.IndexOf(code[i]);

				value ^= index << shift;

				shift += 5;

				if (shift > 31)
				{
					list.Add(value);

					shift &= 7;
					value = (Profile.MagicNumber) ^ index >> 5 - shift;
				}
			}

			return list;
		}

		private static string EncodeString(List<uint> list)
		{
			string code = "";

			uint index = 0;
			int shift = 0;

			for (int i = 0; i < list.Count; i++)
			{
				uint value = list[i];

				value ^= Profile.MagicNumber;

				if (shift > 0)
				{
					index = ((index | (value << shift)) & 0x1F);
					shift = 5 - shift;

					code += Profile.Alphabet[(int)index];
				}

				for (; shift < 28; shift += 5)
				{
					index = ((value >> shift) & 0x1F);

					code += Profile.Alphabet[(int)index];
				}

				index = value >> shift;
				shift = 32 - shift;
			}

			if (shift > 0)
			{
				code += Profile.Alphabet[(int)index];
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

				Entries[i].Offset = reader.Position;

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

		public void PrintEntries()
		{
			Console.WriteLine("numEntries: " + Entries.Length);
			Console.WriteLine();

			for (int i = 0; i < Entries.Length; i++)
			{
				Console.WriteLine("Entry nr: " + i);
				Console.WriteLine("Position: " + Entries[i].Offset);

				Console.Write("ID: " + Entries[i].ID);

				if (Enum.IsDefined(typeof(EntryID), Entries[i].ID))
				{
					Console.Write(" (" + Enum.GetName(typeof(EntryID), Entries[i].ID) + ")");
				}

				Console.WriteLine();

				Console.WriteLine("DataType: " + Entries[i].DataType.ToString());

				switch (Entries[i].DataType)
				{
				case DataType.Int32:
					Console.WriteLine("Value: " + Entries[i].Int32);

					break;
				case DataType.String:
					Console.WriteLine("Value: " + Entries[i].String);

					break;
				case DataType.Single:
					Console.WriteLine("Value: " + Entries[i].Single);

					break;
				case DataType.Binary:
					Console.Write("Value:");

					for (int j = 0; j < Entries[i].Length; j++)
					{
						Console.Write(" " + Entries[i].Bin[j]);
					}

					Console.WriteLine();

					break;
				case DataType.Int8:
					Console.WriteLine("Value: " + Entries[i].Int8);

					break;
				}

				Console.WriteLine();
			}
		}

		private unsafe void LoadEntryData()
		{
			// the badass rank seems to be stored in two entries and the final result calculated like this
			BadassRank = (GetEntry(EntryID.BadassRank1).GetInt32Data() + GetEntry(EntryID.BadassRank2).GetInt32Data()) / 10;

			// the current badass tokens available to invest
			BadassTokensAvailable = GetEntry(EntryID.BadassTokens).GetInt32Data();

			// the badass tokens earned from increasing the badass rank
			BadassTokensEarned = GetEntry(EntryID.BadassTokensEarned).GetInt32Data();

			// golden keys:
			// there can be any number of entries
			// only these 3 however, are written by the game
			// ID   0: shift keys (SHiFT)
			// ID 173: mechromancer dlc (Tulip)
			// ID 254: preorder keys (POPremierClub)
			Entry goldenKeysEntry = GetEntry(EntryID.GoldenKeys);

			if (goldenKeysEntry.Length > 0)
			{
				byte[] goldenKeysBin = goldenKeysEntry.GetBinData();

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

			// the invested bonus tokens, always 14 stats, fixed order, very weird encoding
			Entry bonusStatsEntry = GetEntry(EntryID.BonusStats);

			if (bonusStatsEntry.Length > 0)
			{
				BonusStats = DecodeString(bonusStatsEntry.GetStringData());
			}
			else
			{
				for (int i = 0; i < NumBonusStats; i++)
				{
					BonusStats.Add(0);
				}
			}

#if true
			// the next bonus tokens you'll be offered, same indexes as the bonus stats list, very weird encoding
			Entry nextBonusStatsEntry = GetEntry(EntryID.NextBonusStats);

			if (nextBonusStatsEntry.Length > 0)
			{
				NextBonusStats = DecodeString(nextBonusStatsEntry.GetStringData());
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
#endif
		}

		private unsafe void SaveEntryData()
		{
			// "split" the badass rank again ... no idea why this was done
			int badassRankData = (int)((BadassRank * 10) / 2);
			GetEntry(EntryID.BadassRank1).SetInt32Data(badassRankData);
			GetEntry(EntryID.BadassRank2).SetInt32Data(badassRankData);

			GetEntry(EntryID.BadassTokens).SetInt32Data(BadassTokensAvailable);
			GetEntry(EntryID.BadassTokensEarned).SetInt32Data(BadassTokensEarned);

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

			GetEntry(EntryID.GoldenKeys).SetBinData(goldenKeysBin);

			if (BonusStats.Count == NumBonusStats)
			{
				GetEntry(EntryID.BonusStats).SetStringData(EncodeString(BonusStats));
			}

			if (NextBonusStats.Count == NumNextBonusStats)
			{
				GetEntry(EntryID.NextBonusStats).SetStringData(EncodeString(NextBonusStats));
			}
		}

		public ref Entry GetClaptrapsStashSlotEntry(int slot)
		{
			switch (slot)
			{
			case 1:
				return ref GetEntry(EntryID.ClaptrapsStathSlot1);

			case 2:
				return ref GetEntry(EntryID.ClaptrapsStathSlot2);

			case 3:
				return ref GetEntry(EntryID.ClaptrapsStathSlot3);

			case 4:
				return ref GetEntry(EntryID.ClaptrapsStathSlot4);

			default:
				throw new Exception("Invalid weapon index!");
			}
		}

		public bool IsClaptrapsStashSlotValid(int slot)
		{
			byte[] slotData = GetClaptrapsStashSlotEntry(slot).GetBinData();

			for (int i = 0; i < slotData.Length; i++)
			{
				if (slotData[i] != 0x00) return true;
			}

			return false;
		}

		private string GetGibbedPrefix()
		{
			return IsPreSequel == false ? "BL2" : "BLOZ";
		}

		public string GetClaptrapsStashSlotGibbedCode(int slot)
		{
			return GetGibbedPrefix() + "(" + Convert.ToBase64String(GetClaptrapsStashSlotEntry(slot).GetBinData()) + ")";
		}

		public bool SetClaptrapsStashSlotGibbedCode(int slot, string gibbedCode)
		{
			string prefix = GetGibbedPrefix();

			if (gibbedCode == string.Empty) return false;

			if (gibbedCode.Length < prefix.Length + 1 + 1) return false;

			if (gibbedCode.Substring(0, prefix.Length + 1) != prefix + "(" && gibbedCode[gibbedCode.Length - 1] != ')') return false;

			byte[] slotData;

			try
			{
				slotData = Convert.FromBase64String(gibbedCode.Substring(prefix.Length + 1, gibbedCode.Length - (prefix.Length + 1 + 1)));
			}
			catch (Exception)
			{
				return false;
			}

			GetClaptrapsStashSlotEntry(slot).SetBinData(slotData);

			return true;
		}

		public void DeleteClaptrapsStashSlot(int slot)
		{
			SetClaptrapsStashSlotGibbedCode(slot, GetGibbedPrefix() + "(AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA==)");
		}

		public static int GetBadassRankFromTokens(uint t)
		{
			return (int)Math.Floor(Math.Pow(t, 1.8));
		}

		public static double GetBonusPercentFromTokens(uint t)
		{
			return Math.Round(Math.Pow(t, 0.75), 1);
		}
	}
}
