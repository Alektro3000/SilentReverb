namespace SilentReverbMod
{
    // Token: 0x0200004E RID: 78
    public class DiceCardSelfAbility_SiRvResonate : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x06000136 RID: 310 RVA: 0x000029B5 File Offset: 0x00000BB5
        public override void OnUseCard()
        {
            this.card.ignorePower = true;
            if (base.IsResonance() > 0)
            {
                this.card.GetDiceBehaviorList()[0].behaviourInCard.ActionScript = "SilentReverbResonate";
            }
        }

        // Token: 0x06000138 RID: 312 RVA: 0x00007564 File Offset: 0x00005764
        public override void OnStartParrying()
        {
            BattleUnitModel target = this.card.target;
            if (target == null || target.currentDiceAction == null)
            {
                return;
            }
            target.currentDiceAction.ignorePower = true;
        }
    }
}
