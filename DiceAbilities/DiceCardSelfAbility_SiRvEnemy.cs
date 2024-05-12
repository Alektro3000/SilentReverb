namespace SilentReverbMod
{
    // Token: 0x0200005B RID: 91
    public class DiceCardSelfAbility_SiRvEnemy : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x06000164 RID: 356 RVA: 0x00002B3D File Offset: 0x00000D3D
        public new virtual void OnRoundStart_inHand(BattleUnitModel unit, BattleDiceCardModel self)
        {
            unit.bufListDetail.AddKeywordBufByCard(KeywordBuf.Vibrate, 1, unit);
        }

        // Token: 0x04000094 RID: 148
        public static string Desc = "[If Resonate] Boost Max roll of all dice on this page by 3 \n[Start of Clash] Reduce Power of all target's dice by 2";
    }
}
