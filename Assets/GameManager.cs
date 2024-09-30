using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]private float score;
    [SerializeField] private GameObject[] prefabItems;
    [SerializeField] private Text textScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("GameObject này đã tồn tại");
            Destroy(gameObject);
        }
        textScore = GameObject.Find("TextScore").GetComponent<Text>();
    }
    void Start()
    {
        StartCoroutine(SpawnItem());
        SetScore(0);
    }
    public float GetScore()
    {
       return score;
    }
    public void SetScore(float value)
    {
       this.score = value;
        textScore.text = score.ToString();
    }    
    IEnumerator SpawnItem()
    {
        yield return new WaitForSeconds(1.5f);
        Vector3 posSpawnRandom = new Vector3(Random.Range(-8,8),5.7f,0);
        Instantiate(prefabItems[Random.Range(0,prefabItems.Length)], posSpawnRandom , Quaternion.identity);
        StartCoroutine(SpawnItem());
    }    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
