namespace SilentReverbMod
{
    // Token: 0x0200000B RID: 11
    public class DiceCardSelfAbility_SiRvBase : DiceCardSelfAbilityBase
    {
        // Token: 0x0600002B RID: 43 RVA: 0x00003600 File Offset: 0x00001800
        public int IsResonance()
        {
            PassiveAbilityBase passiveAbilityBase = base.owner.passiveDetail.PassiveList.Find((PassiveAbilityBase x) => x is PassiveAbility_SilentReverb);
            if (passiveAbilityBase == null)
            {
                return 0;
            }
            return (passiveAbilityBase as PassiveAbility_SilentReverb).IsResonance(this.card, this.card.target);
        }
        public int GetUniqueCardCount()
        {
            PassiveAbilityBase PlayerP = owner.passiveDetail.PassiveList.Find(x => x is PassiveAbility_SilentReverbPlayer);
            PassiveAbility_SilentReverbPlayer PlayerPas = PlayerP as PassiveAbility_SilentReverbPlayer;

            if (PlayerPas != null)
            {
                return PlayerPas._usedCount.Count;
            }
            return 12;

        }
    }
}
