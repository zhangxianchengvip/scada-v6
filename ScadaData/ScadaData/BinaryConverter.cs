﻿/*
 * Copyright 2020 Mikhail Shiryaev
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *     http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 * 
 * 
 * Product  : Rapid SCADA
 * Module   : ScadaData
 * Summary  : Converts base data types to an array of bytes and vice versa
 * 
 * Author   : Mikhail Shiryaev
 * Created  : 2020
 * Modified : 2020
 */

using Scada.Data.Models;
using System;
using System.Text;

namespace Scada
{
    /// <summary>
    /// Converts base data types to an array of bytes and vice versa.
    /// <para>Преобразует базовые типы данных в массив байтов и наоборот.</para>
    /// </summary>
    /// <remarks>BinaryConverter uses little endian format.</remarks>
    public static class BinaryConverter
    {
        /// <summary>
        /// Copies the 8-bit unsigned integer to the buffer.
        /// </summary>
        public static void CopyByte(byte value, byte[] buffer, ref int index)
        {
            buffer[index++] = value;
        }

        /// <summary>
        /// Copies the boolean value to the buffer.
        /// </summary>
        public static void CopyBool(bool value, byte[] buffer, int index)
        {
            buffer[index] = (byte)(value ? 1 : 0);
        }

        /// <summary>
        /// Copies the boolean value to the buffer.
        /// </summary>
        public static void CopyBool(bool value, byte[] buffer, ref int index)
        {
            CopyBool(value, buffer, index++);
        }

        /// <summary>
        /// Copies the 16-bit unsigned integer to the buffer.
        /// </summary>
        public static void CopyUInt16(ushort value, byte[] buffer, int index)
        {
            buffer[index++] = (byte)value;
            buffer[index++] = (byte)(value >> 8);
        }

        /// <summary>
        /// Copies the 16-bit unsigned integer to the buffer.
        /// </summary>
        public static void CopyUInt16(ushort value, byte[] buffer, ref int index)
        {
            CopyUInt16(value, buffer, index);
            index += 2;
        }

        /// <summary>
        /// Copies the 32-bit signed integer to the buffer.
        /// </summary>
        public static void CopyInt32(int value, byte[] buffer, int index)
        {
            buffer[index++] = (byte)value;
            buffer[index++] = (byte)(value >> 8);
            buffer[index++] = (byte)(value >> 16);
            buffer[index++] = (byte)(value >> 24);
        }

        /// <summary>
        /// Copies the 32-bit signed integer to the buffer.
        /// </summary>
        public static void CopyInt32(int value, byte[] buffer, ref int index)
        {
            CopyInt32(value, buffer, index);
            index += 4;
        }

        /// <summary>
        /// Copies the 64-bit signed integer to the buffer.
        /// </summary>
        public static void CopyInt64(long value, byte[] buffer, int index)
        {
            buffer[index++] = (byte)value;
            buffer[index++] = (byte)(value >> 8);
            buffer[index++] = (byte)(value >> 16);
            buffer[index++] = (byte)(value >> 24);
            buffer[index++] = (byte)(value >> 32);
            buffer[index++] = (byte)(value >> 40);
            buffer[index++] = (byte)(value >> 48);
            buffer[index++] = (byte)(value >> 56);
        }

        /// <summary>
        /// Copies the 64-bit signed integer to the buffer.
        /// </summary>
        public static void CopyInt64(long value, byte[] buffer, ref int index)
        {
            CopyInt64(value, buffer, index);
            index += 8;
        }

        /// <summary>
        /// Copies the double-precision floating point number to the buffer.
        /// </summary>
        public static void CopyDouble(double value, byte[] buffer, int index)
        {
            CopyInt64(BitConverter.DoubleToInt64Bits(value), buffer, index);
        }

        /// <summary>
        /// Copies the double-precision floating point number to the buffer.
        /// </summary>
        public static void CopyDouble(double value, byte[] buffer, ref int index)
        {
            CopyInt64(BitConverter.DoubleToInt64Bits(value), buffer, index);
            index += 8;
        }

        /// <summary>
        /// Encodes and copies the string to the buffer.
        /// </summary>
        public static void CopyString(string s, byte[] buffer, ref int index)
        {
            int stringLength = s == null ? 0 : s.Length;

            if (stringLength == 0)
            {
                buffer[index++] = 0;
                buffer[index++] = 0;
            }
            else
            {
                byte[] stringData = Encoding.UTF8.GetBytes(s);
                int dataLength = stringData.Length;

                if (dataLength > ushort.MaxValue)
                    throw new ArgumentException("String length exceeded.");

                CopyUInt16((ushort)dataLength, buffer, ref index);
                stringData.CopyTo(buffer, index);
                index += dataLength;
            }
        }

        /// <summary>
        /// Encodes and copies the date and time to the buffer.
        /// </summary>
        public static void CopyTime(DateTime dateTime, byte[] buffer, int index)
        {
            CopyInt64(dateTime.Ticks, buffer, index);
        }

