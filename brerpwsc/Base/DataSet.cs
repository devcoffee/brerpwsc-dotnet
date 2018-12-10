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

namespace WebService.Base {

    /// <summary>
    /// Data set
    /// </summary>
    public class DataSet {

        private List<DataRow> rows {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebService.Base.DataSet"/> class.
        /// </summary>
        public DataSet() {
            rows = new List<DataRow>();
        }

        /// <summary>
        /// Gets the rows
        /// </summary>
        /// <returns>The rows</returns>
        public List<DataRow> GetRows() {
            List<DataRow> temp = new List<DataRow>();
            temp.AddRange(rows);
            return temp;
        }

        /// <summary>
        /// Adds the row
        /// </summary>
        /// <param name="row">Row</param>
        public void AddRow(DataRow row) {
            rows.Add(row);
        }

        /// <summary>
        /// Removes the row
        /// </summary>
        /// <param name="row">Row</param>
        public void RemoveRow(DataRow row) {
            rows.Remove(row);
        }

        /// <summary>
        /// Removes the row
        /// </summary>
        /// <returns>The row</returns>
        /// <param name="pos">Position</param>
        public DataRow RemoveRow(int pos) {
            DataRow row = rows[pos];
            RemoveRow(row);
            return row;
        }

        /// <summary>
        /// Gets the row
        /// </summary>
        /// <returns>The row</returns>
        /// <param name="pos">Position</param>
        public DataRow GetRow(int pos) {
            return rows[pos];
        }

        /// <summary>
        /// Gets the rows count
        /// </summary>
        /// <returns>The rows count</returns>
        public int GetRowsCount() {
            return rows.Count;
        }

        /// <summary>
        /// Clear this instance
        /// </summary>
        public void Clear() {
            rows.Clear();
        }
    }
}

