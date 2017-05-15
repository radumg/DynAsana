# DynAsana 
[![Build Status](https://travis-ci.org/radumg/DynAsana.svg?branch=master)](https://travis-ci.org/radumg/DynAsana) [![GitHub version](https://badge.fury.io/gh/radumg%2FDynAsana.svg)](https://badge.fury.io/gh/radumg%2FDynAsana) [![contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/dwyl/esta/issues)
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

Soon to include support for :
- OAuth flow
- PUT (updated) actions
- DELETE actions

# Getting Started

Getting started with `DynAsana` for your own use is very simple : using Dynamo's built-in package manager, search for `DynAsana` and then click the download button. 

A new category called `DynAsana` should appear in the Dynamo node library, but in some cases you might need to restart Dynamo. Remember that installation for packages is separate for Dynamo Sandbox/Studio and Dynamo for Revit, so you will need to install it separately as required.

# Using DynAsana

DynAsana currently exposes a few nodes in Dynamo, in the `DynAsana` category, organised in a further 2 sub-categories :
* Client
* Classes
* Authentication

## Simple examples
The `samples` folder includes a few simple examples that show you how to :
- retrieve a single task
- retrieve a project
- retrieve tasks in a project
- create a new task in a project

Retrieve a single task :
![samples-simplepostmessage](https://cloud.githubusercontent.com/assets/)

Retrieve a single project :
![samples-simplepostmessage](https://cloud.githubusercontent.com/assets/)

## More complex example
The `samples` folder also includes more complex examples. The reason these are considered more complex examples is because execution is cascaded, requiring multiple GET and/or multiple POST operations to achieve.

#### Retrieve tasks in a project
First retrieves projects from a workspace, then retrieves tasks in that specific project.
![samples-simplepostmessage](https://cloud.githubusercontent.com/assets/11439624/23580567/2a0a5fea-00fc-11e7-82d1-5450e6ab1a2a.png)

#### Create a new task in a workspace
First retrieves a workspace, then creates a new task in that specific workspace.
![samples-simplepostmessage](https://cloud.githubusercontent.com/assets/)

With all the samples, please remember to fill in your own API key, the one used in the samples has been deactivated.

## Client
This subcategory implements a client for access to the Asana API.

![client](https://cloud.githubusercontent.com/assets/)

Please note each client requires a valid API key and the integration does not currently support OAuth, although this is planned for a future update. See the [Authentication]() section for details on setting the API key up.

### Client node
This node creates a new Asana client. It takes in only 1 input :
```
1. token - an OAuth token.
```

### Query nodes
The query nodes, marked with `?` in Dynamo allow you to see the properties of a Client. Use these for troubleshooting and debugging.

## Classes
This subcategory allows the creation of Asana objects which are used to interact with the web service as well as for easy & direct use in Dynamo. They follow the standard Dynamo convention of having nodes for 
- creating new objects (+)
- performing actions (bolt)
- querying (?)

![classes](https://cloud.githubusercontent.com/assets/)

## Authentication

This repository reads the Asana API key directly from an XML file called `keys.xml`. You'll notice this file is not provided in the repository, so you'll have to create your own from the sample one that is provided.
1. Copy `keys.sample.xml` to `keys.xml`
2. Replace the token with your Asana one.

The token is the text between `<token>` and `</token>` and looks something like this : `Bearer 0/xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx`, where the `x` are a long string of alphanumeric characters. These `xxxx` characters represent the actual API key, see below how to obtain one.

*Note* : to create a new API key, please visit the following URL whilst logged in to Asana : http://app.asana.com/-/account_api . Remember that the API key will not be visible after it's created, so copy/paste it somewhere safe & never post it online!

## Prerequisites

This project requires the following applications or libraries be installed :

```
Dynamo : version 1.3 or later
```
```
.Net : version 4.5 or later
```

Please note the project has no dependency to Revit and its APIs, so it will happily run in Dynamo Sandbox or Dynamo Studio.

# Use for development or testing

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

As a prerequisite, this project was authored in and requires :
```
Visual Studio : version 2015 or later
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

Please read [CONTRIBUTING.md](https://github.com/radumg/DynAsana/CONTRIBUTING.md) for details the code of conduct, and the process for submitting pull requests.

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
