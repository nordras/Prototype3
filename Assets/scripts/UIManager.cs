using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
  private int score = 0;
  public Text scoreText;
  public Sprite[] lives;
  public Image livesImage;
  public GameObject TitleScreen;

  public void UpdateLives(int currentLives)
  {
    livesImage.sprite = lives[currentLives];
  }
  public void UpdateScore(int points)
  {
    score += points;
    scoreText.text = "Score: " + score;
  }
  public void ToggleTitleScren(bool show)
  {
    TitleScreen.SetActive(show);
  }
}
