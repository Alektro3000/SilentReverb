namespace SilentReverbMod
{
    // Token: 0x02000070 RID: 112
    public class PassiveAbility_SilentReverbBoss2 : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            base.OnWaveStart();
            owner.allyCardDetail.SetMaxDrawHand(25);
            owner.allyCardDetail.SetMaxHand(25);

            int[] arr = { 31, 32, 33, 34, 35, 36, 37, 38, 39,
                46,47,48,49,50};
            foreach (int card in arr)
                owner.allyCardDetail.AddNewCard(new LorId("SilentReverb", card), false);

            owner.personalEgoDetail.AddCard(new LorId("SilentReverb", 51));
        }

        public override int SpeedDiceNumAdder()
        {
            return 7;
        }

        public override void OnSucceedAttack(BattleDiceBehavior behavior)
        {
            BattleCardTotalResult battleCardResultLog = owner.battleCardResultLog;
            if (battleCardResultLog != null)
            {
                battleCardResultLog.SetPassiveAbility(this);
            }
            int stack = RandomUtil.Range(0, 1);
            BattleUnitModel target = behavior.card.target;
            if (target == null)
            {
                return;
            }
            target.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Vibrate, stack, this.owner);
        }

        //Много добора, много света
        public override void OnRoundStart()
        {
            owner.cardSlotDetail.RecoverPlayPoint(8);
            owner.allyCardDetail.DrawCards(8);
        }
        //Восстановление хп при резонансах
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            //Получаем резонанс
            int num = (owner.passiveDetail.PassiveList.Find(x => x is PassiveAbility_SilentReverb)
                as PassiveAbility_SilentReverb).IsResonance(curCard, curCard.target);
            if (num > 0)
                owner.RecoverHP(5);
        }
    }
}