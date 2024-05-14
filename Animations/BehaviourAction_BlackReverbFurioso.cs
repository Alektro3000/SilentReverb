using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200006E RID: 110
public class BehaviourAction_BlackReverbFurioso : BehaviourActionBase
{
    // Token: 0x0600019A RID: 410 RVA: 0x00002488 File Offset: 0x00000688
    public override bool IsMovable()
    {
        return false;
    }

    // Token: 0x0600019B RID: 411 RVA: 0x00002488 File Offset: 0x00000688
    public override bool IsOpponentMovable()
    {
        return false;
    }

    // Token: 0x0600019C RID: 412 RVA: 0x00008664 File Offset: 0x00006864
    public override List<RencounterManager.MovingAction> GetMovingAction(ref RencounterManager.ActionAfterBehaviour self, ref RencounterManager.ActionAfterBehaviour opponent)
    {
        bool flag = false;
        if (opponent.behaviourResultData != null)
        {
            flag = opponent.behaviourResultData.IsFarAtk();
        }
        if (self.result == Result.Win && !flag)
        {
            _self = self.view.model;
            _target = opponent.view.model;
            List<RencounterManager.MovingAction> list = new List<RencounterManager.MovingAction>();
            List<RencounterManager.MovingAction> list2 = new List<RencounterManager.MovingAction>();
            if (opponent.infoList.Count > 0)
            {
                opponent.infoList.Clear();
            }
            SetShotgun(list, list2);
            SetLance(list, list2);
            SetAxe(list, list2);
            SetMace(list, list2);
            SetHammer(list, list2);
            SetLongSword(list, list2);
            SetDualWield(list, list2);
            SetGreatSword(list, list2);
            SetGauntlet(list, list2);
            SetShortSword(list, list2);
            SetScythe1(list, list2);
            SetScythe2(list, list2);
            SetRevolver(list, list2);
            SetFinal(list, list2);
            opponent.infoList = list2;
            return list;
        }
        return base.GetMovingAction(ref self, ref opponent);
    }

