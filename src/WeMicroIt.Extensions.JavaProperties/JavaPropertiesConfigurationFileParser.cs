using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace WeMicroIt.Extensions.Configuration.JavaProperties
{
    internal class JavaPropertiesConfigurationFileParser
    {
        private JavaPropertiesConfigurationFileParser() { }

        private readonly Dictionary<string, string> _data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public static IDictionary<string, string> Parse(Stream input)
            => new JavaPropertiesConfigurationFileParser().ParseStream(input);

        private Dictionary<string, string> ParseStream(Stream input)
        {
            using (var reader = new StreamReader(input))
            {
                do {

                    var x = reader.ReadLine();
                    if (x.Contains("#"))
                    {
                        x = x.Split('#')[0];
                    }
                    if (!string.IsNullOrEmpty(x) && x.Contains("="))
                    {
                        var position = x.IndexOf("=");
                        _data.Add(x.Substring(0, position).Replace(".", ConfigurationPath.KeyDelimiter), x.Substring(position+1));
                    }
                }
                while (!reader.EndOfStream);
            }

            return _data;
        }

    }
}
