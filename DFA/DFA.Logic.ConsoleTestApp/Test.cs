using DFA.Logic;
using DFA.Objects;
using DFA.Objects.Interfaces;
using System;

namespace DFA.ConsoleTestApp
{
    public class Test
    {
        private static void Main(string[] args)
        {
            char[] alphabet = new char[] { '0', '1' };
            IState a = new State("A", StateType.Init);
            IState b = new State("B", StateType.Other);
            IState c = new State("C", StateType.Final);
            IState d = new State("D", StateType.Final);
            IState e = new State("E", StateType.Other);
            IState f = new State("F", StateType.Final);

            ITransition a0 = new Transition(b, '0');
            ITransition a1 = new Transition(e, '1');
            ITransition b0 = new Transition(b, '0');
            ITransition b1 = new Transition(c, '1');
            ITransition c0 = new Transition(d, '0');
            ITransition c1 = new Transition(c, '1');
            ITransition d0 = new Transition(d, '0');
            ITransition d1 = new Transition(f, '1');
            ITransition e0 = new Transition(e, '0');
            ITransition e1 = new Transition(e, '1');
            ITransition f0 = new Transition(e, '0');
            ITransition f1 = new Transition(f, '1');

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

            IState[] states = new IState[] { a, b, c, d, e, f };
            ITransition[] transitions = new ITransition[] { a0, a1, b0, b1, c0, c1, d0, d1, e0, e1, f0, f1 };

            string word = "0011111000";

            Controller controller = new Controller(states, alphabet, transitions, true);
            bool accepted = controller.Run(word.ToCharArray());
            Console.WriteLine("Das Wort " + word + " wurde " + (accepted ? "" : "nicht ") + "akzeptiert");
            Console.ReadLine();
        }
    }
}