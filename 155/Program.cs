using System;
using System.Collections.Generic;
using System.IO;

namespace BinarySequence
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "﻿binary_sequence.txt";
            string[] lines = File.ReadAllLines(filePath);
            string binaryString = string.Join("", lines);
            int paddingLength = 8 - binaryString.Length % 8;
            if (paddingLength < 8)
            {
                binaryString = binaryString.PadRight(binaryString.Length + paddingLength, '0');
            }

            List<byte> bytes = new List<byte>();
            for (int i = 0; i < binaryString.Length; i += 8)
            {
                string byteString = binaryString.Substring(i, 8);
                byte b = Convert.ToByte(byteString, 2);
                bytes.Add(b);
            }

            bytes.Sort();
            Console.WriteLine("Уникальные числа:");
            foreach (byte b in bytes)
            {
                Console.Write(b + " ");
            }
            Console.WriteLine();
            int maxLength = 1;
            int currentLength = 1;
            byte previousByte = bytes[0];
            List<byte> longestSubsequence = new List<byte>();
            longestSubsequence.Add(previousByte);
            for (int i = 1; i < bytes.Count; i++)
            {
                byte currentByte = bytes[i];
                if (currentByte > previousByte)
                {
                    currentLength++;
                    if (currentLength > maxLength)
                    {
                        maxLength = currentLength;
                        longestSubsequence.Clear();
                        for (int j = i - maxLength + 1; j <= i; j++)
                        {
                            longestSubsequence.Add(bytes[j]);
                        }
                    }
                }
                else
                {
                    currentLength = 1;
                }
                previousByte = currentByte;
            }

            Console.WriteLine("Самая длинная подпоследовательность:");
            foreach (byte b in longestSubsequence)
            {
                Console.Write(b + " ");
            }
            Console.WriteLine("длина: " + maxLength);
        }
    }
}