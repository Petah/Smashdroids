using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MiniMap : MonoBehaviour {

    private float width = 100;
    private float height = 100;
    private float x = 10;
    private float y = 110;

    private float range = 300;

    public GameObject player;
    private List<GameObject> enemies;
    private List<GameObject> asteroids;

    public Texture2D playerIcon;
    public Texture2D enemyIcon;
    public Texture2D asteroidIcon;
    private float iconWidth = 10;
    private float iconHeight = 10;

    public void Start() {
        InvokeRepeating("RescanGameObjects", 0f, 1f);
    }

    public void RescanGameObjects() {
        enemies = new List<GameObject>();
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("AI")) {
            enemies.Add(enemy);
        }
        asteroids = new List<GameObject>();
        foreach (GameObject asteroid in GameObject.FindGameObjectsWithTag("Asteroid")) {
            asteroids.Add(asteroid);
        }
    }

    public void OnGUI() {
        GUI.Box(new Rect(x, y, width, height), "");
        DrawGamesObjects(asteroids, asteroidIcon);
        DrawGamesObjects(enemies, enemyIcon);
        DrawIcon(0.5f, 0.5f, playerIcon);
    }

    public void DrawGamesObjects(List<GameObject> gameObjects, Texture2D icon) {
        foreach (GameObject gameObject in gameObjects) {
            if (gameObject == null) {
                continue;
            }
            float relativeX = (player.transform.position.x - gameObject.transform.position.x) / range + 0.5f;
            float relativeY = (player.transform.position.z - gameObject.transform.position.z) / range + 0.5f;
            relativeX = Mathf.Abs(relativeX - 1);
            if (relativeX > 0 && relativeX < 1 &&
                    relativeY > 0 && relativeY < 1) {
                DrawIcon(relativeX, relativeY, icon);
            }
        }
    }

    public void DrawIcon(float relativeX, float relativeY, Texture2D icon) {
        GUI.DrawTexture(new Rect(
            x + (width * relativeX) - (iconWidth / 2),
            y + (height * relativeY) - (iconHeight / 2),
            iconWidth,
            iconHeight
        ), icon);
    }

//    private Texture2D miniMap;
//
//    public void OnGUI() {
//        if (miniMap) {
////            GUI.DrawTexture(new Rect(0, 128, 128, 128), miniMap);
//        }
//    }
//
//    public void FixedUpdate() {
//        if (!miniMap) {
//            miniMap = new Texture2D(128, 128);
//        }
//
//        miniMap.SetPixel(miniMap.width / 2, miniMap.height / 2, Color.green);
//
//        miniMap.Apply();
//    }

}
