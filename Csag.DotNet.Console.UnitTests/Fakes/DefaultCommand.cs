namespace Csag.DotNet.Console.UnitTests.Fakes
{
    using System.Threading;
    using System.Threading.Tasks;
    using Csag.DotNet.Console.Abstractions;
    using Csag.DotNet.Console.UnitTests.Spies;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// The command for the default verb.
    /// </summary>
    /// <seealso cref="IDotNetConsoleCommand{TOptions}" />
    public class DefaultCommand : IDotNetConsoleCommand<DefaultOptions>
    {
        /// <summary>
        /// The logger
        /// </summary>
        private readonly IUnitTestLogger logger;

        /// <summary>
        /// The environment
        /// </summary>
        private readonly IHostEnvironment environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultCommand" /> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="environment">The environment.</param>
        public DefaultCommand(IUnitTestLogger logger, IHostEnvironment environment)
        {
            this.logger = logger;
            this.environment = environment;
        }

        /// <inheritdoc />
        public async Task RunAsync(DefaultOptions options, CancellationToken cancellationToken)
        {
            this.logger.Log("options", options);
            this.logger.Log("environment", this.environment);
            await Task.CompletedTask;
        }
    }
}
