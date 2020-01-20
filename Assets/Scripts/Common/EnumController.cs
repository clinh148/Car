using System;

public enum TypePool
{
    BlockNormal,
    BlockShort,
    BlockLong,
    BlockEnemy,
    Boss_Speed,
    Boss_Enemy,
    Boss_Speed_Enemy,
    Boss_Cloud,
    TextPopupCombo,
    BlockFakeRight,
    BlockFakeLeft,
    Ball,
    BlockWin,
    Coin,
    ThunderCloud,
    GreyCloud,
}

public enum TypeAttributeBlock
{
    None,
    Oil,
    Boom,
    CreateFake,
    Fake,
    Break,
    Ball
}

public enum TypeCloud
{
    Thunder,
    None
}

public enum TypeSwipe
{
    Up,
    Right,
    Left,
    DoubleUp,
    None
}
public enum TypePanelUI
{
    PanelMain,
    PanelGameOver,
    PanelGameWin,
    PanelInGame,
    PanelPause,
    PanelSetting,
    PanelCollection,
    PanelRoomBox
}

public enum TypeStateGame
{
    None,
    Lobby,
    Playing,
    GameOver,
    GameWin,
    Pause
}

public enum TypeCombo
{
    None,
    Bad,
    Good,
    Great,
    Excellent,
    Perfect,
}

public enum TypeBoss
{
    BossSpeed,
    BossCreateEnemy,
    All
}

public class EnumController
{
    public static TypePool ConvertToPool(string type)
    {
        return (TypePool)Enum.Parse(typeof(TypePool), type, false);
    }
}