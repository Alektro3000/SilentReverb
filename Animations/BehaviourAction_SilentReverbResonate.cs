﻿using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200004D RID: 77
public class BehaviourAction_SilentReverbResonate : BehaviourActionBase
{
    // Token: 0x0600012F RID: 303 RVA: 0x00006FC8 File Offset: 0x000051C8
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
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Hit2, CharMoveState.MoveForward, 2f, true, 0.5f, 1f);
        movingAction.customEffectRes = "SiRv_Resonate";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.NONE);
        list.Add(movingAction);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Penetrate2, CharMoveState.MoveForward, 2f, true, 0.2f, 1f);
        movingAction2.customEffectRes = "Argalia_S1";
        movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.NONE);
        list.Add(movingAction2);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.S15, CharMoveState.MoveForward, 2f, true, 0.2f, 1f);
        movingAction3.customEffectRes = "Argalia_S2";
        movingAction3.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.NONE);
        list.Add(movingAction3);
        RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.S14, CharMoveState.MoveForward, 1f, true, 0.5f, 1f);
        movingAction4.customEffectRes = "SiRv_AppasTrail2";
        movingAction4.SetEffectTiming(EffectTiming.PRE, EffectTiming.PRE, EffectTiming.PRE);
        list.Add(movingAction4);
        List<RencounterManager.MovingAction> infoList = opponent.infoList;
        if (infoList != null && infoList.Count > 0)
        {
            opponent.infoList.Clear();
        }
        RencounterManager.MovingAction movingAction5 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.MoveBack, 2f, true, 0.5f, 1f);
        movingAction5.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.NONE);
        movingAction5.knockbackPower = 2f;
        opponent.infoList.Add(movingAction5);
        RencounterManager.MovingAction movingAction6 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.MoveBack, 2f, true, 0.2f, 1f);
        movingAction6.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.NONE);
        movingAction6.knockbackPower = 2f;
        opponent.infoList.Add(movingAction6);
        RencounterManager.MovingAction movingAction7 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.MoveBack, 2f, true, 0.8f, 1f);
        movingAction7.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.NONE);
        movingAction7.knockbackPower = 2f;
        opponent.infoList.Add(movingAction7);
        RencounterManager.MovingAction movingAction8 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 1f, true, 0.125f, 1f);
        movingAction8.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.NONE);
        opponent.infoList.Add(movingAction8);
        return list;
    }

    // Token: 0x06000131 RID: 305 RVA: 0x00007204 File Offset: 0x00005404
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

    // Token: 0x06000132 RID: 306 RVA: 0x000072D0 File Offset: 0x000054D0
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

    // Token: 0x06000133 RID: 307 RVA: 0x0000734C File Offset: 0x0000554C
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

    // Token: 0x06000134 RID: 308 RVA: 0x000073D8 File Offset: 0x000055D8
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

    // Token: 0x06000135 RID: 309 RVA: 0x000074A0 File Offset: 0x000056A0
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

    // Token: 0x0400006C RID: 108
    private BattleUnitModel _opponent;

    // Token: 0x0400006D RID: 109
    private BadaAtkBehaviourAction _prefab;

    // Token: 0x0400006E RID: 110
    private float _yOffset = 5f;

    // Token: 0x0400006F RID: 111
    private float _elapsedMovUpSelf;

    // Token: 0x04000070 RID: 112
    private Vector3 teleportSrc;

    // Token: 0x04000071 RID: 113
    private Vector3 teleportDst;

    // Token: 0x04000072 RID: 114
    private float _elapsedDownAtk;

    // Token: 0x04000073 RID: 115
    private float _elapsedAirborne;

    // Token: 0x04000074 RID: 116
    private Vector3 originPos;

    // Token: 0x04000075 RID: 117
    private float _elapsedMoveUpOpponent;

    // Token: 0x04000076 RID: 118
    private Vector3 airborneSrc;

    // Token: 0x04000077 RID: 119
    private Vector3 airborneDst;

    // Token: 0x04000078 RID: 120
    private float _elapsedKnockdown;

    // Token: 0x04000079 RID: 121
    private Vector3 knockdownSrc;

    // Token: 0x0400007A RID: 122
    private Vector3 knockdownDst;
}
