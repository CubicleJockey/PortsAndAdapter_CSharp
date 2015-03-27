namespace PortsAndAdapters.Core.UseCaseInputs
{
    public interface IEmptyInput{}

    public sealed class EmptyInput : IEmptyInput
    {
        #region Constructors

        static EmptyInput()
        {
            Instance = new EmptyInput();
        }

        #endregion Constructors

        #region Properties

        public static EmptyInput Instance { get; private set; }

        #endregion Properties
    }
}