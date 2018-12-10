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
using WebService.Base.Enums;

namespace WebService.Base {

    /// <summary>
    /// For composite operation
    /// </summary>
    public class Operation {

        private WebServiceRequest _WebService;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Operation() : this(false, false) {
        }

        /// <summary>
        /// Web service operation
        /// </summary>
        /// <param name="preCommit">Pre Commit Option</param>
        /// <param name="postCommit">Post Commit Option</param>
        public Operation(bool preCommit, bool postCommit) : this(null, preCommit, postCommit) {

        }

        /// <summary>
        /// Web service operation
        /// </summary>
        /// <param name="preCommit">Pre Commit Option</param>
        /// <param name="postCommit">Post Commit Option</param>
        /// <param name="webService">Inner web service</param>
        public Operation(WebServiceRequest webService, bool preCommit, bool postCommit) {
            PreCommit = preCommit;
            PostCommit = postCommit;
            WebService = webService;
        }

        /// <summary>
        /// Web service operation
        /// </summary>
        /// <param name="webService">Inner web service</param>
        public Operation(WebServiceRequest webService) : this(webService, false, false) {

        }

        /// <summary>
        /// Web service for operation
        /// </summary>
        public WebServiceRequest WebService {
            get {
                return _WebService;
            }
            set {
                if (value != null)
                if (value.GetWebServiceMethod() == WebServiceMethod.getList || value.GetWebServiceMethod() == WebServiceMethod.queryData || value.GetWebServiceMethod() == WebServiceMethod.compositeOperation)
                    throw new ArgumentException(String.Format("WebService {0} not allowed for Composite Operation", value.GetWebServiceMethod()));
                
                _WebService = value;
            }
        }

        /// <summary>
        /// If preCommit is true, whatever done before current operation will be committed to the database
        /// </summary>
        public bool PreCommit {
            get;
            set;
        }

        /// <summary>
        /// When postCommit is true, commit is performed after current operation is executed successfully
        /// </summary>
        public bool PostCommit {
            get;
            set;
        }

    }
}
