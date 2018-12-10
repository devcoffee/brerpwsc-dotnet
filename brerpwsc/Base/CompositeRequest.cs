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
using WebService.Base.Enums;

namespace WebService.Base {

    /// <summary>
    /// Web Service Request
    /// </summary>
    public abstract class CompositeRequest : WebServiceRequest {

        /// <summary>
        /// Default constructor
        /// </summary>
        protected CompositeRequest() {
            Operations = new List<Operation>();
        }

        /// <summary>
        /// Composition List of Web Services
        /// </summary>
        private List<Operation> Operations {
            get;
            set;
        }

        /// <summary>
        /// Adds the operation
        /// </summary>
        /// <param name="operation">Operation</param>
        public void AddOperation(Operation operation) {
            Operations.Add(operation);
        }

        /// <summary>
        /// Adds the operation
        /// </summary>
        /// <param name="webService">Web service</param>
        public void AddOperation(WebServiceRequest webService) {
            AddOperation(new Operation(webService));
        }

        /// <summary>
        /// Adds the operation
        /// </summary>
        /// <param name="webService">Web service</param>
        /// <param name="preCommit">If set to <c>true</c> pre commit</param>
        /// <param name="postCommit">If set to <c>true</c> post commit</param>
        public void AddOperation(WebServiceRequest webService, bool preCommit, bool postCommit) {
            AddOperation(new Operation(webService, preCommit, postCommit));
        }

        /// <summary>
        /// Removes the operation
        /// </summary>
        /// <param name="operation">Operation</param>
        public void RemoveOperation(Operation operation) {
            Operations.Remove(operation);
        }

        /// <summary>
        /// Removes the operation
        /// </summary>
        /// <returns>The operation</returns>
        /// <param name="pos">Position</param>
        public Operation RemoveOperation(int pos) {
            Operation operation = Operations[pos];
            RemoveOperation(operation);
            return operation;
        }

        /// <summary>
        /// Gets the operation
        /// </summary>
        /// <returns>The operation</returns>
        /// <param name="pos">Position</param>
        public Operation GetOperation(int pos) {
            return Operations[pos];
        }

        /// <summary>
        /// Get all field
        /// </summary>
        /// <returns>List fields</returns>
        public List<Operation> GetOperations() {
            List<Operation> temp = new List<Operation>();
            temp.AddRange(Operations);
            return temp;
        }

        /// <summary>
        /// Get the count Operations
        /// </summary>
        /// <returns>Count</returns>
        public int GetOperationsCount() {
            return Operations.Count;
        }

        /// <summary>
        /// Clear this instance
        /// </summary>
        public void Clear() {
            Operations.Clear();
        }

        /// <summary>
        /// Request Model
        /// </summary>
        /// <returns>Request Model</returns>
        public override WebServiceRequestModel GetWebServiceRequestModel() {
            return WebServiceRequestModel.CompositeRequest;
        }
    }
}
