using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayerOxygen : MonoBehaviour
{
    public PlayerInteraction player;

    // Update is called once per frame
    void Update()
    {
        var oxygenLevel = player.oxygen / 100f;
        transform.localScale = new Vector3(transform.localScale.x, oxygenLevel, transform.localScale.z);
        transform.localPosition = new Vector3(transform.localPosition.x, -1f + oxygenLevel, transform.localPosition.z);
    }
}
