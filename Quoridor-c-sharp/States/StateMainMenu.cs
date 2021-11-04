using System;
using System.Collections.Generic;
using System.Collections;

namespace Quoridor
{
    class StateMainMenu 
        : State
    {
        //private ArrayList players;

        // Constructors
        public StateMainMenu(Stack<State> states) 
            : base(states)
        {
            //this.players = players;
        }

        // Methods
        public void ChangeStates(String input)
        {
            switch (input)
            {
                case "start":
                    this.states.Push(new StateChooseSide(this.states));
                    break;
                case "quit":
                    Console.WriteLine("Quiting the game...");
                    this.end = true;
                    break;
                default:
                    Console.WriteLine(
                                    "Please, either start or quit the game"
                                    + "\n"
                                    + "-----------------------------------------"
                                    + "\n");
                    break;
            }
        }

        override public void Update()
        {
            Console.Clear();
            GUI.Title("Q U O R I D O R");
            GUI.Title("M a i n   M e n u");
            GUI.Options("Start the game (start)");
            GUI.Options("Quit the game (quit)");

            String userInput = Console.ReadLine();

            this.ChangeStates(userInput);
        }
    }
}
