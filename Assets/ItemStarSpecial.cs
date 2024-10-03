using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemStarSpecial : ItemStar
{



    protected override void EventCollision()
    {
        base.EventCollision();
        Buff.instance.TangSpeed();


    }
   


}
