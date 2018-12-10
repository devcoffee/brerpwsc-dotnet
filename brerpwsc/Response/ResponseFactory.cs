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
    /// Class for build reponses
    /// </summary>
    public class ResponseFactory {

        /// <summary>
        /// Build a response model from xml response
        /// </summary>
        /// <param name="reponseType">Response model</param>
        /// <param name="response">Xml response</param>
        /// <returns>Response model</returns>
        public static WebServiceResponse CreateResponse(WebServiceResponseModel responseModel, XmlDocument responseXml) {
            if (responseModel == WebServiceResponseModel.CompositeResponse)
                return CreateCompositeResponse(responseXml);
            else if (responseModel == WebServiceResponseModel.RunProcessResponse)
                return CreateRunProcessResponse(responseXml);
            else if (responseModel == WebServiceResponseModel.StandardResponse)
                return CreateStandardResponse(responseXml);
            else if (responseModel == WebServiceResponseModel.WindowTabDataResponse)
                return CreateWindowTabDataResponse(responseXml);
            return null;
        }

        /// <summary>
        /// Create a composite response model
        /// </summary>
        /// <param name="response">Xml response</param>
        /// <returns>Response model</returns>
        public static CompositeResponse CreateCompositeResponse(XmlDocument response) {
            CompositeResponse responseModel = new CompositeResponse();

            if (HasFaultError(responseModel, response)) {
                return responseModel;
            }

            responseModel.Status = WebServiceResponseStatus.Successful;

            XmlNodeList xmlResponses = response.GetElementsByTagName("StandardResponse");

            for (int i = 0; i < xmlResponses.Count; i++) {
                XmlElement xmlTemp = (XmlElement)xmlResponses.Item(i);
                WebServiceResponse partialResponse = null;

                if (xmlTemp.GetElementsByTagName("WindowTabData").Count > 0) {
                    XmlDocument xmlDocTemp = new XmlDocument();
                    xmlDocTemp.AppendChild(xmlDocTemp.ImportNode(xmlTemp.GetElementsByTagName("WindowTabData").Item(0), true));
                    partialResponse = CreateWindowTabDataResponse(xmlDocTemp);
                    responseModel.AddResponse(partialResponse);
                } else if (xmlTemp.GetElementsByTagName("RunProcessResponse").Count > 0) {
                    XmlDocument xmlDocTemp = new XmlDocument();
                    xmlDocTemp.AppendChild(xmlDocTemp.ImportNode(xmlTemp.GetElementsByTagName("RunProcessResponse").Item(0), true));
                    partialResponse = CreateRunProcessResponse(xmlDocTemp);
                    responseModel.AddResponse(partialResponse);
                } else {
                    XmlDocument xmlDocTemp = new XmlDocument();
                    xmlDocTemp.AppendChild(xmlDocTemp.ImportNode(xmlTemp, true));
                    partialResponse = CreateStandardResponse(xmlDocTemp);
                    responseModel.AddResponse(partialResponse);
                }

                if (partialResponse != null && partialResponse.Status == WebServiceResponseStatus.Error) {
                    responseModel.Status = WebServiceResponseStatus.Error;
                    responseModel.ErrorMessage = partialResponse.ErrorMessage;
                }
            }

            return responseModel;
        }

        /// <summary>
        /// Create a run process response model
        /// </summary>
        /// <param name="response">Xml response</param>
        /// <returns>Response model</returns>
        public static RunProcessResponse CreateRunProcessResponse(XmlDocument response) {
            RunProcessResponse responseModel = new RunProcessResponse();

            if (HasFaultError(responseModel, response)) {
                return responseModel;
            }

            XmlNodeList xmlProcess = response.GetElementsByTagName("RunProcessResponse");

            if (xmlProcess.Count > 0) {
                if (bool.Parse(xmlProcess.Item(0).Attributes.GetNamedItem("IsError").Value)) {
                    responseModel.Status = WebServiceResponseStatus.Error;
                    XmlNodeList xmlError = response.GetElementsByTagName("Error");
                    responseModel.ErrorMessage = xmlError.Item(0).InnerText;
                    return responseModel;
                }
            }

            responseModel.Status = WebServiceResponseStatus.Successful;

            XmlNodeList xmlSummary = response.GetElementsByTagName("Summary");
            responseModel.Summary = xmlSummary.Item(0).InnerText;

            XmlNodeList xmlLogInfo = response.GetElementsByTagName("LogInfo");
            responseModel.LogInfo = xmlLogInfo.Item(0).InnerText;

            return responseModel;
        }

        /// <summary>
        /// Create a standard response model
        /// </summary>
        /// <param name="response">Xml response</param>
        /// <returns>Response model</returns>
        public static StandardResponse CreateStandardResponse(XmlDocument response) {
            StandardResponse responseModel = new StandardResponse();

            if (HasFaultError(responseModel, response)) {
                return responseModel;
            }

            XmlNodeList xmlError = response.GetElementsByTagName("Error");
            if (xmlError.Count > 0) {
                responseModel.Status = WebServiceResponseStatus.Error;
                responseModel.ErrorMessage = xmlError.Item(0).InnerText;
                return responseModel;
            }

            responseModel.Status = WebServiceResponseStatus.Successful;

            XmlNodeList xmlStandard = response.GetElementsByTagName("StandardResponse");

            if (xmlStandard.Count > 0) {
                
                XmlNode nodeRecordID = xmlStandard.Item(0).Attributes.GetNamedItem("RecordID");
                if (nodeRecordID != null) {
                    string stringRecordID = nodeRecordID.Value.Trim();

                    if (!string.IsNullOrEmpty(stringRecordID))
                        responseModel.RecordID = int.Parse(stringRecordID);
                }
            }

            DataRow dataRow = new DataRow();
            responseModel.OutputFields = dataRow;

            XmlNodeList xmlDataFields = response.GetElementsByTagName("outputField");

            for (int j = 0; j < xmlDataFields.Count; j++) {
                Field field = new Field();
                dataRow.AddField(field);

                XmlElement xmlDataField = (XmlElement)xmlDataFields.Item(j);
                if (xmlDataField.Attributes.GetNamedItem("column") != null)
                    field.Column = xmlDataField.Attributes.GetNamedItem("column").Value;

                if (xmlDataField.Attributes.GetNamedItem("value") != null)
                    field.Value = xmlDataField.Attributes.GetNamedItem("value").Value;
            }

            return responseModel;
        }

        /// <summary>
        /// Create a tab data response model
        /// </summary>
        /// <param name="response">Xml response</param>
        /// <returns>Response model</returns>
        public static WindowTabDataResponse CreateWindowTabDataResponse(XmlDocument response) {
            WindowTabDataResponse responseModel = new WindowTabDataResponse();

            if (HasFaultError(responseModel, response)) {
                return responseModel;
            }

            XmlNodeList xmlError = response.GetElementsByTagName("Error");
            if (xmlError.Count > 0) {
                responseModel.Status = WebServiceResponseStatus.Error;
                responseModel.ErrorMessage = xmlError.Item(0).InnerText;
                return responseModel;
            }

            XmlNodeList xmlSuccess = response.GetElementsByTagName("Success");
            if (xmlSuccess.Count > 0) {
                if (!bool.Parse(xmlSuccess.Item(0).InnerText)) {
                    responseModel.Status = WebServiceResponseStatus.Unsuccessful;
                    return responseModel;
                }
            }

            responseModel.Status = WebServiceResponseStatus.Successful;

            XmlNodeList xmlWindowTabData = response.GetElementsByTagName("WindowTabData");
            if (xmlWindowTabData.Count > 0) {

                XmlNode nodeNumRows = xmlWindowTabData.Item(0).Attributes.GetNamedItem("NumRows");
                if (nodeNumRows != null) {
                    string stringNumRows = nodeNumRows.Value.Trim();

                    if (!string.IsNullOrEmpty(stringNumRows))
                        responseModel.NumRows = int.Parse(stringNumRows);
                }

                XmlNode nodeTotalRows = xmlWindowTabData.Item(0).Attributes.GetNamedItem("TotalRows");
                if (nodeTotalRows != null) {
                    string stringTotalRows = nodeTotalRows.Value.Trim();

                    if (!string.IsNullOrEmpty(stringTotalRows))
                        responseModel.TotalRows = int.Parse(stringTotalRows);
                }

                XmlNode nodeStartRow = xmlWindowTabData.Item(0).Attributes.GetNamedItem("StartRow");
                if (nodeStartRow != null) {
                    string stringStartRow = nodeStartRow.Value.Trim();

                    if (!string.IsNullOrEmpty(stringStartRow))
                        responseModel.StartRow = int.Parse(stringStartRow);
                }

            }

            DataSet dataSet = new DataSet();

            responseModel.DataSet = dataSet;

            XmlNodeList xmlDataSet = response.GetElementsByTagName("DataRow");

            for (int i = 0; i < xmlDataSet.Count; i++) {

                DataRow dataRow = new DataRow();
                dataSet.AddRow(dataRow);

                XmlElement xmlDataRow = (XmlElement)xmlDataSet.Item(i);

                XmlNodeList xmlDataFields = xmlDataRow.GetElementsByTagName("field");

                for (int j = 0; j < xmlDataFields.Count; j++) {
                    Field field = new Field();
                    dataRow.AddField(field);

                    XmlElement xmlDataField = (XmlElement)xmlDataFields.Item(j);
                    field.Column = xmlDataField.Attributes.GetNamedItem("column").Value;

                    if (xmlDataField.GetElementsByTagName("val").Item(0).InnerText == null)
                        field.Value = "";
                    else
                        field.Value = xmlDataField.GetElementsByTagName("val").Item(0).InnerText;
                }
            }

            return responseModel;
        }

        /// <summary>
        /// Processes the error
        /// </summary>
        /// <param name="response">Response document</param>
        /// <param name="responseModel">Response</param>
        private static bool HasFaultError(WebServiceResponse responseModel, XmlDocument response) {
            XmlNodeList xmlFault = response.GetElementsByTagName("faultstring");
            if (xmlFault.Count > 0) {
                responseModel.Status = WebServiceResponseStatus.Error;
                responseModel.ErrorMessage = xmlFault.Item(0).InnerText;
                return true;
            }
            return false;
        }
    }
}
