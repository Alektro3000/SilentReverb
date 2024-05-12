using System;
using UnityEngine;

// Token: 0x02000059 RID: 89
public class BehaviourAction_SiRvargalia_area_ex : BehaviourActionBase
{
    // Token: 0x0600015E RID: 350 RVA: 0x00002AE1 File Offset: 0x00000CE1
    public override FarAreaEffect SetFarAreaAtkEffect(BattleUnitModel self)
    {
        this._self = self;
        FarAreaeffect_SiRvArgaliaAreaEx farAreaeffect_SiRvArgaliaAreaEx = new GameObject().AddComponent<FarAreaeffect_SiRvArgaliaAreaEx>();
        farAreaeffect_SiRvArgaliaAreaEx.Init(self, Array.Empty<object>());
        return farAreaeffect_SiRvArgaliaAreaEx;
    }
}
