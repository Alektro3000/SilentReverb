namespace SilentReverbMod
{
    // Token: 0x0200008E RID: 142
    public class DiceCardSelfAbility_SiRvCrystalHurt2 : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x06000220 RID: 544 RVA: 0x0000BCDC File Offset: 0x00009EDC
        public override void OnUseCard()
        {
            if (base.IsResonance() > 0)
            {
                card.GetDiceBehaviorList()[0].behaviourInCard.ActionScript = "BlackReverbDualWield";
            }
            card.ApplyDiceStatBonus(DiceMatch.AllAttackDice, new DiceStatBonus
            {
                breakDmg = base.IsResonance() * 16 * card.target.bufListDetail.GetKewordBufStack(KeywordBuf.Vibrate)
            });
            if (base.IsResonance() == 0)
            {
                card.ApplyDiceAbility(DiceMatch.AllAttackDice, new DiceCardAbility_SiRvAdd3PoorAtk());
            }
        }
    }
}
