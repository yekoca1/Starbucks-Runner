using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameManager _gameManager;
    //private player _player;
    public Button btnStart, nxtLevel;
    public GameObject menuUI, InGameUI, endUI; 
    public TextMeshProUGUI PuanTxt;

    void Start()
    {
        SetBindings();
           
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        //_player = GameObject.FindWithTag("Player").GetComponent<player>();
    }


    private void SetBindings()
    {
        btnStart.onClick.AddListener(()=>
        {
            _gameManager.startGame();
            menuUI.SetActive(false);
        }
        );   

        nxtLevel.onClick.AddListener(()=>
        {
           endUI.SetActive(false);
           _gameManager.startNextGame();  //çalışmadı bu kod
           
        }
        ); 
    }

    public void showPoint(int puan)
    {
        PuanTxt.text = puan + ": Puan";  //
    }  
    
    void Update()
    {
        
    }

    public void EndLevel()
    {
        endUI.SetActive(true);  
    }
}
