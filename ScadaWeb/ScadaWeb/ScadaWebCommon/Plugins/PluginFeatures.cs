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
 * Module   : ScadaWebCommon
 * Summary  : Represents specialized plugin features
 * 
 * Author   : Mikhail Shiryaev
 * Created  : 2021
 * Modified : 2021
 */

using Scada.Data.Entities;
using Scada.Web.Users;

namespace Scada.Web.Plugins
{
    /// <summary>
    /// Represents specialized plugin features.
    /// <para>Представляет специализированные функции плагина.</para>
    /// </summary>
    public class PluginFeatures
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public PluginFeatures()
        {
            ChartScriptUrl = "";
            CommandScriptUrl = "";
            EventAckScriptUrl = "";
            NotificationScriptUrl = "";
            UserProfileUrl = "";
        }


        /// <summary>
        /// Gets the URL of the chart script.
        /// </summary>
        public string ChartScriptUrl { get; }

        /// <summary>
        /// Gets the URL of the command script.
        /// </summary>
        public string CommandScriptUrl { get; }

        /// <summary>
        /// Gets the URL of the event acknowledgement script.
        /// </summary>
        public string EventAckScriptUrl { get; }

        /// <summary>
        /// Gets the URL of the notification script.
        /// </summary>
        public string NotificationScriptUrl { get; }

        /// <summary>
        /// Gets the URL of the user profile page.
        /// </summary>
        public string UserProfileUrl { get; }


        /// <summary>
        /// Finds a user in an external source.
        /// </summary>
        /// <remarks>The returned used is passed to the PluginLogic.GetUserMenuItems method.</remarks>
        public virtual User FindUser(int userID)
        {
            return null;
        }

        /// <summary>
        /// Gets the configuration for the specified user.
        /// </summary>
        public virtual UserConfig GetUserConfig(int userID)
        {
            return null;
        }
    }
}
