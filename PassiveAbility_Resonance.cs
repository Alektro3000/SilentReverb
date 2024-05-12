using System;

namespace SilentReverbMod
{
    //Базовая пассивка ответственная за резонансы и за силу на каждый третий ход
    public class PassiveAbility_SilentReverb : PassiveAbilityBase
    {
        public int IsResonance(BattlePlayingCardDataInUnitModel card, BattleUnitModel target, ResonanceEffect Type)
        {
            if (target == null || card == null)
                return 0;

            //Резонанс не могут вызывать карты не из нашего мода
            if (card.card.GetID().packageId != SilentReverb_ModInit.packageId)
                return 0;

            //Резонанс не могут вызывать эти две конкретные
            if (card.card.GetID().id == 18 || card.card.GetID().id == 21)
                return 0;

            int num = 0;
            var Buf = target.bufListDetail.GetActivatedBufList().Find(x => x is BattleUnitBuf_SilentFinalPlus);
            if (Buf != null)
                num += 2 * Buf.stack;

            int stack = 0;
            if (target.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate) != null)
                stack = target.bufListDetail.GetActivatedBuf(KeywordBuf.Vibrate).stack;

            return IsResonance(card.speedDiceResultValue, stack, num, Type);
        }
        public int IsResonance(BattlePlayingCardDataInUnitModel card, BattleUnitModel target)
        {
            ResonanceEffect resonanceEffect = ResonanceEffect.None;

            if (card == null || card.owner == null || card.owner.bufListDetail == null)
                return IsResonance(card, target, resonanceEffect);

            foreach (BattleUnitBuf battleUnitBuf in card.owner.bufListDetail.
                GetActivatedBufList().FindAll(x => x is BattleUnitBuf_SiRvResonanceBuf))
            {
                resonanceEffect |= (battleUnitBuf as BattleUnitBuf_SiRvResonanceBuf).Flags;
            }
            return IsResonance(card, target, resonanceEffect);
        }
        public int IsResonance(int speed, int stack, int AddNum, ResonanceEffect Type)
        {
            int num = 1 + AddNum;
            if (HasFlag(Type, ResonanceEffect.AddResonance))
                num++;

            if (HasFlag(Type, ResonanceEffect.ActivateAll))
                return num;

            if (stack == 0)
                return 0;

            int num2 = Math.Abs(speed - stack);

            if (num2 <= (HasFlag(Type, ResonanceEffect.CloseResonance) ? 2 : 0))
                return num;

            if (HasFlag(Type, ResonanceEffect.DistantResonance) && 4 <= num2)
                return num;

            if (stack >= 5 && owner.emotionDetail.EmotionLevel >= 5)
                return num;

            return 0;
        }

        //Сброс считчика вибраций после резонанса
        public override void OnEndBattle(BattlePlayingCardDataInUnitModel curCard)
        {
            base.OnEndBattle(curCard);

            //Если карта не мгновенная и был резонанс
            if (!curCard.isKeepedCard && IsResonance(curCard, curCard.target) >= 1)
            {
                //Убираем вибрацию
                curCard.target.bufListDetail.RemoveBufAll(KeywordBuf.Vibrate);
                //Обновляем счётчик резонансов
                ResonanceCount++;
                //Сбрасываем stack влияющих пасссивок на резонанс
                foreach (BattleUnitBuf battleUnitBuf in 
                    owner.bufListDetail.GetActivatedBufList().FindAll(
                        (BattleUnitBuf x) => x is BattleUnitBuf_SiRvResonanceBuf && x.stack != 0))
                {
                    battleUnitBuf.stack--;
                    if (battleUnitBuf.stack == 0)
                        battleUnitBuf.Destroy();
                    
                }
            }

            //Переводим вибрации, что были на следующий ход на текущий
            BattleUnitBuf readyBuf = curCard.target.bufListDetail.GetReadyBuf(KeywordBuf.Vibrate);
            if (readyBuf != null)
            {
                curCard.target.bufListDetail.AddKeywordBufThisRoundByCard(KeywordBuf.Vibrate, readyBuf.stack, owner);
                curCard.target.bufListDetail.RemoveReadyBuf(readyBuf);
            }

            //Счётчик резонансов
            if (ResonanceCount != 2)
                return;
            ResonanceCount++;

            //Добираем дополнительно карту и получем силу если было три резонанса
            owner.allyCardDetail.DrawCards(1);
            owner.bufListDetail.AddKeywordBufByEtc(KeywordBuf.Strength, 1, null);
        }

        // Token: 0x06000012 RID: 18 RVA: 0x00002113 File Offset: 0x00000313
        public override void OnRoundStart()
        {
            base.OnRoundStart();
            ResonanceCount = 0;
        }
        public override void OnUseCard(BattlePlayingCardDataInUnitModel curCard)
        {
            //Применяем +4 силы на каждую третью страницу
            _count++;
            if (_count == 3)
            {
                _count = 0;
                curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
                {
                    power = 4,
                    dmgRate = -40,
                    breakRate = -40
                });
            }

            //Обновляем Баф
            owner.bufListDetail.RemoveBufAll(typeof(BattleUnitBuf_SilentRevCounter3));
            if (_count > 0)
                owner.bufListDetail.AddBuf(new BattleUnitBuf_SilentRevCounter3
                {
                    stack = _count
                });



            int UsingResonace = IsResonance(curCard, curCard.target);
            if (curCard.card == null)
                return;

            //Сила за резонанс
            int id = curCard.card.GetID().id;
            curCard.ApplyDiceStatBonus(DiceMatch.AllDice, new DiceStatBonus
            {
                min = UsingResonace * 2,
                max = UsingResonace * 2
            });
        }
        //Иммунитет от дальних атак
        public override bool isImmuneByFarAtk
        {
            get => true;
        }

        //Шорткат для определения типа
        public static bool HasFlag(ResonanceEffect Effect, ResonanceEffect Val)
        {
            return (Effect & Val) > ResonanceEffect.None;
        }

        // Счётчик использованных карт до 3
        private int _count;

        // Счётчик резонансов за раунд
        private int ResonanceCount;
    }
}
