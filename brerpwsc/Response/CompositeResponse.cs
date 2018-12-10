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
    /// Response from CompositeInterface Web Service
    /// </summary>
    public class CompositeResponse : WebServiceResponse {

        /// <summary>
        /// Type of response 
        /// </summary>
        public override WebServiceResponseModel GetWebServiceResponseModel() {
            return WebServiceResponseModel.CompositeResponse;
        }

        /// <summary>
        /// Gets or sets the responses
        /// </summary>
        private List<WebServiceResponse> Responses {
            get;
            set;
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CompositeResponse() {
            Responses = new List<WebServiceResponse>();
        }

        /// <summary>
        /// Gets the responses
        /// </summary>
        /// <returns>The responses</returns>
        public List<WebServiceResponse> GetResponses() {
            List<WebServiceResponse> temp = new List<WebServiceResponse>();
            temp.AddRange(Responses);
            return temp;
        }

        /// <summary>
        /// Removes the response
        /// </summary>
        /// <param name="response">Response</param>
        public void RemoveResponse(WebServiceResponse response) {
            Responses.Remove(response);
        }

        /// <summary>
        /// Removes the response
        /// </summary>
        /// <returns>The response</returns>
        /// <param name="pos">Position</param>
        public WebServiceResponse RemoveResponse(int pos) {
            WebServiceResponse returnResponse = GetResponse(pos);
            Responses.Remove(returnResponse);
            return returnResponse;
        }

        /// <summary>
        /// Adds the response
        /// </summary>
        /// <param name="response">Response</param>
        public void AddResponse(WebServiceResponse response) {           
            Responses.Add(response);
        }

        /// <summary>
        /// Gets the responses count
        /// </summary>
        /// <returns>The responses count</returns>
        public int GetResponsesCount() {
            return Responses.Count;
        }

        /// <summary>
        /// Gets the response
        /// </summary>
        /// <returns>The response</returns>
        /// <param name="pos">Position</param>
        public WebServiceResponse GetResponse(int pos) {
            return Responses[pos];
        }

        /// <summary>
        /// Clear this instance
        /// </summary>
        public void Clear() {
            Responses.Clear();
        }

    }
}
