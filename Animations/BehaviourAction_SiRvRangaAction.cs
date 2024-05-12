using System.Collections.Generic;

// Token: 0x02000076 RID: 118
public class BehaviourAction_SiRvRangaAction : BehaviourActionBase
{
    // Token: 0x060001E5 RID: 485 RVA: 0x0000B554 File Offset: 0x00009754
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
            RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S5, CharMoveState.MoveForward, 25f, false, 0.1f, 1f);
            movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.PRE, EffectTiming.PRE);
            new RencounterManager.MovingAction(ActionDetail.S5, CharMoveState.Stop, 0f, true, 0.1f, 1f).SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
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
