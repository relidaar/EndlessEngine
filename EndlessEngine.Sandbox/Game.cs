using System;
using System.Collections.Generic;
using EndlessEngine.Graphics;
using EndlessEngine.Graphics.Interfaces;
using EndlessEngine.Graphics.OpenGL;
using EndlessEngine.Math;

namespace EndlessEngine.Sandbox
{
    internal class Game : IDisposable
    {
        private readonly IWindow _window;
        private readonly Simple2DCamera _camera;
        private readonly IRenderer _renderer;
        
        private readonly Player _player;
        private readonly List<Obstacle> _obstacles;
        
        private const int Ground = 100;

        public Game(int windowWidth, int windowHeight, string windowTitle)
        {
            IGraphicsFactory graphics = new OpenGLGraphicsFactory();
            
            _window = graphics.CreateWindow(windowWidth, windowHeight, windowTitle);
            _renderer = graphics.CreateRenderer();
            _renderer.Init();
            
            _camera = new Simple2DCamera(_window.Width, _window.Height);
            
            _obstacles = new List<Obstacle>();
            _player = new Player
            {
                X = 100,
                Y = 150,
                Width = 64,
                Height = 64,
                Color = Color.White,
                
                RunSpeed = 10,
                JumpSpeed = 10,
                FallSpeed = 8,
                JumpHeight = 200,
                State = PlayerState.IsFalling
            };
            OnUpdate();
        }
        
        private void OnUpdate()
        {
            _window.OnKeyPressed += (sender, e) =>
            {
                switch (e.Key)
                {
                    case Key.Space:
                        if (_player.State == PlayerState.IsOnGround)
                        {
                            _player.State = PlayerState.IsJumping;
                        }
                        break;
                }
            };
        }

        private void OperatePlayer()
        {
            if (_player.State == PlayerState.IsDead) return;

            _player.X += _player.RunSpeed;
            switch (_player.State)
            {
                case PlayerState.IsJumping:
                    if (_player.Y - _player.Height / 2 < Ground + _player.JumpHeight)
                    {
                        _player.Y += _player.JumpSpeed;
                    }
                    else
                    {
                        _player.State = PlayerState.IsFalling;
                    }
                    break;
                case PlayerState.IsFalling:
                    if (_player.Y - _player.Height / 2 >= Ground + _player.FallSpeed)
                    {
                        _player.Y -= _player.FallSpeed;          
                    }
                    else
                    {
                        _player.State = PlayerState.IsOnGround;
                    }
                    break;
            }               
            
            _renderer.Draw(_player.Position, _player.Size, _player.Color);
        }

        public void OperateObstacles()
        {
            if (_obstacles.Count == 0)
            {                           
                var random = new Random();
                var x = random.Next(_camera.X + _window.Width, _camera.X + _window.Width * 2);
                switch (random.Next(1, 4))
                {
                    case 1:
                        _obstacles.Add(Obstacle.Single(10, 100, x, Ground));
                        break;
                    case 2:
                        _obstacles.AddRange(Obstacle.Multiple(10, 100, x, Ground, 2));
                        break;
                    case 3:                            
                        _obstacles.AddRange(Obstacle.Multiple(10, 100, x, Ground, 3));
                        break;
                }
            }

            int obstaclesIndex = 0;
            while (obstaclesIndex < _obstacles.Count)
            {
                var obstacle = _obstacles[obstaclesIndex]; 
                if (obstacle.X + obstacle.Height < _camera.X - _player.RunSpeed)
                    _obstacles.Remove(obstacle);
                    
                obstaclesIndex++;
            }

            foreach (var obstacle in _obstacles)
            {
                _renderer.Draw(obstacle.Position, obstacle.Size, obstacle.Color);
            }
        }

        public void Run()
        {
            while (_window.IsOpen)
            {                
                _camera.X += _player.RunSpeed;
                
                _renderer.SetClearColor(25, 25, 25);
                _renderer.Clear();

                _renderer.SetScene(_camera.Camera);

                OperateObstacles();
                OperatePlayer();

                _renderer.Draw(
                    new Vector2(_camera.X + _window.Width / 2 - _player.RunSpeed, Ground), 
                    new Vector2(_window.Width, 1), 
                    Color.White
                    );

                _window.Display();
            }
        }

        public void Dispose()
        {
            _window?.Dispose();
        }
    }
}