namespace SilentReverbMod
{
    // Token: 0x0200008C RID: 140
    public class DiceCardSelfAbility_SiRvCrystalHurt : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x0600021B RID: 539 RVA: 0x0000BC4C File Offset: 0x00009E4C
        public override void OnUseCard()
        {
            if (base.IsResonance() > 0)
            {
                card.GetDiceBehaviorList()[0].behaviourInCard.ActionScript = "BlackReverbDualWield";
            }
            card.ApplyDiceStatBonus(DiceMatch.AllAttackDice, new DiceStatBonus
            {
                breakDmg = base.IsResonance() * 8 * card.target.bufListDetail.GetKewordBufStack(KeywordBuf.Vibrate)
            });
            if (base.IsResonance() == 0)
            {
                card.ApplyDiceAbility(DiceMatch.AllAttackDice, new DiceCardAbility_SiRvAddPoorAtk());
            }
        }
    }
}
