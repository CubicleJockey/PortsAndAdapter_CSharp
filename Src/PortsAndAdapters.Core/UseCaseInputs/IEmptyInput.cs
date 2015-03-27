namespace PortsAndAdapters.Core.UseCaseInputs
{
    public interface IEmptyInput
    {
    }

    public sealed class EmptyInput : IEmptyInput
    {
        public static EmptyInput Instance
        {
            get { return new EmptyInput(); }
        }
    }
}