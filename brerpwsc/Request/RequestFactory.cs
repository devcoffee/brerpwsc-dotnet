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

namespace WebService.Request {

    /// <summary>
    /// Class for build de Web Service Xml Document 
    /// </summary>
    public class RequestFactory {

        public static readonly string prefix_0 = "_0";
        public static readonly string namespace_0 = "http://idempiere.org/ADInterface/1_0";
        public static readonly string prefixSoapenv = "soapenv";
        public static readonly string namespaceSoapenv = "http://schemas.xmlsoap.org/soap/envelope/";
        public static readonly string attributeXmlns = "xmlns";
        public static readonly string namespaceXmlns = "http://www.w3.org/2000/xmlns/";

        /// <summary>
        /// Generates full request xml document
        /// </summary>
        /// <param name="webService">Web service model</param>
        /// <returns>Full document for request</returns>
        public static XmlDocument CreateRequest(WebServiceRequest webService) {
            return BuildXmlDocument(webService);
        }

        /// <summary>
        /// Generates full request xml document
        /// </summary>
        /// <param name="webService">Web service model</param>
        /// <returns>Full document for request</returns>
        private static XmlDocument BuildXmlDocument(WebServiceRequest webService) {
            XmlDocument docRequest = new XmlDocument();
            // XmlDeclaration xmlDeclaration = docRequest.CreateXmlDeclaration("1.0", "UTF-8", null /* yes */);
            // docRequest.AppendChild(xmlDeclaration);
            docRequest.AppendChild(docRequest.ImportNode(BuildXmlEnvelope(webService), true));
            return docRequest;
        }

        /// <summary>
        /// Generates full request xml document
        /// </summary>
        /// <param name="webService">Web service model</param>
        /// <returns>Full document for request</returns>
        private static XmlElement BuildXmlEnvelope(WebServiceRequest webService) {            
            XmlDocument doc = new XmlDocument();

            XmlElement xmlEnvelope = CreateXmlElementSoapenv(doc, "Envelope");
            XmlAttribute attribute_0 = doc.CreateAttribute(attributeXmlns, prefix_0, namespaceXmlns);
            attribute_0.InnerText = namespace_0;
            xmlEnvelope.Attributes.Append(attribute_0);

            doc.AppendChild(xmlEnvelope);

            XmlElement headerNode = CreateXmlElementSoapenv(doc, "Header");
            XmlElement bodyNode = CreateXmlElementSoapenv(doc, "Body");
            XmlElement serviceMethod = CreateXmlElement_0(doc, webService.GetWebServiceMethod().ToString());

            xmlEnvelope.AppendChild(headerNode);
            xmlEnvelope.AppendChild(bodyNode);
            bodyNode.AppendChild(serviceMethod);
            serviceMethod.AppendChild(doc.ImportNode(BuildXmlRequest(webService), true));

            return xmlEnvelope;
        }

        /// <summary>
        /// Generates the xml body for request
        /// </summary>
        /// <param name="webService">Web service model</param>
        /// <returns>Xml for body</returns>
        private static XmlElement BuildXmlRequest(WebServiceRequest webService) {
            XmlDocument doc = new XmlDocument();

            XmlElement xmlRequest = CreateXmlElement_0(doc, webService.GetWebServiceRequestModel().ToString());

            if (webService.GetWebServiceRequestModel() == WebServiceRequestModel.CompositeRequest) {
                XmlElement xmlServiceType = CreateXmlElement_0(doc, "serviceType");
                xmlServiceType.InnerText = webService.WebServiceType;
                xmlRequest.AppendChild(xmlServiceType);
            }

            xmlRequest.AppendChild(doc.ImportNode(BuildXmlModel(webService), true));			

            if (webService.Login != null)
                xmlRequest.AppendChild(doc.ImportNode(BuildXmlLogin(webService.Login), true));

            return xmlRequest;
        }

