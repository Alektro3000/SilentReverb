namespace SilentReverbMod
{
    // Token: 0x02000022 RID: 34
    public class DiceCardAbility_SiRvRenotePower : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x06000071 RID: 113 RVA: 0x00003B08 File Offset: 0x00001D08
        public override void OnSucceedAttack()
        {
            if (base.Resonance() > 0)
            {
                BattleUnitModel target = base.card.target;
                if (target == null)
                {
                    return;
                }
                target.bufListDetail.AddKeywordBufByCard(KeywordBuf.NullifyPower, 1, base.owner);
                base.card.GetDiceBehaviorList()[0].behaviourInCard.ActionScript = "SilentReverbResonate";
            }
        }
    }
}
