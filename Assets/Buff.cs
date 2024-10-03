using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour 
{
    public static Buff instance;
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
    }
    IEnumerator CoroutineTangSpeed()
    {
        
        float oldSpeed = Player.instance.GetSpeed();
        float newSpeed = oldSpeed + 2f;
        Player.instance.SetSpeed(newSpeed);
        yield return new WaitForSeconds(5);
        Player.instance.SetSpeed(Player.instance.GetSpeed() - 2f);

    }
    public void TangSpeed()
    {
        StartCoroutine(CoroutineTangSpeed());
    }    
}
