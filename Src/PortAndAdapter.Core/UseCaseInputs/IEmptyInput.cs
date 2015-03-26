namespace PortAndAdapter.Core.UseCaseInputs
{
    public interface IEmptyInput
    {

    }

    public class EmptyInput : IEmptyInput
    {
        public static EmptyInput Instance { get { return new EmptyInput(); } }
    }
}