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
using WebService.Logic;

namespace WebService.Base {

    /// <summary>
    /// Class to abstract the iDempiere response
    /// </summary>
    public abstract class WebServiceResponse {
        
        /// <summary>
        /// Type of response 
        /// </summary>
        public abstract WebServiceResponseModel GetWebServiceResponseModel(); 

		/// <summary>
		/// Status
		/// </summary>
		public WebServiceResponseStatus Status {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the error message
		/// </summary>
		public string ErrorMessage {
			get;
			set;
		}

        /// <summary>
        /// Web Service Type Name
        /// </summary>
        /// <returns>Web Service Type Name</returns>
        public string WebServiceType {
            get;
            set;
        }

        public ErrorType GetErrorType()
        {
            return WebServiceResponseLogic.getErrorType(ErrorMessage);
        }
    }
}
