# ![jumpstart Icon](docs/images/jumpstart-icon.png)jumpstart

[![Build status](https://ci.appveyor.com/api/projects/status/99cm2psgntc0ahmy?svg=true)](https://ci.appveyor.com/project/giacomelli/jumpstart)
[![Coverage Status](https://coveralls.io/repos/giacomelli/jumpstart/badge.svg?branch=master&service=github)](https://coveralls.io/github/giacomelli/jumpstart?branch=master)
[![FxCop](http://badgessharp.apphb.com/badges/giacomelli/jumpstart/FxCop)](https://ci.appveyor.com/project/giacomelli/jumpstart/build/artifacts)
[![DupFinder](http://badgessharp.apphb.com/badges/giacomelli/jumpstart/DupFinder)](https://ci.appveyor.com/project/giacomelli/jumpstart/build/artifacts)
[![License](http://img.shields.io/:license-MIT-blue.svg)](https://raw.githubusercontent.com/giacomelli/jumpstart/master/LICENSE)

jumpstart is a command-line tool to create new C# projects from prebuilt/templates.

As an experienced developers it's very common we have some kind of template solution when we start a new project. Maybe it's the latest project we work on, maybe it's a very good template we used every time to bootstrap a specific kind of project. 

I created jumpstart to simplify the process of create the new project based on those templates or prebuilt solutions.

The idea of the tool was born a long time ago and became a little stronger every time that I had to create a new solution and all the projects by hand, but when I saw the message bellow in the [http://xamarin.com/prebuilt](http://xamarin.com/prebuilt ) page I decided to finally write the tool... and the name was very clear, almost.

![](docs/images/Xamarin-jumpstart-message.png)

> The first name that I thought to the tool was prebuilt, but later, my friend [@GiusepeCasagrande](https://github.com/GiusepeCasagrande) convinced me that jumpstart was really better name... and he was right!

--------

## How does it work?
jumpstart is very simple, it get a folder with a template solution and copy it to a new folder replacing the root namespace of the template to the new project namespace. 

A template folder like this:
```shell
jumpstart-template/MyClass.cs
jumpstart-template/Properties
jumpstart-template/Properties/AssemblyInfo.cs
jumpstart-template/JumpStartTemplate.csproj
JumpStartTemplate.sln
```

With this command:
```shell
jumpstart -n My.Amazing.NewProject
```

Will become:
```shell
My.Amazing.NewProject/MyClass.cs
My.Amazing.NewProject/Properties
My.Amazing.NewProject/Properties/AssemblyInfo.cs
My.Amazing.NewProject/My.Amazing.NewProject.csproj
My.Amazing.NewProject.sln
```

> The MyClass.cs, AssemblyInfo.cs, My.Amazing.NewProject.csproj and My.Amazing.NewProject.sln contents was updated by jumpstart to use the namespace My.Amazing.NewProject.


## Usage
Download it from our [releases page](https://github.com/giacomelli/jumpstart/releases).

### Available options:
To see all available options.

```shell
jumpstart -help
```

### Basic (using conventions)
If your template folder is called "jumpstart-template" and its namespace is JumpStartTemplate, the only argument you need to pass to jumpstart is -n(namespace).

```shell
jumpstart -n My.Amazing.NewProject
```

> The "jumpstart-template" folder should be in the same folder where you are calling jumpstart.

### Advanced (specifying template folder and namespace)
For example, your template folder is "my-template" and your template namespace is "My.Template", in this case you should call jumpstart in this way:
```shell
jumpstart -tf my-template -tn My.Template -n My.Amazing.NewProject
```

### Advanced (using a remote .zip template)
You can use a remote .zip file as your template folder. For example, if you want to start a new project with any of those prebuilt apps that Xamarin make available on [http://xamarin.com/prebuilt](http://xamarin.com/prebuilt), you can use the command bellow to jumpstart your new project using those templates:

##### jumpstart Xamarin Sport prebuilt app
```shell
jumpstart -tf https://github.com/xamarin/sport/archive/master.zip -tn Sport.Mobile -n My.Sport.Mobile 
```

> If you are using jumpstart in Mac/Linux, remember to call it with "mono " prefix.

### Good pratices
The jumpstart was designed to simplify the bootstrap of new projects based on templates/prebuilt solutions, with this in mind we recommend you use our conventions to facilitate the life of the user (programmer) that is using your template/prebuilt.

We recommend you add the jumpstart.exe inside your .zip template/prebuilt, like this:

```shell
Your.Amazing.Template.zip
	/jumpstart-template
	/jumpstart.exe
	/readme.txt
```	

Inside the jumpstart-template folder is your whole template/prebuilt solution. You should use the JumpStartTemplate namespace in your template too.

In the readme.txt add the following message:

```txt
To create a new project open prompt/terminal and type:
	* In Windows: jumpstart -n [the namespace of the new project]
 	* In Mac/Linux: mono jumpstart.exe -n [the namespace of the new project] 
```

Of course, you can choose not use the convention template folder "jumpstart-template" and the the convention template namespace JumpStartTemplate, but using them you'll really keep things simple to your template/prebuilt user.


### Cross-platform
- Mono support.
- Fully tested on Windows and Mac.

### Tests 
jumpstart was successfully tested on templates of:

- C# class library projects
- ASP .NET MVC projects 
- Unity3d projects
- Xamarin projects

--------

### FAQ

Having troubles? 
Ask on Twitter [@ogiacomelli](http://twitter.com/ogiacomelli).
 
 
#### Q. Why the namespace template within some files was not replaced?

A. By default jumpstart use an interal regex, called files-regex to choose what files must be replaced, the default pattern is:

```csharp
@"(\.cs|\.cshtml|\.csproj|\.sln|\.meta|\.asax|\.userprefs|\.config|\.sh|\.cmd|\.xaml)$"
```

If your file is not in this regex, you can use the -fr argument to use your own regex.

For example, you want your .txt files to be replaced too. To this case, you can use the command bellow:

```shell
jumpstart -fr "(\.cs|\.cshtml|\.csproj|\.sln|\.meta|\.asax|\.userprefs|\.config|\.sh|\.cmd|\.xaml|\.txt)$" -n  My.Amazing.NewProject
```

> If you believe that your file extensions is a very default file extension to C# projects, please fork jumpsharp and add it to the default regex on file JumpStartOptions.cs and make a pull request.
 --------

### How to improve it?

Create a fork of [jumpstart](https://github.com/giacomelli/jumpstart/fork). 

Did you change it? [Submit a pull request](https://github.com/giacomelli/jumpstart/pull/new/master).


### License
Licensed under the The MIT License (MIT).
In others words, you can use this library for developement any kind of software: open source, commercial, proprietary and alien.
