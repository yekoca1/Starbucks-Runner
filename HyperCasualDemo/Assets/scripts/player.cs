using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public GameManager _gameManager;
    public int forwardSpeed;
    public int coffeeCount = 0;
    LevelManager _levelManager;

    void Start()          // kamera takibi için cinemachine kullanılacak..!
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();   
        _levelManager = _gameManager.GetComponent<LevelManager>();
        coffeeCount = PlayerPrefs.GetInt("puan", 0);
        forwardSpeed = PlayerPrefs.GetInt("speed", 10);
    }

    private float firstTouchx;
    float fark;
    void Update()
    {
        if(_gameManager.currentGameState != GameState.Start)
        {
            return; // eğer game state start durumunda değilse hiç burayı çalıştırma !!!
        }

        Vector3 moveForward = new Vector3(-1*forwardSpeed*Time.deltaTime, 0, 0); // ileriye doğru sabit hız;

        if(Input.GetMouseButtonDown(0))  // ekrana basılı tutulduğunda basılan yöne hareket 
        {
            firstTouchx = Input.mousePosition.x;
        }
        else if(Input.GetMouseButton(0))
        {
            float lastTouchx = Input.mousePosition.x;
            fark = lastTouchx - firstTouchx;

            moveForward += new Vector3(0, 0, fark*Time.deltaTime);
            firstTouchx = lastTouchx;
        }
        transform.position += moveForward;
    }

    private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Collectible"))
            {
                other.transform.SetParent(transform);  // çarptığın objenin parent objesi playerımız olur..!  aşağıya kahveleri YOK EDEN kodu yaz
                //coffeeCount = coffeeCount + 1*(_levelManager.currentLevel+1);
                Destroy(other.gameObject);
                forwardSpeed ++;
                coffeeCount++;
                PlayerPrefs.SetInt("puan", coffeeCount);
                PlayerPrefs.SetInt("speed", forwardSpeed);
                PlayerPrefs.Save();
            }
            else if(other.CompareTag("Finish"))
            {
                /*if(coffeeCount==1)
                {
                    _gameManager.EndGame();
                }

                coffeeCount--;*/
                _gameManager.EndGame();
                Debug.Log("Puanınız :"+coffeeCount);
            }
        }
}
