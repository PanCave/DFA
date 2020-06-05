using DFA.Objects.Interfaces;

namespace DFA.Objects
{
    public class Transition : ITransition
    {
        public Transition(IState endState, char symbol)
        {
            EndState = endState;
            Symbol = symbol;
        }

        public IState EndState { get; }
        public char Symbol { get; }
    }
}