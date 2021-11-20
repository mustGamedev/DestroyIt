using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] gameObjects;
    
    private void Start()
    {
        gameObjects[Random.Range(0,gameObjects.Length)].SetActive(true);
    }
}