using Microsoft.Extensions.Logging;

using MvvmCross.Platforms.Wpf.Core;

using Serilog;
using Serilog.Extensions.Logging;

namespace MyMvvmCrossTemplate.Wpf
{
    public class Setup : MvxWpfSetup<Core.App>
    {
        /// <summary>
        ///     Create the log provider
        /// </summary>
        /// <returns></returns>
        protected override ILoggerProvider CreateLogProvider() => new SerilogLoggerProvider();

        /// <summary>
        ///     Create log factory
        /// </summary>
        /// <returns></returns>
        protected override ILoggerFactory CreateLogFactory()
        {
            // serilog configuration
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Trace()
                .WriteTo.File("output.log")
                .CreateLogger();

            return new SerilogLoggerFactory();
        }
    }
}