        /// <summary>
        /// Generates xml login
        /// </summary>
        /// <param name="login">Login data model</param>
        /// <returns>Xml for Login section</returns>
        private static XmlElement BuildXmlLogin(LoginRequest login) {
            XmlDocument docLogin = new XmlDocument();
            XmlElement xmlLogin = CreateXmlElement_0(docLogin, "ADLoginRequest");
            docLogin.AppendChild(xmlLogin);

            if (!string.IsNullOrEmpty(login.User)) {
                XmlElement xmlUser = CreateXmlElement_0(docLogin, "user");
                xmlUser.InnerText = login.User;
                xmlLogin.AppendChild(xmlUser);
            }

            if (!string.IsNullOrEmpty(login.Pass)) {
                XmlElement xmlPass = CreateXmlElement_0(docLogin, "pass");
                xmlPass.InnerText = login.Pass;
                xmlLogin.AppendChild(xmlPass);
            }

            if (login.Lang != null) {
                XmlElement xmlLang = CreateXmlElement_0(docLogin, "lang");
                xmlLang.InnerText = login.Lang.ToString();
                xmlLogin.AppendChild(xmlLang);
            }

            if (login.ClientID != null) {
                XmlElement xmlClient = CreateXmlElement_0(docLogin, "ClientID");
                xmlClient.InnerText = login.ClientID.ToString();
                xmlLogin.AppendChild(xmlClient);
            }

            if (login.RoleID != null) {
                XmlElement xmlRole = CreateXmlElement_0(docLogin, "RoleID");
                xmlRole.InnerText = login.RoleID.ToString();
                xmlLogin.AppendChild(xmlRole);
            }

            if (login.OrgID != null) {
                XmlElement xmlOrg = CreateXmlElement_0(docLogin, "OrgID");
                xmlOrg.InnerText = login.OrgID.ToString();
                xmlLogin.AppendChild(xmlOrg);
            }

            if (login.WarehouseID != null) {
                XmlElement xmlWarehouse = CreateXmlElement_0(docLogin, "WarehouseID");
                xmlWarehouse.InnerText = login.WarehouseID.ToString();
                xmlLogin.AppendChild(xmlWarehouse);
            }

            if (login.Stage != null) {
                XmlElement xmlStage = CreateXmlElement_0(docLogin, "stage");
                xmlStage.InnerText = login.Stage.ToString();
                xmlLogin.AppendChild(xmlStage);
            }

            return xmlLogin;
        }


