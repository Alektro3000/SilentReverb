namespace SilentReverbMod
{
    // Token: 0x02000063 RID: 99
    public class PassiveAbility_SiRvNoise : PassiveAbilityBase
    {
        // Token: 0x06000180 RID: 384 RVA: 0x00002BFE File Offset: 0x00000DFE
        public override void OnRoundStart()
        {
            base.OnRoundStart();
            isFirstUseCard = false;
        }

        // Token: 0x06000181 RID: 385 RVA: 0x00002C0D File Offset: 0x00000E0D
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            base.OnUseCard(curCard);
            if (curCard == null)
                return;

            if (!isFirstUseCard)
            {
                curCard.ApplyDiceAbility(DiceMatch.AllAttackDice, new DiceCardAbility_SiRvAdd1Vibrate());
                isFirstUseCard = true;
            }
        }

        // Token: 0x04000095 RID: 149
        private bool isFirstUseCard;
    }
}