        /// <summary>
        /// Encodes and copies the date and time to the buffer.
        /// </summary>
        public static void CopyTime(DateTime dateTime, byte[] buffer, ref int index)
        {
            CopyInt64(dateTime.Ticks, buffer, index);
            index += 8;
        }

        /// <summary>
        /// Encodes and copies the input channel data to the buffer.
        /// </summary>
        public static void CopyCnlData(CnlData cnlData, byte[] buffer, ref int index)
        {
            CopyDouble(cnlData.Val, buffer, ref index);
            CopyUInt16((ushort)cnlData.Stat, buffer, ref index);
        }

        /// <summary>
        /// Encodes and copies the file name to the buffer.
        /// </summary>
        public static void CopyFileName(int directoryID, string path, byte[] buffer, ref int index)
        {
            CopyInt32(directoryID, buffer, ref index);
            CopyString(path, buffer, ref index);
        }

        /// <summary>
        /// Encodes and copies the array of bytes to the buffer.
        /// </summary>
        public static void CopyByteArray(byte[] srcArray, byte[] buffer, ref int index)
        {
            int arrayLength = srcArray == null ? 0 : srcArray.Length;
            CopyInt32(arrayLength, buffer, ref index);

            if (srcArray != null)
            {
                Buffer.BlockCopy(srcArray, 0, buffer, index, arrayLength);
                index += arrayLength;
            }
        }

        /// <summary>
        /// Encodes and copies the array of integers to the buffer.
        /// </summary>
        public static void CopyIntArray(int[] srcArray, byte[] buffer, ref int index)
        {
            int arrayLength = srcArray == null ? 0 : srcArray.Length;
            CopyInt32(arrayLength, buffer, ref index);

            if (srcArray != null)
            {
                int dataLength = arrayLength * 4;
                Buffer.BlockCopy(srcArray, 0, buffer, index, dataLength);
                index += dataLength;
            }
        }

        /// <summary>
        /// Encodes and copies the channel data array to the buffer.
        /// </summary>
        public static void CopyCnlDataArray(CnlData[] srcArray, byte[] buffer, ref int index)
        {
            int arrayLength = srcArray == null ? 0 : srcArray.Length;
            CopyInt32(arrayLength, buffer, ref index);

            if (srcArray != null)
            {
                foreach (CnlData cnlData in srcArray)
                {
                    CopyCnlData(cnlData, buffer, ref index);
                }
            }
        }

        /// <summary>
        /// Copies the event to the buffer.
        /// </summary>
        public static void CopyEvent(Event ev, byte[] buffer, ref int index)
        {
            CopyInt64(ev.EventID, buffer, ref index);
            CopyTime(ev.Timestamp, buffer, ref index);
            CopyBool(ev.Hidden, buffer, ref index);
            CopyInt32(ev.CnlNum, buffer, ref index);
            CopyInt32(ev.OutCnlNum, buffer, ref index);
            CopyInt32(ev.ObjNum, buffer, ref index);
            CopyInt32(ev.DeviceNum, buffer, ref index);
            CopyDouble(ev.PrevCnlVal, buffer, ref index);
            CopyUInt16((ushort)ev.PrevCnlStat, buffer, ref index);
            CopyDouble(ev.CnlVal, buffer, ref index);
            CopyUInt16((ushort)ev.CnlStat, buffer, ref index);
            CopyUInt16((ushort)ev.Severity, buffer, ref index);
            CopyBool(ev.AckRequired, buffer, ref index);
            CopyBool(ev.Ack, buffer, ref index);
            CopyTime(ev.AckTimestamp, buffer, ref index);
            CopyInt32(ev.AckUserID, buffer, ref index);
            CopyByte((byte)ev.TextFormat, buffer, ref index);
            CopyString(ev.Text, buffer, ref index);
            CopyByteArray(ev.Data, buffer, ref index);
        }


        /// <summary>
        /// Gets a 8-bit unsigned integer from the buffer.
        /// </summary>
        public static byte GetByte(byte[] buffer, ref int index)
        {
            return buffer[index++];
        }

        /// <summary>
        /// Gets a boolean value from the buffer.
        /// </summary>
        public static bool GetBool(byte[] buffer, ref int index)
        {
            return buffer[index++] > 0;
        }

        /// <summary>
        /// Gets a 16-bit unsigned integer from the buffer.
        /// </summary>
        public static ushort GetUInt16(byte[] buffer, ref int index)
        {
            ushort value = BitConverter.ToUInt16(buffer, index);
            index += 2;
            return value;
        }

        /// <summary>
        /// Gets a 32-bit signed integer from the buffer.
        /// </summary>
        public static int GetInt32(byte[] buffer, ref int index)
        {
            int value = BitConverter.ToInt32(buffer, index);
            index += 4;
            return value;
        }

