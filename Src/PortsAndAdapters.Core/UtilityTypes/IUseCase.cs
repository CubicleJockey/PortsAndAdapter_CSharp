namespace PortsAndAdapters.Core.UtilityTypes
{
    /// <summary>
    ///     Represents a use case of the Mjn Flipboard
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public interface IUseCase<in TInput, out TOutput>
    {
        /// <summary>
        ///     Executes a use case of the Mjn Flipboard
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        TOutput Execute(TInput input);
    }

    /// <summary>
    ///     Represents a use case of the Mjn Flipboard
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    public interface IUseCase<in TInput>
    {
        /// <summary>
        ///     Executes a use case of the Mjn Flipboard
        /// </summary>
        /// <param name="input"></param>
        void Execute(TInput input);
    }
}