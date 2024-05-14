using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000072 RID: 114
public class BehaviourAction_SiRvAxeMaceAction : BehaviourActionBase
{
    // Token: 0x060001D6 RID: 470 RVA: 0x0000B040 File Offset: 0x00009240
    public override List<RencounterManager.MovingAction> GetMovingAction(ref RencounterManager.ActionAfterBehaviour self, ref RencounterManager.ActionAfterBehaviour opponent)
    {
        bool flag = false;
        if (opponent.behaviourResultData != null)
        {
            flag = opponent.behaviourResultData.IsFarAtk();
        }
        if (self.result > Result.Win || flag)
        {
            return base.GetMovingAction(ref self, ref opponent);
        }
        _self = self.view.model;
        _opponent = opponent.view.model;
        List<RencounterManager.MovingAction> list = new List<RencounterManager.MovingAction>();
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S8, CharMoveState.Stop, 0f, true, 0.3f, 1f);
        movingAction.customEffectRes = "SiRv_Axe";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.NONE);
        list.Add(movingAction);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S9, CharMoveState.Stop, 0f, true, 0.5f, 1f);
        movingAction2.customEffectRes = "SiRv_Mace2";
        movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.PRE, EffectTiming.PRE);
        list.Add(movingAction2);
        List<RencounterManager.MovingAction> infoList = opponent.infoList;
        if (infoList != null && infoList.Count > 0)
        {
            opponent.infoList.Clear();
        }
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.MoveBack, 2f, true, 0.3f, 1f);
        movingAction3.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.NONE);
        movingAction3.knockbackPower = 2f;
        opponent.infoList.Add(movingAction3);
        RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 0f, true, 0.5f, 1f);
        movingAction4.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.NONE);
        movingAction4.knockbackPower = 5f;
        opponent.infoList.Add(movingAction4);
        return list;
    }

    // Token: 0x060001D7 RID: 471 RVA: 0x0000B1A0 File Offset: 0x000093A0
    private bool MoveUpSelf(float deltaTime)
    {
        if (_elapsedMovUpSelf < Mathf.Epsilon)
        {
            teleportSrc = _self.view.WorldPosition;
            teleportDst = _self.view.WorldPosition + new Vector3(0f, _yOffset + 1.5f, 0f);
        }
        bool result = false;
        _elapsedMovUpSelf += deltaTime * _prefab.moveUpSelfSpeed;
        float t = _prefab.moveUpSelfCurve.Evaluate(_elapsedMovUpSelf);
        _self.view.WorldPosition = Vector3.Lerp(teleportSrc, teleportDst, t);
        if (_elapsedMovUpSelf > 1f)
        {
            result = true;
        }
        return result;
    }

    // Token: 0x060001D8 RID: 472 RVA: 0x0000B26C File Offset: 0x0000946C
    private bool DownAttackSelf(float deltaTime)
    {
        bool result = false;
        _elapsedDownAtk += deltaTime * _prefab.downAtkSelfSpeed;
        float t = _prefab.downAtkSelfCurve.Evaluate(_elapsedDownAtk);
        _self.view.WorldPosition = Vector3.Lerp(_self.view.WorldPosition, teleportSrc, t);
        if (_elapsedDownAtk > 1f)
        {
            result = true;
        }
        return result;
    }

    // Token: 0x060001D9 RID: 473 RVA: 0x0000B2E8 File Offset: 0x000094E8
    private bool AirbornedOpponent(float deltaTime)
    {
        if (_elapsedAirborne < Mathf.Epsilon)
        {
            originPos = _opponent.view.WorldPosition;
            _opponent.view.WorldPosition = originPos + new Vector3(0f, 1f, 0f);
        }
        _elapsedAirborne += deltaTime * _prefab.airbornedOpponentSpeed;
        return _elapsedAirborne >= 1f;
    }

    // Token: 0x060001DA RID: 474 RVA: 0x0000B374 File Offset: 0x00009574
    private bool MoveUpOpponent(float deltaTime)
    {
        if (_elapsedMoveUpOpponent < Mathf.Epsilon)
        {
            airborneSrc = _opponent.view.WorldPosition;
            airborneDst = _opponent.view.WorldPosition + new Vector3(0f, _yOffset, 0f);
        }
        bool result = false;
        float t = _prefab.airbornedOpponentCurve.Evaluate(_elapsedMoveUpOpponent);
        _opponent.view.WorldPosition = Vector3.Lerp(airborneSrc, airborneDst, t);
        _elapsedMoveUpOpponent += deltaTime * _prefab.moveUpOpponentSpeed;
        if (_elapsedMoveUpOpponent > 1f)
        {
            result = true;
        }
        return result;
    }

    // Token: 0x060001DB RID: 475 RVA: 0x0000B43C File Offset: 0x0000963C
    private bool KnockdownOpponent(float deltaTime)
    {
        if (_elapsedKnockdown < Mathf.Epsilon)
        {
            knockdownSrc = _opponent.view.WorldPosition;
            knockdownDst = originPos;
        }
        bool result = false;
        _elapsedKnockdown += deltaTime * _prefab.knockdownOpponentSpeed;
        float t = _prefab.knockdownOpponentCurve.Evaluate(_elapsedKnockdown);
        _opponent.view.WorldPosition = Vector3.Lerp(knockdownSrc, knockdownDst, t);
        if (_elapsedKnockdown > 1f)
        {
            result = true;
            _self.view.LockPosY(true);
            _opponent.view.LockPosY(true);
        }
        return result;
    }

    // Token: 0x040000AB RID: 171
    private BattleUnitModel _opponent;

    // Token: 0x040000AC RID: 172
    private BadaAtkBehaviourAction _prefab;

    // Token: 0x040000AD RID: 173
    private float _yOffset = 5f;

    // Token: 0x040000AE RID: 174
    private float _elapsedMovUpSelf;

    // Token: 0x040000AF RID: 175
    private Vector3 teleportSrc;

    // Token: 0x040000B0 RID: 176
    private Vector3 teleportDst;

    // Token: 0x040000B1 RID: 177
    private float _elapsedDownAtk;

    // Token: 0x040000B2 RID: 178
    private float _elapsedAirborne;

    // Token: 0x040000B3 RID: 179
    private Vector3 originPos;

    // Token: 0x040000B4 RID: 180
    private float _elapsedMoveUpOpponent;

    // Token: 0x040000B5 RID: 181
    private Vector3 airborneSrc;

    // Token: 0x040000B6 RID: 182
    private Vector3 airborneDst;

    // Token: 0x040000B7 RID: 183
    private float _elapsedKnockdown;

    // Token: 0x040000B8 RID: 184
    private Vector3 knockdownSrc;

    // Token: 0x040000B9 RID: 185
    private Vector3 knockdownDst;
}
