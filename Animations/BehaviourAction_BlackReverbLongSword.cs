using System.Collections.Generic;

// Token: 0x0200003E RID: 62
public class BehaviourAction_BlackReverbLongSword : BehaviourActionBase
{
    // Token: 0x06000100 RID: 256 RVA: 0x00006C0C File Offset: 0x00004E0C
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
            RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S4, CharMoveState.MoveForward, 30f, false, 0.1f, 1f);
            movingAction.customEffectRes = "FX_PC_RolRang_Slash_UP";
            movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.PRE, EffectTiming.PRE);
            new RencounterManager.MovingAction(ActionDetail.S4, CharMoveState.Stop, 0f, true, 0.1f, 1f).SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
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
