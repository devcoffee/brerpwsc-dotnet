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
    /// Web Service Request
    /// </summary>
    public abstract class WebServiceRequest {       

		protected WebServiceRequest(){
			Login = new LoginRequest ();
		}

        /// <summary>
        /// Web Service Login
        /// </summary>
        public LoginRequest Login {
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

        /// <summary>
        /// Web Service Method
        /// </summary>
        /// <returns>Web Service Method</returns>
        public abstract WebServiceMethod GetWebServiceMethod();

        /// <summary>
        /// Web Service Definition
        /// </summary>
        /// <returns>Web Service Definition</returns>
        public abstract WebServiceDefinition GetWebServiceDefinition();

        /// <summary>
        /// Web Service Request Model
        /// </summary>
        /// <returns>Web Service Request Model</returns>
        public abstract WebServiceRequestModel GetWebServiceRequestModel();

		/// <summary>
		/// Web Service Response Model
		/// </summary>
		/// <returns>Web Service Response Model</returns>
		public abstract WebServiceResponseModel GetWebServiceResponseModel();
 
    }
}
