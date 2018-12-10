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
    /// Response from QueryData, GetList, ReadData Web Services
    /// </summary>
    public class WindowTabDataResponse : WebServiceResponse {

		/// <summary>
		/// Initializes a new instance of the <see cref="WebService.Response.WindowTabDataResponse"/> class.
		/// </summary>
		public WindowTabDataResponse(){
            DataSet = new DataSet();
		}

        /// <summary>
        /// Type of response 
        /// </summary>
        public override WebServiceResponseModel GetWebServiceResponseModel() {
            return WebServiceResponseModel.WindowTabDataResponse;
        }

		/// <summary>
		/// Gets or sets the number rows
		/// </summary>
		public int? NumRows {
			get;
			set;
		}

	
		/// <summary>
		/// Gets or sets the total rows
		/// </summary>
		public int? TotalRows {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the start row
		/// </summary>
		public int? StartRow {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the data set
		/// </summary>
        public DataSet DataSet {
			get;
			set;
		}
    }
}
