using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThienThach : Item
{
    protected override void EventCollision()
    {
        Debug.Log("Eat Thien Thach - điểm ");
        float nowScore = GameManager.instance.GetScore();
        nowScore -= 50f;
        GameManager.instance.SetScore(nowScore);
        Player.instance.SetAnimHurt();
    }
    
}
