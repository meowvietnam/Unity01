using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStar : Item
{
    protected override void EventCollision()
    {
        Debug.Log("Eat Item Star + điểm ");
        
        float nowScore = GameManager.instance.GetScore();
        nowScore += 50f;
        GameManager.instance.SetScore(nowScore);
        


    }

}
