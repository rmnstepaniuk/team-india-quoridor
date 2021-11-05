using System;
using System.Collections.Generic;

namespace Quoridor
{
    class State
    {
        // Properties
        protected Stack<State> states;
        protected bool end = false;

        // Constructors
        public State(Stack<State> states)
        {
            this.states = states;

            //Console.WriteLine(this.states.GetHashCode());
        }

        // Methods
        public bool RequestEnd()
        {
            return this.end;
        }
        virtual public void Update()
        {

        }
    }
}
