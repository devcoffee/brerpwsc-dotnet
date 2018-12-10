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
    /// Response from RunProcess Web Service
    /// </summary>
    public class RunProcessResponse : WebServiceResponse {
       
        /// <summary>
        /// Type of response 
        /// </summary>
        public override WebServiceResponseModel GetWebServiceResponseModel() {
            return WebServiceResponseModel.RunProcessResponse;
        }


		/// <summary>
		/// Gets or sets the log info
		/// </summary>
		public string LogInfo {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the summary
		/// </summary>
		public string Summary {
			get;
			set;
		}

    }
}
