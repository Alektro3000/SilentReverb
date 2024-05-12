namespace SilentReverbMod
{
    // Token: 0x02000017 RID: 23
    public class DiceCardSelfAbility_SiRvAnimato : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x06000053 RID: 83 RVA: 0x00003878 File Offset: 0x00001A78
        public override void OnUseCard()
        {
            for (int i = 0; i < base.IsResonance(); i++)
            {
                BattleDiceCardModel battleDiceCardModel = BattleDiceCardModel.CreatePlayingCard(ItemXmlDataList.instance.GetCardItem(new LorId("SilentReverb", 41), false));
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
