jumpstart
===========

[![Build status](https://ci.appveyor.com/api/projects/status/00v2mfh13jolfyhd?svg=true)](https://ci.appveyor.com/project/giacomelli/jumpstart)
[![Coverage Status](https://coveralls.io/repos/giacomelli/jumpstart/badge.svg?branch=master&service=github)](https://coveralls.io/github/giacomelli/jumpstart?branch=master)
[![FxCop](http://badgessharp.apphb.com/badges/giacomelli/jumpstart/FxCop)](https://ci.appveyor.com/project/giacomelli/jumpstart/build/artifacts)
[![DupFinder](http://badgessharp.apphb.com/badges/giacomelli/jumpstart/DupFinder)](https://ci.appveyor.com/project/giacomelli/jumpstart/build/artifacts)
[![License](http://img.shields.io/:license-MIT-blue.svg)](https://raw.githubusercontent.com/giacomelli/jumpstart/master/LICENSE)

jumpstart is a command-line tool to create new C# projects from prebuilt/templates.

As experienced developers it's very common we have some kind of template solution when we start a new project. Maybe it's the latest project we work on, maybe it's a very good template we used every time to start a bootstrap of specific kind of project. 

I created jumpstart to simplify the process of create the new project based on those templates or prebuilt solutions.

The idea of the tool was born a long time ago and became a little stronger every time that I had to create a new project solution and had to create all the solution by hand, but when I saw the message bellow in the [http://xamarin.com/prebuilt](http://xamarin.com/prebuilt ) page I decided to finally write the tool... and the name was very clear, almost.

![](docs/images/Xamarin-jumpstart-message.png)

> The first name that I thought to the tool was prebuilt, but later, my friend [@GiusepeCasagrande](https://github.com/GiusepeCasagrande) convinced me that jumpstart was really better name... and he was right!

--------

##How does it work?
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

> If you are using jumpstart in Mac/Linux, remember to call it with "mono " prefix.


###Cross-platform
- Mono support.
- Fully tested on Windows and MacOSX.

###Code quality
- 100% unit test code coverage.
- FxCop validated.
- Code duplicated verification.
- Good (and well used) design patterns.  
- 100% code documentation

--------

 
--------

FAQ
======

Having troubles? 

- Ask on Twitter [@ogiacomelli](http://twitter.com/ogiacomelli).
 
 --------

How to improve it?
======

Create a fork of [jumpstart](https://github.com/giacomelli/jumpstart/fork). 

Did you change it? [Submit a pull request](https://github.com/giacomelli/jumpstart/pull/new/master).


License
======
Licensed under the The MIT License (MIT).
In others words, you can use this library for developement any kind of software: open source, commercial, proprietary and alien.