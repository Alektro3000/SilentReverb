// Иконка уникальнй карты
public class BattleDiceCardBuf_SilentRevCounter : BattleDiceCardBuf
{
    protected override string keywordId
    {
        get => "SilentReverbcount";
    }
}


//Баф количества резонанса от Крещендо
public class BattleUnitBuf_SilentFinalPlus : BattleUnitBuf
{
    protected override string keywordId
    {
        get => "SilentReverbPlus";
    }

    protected override string keywordIconId
    {
        get => "SilentReverbPlus";
    }
    public override void OnRoundEnd() => Destroy();
}

//Баф скорости от Данзы и Престо
public class BattleUnitBuf_SilentPlusDice : BattleUnitBuf
{
    public override void OnRoundEnd() => Destroy();
    public override int SpeedDiceNumAdder() => stack;
}

//Счетчик уникальных карт для пассивки игрока
public class BattleUnitBuf_SilentRevCounter : BattleUnitBuf
{
    protected override string keywordId
    {
        get => "SilentReverbcount";
    }

    protected override string keywordIconId
    {
        get => "SilentReverbcount";
    }
}

//Счетчик трёх карт для +2 силы
public class BattleUnitBuf_SilentRevCounter3 : BattleUnitBuf
{
    protected override string keywordId
    {
        get => "SilentReverbcount3";
    }

    protected override string keywordIconId
    {
        get => "SilentReverbcount3";
    }
}

//Баф для выбора только одной карты 
public class BattleUnitBuf_SiRvAlreadySelected : BattleUnitBuf
{
    public override void OnRollSpeedDice() => Destroy();
}

//Баф для влияния на условия активации резонанса
public class BattleUnitBuf_SiRvResonanceBuf : BattleUnitBuf
{
    protected override string keywordId
    {
        get => "SilentReverb" + (int)Flags;
    }

    protected override string keywordIconId
    {
        get => "SilentReverb" + IconId;
    }

    public override void OnRoundEnd() => Destroy();

    public ResonanceEffect Flags;
    public string IconId = "";
}

public class BattleUnitBuf_SiRvCreschendoBuf : BattleUnitBuf_SiRvResonanceBuf
{
    public BattleUnitBuf_SiRvCreschendoBuf()
    {
        Flags = ResonanceEffect.ActivateAll;
        IconId = "Ult";
        stack = 0;
    }
}
public class BattleUnitBuf_SiRvAllInOne : BattleUnitBuf_SiRvResonanceBuf
{
    public BattleUnitBuf_SiRvAllInOne()
    {
        Flags = ResonanceEffect.AddResonance | ResonanceEffect.CloseResonance | ResonanceEffect.DistantResonance;
        IconId = "All";
        stack = 0;
    }
}