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
using WebService.Response;
using WebService.Base;
using WebService.Base.Enums;

namespace WebService.Request {

    /// <summary>
    /// iDempiere Web Service SetDocAction
    /// </summary>
    public class SetDocActionRequest : ModelSetDocActionRequest {

        /// <summary>
        /// Web Service Definition
        /// </summary>
        /// <returns>Web Service Definition</returns>
        public override WebServiceDefinition GetWebServiceDefinition() {
            return WebServiceDefinition.ModelADService;
        }

        /// <summary>
        /// Web Service Method
        /// </summary>
        /// <returns>Web Service Method</returns>
        public override WebServiceMethod GetWebServiceMethod() {
            return WebServiceMethod.setDocAction;
        }

		/// <summary>
		/// Web Service Response Model
		/// </summary>
		/// <returns>Web Service Response Model</returns>
		public override WebServiceResponseModel GetWebServiceResponseModel ()	{
			return WebServiceResponseModel.StandardResponse;
		}

    }
}
