namespace SilentReverbMod
{
    // Token: 0x02000079 RID: 121
    public class DiceCardAbility_SiRvAllasHurtDice : DiceCardAbilityBase
    {
        // Token: 0x060001EB RID: 491 RVA: 0x000030FC File Offset: 0x000012FC
        public override void OnWinParrying()
        {
            base.OnWinParrying();
            BattlePlayingCardDataInUnitModel card = base.card;
            if (card == null)
            {
                return;
            }
            BattleUnitModel target = card.target;
            if (target == null)
            {
                return;
            }
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList(target.faction))
            {
                if (battleUnitModel == target)
                {
                    battleUnitModel.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vibrate, 1, base.owner);
                }
                else
                {
                    battleUnitModel.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Vibrate, 1, base.owner);
                }
            }
        }

        // Token: 0x060001EC RID: 492 RVA: 0x0000B60C File Offset: 0x0000980C
        public override void OnSucceedAttack()
        {
            base.OnSucceedAttack();
            BattlePlayingCardDataInUnitModel card = base.card;
            if (card == null)
            {
                return;
            }
            BattleUnitModel target = card.target;
            if (target == null)
            {
                return;
            }
            foreach (BattleUnitModel battleUnitModel in BattleObjectManager.instance.GetAliveList(target.faction))
            {
                if (battleUnitModel == target)
                {
                    battleUnitModel.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vibrate, 1, base.owner);
                }
                else
                {
                    battleUnitModel.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Vibrate, 1, base.owner);
                }
            }
        }
    }
}
