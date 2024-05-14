namespace SilentReverbMod
{
    // Token: 0x02000062 RID: 98
    public class DiceCardSelfAbility_SiRvCreschendoBoss : DiceCardSelfAbility_SiRvBase
    {
        // Token: 0x0600017A RID: 378 RVA: 0x00003FFC File Offset: 0x000021FC
        public override void OnApplyCard()
        {
            BattleUnitModel owner = base.owner;
            if (owner != null)
            {
                owner.view.charAppearance.ChangeMotion(ActionDetail.Aim);
            }
        }

        // Token: 0x0600017B RID: 379 RVA: 0x00004028 File Offset: 0x00002228
        public override void OnReleaseCard()
        {
            BattleUnitModel owner = base.owner;
            if (owner != null)
            {
                owner.view.charAppearance.ChangeMotion(ActionDetail.Standing);
            }
        }

        // Token: 0x0600017C RID: 380 RVA: 0x0000257A File Offset: 0x0000077A
        public override void OnStartBattle()
        {
            base.OnStartBattle();
            base.owner.bufListDetail.AddBuf(new BattleUnitBuf_SiRvCreschendoBuf());
        }

        // Token: 0x0600017F RID: 383 RVA: 0x00002BC8 File Offset: 0x00000DC8
        public override void OnUseCard()
        {
            card.AddDiceAdder(DiceMatch.LastDice, 4 * BattleObjectManager.instance.GetAliveList((base.owner.faction == Faction.Player) ? Faction.Enemy : Faction.Player).Count);
        }
    }
}
