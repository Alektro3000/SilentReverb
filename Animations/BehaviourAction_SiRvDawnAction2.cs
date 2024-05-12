using System.Collections.Generic;

// Token: 0x02000099 RID: 153
public class BehaviourAction_SiRvDawnAction2 : BehaviourActionBase
{
    // Token: 0x0600023F RID: 575 RVA: 0x0000C14C File Offset: 0x0000A34C
    public override List<RencounterManager.MovingAction> GetMovingAction(ref RencounterManager.ActionAfterBehaviour self, ref RencounterManager.ActionAfterBehaviour opponent)
    {
        List<RencounterManager.MovingAction> list = new List<RencounterManager.MovingAction>();
        bool flag = false;
        if (opponent.behaviourResultData != null)
        {
            flag = opponent.behaviourResultData.IsFarAtk();
        }
        if (self.result == Result.Win && self.data.actionType == ActionType.Atk && !flag)
        {
            RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S14, CharMoveState.MoveForward, 30f, false, 0.1f, 1f);
            movingAction.customEffectRes = "FX_Mon_Argalia_Slash_Down_Small";
            movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.PRE, EffectTiming.PRE);
            new RencounterManager.MovingAction(ActionDetail.Penetrate2, CharMoveState.Stop, 0f, true, 0.1f, 1f).SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
            list.Add(movingAction);
            opponent.infoList.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, false, 0.1f, 1f));
        }
        else
        {
            list = base.GetMovingAction(ref self, ref opponent);
        }
        return list;
    }
}
