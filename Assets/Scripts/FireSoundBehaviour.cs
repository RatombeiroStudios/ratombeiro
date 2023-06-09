using UnityEngine;

public class FireSoundBehaviour : MonoBehaviour {
  private int fireCount = 0;

  void Update() {
    var fires = GameObject.FindGameObjectsWithTag("Fire");
    if (fires.Length > fireCount) {
      GetComponent<AudioSource>().Play();
    }

    fireCount = fires.Length;
  }
}
