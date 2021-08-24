using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{
    public static GameplayController instance;
    [SerializeField]
    private Slider airSlider, timeSlider;
    private float airValue, timeValue;
    private float airDeductValue = 1f;
    [SerializeField]
    private bool gameRunning;
    private float airMax = 20f, timeMax = 20f;

    [SerializeField]
    private Canvas gameOverCanvas;
    [SerializeField]
    private Text winText, loseText;
    [SerializeField]
    private GameObject player;
    private float gameOverTimer = 3f;
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    private void Start()
    {
        timeValue = timeMax;
        timeSlider.maxValue = timeValue;
        timeSlider.minValue = 0f;
        timeSlider.value = timeValue;

        airValue = airMax;
        airSlider.maxValue = airValue;
        airSlider.minValue = 0f;
        airSlider.value = airValue;
        gameRunning = true;
        player = GameObject.FindWithTag(TagManager.PLAYER_TAG);
    }
    private void Update() {
        if(!gameRunning)
            return;
        ReduceAir();
        ReduceTime();
    }
    void ReduceTime(){
        timeValue -= Time.deltaTime;
        timeSlider.value = timeValue;
        if(timeValue<=0f)
        {
            // gameRunning = false;
            GameOver(false);
        }
    }
    void ReduceAir(){
        airValue -= Time.deltaTime;
         airSlider.value = airValue;
        if(airValue<=0f)
        {
            // gameRunning = false;
            GameOver(false);
        }
    }
    public void IncreaseAir(float air){
        airValue+=air;
        if(airValue>airMax)
            airValue = airMax;
        airSlider.value = airValue;
    }
    public  void IncreaseTime(float time){
        timeValue += time;
        if(timeValue > timeMax)
            timeValue = timeMax;
        timeSlider.value = timeValue;
    }
    public void GameOver(bool win){
        SoundController.instance.GameOverSound();
        Destroy(player);
        gameOverCanvas.enabled = true;
        gameRunning = false;
        if(win)
            winText.gameObject.SetActive(true);
        else if(!win)
            loseText.gameObject.SetActive(true);
        Invoke("RestartLevel", gameOverTimer);
    }
    private void RestartLevel(){
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
