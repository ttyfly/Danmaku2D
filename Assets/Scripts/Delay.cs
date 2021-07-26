using System.Collections;
using AngleRD.Danmaku2D.Runtime;
using UnityEngine;

public class Delay : MonoBehaviour {
    private PrefabBulletBehaviour prefabBullet;

    void Start() {
        prefabBullet = GetComponent<PrefabBulletBehaviour>();
        StartCoroutine(WaitThenStartBullet());
    }

    IEnumerator WaitThenStartBullet() {
        yield return new WaitForSeconds(1);
        prefabBullet.Play();
    }
}
