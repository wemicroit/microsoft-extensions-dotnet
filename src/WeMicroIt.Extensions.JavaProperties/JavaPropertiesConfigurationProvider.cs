using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System;
using System.IO;
using System.Configuration;
using System.Linq;

namespace WeMicroIt.Extensions.Configuration.JavaProperties
{
    /// <summary>
    /// A Java Properties file based <see cref="FileConfigurationProvider"/>.
    /// </summary>
    internal class JavaPropertiesConfigurationProvider : FileConfigurationProvider
    {
        /// <summary>
        /// /// Initializes a new instance with the specified source.
        /// </summary>
        /// <param name="source">The source settings.</param>
        public JavaPropertiesConfigurationProvider(JavaPropertiesConfigurationSource source) : base(source) { }

        /// <summary>
        /// Loads the Java Properties data from a stream.
        /// </summary>
        /// <param name="stream">The stream to read.</param>
        public override void Load(Stream stream)
        {
            try
            {
                Data = JavaPropertiesConfigurationFileParser.Parse(stream);
            }
            catch (Exception e)
            {
                throw new FormatException("", e);
            }
        }
    }
}