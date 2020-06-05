using DFA.Objects.Interfaces;
using System.Collections.Generic;

namespace DFA.Objects
{
    public class State : IState
    {
        public State(string name, StateType stateType)
        {
            Name = name;
            StateType = stateType;
            Transitions = new List<ITransition>();
        }

        public string Name { get; }
        public StateType StateType { get; }

        public List<ITransition> Transitions { get; }

        public void AddTransition(ITransition transition)
        {
            Transitions.Add(transition);
        }

        public bool IsFinal()
        {
            return StateType == StateType.Final || StateType == StateType.Both;
        }

        public bool IsInit()
        {
            return StateType == StateType.Init || StateType == StateType.Both;
        }
    }
}