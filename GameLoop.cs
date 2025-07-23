using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archuniverse
{
    public class GameLoop
    {
        private static GameLoop? _instance;
        public static GameLoop Instance => _instance ??= new GameLoop();

        private readonly List<ITickable> _tickables = new();

        public void RegisterTickable(ITickable tickable)
        {
            if (!_tickables.Contains(tickable))
                _tickables.Add(tickable);
        }

        public void UnregisterTickable(ITickable tickable)
        {
            _tickables.Remove(tickable);
        }

        public void Run()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            long lastTime = stopwatch.ElapsedMilliseconds;

            while (true)
            {
                long currentTime = stopwatch.ElapsedMilliseconds;
                float deltaTime = (currentTime - lastTime) / 1000f;
                lastTime = currentTime;

                foreach (var tickable in _tickables.ToList())
                {
                    tickable.Tick(deltaTime);
                }

                Thread.Sleep(16); // ~60fps
            }
        }
    }

}
