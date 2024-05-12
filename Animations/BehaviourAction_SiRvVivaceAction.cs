using System.Collections.Generic;

// Token: 0x0200006C RID: 108
public class BehaviourAction_SiRvVivaceAction : BehaviourActionBase
{
    // Token: 0x06000196 RID: 406 RVA: 0x000084D8 File Offset: 0x000066D8
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
            RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S15, CharMoveState.MoveForward, 30f, false, 0.1f, 1f);
            movingAction.customEffectRes = "FX_Mon_Argalia_Slash_H";
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
