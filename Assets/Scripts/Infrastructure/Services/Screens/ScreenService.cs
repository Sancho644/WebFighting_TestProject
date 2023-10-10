using Infrastructure.Factory;
using UI.Screens;

namespace Infrastructure.Services.Screens
{
    public class ScreenService
    {
        private IGameFactory _gameFactory;

        public ScreenService(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Show(ScreenId screenId)
        {
            switch (screenId)
            {
                case ScreenId.Unknown:
                    break;
                case ScreenId.EnemySearch:
                    _gameFactory.CreateSearchingEnemyScreen();
                    break;
            }
        }
    }
}