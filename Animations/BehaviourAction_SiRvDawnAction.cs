using System.Collections.Generic;

// Token: 0x02000053 RID: 83
public class BehaviourAction_SiRvDawnAction : BehaviourActionBase
{
    // Token: 0x06000148 RID: 328 RVA: 0x00007954 File Offset: 0x00005B54
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
            RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.Penetrate2, CharMoveState.MoveForward, 30f, false, 0.1f, 1f);
            movingAction.customEffectRes = "FX_Mon_Argalia_Flash";
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
