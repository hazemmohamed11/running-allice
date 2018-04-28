using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    private float score = 0.0f;
    private int difficultyLevel = 1;
    private int maxDifficultyLevel = 20;
    private int scoreToNextLevel = 10;
    private bool isDead = false;
    public DeathMenu deathMenu;

    void Start()
    {

    }

    void Update()
    {

        if (isDead)
        {
            return;
        }

        if (score >= scoreToNextLevel)
        {
            LevelUp();
        }
        score += Time.deltaTime * difficultyLevel;
        scoreText.text = ((int)score).ToString();

    }

    private void LevelUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
        {
            return;
        }
        scoreToNextLevel *= 2;
        difficultyLevel++;
        GetComponent<PlayerMovement>().SetSpeed(difficultyLevel);
    }

    public void OnDeath()
    {
        isDead = true;
        deathMenu.ToggleEndMenu(score);
    }
}
