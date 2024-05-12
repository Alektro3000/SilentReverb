using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200006F RID: 111
public class BehaviourAction_BlackReverbFuriosoPlus : BehaviourActionBase
{
    // Token: 0x060001B4 RID: 436 RVA: 0x00002488 File Offset: 0x00000688
    public override bool IsMovable()
    {
        return false;
    }

    // Token: 0x060001B5 RID: 437 RVA: 0x00002488 File Offset: 0x00000688
    public override bool IsOpponentMovable()
    {
        return false;
    }

    // Token: 0x060001B6 RID: 438 RVA: 0x00009878 File Offset: 0x00007A78
    public override List<RencounterManager.MovingAction> GetMovingAction(ref RencounterManager.ActionAfterBehaviour self, ref RencounterManager.ActionAfterBehaviour opponent)
    {
        bool flag = false;
        if (opponent.behaviourResultData != null)
        {
            flag = opponent.behaviourResultData.IsFarAtk();
        }
        if (self.result == Result.Win && !flag)
        {
            this._self = self.view.model;
            this._target = opponent.view.model;
            List<RencounterManager.MovingAction> list = new List<RencounterManager.MovingAction>();
            List<RencounterManager.MovingAction> list2 = new List<RencounterManager.MovingAction>();
            if (opponent.infoList.Count > 0)
            {
                opponent.infoList.Clear();
            }
            this.SetShotgun(list, list2);
            this.SetDualWield1(list, list2);
            this.SetDualWield2(list, list2);
            this.SetGreatSword(list, list2);
            this.SetGauntlet(list, list2);
            this.SetShortSword(list, list2);
            this.SetRevolver(list, list2);
            this.SetLance(list, list2);
            this.SetAxe(list, list2);
            this.SetMace(list, list2);
            this.SetHammer(list, list2);
            this.SetLongSword(list, list2);
            this.SetScythe1(list, list2);
            this.SetScythe2(list, list2);
            this.SetScythe3(list, list2);
            this.SetScythe4(list, list2);
            this.SetFinal(list, list2);
            opponent.infoList = list2;
            return list;
        }
        return base.GetMovingAction(ref self, ref opponent);
    }

