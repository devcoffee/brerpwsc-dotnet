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
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Threading;
using WebService.Base;
using WebService.Request;
using WebService.Response;
using WebService.Exceptions;


namespace WebService.Net {

    /// <summary>
    /// This class send a stream data xml.
    /// </summary>
    public class WebServiceConnection {

        public static readonly string DefaultContentType = "text/xml; charset=UTF-8";
        public static readonly string DefaultRequestMethod = "POST";
        public static readonly int DefaultTimeout = 5000;
        public static readonly int DefaultAttempts = 1;
        public static readonly int DefaultAttemptsTimeout = 500;
        public static readonly int DefaultConnectionLimit = 2;
        public static readonly ICredentials DefaultCredentials = CredentialCache.DefaultCredentials;
        public static readonly IWebProxy DefaultWebProxy = WebRequest.DefaultWebProxy;

        private int connectionLimit;
        private int attempts;
        private int attemptsTimeout;
        private int timeout;
        private string appName;
        private XmlDocument xmlRequest;
        private XmlDocument xmlResponse;
        private WebServiceRequest request;

        /// <summary>
        /// For connection simultaneously
        /// </summary>
        public int ConnectionLimit {
            get {
                return connectionLimit;
            }
            set {
                if (value <= 0)
                    connectionLimit = DefaultConnectionLimit;
                else
                    connectionLimit = value;
            }
        }

        /// <summary>
        /// Attempts for request
        /// </summary>
        public int Attempts {
            get {
                return attempts;
            }
            set {
                if (value <= 0)
                    attempts = DefaultAttempts;
                else
                    attempts = value;
            }
        }

        /// <summary>
        /// Gets or sets the attempts timeout. Default: WebServiceConnection.DefaultAttemptsTimeout
        /// </summary>
        /// <value>The attempts timeout</value>
        public int AttemptsTimeout {
            get {
                return attemptsTimeout;
            }
            set {
                if (value <= 0)
                    attemptsTimeout = DefaultTimeout;
                else
                    attemptsTimeout = value;
            }
        }

