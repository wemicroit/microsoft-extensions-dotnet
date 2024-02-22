using Microsoft.Extensions.Configuration;

namespace WeMicroIt.Extensions.Configuration.JavaProperties
{
    /// <summary>
    /// Represents a Java Properties file as an <see cref="IConfigurationSource"/>.
    /// </summary>
    public class JavaPropertiesConfigurationSource : FileConfigurationSource
    {
        /// <summary>
        /// Builds the <see cref="JavaPropertiesConfigurationBuilder"/> for this source.
        /// </summary>
        /// <param name="builder">The <see cref="IConfigurationBuilder"/>.</param>
        /// <returns>A <see cref="JavaPropertiesConfigurationBuilder"/></returns>
        public override IConfigurationProvider Build(IConfigurationBuilder builder)
        {
            EnsureDefaults(builder);
            return new JavaPropertiesConfigurationProvider(this);
        }
    }
}
