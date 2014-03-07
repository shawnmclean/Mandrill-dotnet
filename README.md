# Mandrill Dot Net [![Build Status](http://teamcity.codebetter.com/app/rest/builds/buildType:\(id:bt1136\)/statusIcon)](http://teamcity.codebetter.com/project.html?projectId=project415&guest=1)

## NuGet

Visual Studio users can install this directly into their .NET projects by executing the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)

    PM> Install-Package Mandrill

To utilize the mono build, download and compile the project. The mono version will be up on NuGet soon.

## Description

Mandrill Dot Net is a library that wraps the [Mandrill](http://mandrill.com/) mail API to easily get started in sending mail. It contains methods that
accept just the minimal amount of strongly typed parameters required to start sending out emails. All API calls have their Async counterparts.

## Usage

Go to the [downloads page](https://github.com/shawnmclean/Mandrill-dotnet/downloads) and download the latest version or utilize the NuGet package.
Unzip the file files and reference the following file in your .net project:

	Mandrill.dll

#### Sample Source:

Synchronous:

    MandrillApi api = new MandrillApi("xxxxx-xxxx-xxxx-xxxx");
    UserInfo info = api.UserInfo();
    Console.WriteLine(info.reputation);

Asychronous:

    MandrillApi api = new MandrillApi("xxxxx-xxxx-xxxx-xxxx");
    var task= api.UserInfoAsync();

    task.ContinueWith(data =>
    {
        var userInfo = data.Result;
        Console.WriteLine(userInfo.reputation);
    });

#### Api methods Covered

 1. Users
   1. Info
   2. Ping
 2. Messages
   1. Send
   2. Send-Template
   3. Search
   4. Info
   5. Send-Raw
   6. List-Scheduled
   7. Cancel-Scheduled
   8. Reschedule
   9. Content
 3. Rejects
   1. List
   2. Delete
 4. Templates
   1. Render
   2. Add
   3. Update
	 4. Info
 5. Senders
   1. List
	
## Necessary prerequisites

.NET 4 or Mono

## Contributing

#### Building the source

For running tests, ensure to rename `AppSettings.example.config` to `AppSettings.config` and 
set your own Api Key in the test project. Tests can be executed from rake: `rake test` or from any nunit test runner
tool.

You will also need to create a test template in your Mandrill account. The template's html content must be set to '<span mc:edit="model1"></span>'.
The template's name must match the TemplateExample setting in the AppSettings.config; 'Test' by default.

#### Contributors

  1. [Eli Schleifer](https://github.com/EliSchleifer)
  2. [Marko](https://github.com/markokristian)
  3. [Maksymilian Majer](https://github.com/maksymilian-majer)
  4. [Moacyr Rodrigues Pereira](https://github.com/moacyr)
  5. [Stephen Jazdzewski](https://github.com/jazd)
  6. [Jacob Rillema](https://github.com/rillemjg)

## Change Log

