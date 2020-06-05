using System.Collections.Generic;

namespace DFA.Objects.Interfaces
{
    public interface IState
    {
        string Name { get; }

        StateType StateType { get; }

        List<ITransition> Transitions { get; }

        void AddTransition(ITransition transition);

        bool IsFinal();

        bool IsInit();
    }
}