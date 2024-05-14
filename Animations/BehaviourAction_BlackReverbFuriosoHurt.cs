using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200009D RID: 157
public class BehaviourAction_BlackReverbFuriosoHurt : BehaviourActionBase
{
    // Token: 0x06000249 RID: 585 RVA: 0x00002488 File Offset: 0x00000688
    public override bool IsMovable()
    {
        return false;
    }

    // Token: 0x0600024A RID: 586 RVA: 0x00002488 File Offset: 0x00000688
    public override bool IsOpponentMovable()
    {
        return false;
    }

    // Token: 0x0600024B RID: 587 RVA: 0x0000C318 File Offset: 0x0000A518
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
            SetDualWield1(list, list2);
            SetGreatSword(list, list2);
            SetDualWield2(list, list2);
            SetShotgun(list, list2);
            SetGauntlet(list, list2);
            SetShortSword(list, list2);
            SetRevolver(list, list2);
            SetLance(list, list2);
            SetHammer(list, list2);
            SetAxeMace(list, list2);
            SetLongSword(list, list2);
            SetScythe1(list, list2);
            SetScythe2(list, list2);
            SetScythe3(list, list2);
            SetScythe4(list, list2);
            SetFinal(list, list2);
            opponent.infoList = list2;
            return list;
        }
        return base.GetMovingAction(ref self, ref opponent);
    }

    // Token: 0x0600024C RID: 588 RVA: 0x0000C424 File Offset: 0x0000A624
    private void SetDualWield1(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Slash, CharMoveState.Custom, 1f, false, 0.01f, 1f);
        movingAction.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveLance));
        movingAction.customEffectRes = "FX_PC_RolRang_XSlash_Main_NoUnAtk";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, false, 0.01f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Slash, CharMoveState.Stop, 0f, false, 0.2f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction2);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, false, 0.2f, 1f);
        oppo.Add(item2);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.01f, 1f);
        movingAction3.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveAfter));
        movingAction3.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction3);
        RencounterManager.MovingAction item3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item3);
    }

    // Token: 0x0600024D RID: 589 RVA: 0x0000C540 File Offset: 0x0000A740
    private void SetGreatSword(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S10, CharMoveState.Stop, 1f, true, 0.2f, 1f);
        movingAction.customEffectRes = "FX_PC_RolRang_Greatsword";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 1f, true, 0.2f, 1f)
        {
            knockbackPower = 8f
        });
    }

    // Token: 0x0600024E RID: 590 RVA: 0x0000C5AC File Offset: 0x0000A7AC
    private void SetDualWield2(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S12, CharMoveState.Custom, 0f, false, 0.01f, 1f);
        movingAction.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveDualWield));
        movingAction.customEffectRes = "FX_PC_RolRang_XSlash_Main";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, false, 0.01f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S12, CharMoveState.Stop, 0f, false, 0.2f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction2);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, false, 0.2f, 1f);
        oppo.Add(item2);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.Default, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        movingAction3.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction3);
        RencounterManager.MovingAction item3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item3);
    }

    // Token: 0x0600024F RID: 591 RVA: 0x0000C6B4 File Offset: 0x0000A8B4
    private void SetShotgun(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S11, CharMoveState.MoveBack, 3f, true, 0.2f, 1f);
        movingAction.customEffectRes = "BlackSilence_Shotgun";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 1f, true, 0.2f, 1f)
        {
            knockbackPower = 5f
        });
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.01f, 1f);
        movingAction2.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveAfter));
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction2);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item);
    }

    // Token: 0x06000250 RID: 592 RVA: 0x0000C778 File Offset: 0x0000A978
    private void SetGauntlet(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S5, CharMoveState.MoveForward, 20f, true, 0.01f, 1f);
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S5, CharMoveState.Stop, 1f, false, 0.01f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction2);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item2);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.S5, CharMoveState.MoveForward, 20f, true, 0.01f, 1f);
        movingAction3.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction3);
        RencounterManager.MovingAction item3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item3);
        RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.S5, CharMoveState.Stop, 1f, false, 0.01f, 1f);
        movingAction4.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction4);
        RencounterManager.MovingAction item4 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item4);
        RencounterManager.MovingAction movingAction5 = new RencounterManager.MovingAction(ActionDetail.S5, CharMoveState.MoveForward, 20f, true, 0.01f, 1f);
        movingAction5.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction5);
        RencounterManager.MovingAction item5 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item5);
        RencounterManager.MovingAction movingAction6 = new RencounterManager.MovingAction(ActionDetail.S5, CharMoveState.Stop, 1f, false, 0.01f, 1f);
        movingAction6.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction6);
        RencounterManager.MovingAction item6 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item6);
        RencounterManager.MovingAction movingAction7 = new RencounterManager.MovingAction(ActionDetail.S5, CharMoveState.MoveForward, 20f, true, 0.01f, 1f);
        movingAction7.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction7);
        RencounterManager.MovingAction item7 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item7);
        RencounterManager.MovingAction movingAction8 = new RencounterManager.MovingAction(ActionDetail.S5, CharMoveState.Stop, 1f, false, 0.01f, 1f);
        movingAction8.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction8);
        RencounterManager.MovingAction item8 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item8);
    }

    // Token: 0x06000251 RID: 593 RVA: 0x0000C9E4 File Offset: 0x0000ABE4
    private void SetShortSword(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S7, CharMoveState.Custom, 1f, false, 0.3f, 1f);
        movingAction.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveShortSword));
        movingAction.customEffectRes = "FX_PC_RolRang_Dagger";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.3f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Default, CharMoveState.Stop, 1f, false, 0f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction2);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0f, 1f);
        oppo.Add(item2);
    }

    // Token: 0x06000252 RID: 594 RVA: 0x0000CAA0 File Offset: 0x0000ACA0
    private void SetRevolver(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Fire, CharMoveState.Stop, 1f, true, 0.1f, 1f);
        movingAction.customEffectRes = "BlackSilence_Revolver";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NOT_PRINT, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 1f, true, 0.1f, 1f)
        {
            knockbackPower = 5f
        });
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S2, CharMoveState.Stop, 1f, true, 0.1f, 1f);
        movingAction2.customEffectRes = "BlackSilence_Revolver";
        movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.NOT_PRINT, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction2);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 1f, true, 0.1f, 1f)
        {
            knockbackPower = 5f
        });
    }

    // Token: 0x06000253 RID: 595 RVA: 0x0000CB68 File Offset: 0x0000AD68
    private void SetLance(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Penetrate, CharMoveState.MoveForward, 55f, false, 0.1f, 1f);
        movingAction.customEffectRes = "BlackSilence_Z";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, false, 0.1f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Penetrate, CharMoveState.Stop, 1f, false, 0.1f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction2);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, false, 0.1f, 1f);
        oppo.Add(item2);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.01f, 1f);
        movingAction3.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveAfter));
        movingAction3.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction3);
        RencounterManager.MovingAction item3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item3);
    }

    // Token: 0x06000254 RID: 596 RVA: 0x0000CC70 File Offset: 0x0000AE70
    private void SetHammer(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Hit, CharMoveState.MoveForward, 1f, true, 0.1f, 1f);
        movingAction.customEffectRes = "SiRv_Hammer";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 1f, true, 0.1f, 1f)
        {
            knockbackPower = 8f
        });
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.01f, 1f);
        movingAction2.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveAfter));
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction2);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item);
    }

    // Token: 0x06000255 RID: 597 RVA: 0x0000CD34 File Offset: 0x0000AF34
    private void SetAxeMace(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S8, CharMoveState.Stop, 1f, true, 0.2f, 1f);
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        movingAction.customEffectRes = "SiRv_Axe";
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.2f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S9, CharMoveState.Stop, 1f, true, 0.2f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        movingAction2.customEffectRes = "SiRv_Mace2";
        self.Add(movingAction2);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.2f, 1f);
        oppo.Add(item2);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.S6, CharMoveState.Stop, 1f, true, 0.2f, 1f);
        movingAction3.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        movingAction3.customEffectRes = "SiRv_AxeMace";
        self.Add(movingAction3);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 1f, true, 0.2f, 1f)
        {
            knockbackPower = 8f
        });
        RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.01f, 1f);
        movingAction4.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveAfter));
        movingAction4.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction4);
        RencounterManager.MovingAction item3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item3);
    }

    // Token: 0x06000256 RID: 598 RVA: 0x0000CEA8 File Offset: 0x0000B0A8
    private void SetLongSword(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S4, CharMoveState.MoveForward, 20f, false, 0.1f, 1f);
        movingAction.customEffectRes = "FX_PC_RolRang_Slash_UP";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S4, CharMoveState.Stop, 0f, false, 0.1f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.015f, 1f);
        movingAction2.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveAfter));
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

    // Token: 0x06000257 RID: 599 RVA: 0x0000CFA8 File Offset: 0x0000B1A8
    private void SetScythe1(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S15, CharMoveState.MoveForward, 20f, false, 0.01f, 1f);
        movingAction.customEffectRes = "FX_Mon_Argalia_Slash_H";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S15, CharMoveState.Stop, 0f, false, 0.1f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction2);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.1f, 1f);
        oppo.Add(item2);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.01f, 1f);
        movingAction3.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveAfter));
        movingAction3.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction3);
        RencounterManager.MovingAction item3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item3);
        RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.S15, CharMoveState.MoveForward, 20f, false, 0.01f, 1f);
        movingAction4.customEffectRes = "FX_Mon_Argalia_Slash_H";
        movingAction4.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction4);
        RencounterManager.MovingAction item4 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item4);
        RencounterManager.MovingAction movingAction5 = new RencounterManager.MovingAction(ActionDetail.S15, CharMoveState.Stop, 0f, false, 0.1f, 1f);
        movingAction5.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction5);
        RencounterManager.MovingAction item5 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.1f, 1f);
        oppo.Add(item5);
        RencounterManager.MovingAction movingAction6 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.01f, 1f);
        movingAction6.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveAfter));
        movingAction6.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction6);
        RencounterManager.MovingAction item6 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item6);
        RencounterManager.MovingAction movingAction7 = new RencounterManager.MovingAction(ActionDetail.S15, CharMoveState.MoveForward, 20f, false, 0.01f, 1f);
        movingAction7.customEffectRes = "FX_Mon_Argalia_Slash_H";
        movingAction7.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction7);
        RencounterManager.MovingAction item7 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item7);
        RencounterManager.MovingAction movingAction8 = new RencounterManager.MovingAction(ActionDetail.S15, CharMoveState.Stop, 0f, false, 0.1f, 1f);
        movingAction8.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction8);
        RencounterManager.MovingAction item8 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.1f, 1f);
        oppo.Add(item8);
        RencounterManager.MovingAction movingAction9 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.01f, 1f);
        movingAction9.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveAfter));
        movingAction9.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction9);
        RencounterManager.MovingAction item9 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item9);
    }

    // Token: 0x06000258 RID: 600 RVA: 0x0000D2BC File Offset: 0x0000B4BC
    private void SetScythe2(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S14, CharMoveState.MoveForward, 20f, false, 0.2f, 1f);
        movingAction.customEffectRes = "FX_Mon_Argalia_Slash_Down_Small";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.2f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.01f, 1f);
        movingAction2.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveAfter));
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction2);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item2);
    }

    // Token: 0x06000259 RID: 601 RVA: 0x0000D378 File Offset: 0x0000B578
    private void SetScythe3(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Slash2, CharMoveState.Stop, 1f, true, 0.1f, 1f);
        movingAction.customEffectRes = "FX_Mon_Argalia_Slash_Up";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.1f, 1f);
        oppo.Add(item);
    }

    // Token: 0x0600025A RID: 602 RVA: 0x0000D3D8 File Offset: 0x0000B5D8
    private void SetScythe4(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Hit2, CharMoveState.Stop, 1f, true, 0.2f, 1f);
        movingAction.customEffectRes = "FX_Mon_Argalia_Slash_Down";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 1f, true, 0.4f, 1f)
        {
            knockbackPower = 15f
        });
    }

    // Token: 0x0600025B RID: 603 RVA: 0x0000D444 File Offset: 0x0000B644
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

    // Token: 0x0600025C RID: 604 RVA: 0x0000D528 File Offset: 0x0000B728
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

    // Token: 0x0600025D RID: 605 RVA: 0x0000D60C File Offset: 0x0000B80C
    private bool MoveAfter(float deltaTime)
    {
        bool result = false;
        if (!_bMoveAfter)
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
            _bMoveAfter = true;
        }
        else if (_self.moveDetail.isArrived)
        {
            result = true;
            _bMoveAfter = false;
        }
        return result;
    }

    // Token: 0x0600025E RID: 606 RVA: 0x0000D6EC File Offset: 0x0000B8EC
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

    // Token: 0x0600025F RID: 607 RVA: 0x0000D7D0 File Offset: 0x0000B9D0
    private void SetFinal(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 0f, true, 0.01f, 1f);
        movingAction.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveFinal1));
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S15, CharMoveState.Stop, 0f, true, 0.4f, 1f);
        movingAction2.customEffectRes = "FX_Mon_Argalia_Slash_H";
        movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction2);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.4f, 1f);
        oppo.Add(item2);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.Penetrate2, CharMoveState.Custom, 0f, false, 0.01f, 1f);
        movingAction3.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(MoveFinal2));
        movingAction3.customEffectRes = "FX_Mon_Argalia_Flash";
        movingAction3.SetEffectTiming(EffectTiming.PRE, EffectTiming.NOT_PRINT, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction3);
        RencounterManager.MovingAction item3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item3);
        RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.Penetrate2, CharMoveState.Stop, 0f, false, 0.4f, 1f);
        movingAction4.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction4);
        RencounterManager.MovingAction item4 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.4f, 1f);
        oppo.Add(item4);
        RencounterManager.MovingAction movingAction5 = new RencounterManager.MovingAction(ActionDetail.S13, CharMoveState.Stop, 1f, true, 0.4f, 1f);
        movingAction5.customEffectRes = "FX_Mon_Argalia_Slash_Up";
        movingAction5.SetEffectTiming(EffectTiming.PRE, EffectTiming.NOT_PRINT, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction5);
        RencounterManager.MovingAction item5 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.4f, 1f);
        oppo.Add(item5);
        RencounterManager.MovingAction movingAction6 = new RencounterManager.MovingAction(ActionDetail.S3, CharMoveState.Stop, 0f, true, 1f, 1f);
        movingAction6.customEffectRes = "FX_PC_RolRang_Slash_Last";
        movingAction6.SetEffectTiming(EffectTiming.PRE, EffectTiming.PRE, EffectTiming.PRE);
        self.Add(movingAction6);
        RencounterManager.MovingAction item6 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 1f, 1f);
        oppo.Add(item6);
    }

    // Token: 0x06000260 RID: 608 RVA: 0x0000D9F0 File Offset: 0x0000BBF0
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

    // Token: 0x06000261 RID: 609 RVA: 0x0000DAD4 File Offset: 0x0000BCD4
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

    // Token: 0x040000BF RID: 191
    private BattleUnitModel _target;

    // Token: 0x040000C0 RID: 192
    private bool _bMovedLance;

    // Token: 0x040000C1 RID: 193
    private bool _bMovedShortSword;

    // Token: 0x040000C2 RID: 194
    private bool _bMoveAfter;

    // Token: 0x040000C3 RID: 195
    private bool _bMoveDualWield;

    // Token: 0x040000C4 RID: 196
    private bool _bMoveFinal1;

    // Token: 0x040000C5 RID: 197
    private bool _bMoveFinal2;
}
