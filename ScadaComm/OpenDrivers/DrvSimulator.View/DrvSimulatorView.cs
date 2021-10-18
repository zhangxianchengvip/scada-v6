﻿// Copyright (c) Rapid Software LLC. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Scada.Lang;

namespace Scada.Comm.Drivers.DrvSimulator.View
{
    /// <summary>
    /// Implements the driver user interface.
    /// <para>Реализует пользовательский интерфейс драйвера.</para>
    /// </summary>
    public class DrvSimulatorView : DriverView
    {
        /// <summary>
        /// Gets the driver name.
        /// </summary>
        public override string Name
        {
            get
            {
                return Locale.IsRussian ? "Симулятор устройства" : "Device Simulator";
            }
        }

        /// <summary>
        /// Gets the driver description.
        /// </summary>
        public override string Descr
        {
            get
            {
                return Locale.IsRussian ?
                    "Команды ТУ:\n" +
                    "4, DO - установить состояние реле;\n" +
                    "5, AO - установить аналоговый выход." :

                    "Commands:\n" +
                    "4, DO - set relay state;\n" +
                    "5, AO - set analog output.";
            }
        }
    }
}