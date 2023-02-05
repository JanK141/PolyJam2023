using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    public void ReceiveHit();
    public float Health { get; set; }

}