        /// <summary>
        /// Generates the xml operation for request
        /// </summary>
        /// <param name="webService">Web service model</param>
        /// <returns>Xml for operation</returns>
        private static XmlElement BuildXmlModel(WebServiceRequest webService) {
            XmlDocument doc = new XmlDocument();

            if (webService.GetWebServiceRequestModel() == WebServiceRequestModel.CompositeRequest) {
                CompositeRequest request = (CompositeRequest)webService;

                XmlElement xmlModel = CreateXmlElement_0(doc, "operations");

                foreach (Operation operation in request.GetOperations()) {
                    xmlModel.AppendChild(doc.ImportNode(BuildXmlOperation(operation), true));
                }

                return xmlModel;
            } else if (webService.GetWebServiceRequestModel() == WebServiceRequestModel.ModelCRUDRequest) {
                ModelCRUDRequest request = (ModelCRUDRequest)webService;

                XmlElement xmlModel = CreateXmlElement_0(doc, "ModelCRUD");

                XmlElement xmlServiceType = CreateXmlElement_0(doc, "serviceType");
                xmlServiceType.InnerText = webService.WebServiceType;
                xmlModel.AppendChild(xmlServiceType);

                if (!string.IsNullOrEmpty(request.TableName)) {
                    XmlElement xmlTableName = CreateXmlElement_0(doc, "TableName");
                    xmlTableName.InnerText = request.TableName;
                    xmlModel.AppendChild(xmlTableName);
                }

                if (request.RecordID != null) {
                    XmlElement xmlRecordID = CreateXmlElement_0(doc, "RecordID");
                    xmlRecordID.InnerText = request.RecordID.ToString();
                    xmlModel.AppendChild(xmlRecordID);
                }

                if (request.RecordIDVariable != null) {
                    XmlElement xmlRecordIDVariable = CreateXmlElement_0(doc, "recordIDVariable");
                    xmlRecordIDVariable.InnerText = request.RecordIDVariable;
                    xmlModel.AppendChild(xmlRecordIDVariable);
                }

                if (request.Action != null) {
                    XmlElement xmlAction = CreateXmlElement_0(doc, "Action");
                    xmlAction.InnerText = request.Action.ToString();
                    xmlModel.AppendChild(xmlAction);
                }

                if (!string.IsNullOrEmpty(request.Filter)) {
                    XmlElement xmlFilter = CreateXmlElement_0(doc, "Filter");
                    xmlFilter.InnerText = request.Filter;
                    xmlModel.AppendChild(xmlFilter);
                }

                if (request.Limit != null) {
                    XmlElement xmlLimit = CreateXmlElement_0(doc, "Limit");
                    xmlLimit.InnerText = request.Limit.ToString();
                    xmlModel.AppendChild(xmlLimit);
                }

                if (request.Offset != null) {
                    XmlElement xmlOffset = CreateXmlElement_0(doc, "Offset");
                    xmlOffset.InnerText = request.Offset.ToString();
                    xmlModel.AppendChild(xmlOffset);
                }

                if (request.DataRow != null && request.DataRow.GetFieldsCount() > 0) {
                    xmlModel.AppendChild(doc.ImportNode(BuildXmlFieldsContainer(request.DataRow), true));
                }

                return xmlModel;
            } else if (webService.GetWebServiceRequestModel() == WebServiceRequestModel.ModelGetListRequest) {
                ModelGetListRequest request = (ModelGetListRequest)webService;

                XmlElement xmlModel = CreateXmlElement_0(doc, "ModelGetList");

                XmlElement xmlServiceType = CreateXmlElement_0(doc, "serviceType");
                xmlServiceType.InnerText = request.WebServiceType;
                xmlModel.AppendChild(xmlServiceType);

                if (request.AD_Reference_ID != null) {
                    XmlElement xmlReferenceID = CreateXmlElement_0(doc, "AD_Reference_ID");
                    xmlReferenceID.InnerText = request.AD_Reference_ID.ToString();
                    xmlModel.AppendChild(xmlReferenceID);
                }

                if (!string.IsNullOrEmpty(request.Filter)) {
                    XmlElement xmlFilter = CreateXmlElement_0(doc, "Filter");
                    xmlFilter.InnerText = request.Filter;
                    xmlModel.AppendChild(xmlFilter);
                }

                return xmlModel;
            } else if (webService.GetWebServiceRequestModel() == WebServiceRequestModel.ModelRunProcessRequest) {
                ModelRunProcessRequest request = (ModelRunProcessRequest)webService;

                XmlElement xmlModel = CreateXmlElement_0(doc, "ModelRunProcess");

                XmlElement xmlServiceType = CreateXmlElement_0(doc, "serviceType", request.WebServiceType);
                xmlModel.AppendChild(xmlServiceType);

                if (request.AD_Process_ID != null) {
                    xmlModel.SetAttribute("AD_Process_ID", request.AD_Process_ID.ToString());
                }

                if (request.AD_Menu_ID != null) {
                    xmlModel.SetAttribute("AD_Menu_ID", request.AD_Menu_ID.ToString());
                }

                if (request.AD_Record_ID != null) {
                    xmlModel.SetAttribute("AD_Record_ID", request.AD_Record_ID.ToString());
                }

                if (request.DocAction != null) {
                    DocAction? docAction = request.DocAction;
                    xmlModel.SetAttribute("DocAction", docAction.GetValue());
                }

                if (request.ParamValues != null && request.ParamValues.GetFieldsCount() > 0) {
                    xmlModel.AppendChild(doc.ImportNode(BuildXmlFieldsContainer(request.ParamValues), true));
                }

                return xmlModel;
            } else if (webService.GetWebServiceRequestModel() == WebServiceRequestModel.ModelSetDocActionRequest) {
                ModelSetDocActionRequest request = (ModelSetDocActionRequest)webService;

                XmlElement xmlModel = CreateXmlElement_0(doc, "ModelSetDocAction");

                XmlElement xmlServiceType = CreateXmlElement_0(doc, "serviceType");
                xmlServiceType.InnerText = request.WebServiceType;
                xmlModel.AppendChild(xmlServiceType);

                if (!string.IsNullOrEmpty(request.TableName)) {
                    XmlElement xmlTableName = CreateXmlElement_0(doc, "tableName");
                    xmlTableName.InnerText = request.TableName;
                    xmlModel.AppendChild(xmlTableName);
                }

                if (request.RecordID != null) {
                    XmlElement xmlRecordID = CreateXmlElement_0(doc, "recordID");
                    xmlRecordID.InnerText = request.RecordID.ToString();
                    xmlModel.AppendChild(xmlRecordID);
                }

                if (!string.IsNullOrEmpty(request.RecordIDVariable)) {
                    XmlElement xmlRecordIDVariable = CreateXmlElement_0(doc, "recordIDVariable");
                    xmlRecordIDVariable.InnerText = request.RecordIDVariable;
                    xmlModel.AppendChild(xmlRecordIDVariable);
                }

                if (request.DocAction != null) {
                    XmlElement xmlDocAction = CreateXmlElement_0(doc, "docAction");
                    xmlDocAction.InnerText = request.DocAction.GetValue();
                    xmlModel.AppendChild(xmlDocAction);
                }

                return xmlModel;
            } 
            return doc.CreateElement("NoModel");
        }

