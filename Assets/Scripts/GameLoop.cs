using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour {
  public LevelManagerScriptableObject levelManager;
  public GameObject nextLevelUI;
  public GameObject nextLevelBtn;
  public GameObject gameOverUI;
  public GameObject upgradeUI;

  private bool hasUpgraded = false;
  private float initialDamage = 5f;
  private float initialSplashSizeMultiplier = 1f;

  void Start() {
    levelManager.levelEnd = false;
    levelManager.gameOver = false;
    levelManager.fireMaxHp = 30 + Mathf.FloorToInt(levelManager.level / 3);
  }

  void Update() {

    var fires = GameObject.FindGameObjectsWithTag("Fire");
    var fireSpirits = GameObject.FindGameObjectsWithTag("FireSpirit");
    if (fires.Length == 0 && fireSpirits.Length == 0) {
      levelManager.levelEnd = true;
      nextLevelUI.SetActive(true);

      upgradeUI.SetActive(!hasUpgraded);
      nextLevelBtn.SetActive(hasUpgraded);
    }

    var trees = GameObject.FindGameObjectsWithTag("Tree");
    if (trees.Length == 0) {
      levelManager.gameOver = true;
      gameOverUI.SetActive(true);
    }
  }

  private void ResumeGame() {
    nextLevelUI.SetActive(false);
    gameOverUI.SetActive(false);
    levelManager.levelEnd = false;
    levelManager.gameOver = false;
  }

  public void NextLevel() {
    ResumeGame();
    levelManager.level += 1;
    SceneManager.LoadScene(1);
  }

  public void Restart() {
    ResumeGame();
    levelManager.level = 1;
    levelManager.damage = initialDamage;
    levelManager.splashSizeMultiplier = initialSplashSizeMultiplier;
    SceneManager.LoadScene(1);
  }

  public void UpgradeDamage() {
    levelManager.damage += .5f;
    hasUpgraded = true;
  }

  public void UpgradeSplash() {
    levelManager.splashSizeMultiplier += .05f;
    hasUpgraded = true;
  }
}
