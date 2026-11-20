namespace Csag.DotNet.Console.Internal
{
    using System;
    using System.Threading.Tasks;
    using Csag.DotNet.Console.Abstractions;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// The no operation console application.
    /// </summary>
    /// <seealso cref="IDotNetConsole" />
    public class NoOperationConsole : IDotNetConsole
    {
        /// <inheritdoc />
        public IServiceProvider Services => new ServiceCollection().BuildServiceProvider();

        /// <inheritdoc />
        public Task RunAsync()
        {
            return Task.CompletedTask;
        }
    }
}
