using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class manager : MonoBehaviour {
	public Slider hpSlider;
	public Text ptsText;
	public Camera gameCam;
	public Image pauseScreen;
	public float shake;
	public float shakeAmount;
	public float decreaseFactor;
	public int hpVal;
	public int ptsVal;
	public bool isPaused;

	public Image hurtVig;
	public bool isHurt;
	public float hurt;

	public Image regainVig;
	public bool isRegain;
	public float regain;

	public Image pointVig;
	public bool isPoint;
	public float point;

	// Use this for initialization
	void Start () {
		isPaused = false;
		hpVal = 100;
		ptsVal = 0;
		shake = 0f;
		shakeAmount = 0.3f;
		decreaseFactor = 1.0f;

		hurt = 0f;
		regain = 0f;
		point = 0f;
		hurtVig.color = new Color(1f,1f,1f,0f);
		regainVig.color = new Color(1f,1f,1f,0f);
		pointVig.color = new Color(1f,1f,1f,0f);
	}

	public void plusHealth() {
		if (hpVal < 100) {
			hpVal += 5;
			regain = 1f;
			isRegain = true;
		}
	}

	public void decreaseHealth() {
		if (hpVal > 0) {
			hpVal -= 5;
			hurt = 1f;
			isHurt = true;
		} else {
			// Mati
		}
	}

	public void plusPts() {
		ptsVal += 50;
		point = 1f;
		isPoint = true;
	}

	public void decreasePts() {
		if (ptsVal > 0) {
			ptsVal -= 50;
		}
	}

	public void shakeCam() {
		shake = 1f;
	}

	public void pause() {
		isPaused = true;
		pauseScreen.rectTransform.anchoredPosition = new Vector3 (0, 0, 5);
		Time.timeScale = 0;
	}

	public void resume() {
		isPaused = false;
		pauseScreen.rectTransform.anchoredPosition = new Vector3 (981, 55, 0);
		Time.timeScale = 1;	
	}

	// Update is called once per frame
	void Update () {
		hpSlider.value = hpVal;
		ptsText.text = "" + ptsVal;

		if (shake > 0 && !isPaused) {
			gameCam.transform.localPosition = Random.insideUnitCircle * shakeAmount;
			gameCam.transform.position = new Vector3(gameCam.transform.position.x, gameCam.transform.position.y, -7.5f);
			shake -= Time.deltaTime * decreaseFactor;
		} else {
			shake = 0;
			gameCam.transform.position = new Vector3(0, 0, -7.5f);
		}

		if (hurt > 0 && isHurt) {
			hurtVig.color = new Color(1f,1f,1f,hurt);
			hurt -= Time.deltaTime * decreaseFactor;
		} else {
			hurt = 0;
			isHurt = false;
			hurtVig.color = new Color(1f,1f,1f,0f);
		}

		if (regain > 0 && isRegain) {
			regainVig.color = new Color(1f,1f,1f,regain);
			regain -= Time.deltaTime * decreaseFactor;
		} else {
			regain = 0;
			isRegain = false;
			regainVig.color = new Color(1f,1f,1f,0f);
		}

		if (point > 0 && isPoint) {
			regainVig.color = new Color(1f,1f,1f,point);
			point -= Time.deltaTime * decreaseFactor;
		} else {
			point = 0;
			isPoint = false;
			pointVig.color = new Color(1f,1f,1f,0f);
		}
	}
}
