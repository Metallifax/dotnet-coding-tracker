# Coding Tracker App

For all your coding tracking needs!

_Based on the [Coding Tracker](http://www.thecsharpacademy.com/coding-tracker/) assignment from C# Academy_.

This project uses the [ConsoleTableExt](https://github.com/minhhungit/ConsoleTableExt) package for displaying nice
looking tables in the coding sessions viewer

## Docker

This is a simple Dockerfile that uses the built .dll file to build the image from. To build the CodingTracker.dll file:

```shell
dotnet build --configuration Release
```

Then to build the image, run

```shell
docker build -t dotnet-coding-tracker .
```

Run the Docker image in _interactive mode_ (**note:** non interactive mode will just run infinitely)

```shell
docker run -i dotnet-coding-tracker
```