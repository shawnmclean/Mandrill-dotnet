[![NuGet](http://img.shields.io/nuget/v/Mandrill.svg?style=flat-square)](https://www.nuget.org/packages/Mandrill/)
[![Downloads](http://img.shields.io/nuget/dt/Mandrill.svg?style=flat-square)](https://www.nuget.org/packages/Mandrill/)
[![Build Status](http://img.shields.io/teamcity/codebetter/bt1136.svg?style=flat-square)](http://teamcity.codebetter.com/project.html?projectId=project415&guest=1)
[![Code Coverage](http://img.shields.io/teamcity/coverage/bt1136.svg?style=flat-square)](http://teamcity.codebetter.com/project.html?projectId=project415&guest=1)

# Mandrill Dot Net

## NuGet

Visual Studio users can install this directly into their .NET projects by executing the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)

    PM> Install-Package Mandrill

To utilize the mono build, download and compile the project. The mono version will be up on NuGet soon.

## Description

Mandrill Dot Net is a library that wraps the [Mandrill](http://mandrill.com/) mail API to easily get started in sending mail. It contains methods that accepts requests that matches the structure of the Mandrill API docs. Required properties are accepted in the Request's constructor.

## Usage

Go to the [downloads page](https://github.com/shawnmclean/Mandrill-dotnet/downloads) and download the latest version or utilize the NuGet package.
Unzip the file files and reference the following file in your .net project:

	Mandrill.dll

#### Example Usage:

    MandrillApi api = new MandrillApi("xxxxx-xxxx-xxxx-xxxx");
    UserInfo info = await api.UserInfo();
    Console.WriteLine(info.reputation);

All endpoints are covered by integration tests and can be used as a reference.

## Necessary prerequisites

### .NET 4.5

All method calls are using `async` and `await` and returns a task.

###.NET 4

Support for .NET 4 has be dropped. The last build for .NET 4 is the NuGet version `1.3.1`. The code can be found on tag [.net-4.0](https://github.com/shawnmclean/Mandrill-dotnet/tree/net-4.0).

## Contributing

#### Building the source

For running tests, ensure to rename `AppSettings.example.config` to `AppSettings.config` and
set your own Api Key in the test project. Tests can be executed from rake: `rake test` or from any nunit test runner
tool.

You will also need to create a test template in your Mandrill account. The template's html content must be set to ```<span mc:edit="model1"></span>```.
The template's name must match the `TemplateExample` setting in the `AppSettings.config`; `Test` by default. In addition, the template's label must
match the `TemplateLabel` (default `test`).

#### Contributors

  1. [Eli Schleifer](https://github.com/EliSchleifer)
  2. [Marko](https://github.com/markokristian)
  3. [Maksymilian Majer](https://github.com/maksymilian-majer)
  4. [Moacyr Rodrigues Pereira](https://github.com/moacyr)
  5. [Stephen Jazdzewski](https://github.com/jazd)
  6. [Jacob Rillema](https://github.com/rillemjg)
