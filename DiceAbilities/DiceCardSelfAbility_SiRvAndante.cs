namespace SilentReverbMod
{
    // Token: 0x02000095 RID: 149
    public class DiceCardSelfAbility_SiRvAndante : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x06000233 RID: 563 RVA: 0x0000BF6C File Offset: 0x0000A16C
        public override void OnUseCard()
        {
            if (base.IsResonance() > 0)
            {
                card.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    power = 3 * base.IsResonance()
                });
            }
            if (base.IsResonance() == 0)
            {
                BattleDiceCardModel battleDiceCardModel = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId("SilentReverb", 44), false));
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
