// ****************************************************************************
// <copyright file="ApplicationManifestNamedNode.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2012
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>26-12-2012</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Cimbalino.Phone.Toolkit.Helpers
{
    /// <summary>
    /// Represents a named node in the application manifest.
    /// </summary>
    public class ApplicationManifestNamedNode : IXmlSerializable
    {
        /// <summary>
        /// Gets the list of values for this named node.
        /// </summary>
        /// <value>The list of values for this named node.</value>
        public Dictionary<string, object> Values { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationManifestNamedNode"/> class.
        /// </summary>
        public ApplicationManifestNamedNode()
        {
            Values = new Dictionary<string, object>();
        }

        XmlSchema IXmlSerializable.GetSchema()
        {
            throw new NotImplementedException();
        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            var container = reader.LocalName;

            reader.ReadStartElement();

            while (reader.LocalName != container)
            {
                Values.Add(reader.GetAttribute("Name"), null);
                reader.Read();
            }

            reader.ReadEndElement();
        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}