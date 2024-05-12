using System.Collections.Generic;

public class BehaviourAction_BlackReverbDualWield : BehaviourActionBase
{
    public override List<RencounterManager.MovingAction> GetMovingAction(ref RencounterManager.ActionAfterBehaviour self, ref RencounterManager.ActionAfterBehaviour opponent)
    {
        bool flag = false;
        if (opponent.behaviourResultData != null)
        {
            flag = opponent.behaviourResultData.IsFarAtk();
        }
        if (self.result == Result.Win && self.data.actionType == ActionType.Atk && !flag)
        {
            List<RencounterManager.MovingAction> list = new List<RencounterManager.MovingAction>();
            RencounterManager.MovingAction movingAction = new RencounterManager.MovingAction(ActionDetail.S12, CharMoveState.MoveForward, 40f, false, 0.9f, 1f);
            movingAction.customEffectRes = "FX_PC_RolRang_XSlash_Main";
            movingAction.SetEffectTiming(EffectTiming.PRE, EffectTiming.PRE, EffectTiming.PRE);
            new RencounterManager.MovingAction(ActionDetail.S12, CharMoveState.Stop, 0f, true, 0.1f, 1f).SetEffectTiming(EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT, EffectTiming.NOT_PRINT);
            list.Add(movingAction);
            opponent.infoList.Add(new RencounterManager.MovingAction(ActionDetail.Damaged, CharMoveState.Stop, 1f, false, 0.5f, 1f));
            return list;
        }
        return base.GetMovingAction(ref self, ref opponent);
    }
}
