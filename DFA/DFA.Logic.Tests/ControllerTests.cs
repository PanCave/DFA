using DFA.Objects;
using DFA.Objects.Interfaces;
using System;

namespace DFA.Logic.Tests
{
    public class ControllerTests
    {
        private static void Main(string[] args)
        {
            char[] alphabet = new char[] { '0', '1' };
            State a = new State("A", StateType.Init);
            State b = new State("B", StateType.Other);
            State c = new State("C", StateType.Final);
            State d = new State("D", StateType.Final);
            State e = new State("E", StateType.Other);
            State f = new State("F", StateType.Final);

            Transition a0 = new Transition(b, '0');
            Transition a1 = new Transition(e, '1');
            Transition b0 = new Transition(b, '0');
            Transition b1 = new Transition(c, '1');
            Transition c0 = new Transition(d, '0');
            Transition c1 = new Transition(c, '1');
            Transition d0 = new Transition(d, '0');
            Transition d1 = new Transition(f, '1');
            Transition e0 = new Transition(e, '0');
            Transition e1 = new Transition(e, '1');
            Transition f0 = new Transition(e, '0');
            Transition f1 = new Transition(f, '1');

            a.AddTransition(a0);
            a.AddTransition(a1);
            b.AddTransition(b0);
            b.AddTransition(b1);
            c.AddTransition(c0);
            c.AddTransition(c1);
            d.AddTransition(d0);
            d.AddTransition(d1);
            e.AddTransition(e0);
            e.AddTransition(e1);
            f.AddTransition(f0);
            f.AddTransition(f1);

            IState[] states = new State[] { a, b, c, d, e, f };
            ITransition[] transitions = new Transition[] { a0, a1, b0, b1, c0, c1, d0, d1, e0, e1, f0, f1 };

            string word = "01010111010";

            Controller controller = new Controller(states, alphabet, transitions, true);
            bool accepted = controller.Run(word.ToCharArray());
            Console.WriteLine("Das Wort " + word + " wurde " + (accepted ? "" : "nicht") + " akzeptiert");
        }
    }
}