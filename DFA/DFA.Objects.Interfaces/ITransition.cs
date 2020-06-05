namespace DFA.Objects.Interfaces
{
    public interface ITransition
    {
        IState EndState { get; }
        char Symbol { get; }
    }
}