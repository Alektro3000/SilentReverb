namespace SilentReverbMod
{
    // Token: 0x02000014 RID: 20
    public class DiceCardSelfAbility_SiRvCrystal : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x06000049 RID: 73 RVA: 0x00003804 File Offset: 0x00001A04
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
        }
    }
}
