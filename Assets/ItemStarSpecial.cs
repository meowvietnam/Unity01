using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStarSpecial : ItemStar
{
    private float countdown;

    protected override void EventCollision()
    {
        base.EventCollision();
        StartCoroutine(TangSpeed());
        

    }
    IEnumerator TangSpeed()
    {
        float oldSpeed = Player.instance.GetSpeed();
        float newSpeed = oldSpeed * 1.5f;
        Player.instance.SetSpeed(newSpeed);
        yield return new WaitForSeconds(countdown);
        Player.instance.SetSpeed(oldSpeed);

    }

}