    // Token: 0x060001B7 RID: 439 RVA: 0x0000998C File Offset: 0x00007B8C
    private void SetShotgun(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S11, CharMoveState.MoveBack, 3f, true, 0.4f, 1f);
        movingAction.customEffectRes = "BlackSilence_Shotgun";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 1f, true, 0.4f, 1f)
        {
            knockbackPower = 5f
        });
    }

    // Token: 0x060001B8 RID: 440 RVA: 0x000099F8 File Offset: 0x00007BF8
    private void SetDualWield1(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Slash, CharMoveState.Custom, 1f, false, 0.01f, 1f);
        movingAction.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveLance));
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
        movingAction3.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveAfter));
        movingAction3.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction3);
        RencounterManager.MovingAction item3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item3);
    }

    // Token: 0x060001B9 RID: 441 RVA: 0x00009B14 File Offset: 0x00007D14
    private void SetDualWield2(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S12, CharMoveState.Custom, 0f, false, 0.01f, 1f);
        movingAction.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveDualWield));
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
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.01f, 1f);
        movingAction3.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveAfter));
        movingAction3.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction3);
        RencounterManager.MovingAction item3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item3);
    }

    // Token: 0x060001BA RID: 442 RVA: 0x00009C30 File Offset: 0x00007E30
    private void SetGreatSword(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S10, CharMoveState.Stop, 1f, true, 0.4f, 1f);
        movingAction.customEffectRes = "FX_PC_RolRang_Greatsword";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.4f, 1f);
        oppo.Add(item);
    }

    // Token: 0x060001BB RID: 443 RVA: 0x00009C90 File Offset: 0x00007E90
    private void SetGauntlet(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S5, CharMoveState.MoveForward, 15f, false, 0.2f, 1f);
        movingAction.customEffectRes = "SiRv_Ranga1";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.2f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S5, CharMoveState.Stop, 1f, false, 0.01f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction2);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item2);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.S6, CharMoveState.MoveForward, 15f, false, 0.2f, 1f);
        movingAction3.customEffectRes = "SiRv_Ranga2";
        movingAction3.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction3);
        RencounterManager.MovingAction item3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.2f, 1f);
        oppo.Add(item3);
        RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.S6, CharMoveState.Stop, 1f, false, 0.01f, 1f);
        movingAction4.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction4);
        RencounterManager.MovingAction item4 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item4);
    }

    // Token: 0x060001BC RID: 444 RVA: 0x00009DE0 File Offset: 0x00007FE0
    private void SetShortSword(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S7, CharMoveState.Custom, 1f, false, 0.3f, 1f);
        movingAction.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveShortSword));
        movingAction.customEffectRes = "FX_PC_RolRang_Dagger";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.3f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Default, CharMoveState.Stop, 1f, false, 0.01f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction2);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item2);
    }

    // Token: 0x060001BD RID: 445 RVA: 0x00009E9C File Offset: 0x0000809C
    private void SetRevolver(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Fire, CharMoveState.Stop, 1f, true, 0.2f, 1f);
        movingAction.customEffectRes = "BlackSilence_Revolver";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NOT_PRINT, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 1f, true, 0.2f, 1f)
        {
            knockbackPower = 8f
        });
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S2, CharMoveState.Stop, 1f, true, 0.2f, 1f);
        movingAction2.customEffectRes = "BlackSilence_Revolver";
        movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.NOT_PRINT, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction2);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 1f, true, 0.2f, 1f)
        {
            knockbackPower = 8f
        });
    }

    // Token: 0x060001BE RID: 446 RVA: 0x00009F64 File Offset: 0x00008164
    private void SetLance(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Penetrate, CharMoveState.MoveForward, 55f, false, 0.1f, 1f);
        movingAction.customEffectRes = "BlackSilence_Z";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, false, 0.1f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Penetrate, CharMoveState.Stop, 1f, false, 0.2f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction2);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, false, 0.2f, 1f);
        oppo.Add(item2);
    }

    // Token: 0x060001BF RID: 447 RVA: 0x0000A00C File Offset: 0x0000820C
    private void SetAxe(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.01f, 1f);
        movingAction.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveAfter));
        movingAction.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S8, CharMoveState.Stop, 1f, true, 0.3f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        movingAction2.customEffectRes = "SiRv_Axe";
        self.Add(movingAction2);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.3f, 1f);
        oppo.Add(item2);
    }

    // Token: 0x060001C0 RID: 448 RVA: 0x0000A0C8 File Offset: 0x000082C8
    private void SetMace(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S9, CharMoveState.Stop, 1f, true, 0.3f, 1f);
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        movingAction.customEffectRes = "SiRv_Mace";
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.3f, 1f);
        oppo.Add(item);
    }

    // Token: 0x060001C1 RID: 449 RVA: 0x0000A128 File Offset: 0x00008328
    private void SetHammer(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Hit, CharMoveState.MoveForward, 1f, true, 0.2f, 1f);
        movingAction.customEffectRes = "SiRv_Hammer";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 1f, true, 0.2f, 1f)
        {
            knockbackPower = 5f
        });
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.01f, 1f);
        movingAction2.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveAfter));
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction2);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item);
    }

    // Token: 0x060001C2 RID: 450 RVA: 0x0000A1EC File Offset: 0x000083EC
    private void SetLongSword(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S4, CharMoveState.MoveForward, 20f, false, 0.2f, 1f);
        movingAction.customEffectRes = "FX_PC_RolRang_Slash_UP";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S4, CharMoveState.Stop, 0f, false, 0.3f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.015f, 1f);
        movingAction2.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveAfter));
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

    // Token: 0x060001C3 RID: 451 RVA: 0x0000A2EC File Offset: 0x000084EC
    private void SetScythe1(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S15, CharMoveState.MoveForward, 20f, false, 0.3f, 1f);
        movingAction.customEffectRes = "FX_Mon_Argalia_Slash_H";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.3f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.S15, CharMoveState.Stop, 0f, false, 0.1f, 1f);
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction2);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.1f, 1f);
        oppo.Add(item2);
        RencounterManager.MovingAction movingAction3 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.01f, 1f);
        movingAction3.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveAfter));
        movingAction3.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction3);
        RencounterManager.MovingAction item3 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item3);
        RencounterManager.MovingAction movingAction4 = new RencounterManager.MovingAction(ActionDetail.S15, CharMoveState.MoveForward, 20f, false, 0.3f, 1f);
        movingAction4.customEffectRes = "FX_Mon_Argalia_Slash_H";
        movingAction4.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction4);
        RencounterManager.MovingAction item4 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.3f, 1f);
        oppo.Add(item4);
        RencounterManager.MovingAction movingAction5 = new RencounterManager.MovingAction(ActionDetail.S15, CharMoveState.Stop, 0f, false, 0.1f, 1f);
        movingAction5.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction5);
        RencounterManager.MovingAction item5 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.1f, 1f);
        oppo.Add(item5);
        RencounterManager.MovingAction movingAction6 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.01f, 1f);
        movingAction6.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveAfter));
        movingAction6.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction6);
        RencounterManager.MovingAction item6 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item6);
    }

    // Token: 0x060001C4 RID: 452 RVA: 0x0000A4FC File Offset: 0x000086FC
    private void SetScythe2(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S14, CharMoveState.MoveForward, 20f, false, 0.3f, 1f);
        movingAction.customEffectRes = "FX_Mon_Argalia_Slash_Down_Small";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.3f, 1f);
        oppo.Add(item);
        RencounterManager.MovingAction movingAction2 = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 1f, true, 0.01f, 1f);
        movingAction2.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveAfter));
        movingAction2.SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
        self.Add(movingAction2);
        RencounterManager.MovingAction item2 = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.01f, 1f);
        oppo.Add(item2);
    }

    // Token: 0x060001C5 RID: 453 RVA: 0x0000A5B8 File Offset: 0x000087B8
    private void SetScythe3(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Slash2, CharMoveState.Stop, 1f, true, 0.2f, 1f);
        movingAction.customEffectRes = "FX_Mon_Argalia_Slash_Up";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        RencounterManager.MovingAction item = new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, true, 0.2f, 1f);
        oppo.Add(item);
    }

    // Token: 0x060001C6 RID: 454 RVA: 0x0000A618 File Offset: 0x00008818
    private void SetScythe4(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Hit2, CharMoveState.Stop, 1f, true, 0.4f, 1f);
        movingAction.customEffectRes = "FX_Mon_Argalia_Slash_Down";
        movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.NONE, EffectTiming.WITHOUT_DMGTEXT);
        self.Add(movingAction);
        oppo.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Knockback, 1f, true, 0.4f, 1f)
        {
            knockbackPower = 15f
        });
    }

    // Token: 0x060001C7 RID: 455 RVA: 0x0000A684 File Offset: 0x00008884
    private bool MoveLance(float deltaTime)
    {
        if (this._target == null)
        {
            return true;
        }
        bool result = false;
        if (!this._bMovedLance)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float x = this._target.view.transform.localScale.x;
            float num = SingletonBehavior<HexagonalMapManager>.Instance.tileSize * x + 6f;
            int num2 = 1;
            if (this._self.view.WorldPosition.x < this._target.view.WorldPosition.x)
            {
                num2 = -1;
            }
            Vector3 pos = worldPosition - new Vector3((float)num2 * num, 0f, 0f);
            this._self.moveDetail.Move(pos, 400f, false, true);
            this._bMovedLance = true;
        }
        else if (this._self.moveDetail.isArrived)
        {
            result = true;
        }
        return result;
    }

    // Token: 0x060001C8 RID: 456 RVA: 0x0000A768 File Offset: 0x00008968
    private bool MoveShortSword(float deltaTime)
    {
        if (this._target == null)
        {
            return true;
        }
        bool result = false;
        if (!this._bMovedShortSword)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float x = this._target.view.transform.localScale.x;
            float num = SingletonBehavior<HexagonalMapManager>.Instance.tileSize * x + 6f;
            int num2 = 1;
            if (this._self.view.WorldPosition.x < this._target.view.WorldPosition.x)
            {
                num2 = -1;
            }
            Vector3 pos = worldPosition - new Vector3((float)num2 * num, 0f, 0f);
            this._self.moveDetail.Move(pos, 250f, false, false);
            this._bMovedShortSword = true;
        }
        else if (this._self.moveDetail.isArrived)
        {
            result = true;
        }
        return result;
    }

    // Token: 0x060001C9 RID: 457 RVA: 0x0000A84C File Offset: 0x00008A4C
    private bool MoveAfter(float deltaTime)
    {
        bool result = false;
        if (!this._bMoveAfter)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float x = this._target.view.transform.localScale.x;
            float num = SingletonBehavior<HexagonalMapManager>.Instance.tileSize * x + 6f;
            int num2 = 1;
            if (this._self.view.WorldPosition.x < this._target.view.WorldPosition.x)
            {
                num2 = -1;
            }
            Vector3 pos = worldPosition + new Vector3((float)num2 * num, 0f, 0f);
            this._self.moveDetail.Move(pos, 150f, true, false);
            this._bMoveAfter = true;
        }
        else if (this._self.moveDetail.isArrived)
        {
            result = true;
            this._bMoveAfter = false;
        }
        return result;
    }

    // Token: 0x060001CA RID: 458 RVA: 0x0000A92C File Offset: 0x00008B2C
    private bool MoveDualWield(float deltaTime)
    {
        if (this._target == null)
        {
            return true;
        }
        bool result = false;
        if (!this._bMoveDualWield)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float x = this._target.view.transform.localScale.x;
            float num = SingletonBehavior<HexagonalMapManager>.Instance.tileSize * x + 12f;
            int num2 = 1;
            if (this._self.view.WorldPosition.x < this._target.view.WorldPosition.x)
            {
                num2 = -1;
            }
            Vector3 pos = worldPosition - new Vector3((float)num2 * num, 0f, 0f);
            this._self.moveDetail.Move(pos, 250f, false, false);
            this._bMoveDualWield = true;
        }
        else if (this._self.moveDetail.isArrived)
        {
            result = true;
        }
        return result;
    }

    // Token: 0x060001CB RID: 459 RVA: 0x0000AA10 File Offset: 0x00008C10
    private void SetFinal(List<RencounterManager.MovingAction> self, List<RencounterManager.MovingAction> oppo)
    {
        RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Move, CharMoveState.Custom, 0f, true, 0.01f, 1f);
        movingAction.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveFinal1));
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
        movingAction3.SetCustomMoving(new RencounterManager.MovingAction.MoveCustomEvent(this.MoveFinal2));
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

    // Token: 0x060001CC RID: 460 RVA: 0x0000AC30 File Offset: 0x00008E30
    private bool MoveFinal1(float deltaTime)
    {
        if (this._target == null)
        {
            return true;
        }
        bool result = false;
        if (!this._bMoveFinal1)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float x = this._target.view.transform.localScale.x;
            float num = SingletonBehavior<HexagonalMapManager>.Instance.tileSize * x + 6f;
            int num2 = 1;
            if (this._self.view.WorldPosition.x < this._target.view.WorldPosition.x)
            {
                num2 = -1;
            }
            Vector3 pos = worldPosition + new Vector3((float)num2 * num, 0f, 0f);
            this._self.moveDetail.Move(pos, 250f, false, false);
            this._bMoveFinal1 = true;
        }
        else if (this._self.moveDetail.isArrived)
        {
            result = true;
        }
        return result;
    }

    // Token: 0x060001CD RID: 461 RVA: 0x0000AD14 File Offset: 0x00008F14
    private bool MoveFinal2(float deltaTime)
    {
        if (this._target == null)
        {
            return true;
        }
        bool result = false;
        if (!this._bMoveFinal2)
        {
            Vector3 worldPosition = this._target.view.WorldPosition;
            float x = this._target.view.transform.localScale.x;
            float num = SingletonBehavior<HexagonalMapManager>.Instance.tileSize * x + 6f;
            int num2 = 1;
            if (this._self.view.WorldPosition.x < this._target.view.WorldPosition.x)
            {
                num2 = -1;
            }
            Vector3 pos = worldPosition - new Vector3((float)num2 * num, 0f, 0f);
            this._self.moveDetail.Move(pos, 250f, false, false);
            this._bMoveFinal2 = true;
        }
        else if (this._self.moveDetail.isArrived)
        {
            result = true;
        }
        return result;
    }

    // Token: 0x040000A4 RID: 164
    private BattleUnitModel _target;

    // Token: 0x040000A5 RID: 165
    private bool _bMovedLance;

    // Token: 0x040000A6 RID: 166
    private bool _bMovedShortSword;

    // Token: 0x040000A7 RID: 167
    private bool _bMoveAfter;

    // Token: 0x040000A8 RID: 168
    private bool _bMoveDualWield;

    // Token: 0x040000A9 RID: 169
    private bool _bMoveFinal1;

    // Token: 0x040000AA RID: 170
    private bool _bMoveFinal2;
}
