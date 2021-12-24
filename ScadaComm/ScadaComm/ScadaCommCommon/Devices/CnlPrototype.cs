﻿/*
 * Copyright 2021 Rapid Software LLC
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
 * Module   : ScadaCommCommon
 * Summary  : Represents a channel prototype
 * 
 * Author   : Mikhail Shiryaev
 * Created  : 2020
 * Modified : 2021
 */

using Scada.Data.Entities;
using System;

namespace Scada.Comm.Devices
{
    /// <summary>
    /// Represents a channel prototype.
    /// <para>Представляет прототип канала.</para>
    /// </summary>
    public class CnlPrototype : Cnl
    {
        /// <summary>
        /// Gets or sets the channel format code.
        /// </summary>
        public string FormatCode { get; set; }

        /// <summary>
        /// Gets or sets the channel quantity code.
        /// </summary>
        public string QuantityCode { get; set; }

        /// <summary>
        /// Gets or sets the channel unit code.
        /// </summary>
        public string UnitCode { get; set; }


        /// <summary>
        /// Gets a tag format by the format code of the channel prototype.
        /// </summary>
        private TagFormat GetTagFormat()
        {
            // TODO: use constants
            switch (FormatCode)
            {
                case "G": 
                    return TagFormat.FloatNumber;

                default: 
                    return null;
            }
        }

        /// <summary>
        /// Sets the channel format code.
        /// </summary>
        public CnlPrototype SetFormat(string formatCode)
        {
            FormatCode = formatCode;
            return this;
        }

        /// <summary>
        /// Executes the specified action that sets the channel prototype properties.
        /// </summary>
        public CnlPrototype Setup(Action<CnlPrototype> action)
        {
            action?.Invoke(this);
            return this;
        }

        /// <summary>
        /// Converts the channel prototype to a device tag.
        /// </summary>
        public DeviceTag ToDeviceTag()
        {
            return new DeviceTag(TagCode, Name)
            {
                DataType = (TagDataType)DataTypeID,
                DataLen = DataLen ?? 1,
                Format = GetTagFormat()
            };
        }
    }
}
