# Mandrill Dot Net

## NuGet

Visual Studio users can install this directly into their .NET projects by executing the following command in the [Package Manager Console](http://docs.nuget.org/docs/start-here/using-the-package-manager-console)

    PM> Install-Package Mandrill

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
    var task= api.UserInfoAsyc();

    task.ContinueWith(data =>
    {
        var userInfo = data.Result;
        Console.WriteLine(userInfo.reputation);
    });

## Api methods Covered

 1. User Calls
   1. Info
   2. Ping
 2. Messages Calls
   1. Send
   2. Send-Template
	
## Necessary prerequisites

.NET 4