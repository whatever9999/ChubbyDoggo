using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Camera cam;
    public GameObject[] droppables;
    public new Renderer renderer;
    private float maxWidth;
    public float timeLeft = 0;
    public Text timerText;
    public GameObject gameOver;
    public GameObject restartButton;
    public GameObject splashScreen;
    public GameObject startButton;
    private bool playing;
    public DogeController dogeController;

    // Use this for initialization
    void Start() {
        renderer = droppables[0].GetComponent<Renderer>();

        if (cam == null) {
            cam = Camera.main;
        }
        playing = false;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float carrotWidth = renderer.bounds.extents.x;
        maxWidth = targetWidth.x - carrotWidth;
        UpdateText();
    }

    void FixedUpdate() {
        if(playing) {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = 0;
            }
            UpdateText();
        }
    }

    public void StartGame() {
        splashScreen.SetActive(false);
        startButton.SetActive(false);
        UpdateText();
        dogeController.ToggleControl(true);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        yield return new WaitForSeconds(2.0f);
        playing = true;
        while (timeLeft > 0) {
            GameObject droppable = droppables[Random.Range(0, droppables.Length)];
            Vector3 spawnPosition = new Vector3(Random.Range(-maxWidth + 1, maxWidth - 1), transform.position.y, 0.0f);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(droppable, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));
        }
        yield return new WaitForSeconds(0.2f);
        gameOver.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        restartButton.SetActive(true);
    }

    void UpdateText() {
        timerText.text = "Time Left:\n" + Mathf.RoundToInt(timeLeft);
    }
}