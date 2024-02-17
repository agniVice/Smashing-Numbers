using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberSpawner : MonoBehaviour, ISubscriber
{
    public static NumberSpawner Instance;

    public List<GameObject> Prefabs = new List<GameObject>();

    private Digit _currentNumber;
    private Digit _nextNumber;

    private int _maxNumber = 1;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }
    private void SpawnNumber()
    { 
        _currentNumber = Instantiate(Prefabs[GetRandomNumber()], GameObject.FindObjectOfType<HUD>().CurrentNumber.transform.position, Quaternion.identity, GameObject.FindObjectOfType<NumberParent>().transform).GetComponent<Digit>();
        _currentNumber.OnNumberSpawn();
    }
    private void SpawnNextNumber()
    {
        _currentNumber = Instantiate(Prefabs[GetRandomNumber()], GameObject.FindObjectOfType<HUD>().NextNumber.transform.position, Quaternion.identity, GameObject.FindObjectOfType<NumberParent>().transform).GetComponent<Digit>();
        _currentNumber.OnNumberSpawn();
    }
    private int GetRandomNumber()
    {
        switch(_maxNumber)
        {
            case 1:
                {
                    return 1;
                }
            case 2:
                {
                    return 1;
                }
            case 3:
                {
                    return 1;
                }
            case 4:
                {
                    float random = Random.Range(0, 100);

                    if (random >= 75)
                        return 2;
                    else
                        return 1;
                }
            case 5:
                {
                    float random = Random.Range(0, 100);

                    if (random >= 75)
                        return 3;
                    else if (random >= 60)
                        return 2;
                    else
                        return 1;
                }
            case 6:
                {
                    float random = Random.Range(0, 100);

                    if (random >= 80)
                        return 4;
                    else if (random >= 60)
                        return 3;
                    else if (random >= 35)
                        return 2;
                    else
                        return 1;
                }
            case 7:
                {
                    float random = Random.Range(0, 100);

                    if (random >= 85)
                        return 5;
                    else if (random >= 65)
                        return 4;
                    else if (random >= 50)
                        return 3;
                    else if (random >= 15)
                        return 2;
                    else 
                        return 1;
                }
            case 8:
                {
                    float random = Random.Range(0, 100);

                    if (random >= 80)
                        return 6;
                    else if (random >= 65)
                        return 5;
                    else if (random >= 50)
                        return 4;
                    else if (random >= 20)
                        return 3;
                    else if (random >= 5)
                        return 2;
                    else 
                        return 1;
                }
            case 9:
                {
                    float random = Random.Range(0, 100);

                    if (random >= 85)
                        return 7;
                    else if (random >= 65)
                        return 6;
                    else if (random >= 50)
                        return 5;
                    else if (random >= 20)
                        return 4;
                    else if (random >= 5)
                        return 3;
                    else 
                        return 2;
                }
        }
        return 1;
    }

    public void SubscribeAll()
    {
        GameState.Instance.GameStarted += SpawnNumber;
        GameState.Instance.NumberDropped += SpawnNextNumber;
    }

    public void UnsubscribeAll()
    {
        
    }
    public void CheckMaxNumber(int numberForCheck)
    {
        if (numberForCheck > _maxNumber)
            _maxNumber = numberForCheck;
    }
}