    // Token: 0x0600019D RID: 413 RVA: 0x00008760 File Offset: 0x00006960
    private void SetShotgun(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S11, CharMoveState.MoveBack, 3f, true, 0.3f, 1f);
        movingAction.customEffectRes = "BlackSilence_Shotgun";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 1f, true, 0.3f, 1f)
        {
            knockbackPower = 5f
        });
    }

    // Token: 0x0600019E RID: 414 RVA: 0x000087CC File Offset: 0x000069CC
    private void SetLance(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Penetrate, CharMoveState.Custom, 1f, false, 0f, 1f);
        movingAction.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveLance));
        movingAction.customEffectRes = "BlackSilence_Z";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Penetrate, CharMoveState.Stop, 0f, false, 0.3f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction);
        self.Add(movingAction2);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.1f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.1f, 1f);
        oppo.Add(item2);
    }

    // Token: 0x0600019F RID: 415 RVA: 0x00008888 File Offset: 0x00006A88
    private void SetAxe(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S8, CharMoveState.Stop, 1f, true, 0.5f, 1f);
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        movingAction.customEffectRes = "SiRv_Axe";
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.1f, 1f);
        oppo.Add(item);
    }

    // Token: 0x060001A0 RID: 416 RVA: 0x000088E8 File Offset: 0x00006AE8
    private void SetMace(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S9, CharMoveState.Stop, 1f, true, 0.5f, 1f);
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        movingAction.customEffectRes = "SiRv_Mace";
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.1f, 1f);
        oppo.Add(item);
    }

    // Token: 0x060001A1 RID: 417 RVA: 0x00008948 File Offset: 0x00006B48
    private void SetHammer(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Hit, CharMoveState.MoveForward, 1f, true, 0.6f, 1f);
        movingAction.customEffectRes = "SiRv_Hammer";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 6f, true, 0.1f, 1f);
        movingAction2.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveAfterHammer));
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction);
        self.Add(movingAction2);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 1f, true, 0.6f, 1f)
        {
            knockbackPower = 5f
        });
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.1f, 1f);
        oppo.Add(item);
    }

    // Token: 0x060001A2 RID: 418 RVA: 0x00008A0C File Offset: 0x00006C0C
    private void SetLongSword(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S4, CharMoveState.MoveForward, 20f, false, 0.2f, 1f);
        movingAction.customEffectRes = "FX_PC_RolRang_Slash_UP";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S4, CharMoveState.Stop, 0f, false, 0.3f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.015f, 1f);
        movingAction2.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveAfterHammer));
        self.Add(movingAction);
        self.Add(movingAction2);
        self.Add(item);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, false, 0.2f, 1f);
        oppo.Add(item2);
        RencounterManager.MovingAction item3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, false, 0.3f, 1f);
        oppo.Add(item3);
        RencounterManager.MovingAction item4 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.015f, 1f);
        oppo.Add(item4);
    }

    // Token: 0x060001A3 RID: 419 RVA: 0x00008B0C File Offset: 0x00006D0C
    private void SetDualWield(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Slash, CharMoveState.Custom, 0f, false, 0.01f, 1f);
        movingAction.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveDualWield));
        movingAction.customEffectRes = "FX_PC_RolRang_XSlash_Main_NoUnAtk";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Slash, CharMoveState.Stop, 0f, false, 0.5f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction);
        self.Add(movingAction2);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, false, 0.01f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.1f, 1f);
        oppo.Add(item2);
    }

    // Token: 0x060001A4 RID: 420 RVA: 0x00008BC8 File Offset: 0x00006DC8
    private void SetShortSword(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S7, CharMoveState.Custom, 1f, false, 0.2f, 1f);
        movingAction.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveShortSword));
        movingAction.customEffectRes = "FX_PC_RolRang_Dagger";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.5f, 1f);
        oppo.Add(item);
    }

    // Token: 0x060001A5 RID: 421 RVA: 0x00008C3C File Offset: 0x00006E3C
    private void SetGreatSword(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S10, CharMoveState.Stop, 1f, true, 1f, 1f);
        movingAction.customEffectRes = "FX_PC_RolRang_Greatsword";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.1f, 1f);
        oppo.Add(item);
    }

    // Token: 0x060001A6 RID: 422 RVA: 0x00008C9C File Offset: 0x00006E9C
    private void SetGauntlet(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S5, CharMoveState.Custom, 1f, false, 0.4f, 1f);
        movingAction.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveGauntlet1));
        movingAction.customEffectRes = "SiRv_Ranga1";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S6, CharMoveState.Custom, 1f, false, 0.4f, 1f);
        movingAction2.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveGauntlet2));
        movingAction2.customEffectRes = "SiRv_Ranga2";
        movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        self.Add(movingAction2);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, false, 0.4f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, false, 0.4f, 1f);
        oppo.Add(item2);
    }

    // Token: 0x060001A7 RID: 423 RVA: 0x00008D78 File Offset: 0x00006F78
    private void SetScythe1(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Special, CharMoveState.Stop, 0f, true, 0.4f, 1f);
        movingAction.customEffectRes = "Argalia2_H";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 0.1f, true, 0.4f, 1f)
        {
            knockbackPower = 5f
        });
    }

    // Token: 0x060001A8 RID: 424 RVA: 0x00008DE4 File Offset: 0x00006FE4
    private void SetScythe2(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S15, CharMoveState.MoveForward, 30f, false, 0.3f, 1f);
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        movingAction.customEffectRes = "Argalia_S2";
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S15, CharMoveState.Stop, 0f, false, 0.3f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Default, CharMoveState.Stop, 0f, true, 0.01f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction);
        self.Add(movingAction2);
        self.Add(item);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, false, 0.3f, 1f);
        oppo.Add(item2);
        RencounterManager.MovingAction item3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.3f, 1f);
        oppo.Add(item3);
        RencounterManager.MovingAction item4 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item4);
    }

    // Token: 0x060001A9 RID: 425 RVA: 0x00008ED8 File Offset: 0x000070D8
    private void SetRevolver(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Fire, CharMoveState.Stop, 1f, true, 0.4f, 1f);
        movingAction.customEffectRes = "BlackSilence_Revolver";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NOT_PRINT, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S2, CharMoveState.Stop, 1f, true, 0.4f, 1f);
        movingAction2.customEffectRes = "BlackSilence_Revolver";
        movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.NOT_PRINT, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction2);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 1f, true, 0.1f, 1f)
        {
            knockbackPower = 8f
        });
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 1f, true, 0.1f, 1f)
        {
            knockbackPower = 8f
        });
    }

    // Token: 0x060001AA RID: 426 RVA: 0x00008FA0 File Offset: 0x000071A0
    private void SetFinal(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 0f, true, 0.01f, 1f);
        movingAction.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveFinal1));
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S15, CharMoveState.Stop, 0f, true, 0.5f, 1f);
        movingAction2.customEffectRes = "FX_Mon_Argalia_Slash_H";
        movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.S13, CharMoveState.Custom, 0f, false, 0.01f, 1f);
        movingAction3.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveFinal2));
        movingAction3.customEffectRes = "FX_Mon_Argalia_Slash_Up";
        movingAction3.SetEffectTiming(EffectTiming.PRE, EffectTiming.NOT_PRINT, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.S13, CharMoveState.Stop, 0f, false, 0.5f, 1f);
        movingAction4.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        RencounterManager.MovingAction movingAction5 = new RencounterManager.MovingAction(ActionDetail.S3, CharMoveState.Stop, 0f, true, 1f, 1f);
        movingAction5.customEffectRes = "FX_PC_RolRang_Slash_Last";
        movingAction5.SetEffectTiming(EffectTiming.PRE, EffectTiming.PRE, EffectTiming.PRE);
        self.Add(movingAction);
        self.Add(movingAction2);
        self.Add(movingAction3);
        self.Add(movingAction4);
        self.Add(movingAction5);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.5f, 1f);
        oppo.Add(item2);
        RencounterManager.MovingAction item3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item3);
        RencounterManager.MovingAction item4 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.5f, 1f);
        oppo.Add(item4);
        RencounterManager.MovingAction item5 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 1f, 1f);
        oppo.Add(item5);
    }

    // Token: 0x060001AB RID: 427 RVA: 0x00009160 File Offset: 0x00007360
    private bool MoveLance(float deltaTime)
    {
        if (_target == null)
        {
            return true;
        }
        bool result = false;
        if (!_bMovedLance)
        {
            Vector3 worldPosition = _target.view.WorldPosition;
            float x = _target.view.transform.localScale.x;
            float num = SingletonBehavior<HexagonalMapManager>.Instance.tileSize * x + 6f;
            int num2 = 1;
            if (_self.view.WorldPosition.x < _target.view.WorldPosition.x)
            {
                num2 = -1;
            }
            Vector3 pos = worldPosition - new Vector3((float)num2 * num, 0f, 0f);
            _self.moveDetail.Move(pos, 400f, false, true);
            _bMovedLance = true;
        }
        else if (_self.moveDetail.isArrived)
        {
            result = true;
        }
        return result;
    }

    // Token: 0x060001AC RID: 428 RVA: 0x00009244 File Offset: 0x00007444
    private bool MoveAfterHammer(float deltaTime)
    {
        bool result = false;
        if (!_bMoveAfterHammer)
        {
            Vector3 worldPosition = _target.view.WorldPosition;
            float x = _target.view.transform.localScale.x;
            float num = SingletonBehavior<HexagonalMapManager>.Instance.tileSize * x + 6f;
            int num2 = 1;
            if (_self.view.WorldPosition.x < _target.view.WorldPosition.x)
            {
                num2 = -1;
            }
            Vector3 pos = worldPosition + new Vector3((float)num2 * num, 0f, 0f);
            _self.moveDetail.Move(pos, 150f, true, false);
            _bMoveAfterHammer = true;
        }
        else if (_self.moveDetail.isArrived)
        {
            result = true;
        }
        return result;
    }

    // Token: 0x060001AD RID: 429 RVA: 0x00009320 File Offset: 0x00007520
    private bool MoveGauntlet1(float deltaTime)
    {
        if (_target == null)
        {
            return true;
        }
        bool result = false;
        if (!_bMovedGauntlet1)
        {
            Vector3 worldPosition = _target.view.WorldPosition;
            float x = _target.view.transform.localScale.x;
            float num = SingletonBehavior<HexagonalMapManager>.Instance.tileSize * x + 6f;
            int num2 = 1;
            if (_self.view.WorldPosition.x < _target.view.WorldPosition.x)
            {
                num2 = -1;
            }
            Vector3 pos = worldPosition - new Vector3((float)num2 * num, 0f, 0f);
            _self.moveDetail.Move(pos, 250f, false, false);
            _bMovedGauntlet1 = true;
        }
        else if (_self.moveDetail.isArrived)
        {
            result = true;
        }
        return result;
    }

    // Token: 0x060001AE RID: 430 RVA: 0x00009404 File Offset: 0x00007604
    private bool MoveGauntlet2(float deltaTime)
    {
        if (_target == null)
        {
            return true;
        }
        bool result = false;
        if (!_bMoveGauntler2)
        {
            Vector3 worldPosition = _target.view.WorldPosition;
            float x = _target.view.transform.localScale.x;
            float num = SingletonBehavior<HexagonalMapManager>.Instance.tileSize * x + 6f;
            int num2 = 1;
            if (_self.view.WorldPosition.x < _target.view.WorldPosition.x)
            {
                num2 = -1;
            }
            Vector3 pos = worldPosition - new Vector3((float)num2 * num, 0f, 0f);
            _self.moveDetail.Move(pos, 250f, false, false);
            _bMoveGauntler2 = true;
        }
        else if (_self.moveDetail.isArrived)
        {
            result = true;
        }
        return result;
    }

    // Token: 0x060001AF RID: 431 RVA: 0x000094E8 File Offset: 0x000076E8
    private bool MoveShortSword(float deltaTime)
    {
        if (_target == null)
        {
            return true;
        }
        bool result = false;
        if (!_bMovedShortSword)
        {
            Vector3 worldPosition = _target.view.WorldPosition;
            float x = _target.view.transform.localScale.x;
            float num = SingletonBehavior<HexagonalMapManager>.Instance.tileSize * x + 6f;
            int num2 = 1;
            if (_self.view.WorldPosition.x < _target.view.WorldPosition.x)
            {
                num2 = -1;
            }
            Vector3 pos = worldPosition - new Vector3((float)num2 * num, 0f, 0f);
            _self.moveDetail.Move(pos, 250f, false, false);
            _bMovedShortSword = true;
        }
        else if (_self.moveDetail.isArrived)
        {
            result = true;
        }
        return result;
    }

    // Token: 0x060001B0 RID: 432 RVA: 0x000095CC File Offset: 0x000077CC
    private bool MoveDualWield(float deltaTime)
    {
        if (_target == null)
        {
            return true;
        }
        bool result = false;
        if (!_bMoveDualWield)
        {
            Vector3 worldPosition = _target.view.WorldPosition;
            float x = _target.view.transform.localScale.x;
            float num = SingletonBehavior<HexagonalMapManager>.Instance.tileSize * x + 12f;
            int num2 = 1;
            if (_self.view.WorldPosition.x < _target.view.WorldPosition.x)
            {
                num2 = -1;
            }
            Vector3 pos = worldPosition - new Vector3((float)num2 * num, 0f, 0f);
            _self.moveDetail.Move(pos, 250f, false, false);
            _bMoveDualWield = true;
        }
        else if (_self.moveDetail.isArrived)
        {
            result = true;
        }
        return result;
    }

    // Token: 0x060001B1 RID: 433 RVA: 0x000096B0 File Offset: 0x000078B0
    private bool MoveFinal1(float deltaTime)
    {
        if (_target == null)
        {
            return true;
        }
        bool result = false;
        if (!_bMoveFinal1)
        {
            Vector3 worldPosition = _target.view.WorldPosition;
            float x = _target.view.transform.localScale.x;
            float num = SingletonBehavior<HexagonalMapManager>.Instance.tileSize * x + 6f;
            int num2 = 1;
            if (_self.view.WorldPosition.x < _target.view.WorldPosition.x)
            {
                num2 = -1;
            }
            Vector3 pos = worldPosition + new Vector3((float)num2 * num, 0f, 0f);
            _self.moveDetail.Move(pos, 250f, false, false);
            _bMoveFinal1 = true;
        }
        else if (_self.moveDetail.isArrived)
        {
            result = true;
        }
        return result;
    }

    // Token: 0x060001B2 RID: 434 RVA: 0x00009794 File Offset: 0x00007994
    private bool MoveFinal2(float deltaTime)
    {
        if (_target == null)
        {
            return true;
        }
        bool result = false;
        if (!_bMoveFinal2)
        {
            Vector3 worldPosition = _target.view.WorldPosition;
            float x = _target.view.transform.localScale.x;
            float num = SingletonBehavior<HexagonalMapManager>.Instance.tileSize * x + 6f;
            int num2 = 1;
            if (_self.view.WorldPosition.x < _target.view.WorldPosition.x)
            {
                num2 = -1;
            }
            Vector3 pos = worldPosition - new Vector3((float)num2 * num, 0f, 0f);
            _self.moveDetail.Move(pos, 250f, false, false);
            _bMoveFinal2 = true;
        }
        else if (_self.moveDetail.isArrived)
        {
            result = true;
        }
        return result;
    }

    // Token: 0x0400009B RID: 155
    private BattleUnitModel _target;

    // Token: 0x0400009C RID: 156
    private bool _bMovedLance;

    // Token: 0x0400009D RID: 157
    private bool _bMoveAfterHammer;

    // Token: 0x0400009E RID: 158
    private bool _bMovedGauntlet1;

    // Token: 0x0400009F RID: 159
    private bool _bMoveGauntler2;

    // Token: 0x040000A0 RID: 160
    private bool _bMovedShortSword;

    // Token: 0x040000A1 RID: 161
    private bool _bMoveDualWield;

    // Token: 0x040000A2 RID: 162
    private bool _bMoveFinal1;

    // Token: 0x040000A3 RID: 163
    private bool _bMoveFinal2;
}
