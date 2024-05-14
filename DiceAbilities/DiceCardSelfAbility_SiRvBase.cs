using System.IO;

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
            return (passiveAbilityBase as PassiveAbility_SilentReverb).IsResonance(card, card.target);
        }
        // Token: 0x0600002B RID: 43 RVA: 0x00003600 File Offset: 0x00001800
        public int GetVibrations()
        {
            PassiveAbilityBase passiveAbilityBase = base.owner.passiveDetail.PassiveList.Find((PassiveAbilityBase x) => x is PassiveAbility_SilentReverb);
            if (passiveAbilityBase == null)
            {
                return 0;
            }
            return (passiveAbilityBase as PassiveAbility_SilentReverb).IsResonance(card, card.target);
        }
        public int GetUniqueCardCount()
        {
            if (owner == null)
                return 0;
            if (owner.passiveDetail == null)
                return 0;
            if (owner.passiveDetail.PassiveList == null)
                return 0;


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
