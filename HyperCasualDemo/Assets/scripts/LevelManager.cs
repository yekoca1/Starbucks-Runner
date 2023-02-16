using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public Level[] levels; 
    public int currentLevel;
    private player _player;
    private Vector3 defaultPosition; 
   
    public void Start()  // puan için de kullanılır
    {
        _player = GameObject.FindWithTag("Player").GetComponent<player>();
        currentLevel = PlayerPrefs.GetInt("Level", 0);
        defaultPosition = _player.transform.position;
    }
    
    public void startLevel()
    {
        levels[currentLevel].gameObject.SetActive(true);  // array boyutunda bir hata olabilir VEE N ye basınca geçiyo next levela basınca geçmiyo
        _player.transform.position = defaultPosition;
        
        
    }

    public void startNextLevel()
    {
        levels[currentLevel].gameObject.SetActive(false); // eski leveli kapat yeni leveli aç
        currentLevel++;
        PlayerPrefs.SetInt("Level", currentLevel);
        PlayerPrefs.Save();
        startLevel();
       // _player.coffeeCount = 0;
    }

    public void endLevel()
    {

    }
    private void Update()
    {
        
        
    }
}
