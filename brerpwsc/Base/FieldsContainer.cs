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
    /// For field collections
    /// </summary>
    public abstract class FieldsContainer {

        /// <summary>
        /// Default constructor
        /// </summary>
        public FieldsContainer() {
            Fields = new List<Field>();
        }

        /// <summary>
        /// Fields
        /// </summary>
        private List<Field> Fields {
            get;
            set;
        }

        /// <summary>
        /// Get all field
        /// </summary>
        /// <returns>List fields</returns>
        public List<Field> GetFields() {
            List<Field> temp = new List<Field>();
            temp.AddRange(Fields);
            return temp;
        }

        /// <summary>
        /// Removes the field
        /// </summary>
        /// <param name="field">Field</param>
        public void RemoveField(Field field) {
            Fields.Remove(field);
        }

        /// <summary>
        /// Removes the field
        /// </summary>
        /// <returns>The field</returns>
        /// <param name="pos">Position</param>
        public Field RemoveField(int pos) {
            Field returnField = GetField(pos);
            Fields.Remove(returnField);
            return returnField;
        }

        /// <summary>
        /// Removes the field
        /// </summary>
        /// <returns>The field</returns>
        /// <param name="columnName">Column name</param>
        public Field RemoveField(string columnName) {
            Field returnField = GetField(columnName);
            Fields.Remove(returnField);
            return returnField;
        }

        /// <summary>
        /// Adds the field
        /// </summary>
        /// <param name="columnName">Column name</param>
        /// <param name="value">Value</param>
        public void AddField(string columnName, object value) {
            AddField(new Field(columnName, value));
        }

        /// <summary>
        /// Add a new field
        /// </summary>
        /// <param name="field">New Field</param>
        public void AddField(Field field) {
            Field findField = GetField(field.Column);
            if (findField != null)
                Fields.Remove(findField);
            Fields.Add(field);
        }

        /// <summary>
        /// Get the count fields
        /// </summary>
        /// <returns>Count</returns>
        public int GetFieldsCount() {
            return Fields.Count;
        }

        /// <summary>
        /// Find a field from column name value
        /// </summary>
        /// <param name="columnName">Key for column name</param>
        /// <returns>Field</returns>
        public Field GetField(string columnName) {
            for (int i = 0; i < Fields.Count; i++) {
                if (Fields[i].Column.Equals(columnName))
                    return Fields[i];
            }
            return null;
        }

        /// <summary>
        /// Gets the field
        /// </summary>
        /// <returns>The field</returns>
        /// <param name="pos">Position</param>
        public Field GetField(int pos) {
            return Fields[pos];
        }

        /// <summary>
        /// Clear this instance
        /// </summary>
        public void Clear() {
            Fields.Clear();
        }

        /// <summary>
        /// Get the node root name
        /// </summary>
        /// <returns>Fields Container Type</returns>
        public abstract FieldsContainerType GetWebServiceFieldsContainerType();
    }
}
