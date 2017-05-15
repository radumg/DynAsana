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


## Simple example
The `samples` folder includes a few simple examples that show you how to :
- retrieve a single task
- retrieve a project
- retrieve tasks in a project
- create a new task in a project

Retrieve a single task :
![samples-simplepostmessage](https://cloud.githubusercontent.com/assets/11439624/23580567/2a0a5fea-00fc-11e7-82d1-5450e6ab1a2a.png)

Retrieve a single project :
![samples-simplepostmessage](https://cloud.githubusercontent.com/assets/11439624/23580567/2a0a5fea-00fc-11e7-82d1-5450e6ab1a2a.png)

Retrieve tasks in a project :
![samples-simplepostmessage](https://cloud.githubusercontent.com/assets/11439624/23580567/2a0a5fea-00fc-11e7-82d1-5450e6ab1a2a.png)

Create a new task in a project :
![samples-simplepostmessage](https://cloud.githubusercontent.com/assets/11439624/23580567/2a0a5fea-00fc-11e7-82d1-5450e6ab1a2a.png)


## More complex example
The `samples` folder also includes a more complex example that shows you how to create a new task in a specific project and then add a tag to it. The reason this is considered a more complex example is because execution is cascaded, requiring multiple GETs and multiple POSTs to achieve.

The definition is pictured below :
![samples-postmessageswithicons](https://cloud.githubusercontent.com/assets/11439624/23580571/34206bc8-00fc-11e7-8f7b-469a9cc9f61c.png)

Please remember to fill in your own API key, the one used in the samples has been deactivated.

## Client
This subcategory implements a client for access to the Asana API.

![client](https://cloud.githubusercontent.com/assets/11439624/23580535/b260cea2-00fb-11e7-8def-5cfc85005761.PNG)

Please note each client requires a valid API key and the integration does not currently support OAuth, although this is planned for a future update. See the [Authentication]() section for details on setting the API key up.

### Client node
This node creates a new Asana client. It takes in only 1 input :
```
1. token - an OAuth token.

```

### PostWebhookMessage node
This node will post a message to a Slack channel through a webhook, provided the following inputs :
```
1. SlackClient : a Slack client with a valid token that has a webhook configured
```
```
2. text : the text to post as a message, supports all Slack formatting
```
```
3. emoji : the emoji to use as the message image, as per Slack syntax ( :rocket: for example)
```

### Query nodes
The query nodes, marked with `?` in Dynamo allow you to see the properties of a Client. Use these for troubleshooting and debugging.

## Classes
This subcategory allows the creation of Asana objects which are used to interact with the web service as well as for easy & direct use in Dynamo. They follow the standard Dynamo convention of having nodes for 
- creating new objects (+)
- performing actions (bolt)
- querying (?)

![class](https://cloud.githubusercontent.com/assets/11439624/23580538/c75e2610-00fb-11e7-8456-ba3cc9d7d972.PNG)

### Initialising
This node creates a new Webhok. It takes in a few inputs :
```
1. URL : the Slack URL to post to, in the form of 
https://hooks.slack.com/services/{teamID}/B4AHCV22F/...
```
```
2. Channel : the channel to post the message to, note that a valid existing channel's name is required otherwise sending messages will fail
```
```
3. User : the name of the integration, equivalent to a user's name and displayed as message author
```
```
4. EmojiIcon : the emoji to use as the message image, as per Slack syntax ( :rocket: for example)
```
```
5. UrlIcon : a URL to an image to use as the message image. An image is used as icon only when the emoji input is invalid or an empty string. Requires the URL to an image hosted on the internet.
```

### Post node
This node is the one that actually posts the message to Slack. It requires 2 inputs :
```
1. Webhook : a pre-configure webhook, see node above
```
```
2. text : the text to post as a message, supports all Slack formatting
```

### Query nodes
The query nodes, marked with `?` in Dynamo allow you to see the properties of a Webhook. Use these for troubleshooting and debugging.

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
