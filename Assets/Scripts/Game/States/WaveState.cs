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

    public override void OnStateEnter()
    {
        _GameManager._currentWave += 1;

        _GameManager._GameSettings._waveCount.text = "Wave "+_wavenumber.ToString();
    }

    public override Type Tick()
    {
        if (_EnemiesDefeated)
        {
            return typeof(ShopState);
        }
        return null;
    }

    public void setEnemiesDefeated()
    {
        _EnemiesDefeated = true;
    }
}