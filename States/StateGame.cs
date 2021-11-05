using System;
using System.Collections;
using System.Collections.Generic;

namespace Quoridor
{
    class StateGame
        : State
    {
        // Properties
        protected ArrayList players;
        private String startingSide;
        //int check;

        // Constructors
        public StateGame(Stack<State> states, ArrayList players, String side)
            : base(states)
        {
            this.players = players;
            this.startingSide = side;
        }

        // Methods
        public void ChangeStates(String input)
        {
            switch(input)
            {
                case "move":
                    foreach (Player player in players)
                    {
                        if (player.Side == startingSide)
                        {
                            player.Move();
                            break;
                        }
                    }
                    break;
                case "jump":
                    foreach (Player player in players)
                    {
                        if (player.Side == startingSide)
                        {
                            player.Jump();
                            break;
                        }
                    }
                    break;
                case "wall":
                    foreach (Player player in players)
                    {
                        if (player.Side == startingSide)
                        {
                            player.PlaceWall();
                            break;
                        }
                    }
                    break;
                case "exit":
                    this.end = true;
                    break;
                default:
                    Console.WriteLine(
                                    "Please, make a move"
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
            GUI.Board();
            GUI.Options("Move to coordinate (move)");
            GUI.Options("Jump over player (jump)");
            GUI.Options("Place a wall (wall)");
            GUI.Options("Exit the game (exit)");



            String input = Console.ReadLine();

            this.ChangeStates(input);

        }
    }
}
