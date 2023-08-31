# C# TDD Kata: The Game Of Life

## The issue

- https://github.com/babelcodes/csharp/issues/3


## The challenge

```
........
....*...
...**...
........
```

![](https://kata-log.rocks/images/game_of_life_graphic.jpg)

### Description
- https://codingdojo.org/kata/GameOfLife/
- https://kata-log.rocks/game-of-life-kata

Rules
1. [A living cell with less than 2 neighbors => Dies](https://github.com/babelcodes/csharp/blob/2837df416f0ad7573a12cddc463d0fe698019440/katas/TheGameOfLife/test/src/BoardShould.cs#L79)
1. [A living cell with 2 or neighbors => Survives](https://github.com/babelcodes/csharp/blob/2837df416f0ad7573a12cddc463d0fe698019440/katas/TheGameOfLife/test/src/BoardShould.cs#L102)
1. [A living cell with more than 3 neighbors => Dies](https://github.com/babelcodes/csharp/blob/2837df416f0ad7573a12cddc463d0fe698019440/katas/TheGameOfLife/test/src/BoardShould.cs#L125)
1. [A dead cell with exactly 3 neighbors => Becomes alive](https://github.com/babelcodes/csharp/blob/2837df416f0ad7573a12cddc463d0fe698019440/katas/TheGameOfLife/test/src/BoardShould.cs#L144)


### Other Solutions
- https://github.com/robbell/test-driven-life
- https://github.com/jkratz55/game-of-life-kata/tree/master/csharp/Life
- https://github.com/MrDKOz/code-kata-game-of-life/tree/main


## Run

```shell
$ cd katas/TheGameOfLife/test/
$ dotnet watch test
```