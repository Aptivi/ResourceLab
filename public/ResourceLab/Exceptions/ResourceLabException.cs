//
// ResourceLab  Copyright (C) 2025  Aptivi
//
// This file is part of ResourceLab
//
// ResourceLab is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// ResourceLab is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY, without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
//

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ResourceLab.Exceptions
{
    /// <summary>
    /// Exception class of resource management errors
    /// </summary>
    public class ResourceLabException : Exception
    {
        /// <summary>
        /// Creates a new instance of this exception
        /// </summary>
        public ResourceLabException()
        { }

        /// <summary>
        /// Creates a new instance of this exception
        /// </summary>
        /// <param name="message">Message to describe the exception</param>
        public ResourceLabException(string message) :
            base(message)
        { }

        /// <summary>
        /// Creates a new instance of this exception
        /// </summary>
        /// <param name="message">Message to describe the exception</param>
        /// <param name="innerException">Inner exception to use</param>
        public ResourceLabException(string message, Exception innerException) :
            base(message, innerException)
        { }
    }
}
