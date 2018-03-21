using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsContainer : Container {
    public StatEffect Effect;

    public override void Take()
    {
        var playerStats = GameObject.Find("player_stats").GetComponent<PlayerStats>();
        playerStats.effects.Add(Effect);
    }
}
