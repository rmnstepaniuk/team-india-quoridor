using System;
using System.Collections.Generic;
using System.Collections;

namespace Quoridor
{
    class StateChooseSide 
        : State
    {
        // Variables
        Player player, bot;
        protected ArrayList players = new ArrayList();

        // Constructors
        public StateChooseSide(Stack<State> states)
            : base(states)
        {
        }

        // Methods
        public void ChangeStates(String input)
        {
            switch(input)
            {
                case "white":
                    player = new Player(input);
                    bot = new Player("black");
                    players.Add(player);
                    players.Add(bot);
                    Console.WriteLine(player.ToString());
                    this.states.Push(new StateGame(this.states, this.players));

                    break;
                case "black":
                    player = new Player(input);
                    bot = new Player("white");
                    players.Add(player);
                    players.Add(bot);
                    Console.WriteLine(player.ToString());
                    this.states.Push(new StateGame(this.states, this.players));

                    break;
                case "exit":
                    Console.WriteLine("Exiting to Main Menu...\n");
                    this.end = true;
                    break;
                default:
                    Console.WriteLine(
                                    "Please, choose either white or black side"
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
            GUI.Title("CHOOSE YOUR SIDE");
            GUI.Options("Choose your side (white | black)");
            GUI.Options("Exit to Main Menu (exit)");

            string userInput = Console.ReadLine();

            this.ChangeStates(userInput);
        }
    }
}
