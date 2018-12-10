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
using System.Reflection;
using WebService.Base.Enums;

namespace WebService.Base {

    /// <summary>
    /// Filed for ModelCRUDRequest
    /// </summary>
    public class Field {

        /// <summary>
        /// Initializes a new instance of the <see cref="WebService.Base.Field"/> class.
        /// </summary>
        public Field() {
        }

        /// <summary>
        /// Constructor colum
        /// </summary>
        /// <param name="colum">Field Column</param>
        public Field(string column) {
            Column = column;
        }

        /// <summary>
        /// Constructor colum and value
        /// </summary>
        /// <param name="column">Field Column</param>
        /// <param name="value">Field Value</param>
        public Field(string column, object value)
            : this(column) {
            Value = value;
        }

        /// <summary>
        /// Field val
        /// </summary>
        public object Value {
            get;
            set;
        }

        /// <summary>
        /// Field column
        /// </summary>
        public string Column {
            get;
            set;
        }

        /// <summary>
        /// Field type
        /// </summary>
        public string Type {
            get;
            set;
        }

        /// <summary>
        /// Field lval for search key
        /// </summary>
        public string Lval {
            get;
            set;
        }

        /// <summary>
        /// Field disp
        /// </summary>
        public bool? Disp {
            get;
            set;
        }

        /// <summary>
        /// Field edit
        /// </summary>
        public bool? Edit {
            get;
            set;
        }

        /// <summary>
        /// Field error
        /// </summary>
        public bool? Error {
            get;
            set;
        }

        /// <summary>
        /// Field errorVal
        /// </summary>
        public string ErrorVal {
            get;
            set;
        }

        /// <summary>
        /// Gets the string value
        /// </summary>
        /// <returns>The string value</returns>
        public string GetStringValue() {
            return Value == null ? null : Value.ToString();
        }

        /// <summary>
        /// Gets the int value
        /// </summary>
        /// <returns>The int value</returns>
        public int? GetIntValue() {
            if (Value == null)
                return null;

            if (Value is string)
                return int.Parse(Value.ToString());

            return (int)Value;
        }

        /// <summary>
        /// Gets the byte value
        /// </summary>
        /// <returns>The byte value</returns>
        public byte[] GetByteValue() {
            if (Value == null)
                return null;

            if (Value is string)
                return Convert.FromBase64String(Value.ToString());

            return (byte[])Value;
        }

        /// <summary>
        /// Gets the double value
        /// </summary>
        /// <returns>The double value</returns>
        public double? GetDoubleValue() {
            if (Value == null)
                return null;

            if (Value is string)
                return double.Parse(Value.ToString());

            return (double)Value;
        }

        /// <summary>
        /// Gets the float value
        /// </summary>
        /// <returns>The float value</returns>
        public float? GetFloatValue() {
            if (Value == null)
                return null;

            if (Value is string)
                return float.Parse(Value.ToString());

            return (float)Value;
        }

        /// <summary>
        /// Gets the boolean value
        /// </summary>
        /// <returns>The boolean value</returns>
        public bool? GetBooleanValue() {
            if (Value == null)
                return null;

            if (Value is string) {
                string stringValue = Value.ToString().ToUpper();

                if (stringValue.Equals("Y") || stringValue.Equals("YES"))
                    stringValue = bool.TrueString;

                if (stringValue.Equals("N") || stringValue.Equals("NO"))
                    stringValue = bool.FalseString;

                return bool.Parse(stringValue);
            }

            return (bool)Value;
        }

        /// <summary>
        /// Gets the date value
        /// </summary>
        /// <returns>The date value</returns>
        public DateTime? GetDateValue() {
            if (Value == null)
                return null;

            if (Value is string)
                return DateTime.Parse(Value.ToString());

            return (DateTime)Value;
        }

        /// <summary>
        /// Gets the document status value
        /// </summary>
        /// <returns>The document status value</returns>
        public DocStatus? GetDocStatusValue() {
            if (Value == null)
                return null;

            if (Value is string) {
                Type typeDocStatus = typeof(DocStatus);
                FieldInfo[] fieldInfo = typeDocStatus.GetFields();

                foreach (FieldInfo field in fieldInfo) {
                    if (field.Name.Equals("value__")) continue;

                    DocStatus docStatus = (DocStatus)Enum.Parse(typeof(DocStatus), field.Name, false);
                    if (Value.ToString().Equals(docStatus.GetValue()))
                        return docStatus;

                }

                return (DocStatus)Enum.Parse(typeof(DocStatus), Value.ToString(), false);
            }

            return (DocStatus)Value;
        }

        /// <summary>
        /// Gets the document action value
        /// </summary>
        /// <returns>The document action value</returns>
        public DocAction? GetDocActionValue() {
            if (Value == null)
                return null;

            if (Value is string) {
                Type typeDocAction = typeof(DocAction);
                FieldInfo[] fieldInfo = typeDocAction.GetFields();

                foreach (FieldInfo field in fieldInfo) {
                    if (field.Name.Equals("value__")) continue;

                    DocAction docAction = (DocAction)Enum.Parse(typeof(DocAction), field.Name, false);
                    if (Value.ToString().Equals(docAction.GetValue()))
                        return docAction;

                }

                return (DocAction)Enum.Parse(typeof(DocAction), Value.ToString(), false);
            }

            return (DocAction)Value;
        }

    }
}
