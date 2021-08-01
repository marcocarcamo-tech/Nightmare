using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int time = 30;
    public int difficulty = 1;
    [SerializeField]int score;

    //Score property
    public int Score
    {
        get => score;
        set {
            score = value;
            if (score % 1000 == 0) {
                difficulty++;
            }
            
        }
    }

    // Singleton design pattern
    void Awake()
    {
        if(Instance == null) {
            Instance = this;
        }
    }

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(CountDownRoutine());
    }

    private void Update()
    {
        //Debug.Log(time);
    }

    IEnumerator CountDownRoutine() {
        while(time > 0) {
            yield return new WaitForSeconds(1);
            time--;

        }
    }

    
}
