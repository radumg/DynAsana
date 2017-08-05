# DynAsana 
[![Codacy Badge](https://api.codacy.com/project/badge/Grade/bd5ffec958564aa4bc0f6f17315c8986)](https://www.codacy.com/app/radugidei/DynAsana?utm_source=github.com&utm_medium=referral&utm_content=radumg/DynAsana&utm_campaign=badger)
[![Build Status](https://travis-ci.org/radumg/DynAsana.svg?branch=master)](https://travis-ci.org/radumg/DynAsana) [![GitHub version](https://badge.fury.io/gh/radumg%2FDynAsana.svg)](https://badge.fury.io/gh/radumg%2FDynAsana) [![contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/radumg/DynAsana/blob/master/CONTRIBUTING.md)
---
**DynAsana** is a [Dynamo](http://www.dynamobim.org) package providing integration with task management app [Asana](http://www.asana.com), allowing you to retrieve & create tasks.

Includes GET (retrieval) support for :
- workspaces/organisations
- projects
- tasks
- tags
- users

Includes POST (creation) support for :
- tasks
- projects
- tags

Soon to include support for :
- OAuth flow
- PUT (updated) actions
- DELETE actions

# Getting Started

Getting started with `DynAsana` for your own use is very simple : using Dynamo's built-in package manager, search for `DynAsana` and then click the download button. 

A new category called `DynAsana` should appear in the Dynamo node library, but in some cases you might need to restart Dynamo. Remember that installation for packages is separate for Dynamo Sandbox/Studio and Dynamo for Revit, so you will need to install it separately as required.

# Using DynAsana

DynAsana currently exposes a few nodes in Dynamo, in the `DynAsana` category and further organised into classes that reflect Asana objects.
There are a few exceptions, namely :
* Client
* Authentication
* Helpers

These 3 classes are part of the integration and do not represent actual Asana objects.

![dynasana](https://user-images.githubusercontent.com/11439624/27520915-36358b86-5a0d-11e7-9a1a-f34b370bc8d6.PNG)


## Class structure
As mentioned, each class represents an Asana object, for example `Tags`.

This structure allows the creation of Asana objects which are used to interact with the web service as well as for easy & direct use in Dynamo. They follow the standard Dynamo convention of having nodes for 
- creating new objects `(+)`
- performing actions `(bolt)`
- querying `(?)`

![Structure](https://user-images.githubusercontent.com/11439624/27520902-073c9fcc-5a0d-11e7-88e8-83e032f91ef1.PNG)

### Create an object
To create a tag for example, use nodes in the `+` section.
Using Tag as an example, you'll find 3 nodes :

**Tag()**
```
Use this node to create an empty Tag object. Every class has this empty constructor that allows you to create offline objects - meaning they're never sent to the Asana servers.
```

**CreateTag**
```
Use this node to create a Tag object on the Asana server.

This node requires you to build an offline tag first, then supplying that (along with a client) to this node as input. The result will be the newly-created Tag, as returned by the Asana servers.
Most classes behave this way.
```

### Perform actions & modify objects
To perform actions and/or communicate with the Asana servers, use the nodes in modify section (lightning bolt).

**GetAllTags**
```
Use this node to retrieve all Tags in your workspace from the Asana servers, returning complete Tag objects which can then be used for modification, assigning to a task, etc. 
Any nodes that include web action verbs such as Get, Post, Put, Delete, involve communicating with the Asana servers.
```

### Query nodes
The query nodes, marked with `?` in Dynamo allow you to see the properties of an object. Use these for troubleshooting and debugging.


## Example Dynamo graphs
### Simple examples
The `samples` folder includes a few simple examples that show you how to :
- retrieve a single task
- retrieve tasks in a project
- retrieve all projects

Retrieve a single task :
![samples-simplepostmessage](https://raw.githubusercontent.com/radumg/DynAsana/master/Samples/Samples-Simple-GetTaskById.png)

Retrieve projects :
![samples-simplepostmessage](https://raw.githubusercontent.com/radumg/DynAsana/master/Samples/Samples-Simple-GetProjects.png)

#### Retrieve tasks in a project
First retrieves projects from a workspace, then retrieves tasks in that specific project.
![samples-simplepostmessage](https://raw.githubusercontent.com/radumg/DynAsana/master/Samples/Samples-Simple-GetTasksByProject.png)

With all the samples, please remember to fill in your own API key, the one used in the samples is invalid or has been deactivated.

### Complex examples
The `samples` folder also includes more complex examples. The reason these are considered more complex examples is because execution is cascaded, requiring multiple GET and/or multiple POST operations to achieve.

Included complex samples :
- create a new task in a project

#### Create a new task in a workspace
First retrieves a workspace & project, then creates a new task in that specific workspace/project pair.
![samples-simplepostmessage](https://raw.githubusercontent.com/radumg/DynAsana/master/Samples/Samples-Complex-CreateTask.png)

## Nodes

### Client
This class implements a client for access to the Asana API.
Think of a client as an individual connection to the Asana servers that all actions require.

In this integration, clients are not static, allowing you to use multiple clients in the same graph, to create tasks in different organisations, etc. 

Please note each client requires a valid API key and the integration does not currently support OAuth, although this is planned for a future update. See the **Authentication** section for details on setting the API key up.

#### Client node
This node creates a new Asana client. It takes in only 1 input :
```
1. token - an OAuth token.
```

### Authentication

This integration reads the Asana API key directly from an XML file called `keys.xml`. You'll notice this file is not provided in the repository, so you'll have to create your own from the sample one that is provided.
1. Copy `keys.sample.xml` to `keys.xml`
2. Replace the token with your Asana one.

The token is the text between `<token>` and `</token>` and looks something like this : `Bearer 0/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx`, where the `x` are a long string of alphanumeric characters. These `xxxx` characters represent the actual API key, see below how to obtain one.

*Note* : to create a new API key, please visit the following URL whilst logged in to Asana : http://app.asana.com/-/account_api . Remember that the API key will not be visible after it's created, so copy/paste it somewhere safe & never post it online!

#### GetTokenFromXMLFile node
This node reads the Asana token from an XML file. It takes in only 1 input :
```
1. filePath - the full path to the XML file containing the Asana token. I suggest placing this on your organisation's network somewhere for easy re-use.
```


## Prerequisites

This project requires the following applications or libraries be installed :

```
Dynamo : version 1.3 or later
```
```
.Net : version 4.6.1 or later
```

Please note the project has no dependency to Revit and its APIs, so it will happily run in Dynamo Sandbox or Dynamo Studio.

# Use for development or testing

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

As a prerequisite, this project was authored in and requires :
```
Visual Studio : version 2017 or later
```

## Get your development copy of DynAsana

If you already have a Github account, fork (& star) the project, then `clone to desktop` or `clone using Github Desktop`.

If you don't already have a Github account or don't want one, follow these steps :
```
- click the green `Clone or Download` button on this project's page and select `Download ZIP`
- unzip the downloaded file
- to enable testing in Dynamo, copy the `packages\DynAsana` folder to the location of Dynamo packages  :
    - `%appdata\Dynamo\Dynamo Core\1.2\packages` for Dynamo Sandbox, replacing `1.2` with your version of Dynamo
    - `%appdata\Dynamo\Dynamo Revit\1.2\packages` for Dynamo for Revit, replacing `1.2` with your version of Dynamo
```

After you have the project saved to your development machine, navigate to the `DynAsana\src` folder and open the `DynAsana.sln` solution to access the full Visual Studio solution and source code. 

Build the project before making any changes to make sure the environment is properly set up, as the project relies on a few NuGet packages, see list below.

## Built with

The `DynAsana` project relies on a few community-published NuGet packages as listed below :
* [Newtonsoft](https://www.nuget.org/packages/newtonsoft.json/) - handles serializing and deserializing to JSON
* [RestSharp](https://www.nuget.org/packages/RestSharp/) - enables easier interaction with REST API endpoints
* [DynamoServices](https://www.nuget.org/packages/DynamoVisualProgramming.DynamoServices/2.0.0-beta4066) - an official Dynamo package providing support for better mapping of C# code to Dynamo nodes

## Contributing

Please read [CONTRIBUTING.md](https://github.com/radumg/DynAsana/blob/master/CONTRIBUTING.md) for details on how to contribute to this package. Please also read the [CODE OF CONDUCT.md](https://github.com/radumg/DynAsana/blob/master/CODE_OF_CONDUCT.md).

## Versioning & Releases

DynAsana use the [SemVer](http://semver.org/) semantic versioning standard.
For the versions available, see the versions listed in the Dynamo package manager or [releases on this repository](https://github.com/radumg/DynAsana/releases).
The versioning for this project is `X.Y.Z` where
- `X` is a major release, which may not be fully compatible with prior major releases
- `Y` is a minor release, which adds both new features and bug fixes
- `Z` is a patch release, which adds just bug fixes

## Authors

* **Radu Gidei** : [Github profile](https://github.com/radumg), [Twitter profile](https://twitter.com/radugidei)

## License

This project is licensed under the GNU AGPL 3.0 License - see the [LICENSE FILE](https://github.com/radumg/DynAsana/blob/master/LICENSE) for details.

## Acknowledgments

* Hat tip to the [UK Dynamo User Group](http://www.twitter.com/ukdynug) and the wider [Dynamo community](http://www.dynamobim.org) for spurring me on to present & release this.

* The codebase is in no way striving for efficiency, but instead simplicity & legibility for the community's benefit - hence the many comments left throughout the code. Any suggestions or help improving it is warmly welcomed.
