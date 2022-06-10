# Endless Engine

[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]

[Report Bug][project-issues-link]
·
[Request Feature][project-issues-link]

Endless Engine is a simple cross-platform 2D rendering engine.

## Table of Contents

- [Getting Started](#getting-started)
    - [Prerequisites](#prerequisites)
- [Usage](#usage)
- [Roadmap](#roadmap)
- [Contributing](#contributing)
- [License](#license)
- [Contact](#contact)



## Getting Started

### Prerequisites

[![.NET Version][dotnet-shield]][dotnet-url]


1. Clone the repo
   ```sh
   git clone https://github.com/relidaar/EndlessEngine.git
   ```
2. Change your directory
   ```sh
   cd EndlessEngine
   ```



## Usage
[(Back to top)](#table-of-contents)

```sh
public class Game : IDisposable
{
    private readonly IGraphicsFactory _graphics;
    private readonly IWindow _window;
    private readonly IRenderer _renderer;

    public Game(int windowWidth, int windowHeight, string windowTitle)
    {
        _graphics = new OpenGLGraphicsFactory();
        _window = _graphics.CreateWindow(windowWidth, windowHeight, windowTitle, false);
        _renderer = _graphics.CreateRenderer();
        _renderer.Init();
        
        // Initialize your game entities here
            
        OnUpdate();
    }
        
    private void OnUpdate()
    {
        _window.OnKeyPressed += (sender, e) =>
        {
            switch (e.Key)
            {
                // Register your handlers here
            }
        };
    
        // Write your update logic here
    }

    public void Run()
    {
        while (_window.IsOpen)
        {
            _renderer.Clear();
                
            // Create your game logic here
                
            _window.Display();
        }
    }

    public void Dispose()
    {
        _window?.Dispose();
    }
}
```

```
var game = new Game(800, 600, "Sample Game");
game.Run();
```



## Roadmap
[(Back to top)](#table-of-contents)

See the [open issues][project-issues-link] for a list of proposed features (and known issues).



## Contributing
[(Back to top)](#table-of-contents)

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request



## License
[(Back to top)](#table-of-contents)

Distributed under the MIT License. See  [`LICENSE`][license-url] for more information.



## Contact
[(Back to top)](#table-of-contents)

Project Link: [https://github.com/relidaar/EndlessEngine][project-link]

[![LinkedIn][linkedin-shield]][linkedin-url]



[project-link]: https://github.com/relidaar/EndlessEngine
[project-issues-link]: https://github.com/relidaar/EndlessEngine/issues

[contributors-shield]: https://img.shields.io/github/contributors/relidaar/EndlessEngine?style=for-the-badge
[contributors-url]: https://github.com/relidaar/EndlessEngine/graphs/contributors

[forks-shield]: https://img.shields.io/github/forks/relidaar/EndlessEngine?style=for-the-badge
[forks-url]: https://github.com/relidaar/EndlessEngine/network/members

[issues-shield]: https://img.shields.io/github/issues/relidaar/EndlessEngine?style=for-the-badge
[issues-url]: https://github.com/relidaar/EndlessEngine/issues

[license-shield]: https://img.shields.io/github/license/relidaar/EndlessEngine?style=for-the-badge
[license-url]: https://github.com/relidaar/EndlessEngine/blob/main/LICENSE

[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/oleksandr-sviatetskyi-45424b143/

[dotnet-shield]: https://img.shields.io/badge/.NET_Core-2.1-brightgreen.svg?style=flat-square
[dotnet-url]: https://dotnet.microsoft.com/download/dotnet/2.1
