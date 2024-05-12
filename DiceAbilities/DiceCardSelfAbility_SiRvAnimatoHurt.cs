namespace SilentReverbMod
{
    // Token: 0x02000082 RID: 130
    public class DiceCardSelfAbility_SiRvAnimatoHurt : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x06000205 RID: 517 RVA: 0x0000B99C File Offset: 0x00009B9C
        public override void OnUseCard()
        {
            if (base.IsResonance() == 0)
            {
                this.card.ignorePower = true;
                BattleUnitModel target = this.card.target;
                if (target != null && target.currentDiceAction != null)
                {
                    target.currentDiceAction.ignorePower = true;
                }
            }
            for (int i = 0; i < base.IsResonance(); i++)
            {
                BattleDiceCardModel battleDiceCardModel = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId("SilentReverb", 42), false));
                if (battleDiceCardModel != null)
                {
                    foreach (BattleDiceBehavior behaviour in battleDiceCardModel.CreateDiceCardBehaviorList())
                    {
                        base.owner.cardSlotDetail.keepCard.AddBehaviourForOnlyDefense(battleDiceCardModel, behaviour);
                    }
                }
            }
        }
    }
}
