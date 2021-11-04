using System;
using System.Collections;
using System.Collections.Generic;

namespace Quoridor
{
    class StateGame
        : State
    {
        // Variables
        protected ArrayList players;

        // Constructors
        public StateGame(Stack<State> states, ArrayList players)
            : base(states)
        {
            this.players = players;
        }

        // Methods
        public void ChangeStates(String input)
        {
            switch(input)
            {
                case "start":
                    this.end = true;
                    break;
                default:
                    this.end = true;
                    break;
            }
        }
        override public void Update()
        {
            Console.Clear();
            GUI.Title("Q U O R I D O R");
            GUI.Board();
            GUI.Options("Move to coordinate (move)");
            GUI.Options("Jump to coordinate (jump)");
            GUI.Options("Place a wall (wall)");
            GUI.Options("Exit the game (exit)");
            String input = Console.ReadLine();

            this.ChangeStates(input);

        }
    }
}
