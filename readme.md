# Coding Tracker App

For all your coding tracking needs!

_Based on the [Coding Tracker](http://www.thecsharpacademy.com/coding-tracker/) assignment from C# Academy_.

This project uses the [ConsoleTableExt](https://github.com/minhhungit/ConsoleTableExt) package for displaying nice
looking tables in the coding sessions viewer

## Docker

**To run the image from Dockerhub without cloning this repository, simply run this command:**

```shell
docker run -i mattforge/dotnet-coding-tracker:master
```

<br>

**To build the image locally, follow these steps:**

To build the image, run:

```shell
docker build -t dotnet-coding-tracker .
```

Run the Docker image in _interactive mode_ (**note:** non interactive mode will just run infinitely)

```shell
docker run -i dotnet-coding-tracker
```