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
using BL2Kit;

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

    public struct Entry
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
    }

    class B2Profile
    {
        public Entry[] Entries;

		public B2Profile()
		{
			Array.Resize(ref Entries, 0);
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

			FileStream outputFile = File.OpenWrite(path);

			// BinaryWriter outputFileStream = new BinaryWriter(outputFile, Encoding.ASCII, true);
			BinaryWriter outputFileStream = new BinaryWriter(outputFile);

			outputFileStream.Write(hash); // write SHA1 hash

			int actualUncompressedLength = (int)uncompressedStream.Length;
			outputFileStream.Write(actualUncompressedLength.Swap());

			outputFileStream.Write(compressedBytes, 0, actualCompressedLength);

			outputFileStream.Close();

			return true;
		}

        public void ReadEntries(Reader reader)
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
        }

		public void WriteEntries(Writer writer)
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

		public Nullable<Entry> GetFromID(uint ID)
		{
			for (int i = 0; i < Entries.Length; i++)
			{
				if (Entries[i].ID == ID) return Entries[i];
			}

			return null;
		}
    }
}
