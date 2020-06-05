using DFA.Objects.Interfaces;
using System;
using System.Collections.Generic;

namespace DFA.Logic
{
    public class Controller
    {
        private readonly bool isDebug;
        private IState currentState;

        public Controller(IState[] states, char[] alphabet, ITransition[] transitions, bool isDebug)
        {
            States = states;
            Alphabet = alphabet;
            Transitions = transitions;
            this.isDebug = isDebug;
            if (!Validate()) throw new ArgumentException("Invalid DFA");
        }

        public char[] Alphabet { get; }

        public IState[] States { get; }

        public ITransition[] Transitions { get; }

        public void Reset()
        {
            foreach (IState state in States)
            {
                if (state.StateType == StateType.Init || state.StateType == StateType.Both)
                {
                    currentState = state;
                    break;
                }
            }
        }

        public bool Run(char[] word)
        {
            foreach (char symbol in word)
            {
                Translate(symbol);
            }
            return currentState.IsFinal();
        }

        private void Translate(char symbol)
        {
            foreach (ITransition transition in currentState.Transitions)
            {
                if (transition.Symbol.Equals(symbol))
                {
                    Console.WriteLine("Gehe von Zustand " + currentState.Name + " mit Symbol " + symbol + " zu Zustand " + transition.EndState.Name);
                    currentState = transition.EndState;
                }
            }
        }

        private bool Validate()
        {
            List<string> names = new List<string>();
            bool hasEndStates = false;
            if (Transitions.Length != Alphabet.Length * States.Length) return false;
            foreach (IState state in States)
            {
                if (state.Name.Equals("")) return false;
                if (names.Contains(state.Name)) return false;
                else names.Add(state.Name);

                if (state.IsInit())
                {
                    if (currentState != null) return false;
                    else currentState = state;
                }
                if (state.IsFinal())
                {
                    hasEndStates = true;
                }

                if (state.Transitions.Count != Alphabet.Length) return false;
                foreach (ITransition transition in state.Transitions)
                {
                    bool alphabetContainsSymbol = false;
                    foreach (char symbol in Alphabet)
                    {
                        if (symbol == transition.Symbol)
                        {
                            alphabetContainsSymbol = true;
                            break;
                        }
                    }
                    if (!alphabetContainsSymbol) return false;

                    bool statesContainsEndState = false;
                    foreach (IState endstate in States)
                    {
                        if (endstate == transition.EndState)
                        {
                            statesContainsEndState = true;
                            break;
                        }
                    }
                    if (!statesContainsEndState) return false;
                }
            }

            return hasEndStates && currentState != null;
        }
    }
}