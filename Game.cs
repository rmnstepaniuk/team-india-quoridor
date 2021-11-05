using System;
using System.Collections;
using System.Collections.Generic;

namespace Quoridor
{
    class Game
    {
        // Properties
        private bool end;
        public bool End
        {
            get { return this.end; }
            set { this.end = value; }
        }
        private ArrayList players;
        private Stack<State> states;

        // Private methods
        private void InitVariables()
        {
            this.end = false;
        }

        private void InitStates()
        {
            this.states = new Stack<State>();

            // Push first state
            this.states.Push(new StateMainMenu(this.states));

            // Push tester first state
            //this.states.Push(new StateChooseSide(this.states));
        }

        private void InitPlayers()
        {
            this.players = new ArrayList();
        }

        // Constructors and Destructors
        public Game()
        {
            this.InitVariables();
            this.InitStates();
            this.InitPlayers();
        }

        public void Run()
        {
            while (this.states.Count > 0)
            {
                this.states.Peek().Update();

                if (this.states.Peek().RequestEnd())
                    this.states.Pop();

            }
        }
    }
}
