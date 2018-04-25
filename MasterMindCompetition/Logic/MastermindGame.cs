﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMindCompetition.Logic { //this namespace handles the shared logic of all sub-games
    public enum Colour { Red, Green, Blue, Yellow, Orange, Pink}

    public abstract class MastermindGame { //abstract as a game must be of a certain type (ie auto-codemaker)
        protected Code target; //the code generated by the codemaker
        protected List<Code> guessCodes= new List<Code>(); //holds the codebreaker's guesses
        protected IMastermindHostForm hostForm; //reference back to GUI
        protected int codeLength;
        public int maxGuesses { get; set; } //the max number of guesses that may be made
        

        protected MastermindGame(IMastermindHostForm _form) { //initialise the game
            hostForm = _form; //update the host form
			
        }

		public int getCurrentGuesses() { //external access to this variable
			return guessCodes.Count; //return the value
		}

        public void runGame(int _maxGuesses, int _codeLength) { //the game loop

            //initialise some vars
            maxGuesses = _maxGuesses;
            codeLength = _codeLength;

            initialiseGame();//run first stages of game (generating target code, etc)

	        while (doTurn() && (guessCodes.Count < maxGuesses || maxGuesses <= 0)); //repeat doTurn until game over
			if(guessCodes.Count >= maxGuesses && maxGuesses > 0) //if the player has expended their avaliable turns
				endGame(false);//tell the form to display its loss message
			//a message is not displayed if it stops due to 'unnatural causes' (the input code was null. this normally means the form wants to close)
        } //create a new game

        protected abstract void initialiseGame(); //run first stages of game (generating target code, etc)

	    protected abstract bool doTurn(); //return true if game to be continued, false if game over

	    protected abstract void endGame(bool winLose); //end the game with a win or lose state

        //properties to allow limited access to some private members from public scope
        public List<Code> GuessCodes { get { return guessCodes; } } //allow readonly access to the guessed codes
    }
}
