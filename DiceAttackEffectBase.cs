using Battle.DiceAttackEffect;
using UnityEngine;

public class DiceAttackEffect_SilentReberb_BaseAttackEffect : DiceAttackEffect
{
    public void SetParameters(string name, float positionX = 0.3f, float positionY = 0.6f, float scale = 0.5f, bool overSelf = true, bool isFixed = false, float? duration = null)
    {
        vfxname = name;
        PositionX = positionX;
        PositionY = positionY;
        Scale = scale;
        OverSelf = overSelf;
        IsFixed = isFixed;
        Duration = duration;
    }

    public override void Initialize(BattleUnitView self, BattleUnitView target, float destroyTime)
    {
        base.Initialize(self, target, destroyTime);
        _self = self.model;
        _selfTransform = self.atkEffectRoot;
        _targetTransform = (OverSelf ? self.atkEffectRoot : target.atkEffectRoot);
        transform.parent = (OverSelf ? self.charAppearance.transform : target.transform);
        _duration = (Duration ?? destroyTime);
        spr.sprite = SilentReverb_ModInit.ArtWorks[vfxname];
        Texture2D texture = spr.sprite.texture;
        Sprite sprite = Sprite.Create(texture, new Rect(0f, 0f, texture.width, texture.height), new Vector2(PositionX, PositionY));
        spr.sprite = sprite;
        gameObject.layer = LayerMask.NameToLayer("Effect");
        ResetLocalTransform(base.transform);
    }

    protected override void Update()
    {
        base.Update();
        _duration -= Time.deltaTime;
        spr.color = new Color(1f, 1f, 1f, _duration * 2f);
    }

    public override void SetScale(float scaleFactor)
    {
        base.SetScale(IsFixed ? Scale : scaleFactor * Scale);
    }

    private float _duration;

    private bool OverSelf;

    private float PositionX;

    private float PositionY;

    private float Scale;

    private string vfxname;

    private bool IsFixed;

    private float? Duration;
}
