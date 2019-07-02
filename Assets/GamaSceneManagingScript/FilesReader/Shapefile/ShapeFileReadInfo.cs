﻿using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Text;
using UnityEngine;

namespace ummisco.gama.unity.files.ShapefileImporter
{
    /// <summary>
    /// The ShapeFileReadInfo class stores information about a shapefile
    /// that can be used by external clients during a shapefile read.
    /// </summary>
    public class ShapeFileReadInfo
    {
        #region Private fields
        private string fileName;
        private ShapeFile shapeFile;
        private Stream stream;
        private int numBytesRead;
        private int recordIndex;
        #endregion Private fields

        #region Constructor
        /// <summary>
        /// Constructor for the ShapeFileReadInfo class.
        /// </summary>
        public ShapeFileReadInfo()
        {
        }
        #endregion Constructor

        #region Properties
        /// <summary>
        /// The full pathname of the shapefile.
        /// </summary>
        public string FileName
        {
            get { return this.fileName; }
            set { this.fileName = value; }
        }

        /// <summary>
        /// A reference to the shapefile instance.
        /// </summary>
        public ShapeFile ShapeFile
        {
            get { return this.shapeFile; }
            set { this.shapeFile = value; }
        }

        /// <summary>
        /// An opened file stream for a shapefile.
        /// </summary>
        public Stream Stream
        {
            get { return this.stream; }
            set { this.stream = value; }
        }

        /// <summary>
        /// The number of bytes read from a shapefile so far.
        /// Can be used to compute a progress value.
        /// </summary>
        public int NumberOfBytesRead
        {
            get { return this.numBytesRead; }
            set { this.numBytesRead = value; }
        }

        /// <summary>
        /// A general-purpose record index.
        /// </summary>
        public int RecordIndex
        {
            get { return this.recordIndex; }
            set { this.recordIndex = value; }
        }
        #endregion Properties

        #region Public methods
        /// <summary>
        /// Output some of the field values in the form of a string.
        /// </summary>
        /// <returns>A string representation of the field values.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("ShapeFileReadInfo: FileName={0}, ", this.fileName);
            sb.AppendFormat("NumberOfBytesRead={0}, RecordIndex={1}", this.numBytesRead, this.recordIndex);

            return sb.ToString();
        }
        #endregion Public methods
    }
}