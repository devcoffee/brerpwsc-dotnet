////
/// Copyright (c) 2016 Saúl Piña <sauljabin@gmail.com>.
/// 
/// This file is part of idempierewsc.
/// 
/// idempierewsc is free software: you can redistribute it and/or modify
/// it under the terms of the GNU Lesser General Public License as published by
/// the Free Software Foundation, either version 3 of the License, or
/// (at your option) any later version.
/// 
/// idempierewsc is distributed in the hope that it will be useful,
/// but WITHOUT ANY WARRANTY; without even the implied warranty of
/// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
/// GNU Lesser General Public License for more details.
/// 
/// You should have received a copy of the GNU Lesser General Public License
/// along with idempierewsc.  If not, see <http://www.gnu.org/licenses/>.
////

using System.Collections.Generic;

namespace WebService.Base {

    /// <summary>
    /// Component info
    /// </summary>
    public sealed class ComponentInfo {
        
        public static readonly string Name = "iDempiere Web Service Client";
        public static readonly string ComponentName = "idempierewsc";
        public static readonly string Version = "1.6.0";

        /// <summary>
        /// To the dictionary
        /// </summary>
        /// <returns>The dictionary</returns>
        public static Dictionary<string, string> ToDictionary() {
            Dictionary<string, string> info = new Dictionary<string, string>();
            info.Add("Name", Name);
            info.Add("ComponentName", ComponentName);
            info.Add("Version", Version);
            return info;
        }
    }
}

