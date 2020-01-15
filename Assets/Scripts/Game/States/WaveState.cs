using System;

public class WaveState : GameState
{
    public WaveState(GameManager _gm) : base(_gm)
    {
        _GameManager = _gm;
    }

    public int _wavenumber;
    public override GameManager _GameManager { get; set; }

    private bool _EnemiesDefeated;

    private int _killCount;

    private int _amount;

    public override void OnStateEnter()
    {
        _killCount = 0;
        _amount = _GameManager._currentWave * 2;
        _GameManager._GameSettings._waveCount.text = 
            "Wave "+_GameManager._currentWave.ToString();

        _GameManager.onShouldSpawnEnemies?.Invoke(_amount);
        Mortal.onAnyNpcDead += AddKillCount;
    }

    private void AddKillCount(Mortal m)
    {
        _killCount += 1;

        if (_amount == _killCount)
            setEnemiesDefeated(true);
    }

    public override Type Tick()
    {
        if (_EnemiesDefeated)
        {
            return typeof(ShopState);
        }
        return null;
    }

    public void setEnemiesDefeated(bool value)
    {
        _EnemiesDefeated = value;
    }
}