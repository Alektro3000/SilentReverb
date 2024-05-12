namespace SilentReverbMod
{
    // Token: 0x02000034 RID: 52
    public class DiceCardSelfAbility_SiRvFinal : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x060000B6 RID: 182 RVA: 0x00004050 File Offset: 0x00002250
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            return GetUniqueCardCount() >= 5;
        }
    }
}
