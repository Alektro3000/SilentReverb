namespace SilentReverbMod
{
    // Token: 0x02000043 RID: 67
    public class DiceCardSelfAbility_SiRvFinal1 : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x0600010D RID: 269 RVA: 0x00006CD4 File Offset: 0x00004ED4
        public override bool OnChooseCard(BattleUnitModel owner)
        {
            PassiveAbilityBase passiveAbilityBase = owner.passiveDetail.PassiveList.Find((PassiveAbilityBase x) => x is PassiveAbility_SilentReverbPlayer);
            return owner.passiveDetail.PassiveList.Exists((PassiveAbilityBase x) => x is PassiveAbility_SilentReverbBoss) || passiveAbilityBase == null || (passiveAbilityBase as PassiveAbility_SilentReverbPlayer)._usedCount.Count >= 5;
        }

        // Token: 0x06000110 RID: 272 RVA: 0x0000280F File Offset: 0x00000A0F
        public override void OnUseCard()
        {
            base.OnUseCard();
            if (base.IsResonance() != 0)
            {
                this.card.target.bufListDetail.AddBuf(new BattleUnitBuf_SilentFinalPlus
                {
                    stack = base.IsResonance()
                });
            }
        }
    }
}
