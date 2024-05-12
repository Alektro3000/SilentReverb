namespace SilentReverbMod
{
    // Token: 0x02000081 RID: 129
    public class DiceCardAbility_SiRvAnimatoDice : DiceCardAbilityBase
    {
        // Token: 0x06000201 RID: 513 RVA: 0x00002BAB File Offset: 0x00000DAB
        public override void OnSucceedAttack(BattleUnitModel target)
        {
            base.OnSucceedAttack(target);
            target.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vibrate, 7, base.owner);
        }

        // Token: 0x06000202 RID: 514 RVA: 0x00002F4F File Offset: 0x0000114F
        public override void OnLoseParrying()
        {
            BattlePlayingCardDataInUnitModel currentDiceAction = base.owner.currentDiceAction;
            if (currentDiceAction == null)
            {
                return;
            }
            currentDiceAction.DestroyDice(DiceMatch.AllDice, DiceUITiming.AttackAfter);
        }

        // Token: 0x06000203 RID: 515 RVA: 0x00002F4F File Offset: 0x0000114F
        public override void OnDrawParrying()
        {
            BattlePlayingCardDataInUnitModel currentDiceAction = base.owner.currentDiceAction;
            if (currentDiceAction == null)
            {
                return;
            }
            currentDiceAction.DestroyDice(DiceMatch.AllDice, DiceUITiming.AttackAfter);
        }
    }
}
