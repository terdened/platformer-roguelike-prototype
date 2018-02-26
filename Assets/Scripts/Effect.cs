using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[System.Serializable]
public class StatEffect
{// Fire
    public float AdditionalFireRate; // 1 = 1 bulet/sec, 0.5 = 2 bulet/sec
    public float AdditionalDamage;
    public float AdditionalBuletDistance;
    public float AdditionalBuletSpeed;

    // Movement
    public float AdditionalJumpPower;
    public float AdditionalMoveSpeed;
}
