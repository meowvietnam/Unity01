using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField]private float speed;
    [SerializeField] private float timeDestroy = 5f;

    protected void Start()
    {
        StartCoroutine(DestroyObjCoroutine());
    }

    // Update is called once per frame
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            EventCollision();
            Destroy(gameObject);
        }
    }
    protected abstract void EventCollision();
   
    protected void Update()
    {
        ItemMove();
    }
    void ItemMove()
    {
        transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;

    }
    
    IEnumerator DestroyObjCoroutine()
    {
        yield return new WaitForSeconds(timeDestroy);
        Destroy(gameObject);

    }    
    
}
