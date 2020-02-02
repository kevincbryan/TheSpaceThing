using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerOxygen : MonoBehaviour
{
    public PlayerInteraction player;

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x, player.oxygen / 100f, transform.localScale.z);
    }
}