        /// <summary>
        /// Gets a 64-bit signed integer from the buffer.
        /// </summary>
        public static long GetInt64(byte[] buffer, ref int index)
        {
            long value = BitConverter.ToInt64(buffer, index);
            index += 8;
            return value;
        }

        /// <summary>
        /// Gets a double-precision floating point number from the buffer.
        /// </summary>
        public static double GetDouble(byte[] buffer, ref int index)
        {
            double value = BitConverter.ToDouble(buffer, index);
            index += 8;
            return value;
        }

        /// <summary>
        /// Gets a string from the buffer.
        /// </summary>
        public static string GetString(byte[] buffer, int index)
        {
            int dataLength = BitConverter.ToUInt16(buffer, index);
            return dataLength > 0 ? Encoding.UTF8.GetString(buffer, index + 2, dataLength) : "";
        }

        /// <summary>
        /// Gets a string from the buffer.
        /// </summary>
        public static string GetString(byte[] buffer, ref int index)
        {
            int dataLength = GetUInt16(buffer, ref index);
            string s = dataLength > 0 ? Encoding.UTF8.GetString(buffer, index, dataLength) : "";
            index += dataLength;
            return s;
        }

        /// <summary>
        /// Gets date and time from the buffer.
        /// </summary>
        public static DateTime GetTime(byte[] buffer, ref int index)
        {
            DateTime value = new DateTime(BitConverter.ToInt64(buffer, index), DateTimeKind.Utc);
            index += 8;
            return value;
        }

        /// <summary>
        /// Gets an input channel data from the buffer.
        /// </summary>
        public static CnlData GetCnlData(byte[] buffer, ref int index)
        {
            return new CnlData(
                GetDouble(buffer, ref index),
                GetUInt16(buffer, ref index));
        }

        /// <summary>
        /// Gets an array of bytes from the buffer.
        /// </summary>
        public static byte[] GetByteArray(byte[] buffer, ref int index)
        {
            int arrayLength = GetInt32(buffer, ref index);

            if (arrayLength > 0)
            {
                byte[] array = new byte[arrayLength];
                Buffer.BlockCopy(buffer, index, array, 0, arrayLength);
                index += arrayLength;
                return array;
            }
            else
            {
                return new byte[0];
            }
        }

        /// <summary>
        /// Gets an array of integers from the buffer.
        /// </summary>
        public static int[] GetIntArray(byte[] buffer, ref int index)
        {
            int arrayLength = GetInt32(buffer, ref index);

            if (arrayLength > 0)
            {
                int[] array = new int[arrayLength];
                int dataLength = arrayLength * 4;
                Buffer.BlockCopy(buffer, index, array, 0, dataLength);
                index += dataLength;
                return array;
            }
            else
            {
                return new int[0];
            }
        }

        /// <summary>
        /// Gets a channel data array from the buffer.
        /// </summary>
        public static CnlData[] GetCnlDataArray(byte[] buffer, ref int index)
        {
            int arrayLength = BitConverter.ToInt32(buffer, index);
            index += 4;

            if (arrayLength > 0)
            {
                CnlData[] array = new CnlData[arrayLength];

                for (int i = 0; i < arrayLength; i++)
                {
                    array[i] = new CnlData(
                        BitConverter.ToDouble(buffer, index),
                        BitConverter.ToUInt16(buffer, index + 8));
                    index += 10;
                }

                return array;
            }
            else
            {
                return new CnlData[0];
            }
        }

        /// <summary>
        /// Gets an event from the buffer.
        /// </summary>
        public static Event GetEvent(byte[] buffer, ref int index)
        {
            Event ev = new Event();
            ev.EventID = GetInt64(buffer, ref index);
            ev.Timestamp = GetTime(buffer, ref index);
            ev.Hidden = GetBool(buffer, ref index);
            ev.CnlNum = GetInt32(buffer, ref index);
            ev.OutCnlNum = GetInt32(buffer, ref index);
            ev.ObjNum = GetInt32(buffer, ref index);
            ev.DeviceNum = GetInt32(buffer, ref index);
            ev.PrevCnlVal = GetDouble(buffer, ref index);
            ev.PrevCnlStat = GetUInt16(buffer, ref index);
            ev.CnlVal = GetDouble(buffer, ref index);
            ev.CnlStat = GetUInt16(buffer, ref index);
            ev.Severity = GetUInt16(buffer, ref index);
            ev.AckRequired = GetBool(buffer, ref index);
            ev.Ack = GetBool(buffer, ref index);
            ev.AckTimestamp = GetTime(buffer, ref index);
            ev.AckUserID = GetInt32(buffer, ref index);
            ev.TextFormat = (EventTextFormat)GetByte(buffer, ref index);
            ev.Text = GetString(buffer, ref index);
            ev.Data = GetByteArray(buffer, ref index);
            return ev;
        }
    }
}
