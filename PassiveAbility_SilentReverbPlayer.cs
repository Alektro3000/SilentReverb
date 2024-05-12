using System.Collections.Generic;

namespace SilentReverbMod
{
    //Пассивка игрока
    public class PassiveAbility_SilentReverbPlayer : PassiveAbilityBase
    {
        public override void OnWaveStart()
        {
            base.OnWaveStart();
            owner.allyCardDetail.SetMaxDrawHand(12);
            owner.allyCardDetail.SetMaxHand(12);

            for (int i = 0; i < 3; i++)
            {
                owner.allyCardDetail.AddNewCard(new LorId("SilentReverb", 10 + i), false);
                owner.personalEgoDetail.AddCard(new LorId("SilentReverb", 13 + i));
            }
            owner.personalEgoDetail.AddCard(new LorId("SilentReverb", 16));
            GetFinal = 0;
            owner.bufListDetail.AddBufWithoutDuplication(new BattleUnitBuf_SilentRevCounter
            {
                stack = 0
            });
        }

        public override void OnRoundStart()
        {
            base.OnRoundStart();
            //Выбираем цель
            var RandomTarget = RandomUtil.SelectOne(
                BattleObjectManager.instance.GetAliveListExceptFaction(owner.faction));

            //Накладываем резонанс
            RandomTarget.bufListDetail.AddKeywordBufThisRoundByCard(
                KeywordBuf.Vibrate, RandomUtil.SelectOne(new int[]{1,2}), owner);

            //Очищаем все значки карт
            foreach (BattleDiceCardModel battleDiceCardModel in owner.allyCardDetail.GetAllDeck())
                battleDiceCardModel.RemoveBuf<BattleDiceCardBuf_SilentRevCounter>();

            //И обратно вставляем
            foreach (BattleDiceCardModel battleDiceCardModel2 in owner.allyCardDetail.GetAllDeck())
            {
                LorId id = battleDiceCardModel2.GetID();
                if (!_usedCount.Contains(id) && IsUniqueCard(id))
                    battleDiceCardModel2.AddBuf(new BattleDiceCardBuf_SilentRevCounter());
            }
        }


        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            //Получаем резонанс
            int num = (owner.passiveDetail.PassiveList.Find(x => x is PassiveAbility_SilentReverb)
                as PassiveAbility_SilentReverb).IsResonance(curCard, curCard.target);

            int id = curCard.card.GetID().id;
            if (GetFinal == 0 && id == 16 && num > 0)
            {
                owner.personalEgoDetail.RemoveCard(new LorId("SilentReverb", 16));
                owner.personalEgoDetail.AddCard(new LorId("SilentReverb", 17));
                owner.personalEgoDetail.AddCard(new LorId("SilentReverb", 18));
                if (num > 1)
                {
                    owner.allyCardDetail.AddNewCard(new LorId("SilentReverb", 19), false);
                }
                GetFinal = 1;
            }
            if (id == 16 || id == 17 || id == 18)
            {
                _usedCount.Clear();
                owner.bufListDetail.RemoveBufAll(typeof(BattleUnitBuf_SilentRevCounter));
                owner.bufListDetail.AddBufWithoutDuplication(new BattleUnitBuf_SilentRevCounter
                {
                    stack = 0
                });
            }
            if (!_usedCount.Contains(curCard.card.GetID()) && IsUniqueCard(curCard.card.GetID()))
            {
                _usedCount.Add(curCard.card.GetID());
                owner.bufListDetail.RemoveBufAll(typeof(BattleUnitBuf_SilentRevCounter));
                owner.bufListDetail.AddBufWithoutDuplication(new BattleUnitBuf_SilentRevCounter
                {
                    stack = _usedCount.Count
                });
            }
        }

        // Считается ли данная карта в счетчике 12 карт
        public bool IsUniqueCard(LorId a)
        {
            return ((1 <= a.id && a.id <= 12) || a.id == 19) && a.packageId == "SilentReverb";
        }

        public List<LorId> _usedCount = new List<LorId>();

        private int GetFinal;
    }
}
