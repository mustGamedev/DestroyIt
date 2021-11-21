using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _buildingPrefabs;
    private void Start()
    {
        _buildingPrefabs[Random.Range(0,_buildingPrefabs.Length)].SetActive(true);
    }
}