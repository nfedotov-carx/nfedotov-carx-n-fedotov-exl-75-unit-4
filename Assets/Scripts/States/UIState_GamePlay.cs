using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class GamePlayState : GameState
    {
        public LevelController levelContr;
        public PlayerContr playerContr;
        public GameState gameOverState;
        public TMP_Text scoreText;

        protected override void OnEnable()
        {
            base.OnEnable();

            Debug.Log("Ping?");
            levelContr.enabled = true;
            playerContr.enabled = true;
            // levelContr.gameObject.SetActive(true); // �� ������
            // playerContr.gameObject.SetActive(true); // �� ������
            levelContr.score = 0; // �� ������

            GameEvents.onCollisionStone += OnGameOver;
            GameEvents.onStickHit += OnStickHit;
            //OnStickHit();
        }

        
        private void OnStickHit()
        {
            scoreText.text = $" Score: {levelContr.score}";
        }
        

        private void OnGameOver()
        {
            Exit();
            gameOverState.Enter();
        }

        protected override void OnDisable()
        {
            base.OnDisable();

            GameEvents.onCollisionStone -= OnGameOver;

            levelContr.enabled = false;
            playerContr.enabled = false;
        }
    }
}