        /// <summary>
        /// Timeout for request. Default: WebServiceConnection.DefaultTimeout
        /// </summary>
        public int Timeout {
            get {
                return timeout;
            }
            set {
                if (value <= 0)
                    timeout = DefaultTimeout;
                else
                    timeout = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the app
        /// </summary>
        /// <value>The name of the app</value>
        public string AppName {       
            get {
                return appName;
            }
            set {
                if (appName == null)
                    appName = "";
                else
                    appName = value;
            }

        }

        /// <summary>
        /// total Attempts for request
        /// </summary>
        public int AttemptsRequest {
            get;
            protected set;
        }

        /// <summary>
        /// Total time for request
        /// </summary>
        public int TimeRequest {
            get;
            protected set;
        }

        /// <summary>
        /// Proxy. Default: WebServiceConnection.DefaultProxy
        /// </summary>
        public IWebProxy Proxy {
            get;
            set;
        }

        /// <summary>
        /// Credentials. Default: WebServiceConnection.DefaultCredentials
        /// </summary>
        public ICredentials Credentials {
            get;
            set;
        }

        /// <summary>
        /// Url for connect
        /// </summary>
        public string Url {
            get;
            set;
        }

        /// <summary>
        /// Data typ. Default: WebServiceConnection.DefaultContentType
        /// </summary>
        public string ContentType {
            get;
            set;
        }

        /// <summary>
        /// Method for request. Default: WebServiceConnection.DefaultRequestMethod
        /// </summary>
        public string RequestMethod {
            get;
            set;
        }

        /// <summary>
        /// Gets the user agent
        /// </summary>
        /// <returns>The user agent</returns>
        public string GetUserAgent() {
            return string.Format("{0} ({1}/{2}/{3}/{4}) {5}", ComponentInfo.Name, ComponentInfo.ComponentName, ComponentInfo.Version, ".NET", Environment.OSVersion, AppName).Trim();
        }

        /// <summary>
        /// Gets the web service path 
        /// </summary>
        /// <returns>The path</returns>
        private string GetPath() {
           if (request == null)
                return null;
            return string.Format("/ADInterface/services/{0}", request.GetWebServiceDefinition().ToString());        
        }

        /// <summary>
        /// Build the Url for WebService Connection
        /// </summary>
        /// <returns>Url for create HttpWebRequest</returns>
        private string GetWebServiceUrl(){
            if (GetPath() == null)
                return Url;

            string urlTemp = Url;
            if (urlTemp.EndsWith("/"))
                urlTemp = urlTemp.Substring(0, urlTemp.Length - 1);

            string path = GetPath();
            if (path.StartsWith("/"))
                path = path.Substring(1);

            return String.Format("{0}/{1}", urlTemp, path);
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public WebServiceConnection() {
            Timeout = DefaultTimeout;
            ContentType = DefaultContentType;
            RequestMethod = DefaultRequestMethod;
            Credentials = DefaultCredentials;
            Attempts = DefaultAttempts;
            ConnectionLimit = DefaultConnectionLimit;
            AttemptsTimeout = DefaultAttemptsTimeout;
            Proxy = DefaultWebProxy;
            Url = "";
        }

        /// <summary>
        /// FOR SSL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="certificate"></param>
        /// <param name="chain"></param>
        /// <param name="sslPolicyErrors"></param>
        /// <returns></returns>
        private bool OnValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) {
            return true;
        }

        /// <summary>
        /// Send data in xml format
        /// </summary>
        /// <param name="dataRequest">Xml Document</param>
        /// <returns>Xml Response</returns>
        public XmlDocument SendRequest(XmlDocument dataRequest) {
            return SendRequest(dataRequest.OuterXml);
        }

        /// <summary>
        /// Send string data
        /// </summary>
        /// <param name="dataRequest">Data</param>
        /// <returns>Xml Response</returns>
        public XmlDocument SendRequest(string dataRequest) {

            if (string.IsNullOrEmpty(Url))
                throw new WebServiceException("URL must be different than empty or null");

            ServicePointManager.ServerCertificateValidationCallback = OnValidateCertificate;
            ServicePointManager.DefaultConnectionLimit = ConnectionLimit;
            ServicePointManager.Expect100Continue = false;

            TimeSpan startTime = TimeSpan.FromMilliseconds(Environment.TickCount);
            AttemptsRequest = 0;
            bool successful = false;
            string dataResponse = "";   
            XmlDocument xmlDocument = new XmlDocument();

            while (!successful) {
                AttemptsRequest++;

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(GetWebServiceUrl());
                request.Timeout = Timeout;
                request.KeepAlive = false;
                request.Method = RequestMethod;
                request.UserAgent = GetUserAgent();

                byte[] bytesData = Encoding.UTF8.GetBytes(dataRequest);
                request.ContentType = ContentType;
                request.ContentLength = bytesData.Length;

                if (Proxy != null)
                    request.Proxy = Proxy;

                if (Credentials != null)
                    request.Credentials = Credentials;

                try {
                    Stream requestStreamData = request.GetRequestStream();
                    requestStreamData.Write(bytesData, 0, bytesData.Length);
                    requestStreamData.Close();

                    WebResponse response = request.GetResponse();

                    Stream responseStreamData = response.GetResponseStream();
                    StreamReader readResponseStreamData = new StreamReader(responseStreamData, Encoding.UTF8);
                    dataResponse = readResponseStreamData.ReadToEnd();

                    readResponseStreamData.Close();
                    responseStreamData.Close();
                    response.Close();

                    xmlDocument.LoadXml(dataResponse);

                    successful = true;
                } catch (Exception e) {                    
                    if (AttemptsRequest >= Attempts) {
                        TimeRequest = (int)TimeSpan.FromMilliseconds(Environment.TickCount).Subtract(startTime).Duration().TotalMilliseconds;
                        if (e.GetType().Equals(typeof(WebException))) {
                            WebException we = (WebException)e;
                            if (we.Status == WebExceptionStatus.Timeout) {
                                throw new WebServiceTimeoutException("Timeout exception, operation has expired", e);
                            }
                        }                        
                        throw new WebServiceException("Error sending request", e);
                    } else {
                        Thread.Sleep(AttemptsTimeout);
                        continue;
                    }
                }
            }

            TimeRequest = (int)TimeSpan.FromMilliseconds(Environment.TickCount).Subtract(startTime).Duration().TotalMilliseconds;

            return xmlDocument;
        }       

        #region RUN PROCESS

        /// <summary>
        /// Send request for run process web service
        /// </summary>
        /// <param name="request">Request to send</param>
        /// <returns>Response model</returns>
        public RunProcessResponse SendRequest(RunProcessRequest request) {
            return (RunProcessResponse)SendRequest((WebServiceRequest)request);
        }

        #endregion

        #region READ DATA

        /// <summary>
        /// Send request for read data web service
        /// </summary>
        /// <param name="request">Request to send</param>
        /// <returns>Response model</returns>
        public WindowTabDataResponse SendRequest(ReadDataRequest request) {
            return (WindowTabDataResponse)SendRequest((WebServiceRequest)request);
        }

        #endregion

        #region QUERY DATA

        /// <summary>
        /// Send request for query data web service
        /// </summary>
        /// <param name="request">Request to send</param>
        /// <returns>Response model</returns>
        public WindowTabDataResponse SendRequest(QueryDataRequest request) {
            return (WindowTabDataResponse)SendRequest((WebServiceRequest)request);
        }

        #endregion

        #region GET LIST

        /// <summary>
        /// Send request for getlist data web service
        /// </summary>
        /// <param name="request">Request to send</param>
        /// <returns>Response model</returns>
        public WindowTabDataResponse SendRequest(GetListRequest request) {
            return (WindowTabDataResponse)SendRequest((WebServiceRequest)request);
        }

        #endregion

        #region DELETE DATA

        /// <summary>
        /// Send request for delete data web service
        /// </summary>
        /// <param name="request">Request to send</param>
        /// <returns>Response model</returns>
        public StandardResponse SendRequest(DeleteDataRequest request) {
            return (StandardResponse)SendRequest((WebServiceRequest)request);
        }

        #endregion

        #region CREATE DATA

        /// <summary>
        /// Send request for create data web service
        /// </summary>
        /// <param name="request">Request to send</param>
        /// <returns>Response model</returns>
        public StandardResponse SendRequest(CreateDataRequest request) {
            return (StandardResponse)SendRequest((WebServiceRequest)request);
        }

        #endregion

        #region CREATE UPDATE DATA

        /// <summary>
        /// Send request for create update data web service
        /// </summary>
        /// <param name="request">Request to send</param>
        /// <returns>Response model</returns>
        public StandardResponse SendRequest(CreateUpdateDataRequest request) {
            return (StandardResponse)SendRequest((WebServiceRequest)request);
        }

        #endregion

        #region UPDATE DATA

        /// <summary>
        /// Send request for update data web service
        /// </summary>
        /// <param name="request">Request to send</param>
        /// <returns>Response model</returns>
        public StandardResponse SendRequest(UpdateDataRequest request) {
            return (StandardResponse)SendRequest((WebServiceRequest)request);
        }

        #endregion

        #region SET DOC ACTION

        /// <summary>
        /// Send request for doc action web service
        /// </summary>
        /// <param name="request">Request to send</param>
        /// <returns>Response model</returns>
        public StandardResponse SendRequest(SetDocActionRequest request) {
            return (StandardResponse)SendRequest((WebServiceRequest)request);
        }

        #endregion

        #region COMPOSITE OPERATION

        /// <summary>
        /// Send request for composite web service
        /// </summary>
        /// <param name="request">Request to send</param>
        /// <returns>Response model</returns>
        public CompositeResponse SendRequest(CompositeOperationRequest request) {
            return (CompositeResponse)SendRequest((WebServiceRequest)request);
        }

        #endregion       

        /// <summary>
        /// Generic send request
        /// </summary>
        /// <param name="request">Request to send</param>
        /// <returns>Response model</returns>        
        public virtual WebServiceResponse SendRequest(WebServiceRequest request) {
            this.request = request;

            XmlDocument xmlRequest = RequestFactory.CreateRequest(request);
            this.xmlRequest = xmlRequest;

            XmlDocument xmlResponse = SendRequest(xmlRequest);
            this.xmlResponse = xmlResponse;

            WebServiceResponse response = ResponseFactory.CreateResponse(request.GetWebServiceResponseModel(), xmlResponse);

            if ((response is CompositeResponse) && (request is CompositeRequest)) {
                CompositeResponse compositeResponse = (CompositeResponse)response;
                CompositeRequest compositeRequest = (CompositeRequest)request;

                if (compositeResponse.GetResponsesCount() > 0) {
                    List<WebServiceResponse> responses = compositeResponse.GetResponses();
                    List<Operation> operations = compositeRequest.GetOperations();

                    for (int i = 0; i < responses.Count; i++) {
                        WebServiceResponse tempResponse = responses[i];
                        WebServiceRequest temRequest = operations[i].WebService;
                        tempResponse.WebServiceType = temRequest.WebServiceType;
                    }
                }
            }

            response.WebServiceType = request.WebServiceType;
            return response;
        }

        /// <summary>
        /// Gets the xml request
        /// </summary>
        /// <returns>The xml request</returns>
        public XmlDocument GetXmlRequest() {
            return xmlRequest;
        }

        /// <summary>
        /// Gets the xml response
        /// </summary>
        /// <returns>The xml response</returns>
        public XmlDocument GetXmlResponse() {
            return xmlResponse;
        }

        /// <summary>
        /// Writes the request
        /// </summary>
        /// <param name="fileName">File name</param>
        public void WriteRequest(String fileName) {
            TextWriter streamWriter = new StreamWriter(fileName, false, Encoding.UTF8);
            WriteRequest(streamWriter);
        }

        /// <summary>
        /// Writes the request
        /// </summary>
        /// <param name="outStream">Out stream</param>
        public void WriteRequest(TextWriter outStream) {
            xmlRequest.Save(outStream);
        }

        /// <summary>
        /// Writes the response
        /// </summary>
        /// <param name="fileName">File name</param>
        public void WriteResponse(String fileName) {
            TextWriter streamWriter = new StreamWriter(fileName, false, Encoding.UTF8);
            WriteResponse(streamWriter);
        }

        /// <summary>
        /// Writes the response
        /// </summary>
        /// <param name="outStream">Out stream</param>
        public void WriteResponse(TextWriter outStream) {
            xmlResponse.Save(outStream);           
        }

    }
}
