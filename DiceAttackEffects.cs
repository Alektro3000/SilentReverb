using Battle.DiceAttackEffect;

public class DiceAttackEffect_SiRv_AppasTrail1 : DiceAttackEffect_SilentReberb_BaseAttackEffect
{
    public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
    {
        SetParameters("AppasTrail1", 0.45f, 0.2f, 1.5f, true, true, null);
        base.Initialize(self, target, destroyTime);
    }
}
public class DiceAttackEffect_SiRv_AppasTrail2 : DiceAttackEffect_SilentReberb_BaseAttackEffect
{
    public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
    {
        base.SetParameters("AppasTrail2", 0.65f, 0.3f, 1.5f, true, true, null);
        base.Initialize(self, target, destroyTime);
    }
}

public class DiceAttackEffect_SiRv_Axe : DiceAttackEffect_SilentReberb_BaseAttackEffect
{
    public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
    {
        base.SetParameters("Axe", 0.55f, 0.15f, 1.5f, true, true, new float?(0.6f));
        base.Initialize(self, target, destroyTime);
    }
}

public class DiceAttackEffect_SiRv_AxeMace : DiceAttackEffect_SilentReberb_BaseAttackEffect
{
    public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
    {
        base.SetParameters("AxeMace", 0.68f, 0.05f, 1f, true, true, new float?(0.6f));
        base.Initialize(self, target, destroyTime);
    }
}



public class DiceAttackEffect_SiRv_Hammer : DiceAttackEffect_SilentReberb_BaseAttackEffect
{
    public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
    {
        base.SetParameters("Hammer", 0.75f, 0.2f, 1.5f, true, true, new float?(0.6f));
        base.Initialize(self, target, destroyTime);
    }
}


public class DiceAttackEffect_SiRv_Mace : DiceAttackEffect_SilentReberb_BaseAttackEffect
{
    public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
    {
        base.SetParameters("Mace", 0.555f, 0.3f, 1.5f, true, true, new float?(0.6f));
        base.Initialize(self, target, destroyTime);
    }
}


public class DiceAttackEffect_SiRv_Mace2 : DiceAttackEffect_SilentReberb_BaseAttackEffect
{
    public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
    {
        base.SetParameters("Mace2", 0.65f, 0.25f, 1.5f, true, true, new float?(0.6f));
        base.Initialize(self, target, destroyTime);
    }
}

public class DiceAttackEffect_SiRv_Ranga1 : DiceAttackEffect_SilentReberb_BaseAttackEffect
{
    public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
    {
        base.SetParameters("Ranga1", 0.425f, 0.36f, 1.5f, true, true, new float?(0.6f));
        base.Initialize(self, target, destroyTime);
    }
}

public class DiceAttackEffect_SiRv_Ranga2 : DiceAttackEffect_SilentReberb_BaseAttackEffect
{
    public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
    {
        base.SetParameters("Ranga2", 0.66f, 0.36f, 1.5f, true, true, new float?(0.6f));
        base.Initialize(self, target, destroyTime);
    }
}

public class DiceAttackEffect_SiRv_Resonate : DiceAttackEffect_SilentReberb_BaseAttackEffect
{
    public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
    {
        base.SetParameters("Resonate", 0.845f, 0.25f, 1.5f, true, true, null);
        base.Initialize(self, target, destroyTime);
    }
}


public class DiceAttackEffect_SiRvResonate : DiceAttackEffect
{
    public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
    {
        base.Initialize(self, target, destroyTime);
        this.EarthQuake();
    }

    private void EarthQuake()
    {
        BattleCamManager instance = SingletonBehavior<BattleCamManager>.Instance;
        CameraFilterPack_FX_EarthQuake cameraFilterPack_FX_EarthQuake = ((instance != null) ? instance.EffectCam.gameObject.AddComponent<CameraFilterPack_FX_EarthQuake>() : null) ?? null;
        if (cameraFilterPack_FX_EarthQuake != null)
        {
            cameraFilterPack_FX_EarthQuake.X = this.forceX;
            cameraFilterPack_FX_EarthQuake.Y = this.forceY;
            cameraFilterPack_FX_EarthQuake.Speed = 50f;
        }
        BattleCamManager instance2 = SingletonBehavior<BattleCamManager>.Instance;
        AutoScriptDestruct autoScriptDestruct = ((instance2 != null) ? instance2.EffectCam.gameObject.AddComponent<AutoScriptDestruct>() : null) ?? null;
        if (autoScriptDestruct != null)
        {
            autoScriptDestruct.targetScript = cameraFilterPack_FX_EarthQuake;
            autoScriptDestruct.time = 0.35f;
        }
    }

    public float forceX = 0.03f;

    public float forceY = 0.01f;
}
