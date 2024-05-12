using LOR_DiceSystem;

namespace SilentReverbMod
{
    // Token: 0x02000090 RID: 144
    public class DiceCardAbility_SiRvAdagioDice : DiceCardAbilityBase
    {
        // Token: 0x06000225 RID: 549 RVA: 0x0000BDD8 File Offset: 0x00009FD8
        public override void OnWinParrying()
        {
            if (card == null || card.target == null || card.target.currentDiceAction == null)
            {
                return;
            }
            BattleUnitModel target = card.target;
            if (target == null)
            {
                return;
            }
            BattlePlayingCardDataInUnitModel currentDiceAction = target.currentDiceAction;
            if (currentDiceAction == null)
            {
                return;
            }
            currentDiceAction.AddDiceAdder(DiceMatch.NextDice, -3);
        }

        // Token: 0x1700001C RID: 28
        // (get) Token: 0x06000227 RID: 551 RVA: 0x00002145 File Offset: 0x00000345
        public override bool IsImmuneDestory
        {
            get
            {
                return true;
            }
        }

        // Token: 0x06000228 RID: 552 RVA: 0x0000BE38 File Offset: 0x0000A038
        public override void BeforeRollDice()
        {
            if (behavior.TargetDice.card.card.XmlData.Spec.Ranged == CardRange.Far)
            {
                behavior.TargetDice.ApplyDiceStatBonus(new DiceStatBonus
                {
                    power = -999,
                    min = -999,
                    max = -999
                });
            }
        }
    }
}
