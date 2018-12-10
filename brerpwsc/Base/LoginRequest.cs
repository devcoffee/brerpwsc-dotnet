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

using WebService.Base.Enums;

namespace WebService.Base {

    /// <summary>
    /// Class to abstract the iDempiere Web Service Login
    /// </summary>
    public class LoginRequest {

        /// <summary>
		/// iDempiere User (select name from ad_user)
        /// </summary>
        public string User {
            get;
            set;
        }

        /// <summary>
		/// iDempiere Password (select password from ad_user)
        /// </summary>
        public string Pass {
            get;
            set;
        }

        /// <summary>
        /// Language. Example: Language.es_CO, Language.en_US
        /// </summary>
        public Language? Lang {
            get;
            set;
        }

        /// <summary>
		/// Client (select ad_client_id from ad_client)
        /// </summary>
        public int? ClientID {
            get;
            set;
        }

        /// <summary>
		/// Role (select ad_role_id from ad_role)
        /// </summary>
        public int? RoleID {
            get;
            set;
        }

        /// <summary>
		/// Organization (select ad_org_id from ad_org)
        /// </summary>
        public int? OrgID {
            get;
            set;
        }

        /// <summary>
		/// Warehouse (select m_warehouse_id from m_warehouse)
        /// </summary>
        public int? WarehouseID {
            get;
            set;
        }

        /// <summary>
        /// Login stage
        /// </summary>
        public int? Stage {
            get;
            set;
        }

    }
}
