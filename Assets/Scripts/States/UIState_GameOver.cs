using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GameOverState : GameState
    {
        public GameState mainMenuState;
        public LevelController levelContr;

        public void Restart()
        {
           levelContr.ClearStones();

            Exit();
            mainMenuState.Enter();
        }
    }
}
