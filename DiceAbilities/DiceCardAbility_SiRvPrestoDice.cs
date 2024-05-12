namespace SilentReverbMod
{
    // Token: 0x0200009A RID: 154
    public class DiceCardAbility_SiRvPrestoDice : DiceCardAbility_SiRvSilentReverbBase
    {
        // Token: 0x06000241 RID: 577 RVA: 0x0000C214 File Offset: 0x0000A414
        public override void OnSucceedAreaAttack(BattleUnitModel target)
        {
            target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Disarm, 2, base.owner);
            target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Binding, 2, base.owner);
            target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Weak, 2, base.owner);
            target.bufListDetail.RemoveBufAll(KeywordBuf.Vibrate);
            target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Vibrate, RandomUtil.Range(4, 7), null);
            if (this.res == 0)
            {
                base.owner.breakDetail.RecoverBreak(8);
            }
            if (this.res > 0)
            {
                base.owner.RecoverHP(8 * this.res);
            }
        }

        // Token: 0x06000242 RID: 578 RVA: 0x000030C2 File Offset: 0x000012C2
        public override void BeforeRollDice()
        {
            this.res = base.Resonance();
        }

        // Token: 0x040000BE RID: 190
        private int res;
    }
}
