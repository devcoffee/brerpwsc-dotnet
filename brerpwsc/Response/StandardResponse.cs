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

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using WebService.Base;
using WebService.Base.Enums;

namespace WebService.Response {

    /// <summary>
    /// Response from SetDocAction, CreateData, DeleteData, UpdateData Web Services
    /// </summary>
    public class StandardResponse : WebServiceResponse {

		/// <summary>
		/// Initializes a new instance of the <see cref="WebService.Response.StandardResponse"/> class
		/// </summary>
		public StandardResponse(){
			OutputFields = new DataRow ();
		}

        /// <summary>
        /// Type of response 
        /// </summary>
        public override WebServiceResponseModel GetWebServiceResponseModel() {
            return WebServiceResponseModel.StandardResponse;
        }

		/// <summary>
		/// Gets or sets the record ID
		/// </summary>
		public int? RecordID {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the output fields
		/// </summary>
		public DataRow OutputFields {
			get;
			set;
		}

    }
}
