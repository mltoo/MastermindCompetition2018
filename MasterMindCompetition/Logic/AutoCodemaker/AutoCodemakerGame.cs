﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMindCompetition.Logic.AutoCodemaker {//contains code for specifically the auto-codemaker sub game
    internal class AutoCodemakerGame : MastermindGame { //specifically the game where the computer acts as the codemaker and a human player acts as codebreaker
        private Codemaker codemaker = new Codemaker(); //create a new codemaker

	    protected new IAutoCodemakerHostForm hostForm;
        public AutoCodemakerGame(IAutoCodemakerHostForm _hostForm) : base(_hostForm){ //create (but do not start) a new game
	        hostForm = _hostForm; //take in a reference to the host form
	        //TODO: fill this out
        }

        protected override void initialiseGame() { //run first stages of game (generating target code, etc)
            target = codemaker.generateCode(codeLength); //generate a new code
        }

	    protected override bool doTurn() {
		    hostForm.nextTurn();


			Code inputCode = hostForm.getCodeFromPlayer();
			hostForm.endPlayerInput();
			guessCodes.Add(inputCode);
			if (guessCodes[guessCodes.Count - 1] == target) {
				endGame(true);
				return false;//no more turns to be done
			}
			hostForm.displayResults(inputCode.checkGuess(target));

		    return true; //the player has not guessed the code yet; more turns need to be done
	    }

	    protected override void endGame(bool winLose) {
		    hostForm.endGame(winLose);
	    }

    }
}