        /// <summary>
        /// Generates xml for fields
        /// </summary>
        /// <param name="container">Fields container</param>
        /// <returns>Xml for fields section</returns>
        private static XmlElement BuildXmlFieldsContainer(FieldsContainer container) {
            XmlDocument doc = new XmlDocument();
            XmlElement xmlFields = CreateXmlElement_0(doc, container.GetWebServiceFieldsContainerType().ToString());

            foreach (Field field in container.GetFields()) {
                xmlFields.AppendChild(doc.ImportNode(BuildXmlField(field), true));
            }

            return xmlFields;
        }

        /// <summary>
        /// Generates xml Field
        /// </summary>
        /// <param name="field">Field</param>
        /// <returns>Xml for Field section</returns>
        private static XmlElement BuildXmlField(Field field) {
            XmlDocument doc = new XmlDocument();
            XmlElement xmlField = CreateXmlElement_0(doc, "field");

            if (!string.IsNullOrEmpty(field.Column)) {
                xmlField.SetAttribute("column", field.Column);
            }

            if (!string.IsNullOrEmpty(field.Type)) {
                xmlField.SetAttribute("type", field.Type);
            }

            if (!string.IsNullOrEmpty(field.Lval)) {
                xmlField.SetAttribute("lval", field.Lval);
            }

            if (field.Disp != null) {
                xmlField.SetAttribute("disp", field.Disp.ToString().ToLower());
            }

            if (field.Edit != null) {
                xmlField.SetAttribute("edit", field.Edit.ToString().ToLower());
            }

            if (field.Error != null) {
                xmlField.SetAttribute("error", field.Error.ToString().ToLower());
            }

            if (!string.IsNullOrEmpty(field.ErrorVal)) {
                xmlField.SetAttribute("errorVal", field.ErrorVal);
            }

            if (field.Value != null) {

                string value = "";
                object objValue = field.Value;

                if (objValue is DateTime) {
                    value = string.Format("{0:yyyy-MM-dd HH:mm:ss}", objValue);
                } else if (objValue is Boolean) {
                    value = ((Boolean)objValue) ? "Y" : "N";
                } else if (objValue is DocAction) {
                    value = ((DocAction)objValue).GetValue();
                } else if (objValue is DocStatus) {
                    value = ((DocStatus)objValue).GetValue();
                } else if (objValue is byte[]) {
                    value = Convert.ToBase64String((byte[])objValue);
                } else {
                    value = objValue.ToString();
                }

                XmlElement xmlVal = CreateXmlElement_0(doc, "val", value);
                xmlField.AppendChild(xmlVal);
            }

            return xmlField;
        }

        /// <summary>
        /// Get the xml for operation in composite interface
        /// </summary>
        /// <param name="operation">Operation container</param>
        /// <returns>Xml operation</returns>
        private static XmlElement BuildXmlOperation(Operation operation) {
            XmlDocument doc = new XmlDocument();
            XmlElement xmlOperation = CreateXmlElement_0(doc, "operation");
            xmlOperation.SetAttribute("preCommit", operation.PreCommit.ToString().ToLower());
            xmlOperation.SetAttribute("postCommit", operation.PostCommit.ToString().ToLower());

            XmlElement xmlTargetPort = CreateXmlElement_0(doc, "TargetPort");
            xmlTargetPort.InnerText = operation.WebService.GetWebServiceMethod().ToString();
            xmlOperation.AppendChild(xmlTargetPort);

            xmlOperation.AppendChild(doc.ImportNode(BuildXmlModel(operation.WebService), true));
            return xmlOperation;
        }

        /// <summary>
        /// Creates element for _0 attribute
        /// </summary>
        /// <param name="xmlDocument">Xml Document base</param>
        /// <param name="name">Element Name</param>
        /// <returns>Element</returns>
        private static XmlElement CreateXmlElement_0(XmlDocument xmlDocument, string name) {
            return xmlDocument.CreateElement(prefix_0, name, namespace_0);
        }

        /// <summary>
        /// Creates the xml element 0
        /// </summary>
        /// <returns>The xml element 0</returns>
        /// <param name="xmlDocument">Xml document</param>
        /// <param name="name">Name</param>
        /// <param name="text">Text</param>
        private static XmlElement CreateXmlElement_0(XmlDocument xmlDocument, string name, string text) {
            XmlElement element = xmlDocument.CreateElement(prefix_0, name, namespace_0);
            element.InnerText = text;
            return element;
        }

        /// <summary>
        /// Creates element for soapenv attribute
        /// </summary>
        /// <param name="xmlDocument">Xml Document base</param>
        /// <param name="name">Element Name</param>
        /// <returns>Element</returns>
        private static XmlElement CreateXmlElementSoapenv(XmlDocument xmlDocument, string name) {
            return xmlDocument.CreateElement(prefixSoapenv, name, namespaceSoapenv);
        }
      
    }
}
