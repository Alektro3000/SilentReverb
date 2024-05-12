namespace SilentReverbMod
{
    // Token: 0x02000010 RID: 16
    public class DiceCardAbility_SiRvSilentReverbBase : DiceCardAbilityBase
    {
        // Token: 0x0600003E RID: 62 RVA: 0x0000373C File Offset: 0x0000193C
        public int Resonance()
        {
            PassiveAbilityBase passiveAbilityBase = base.owner.passiveDetail.PassiveList.Find((PassiveAbilityBase x) => x is PassiveAbility_SilentReverb);
            if (passiveAbilityBase == null)
            {
                return 0;
            }
            return (passiveAbilityBase as PassiveAbility_SilentReverb).IsResonance(base.card, base.card.target);
        }
    }
}
