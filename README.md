# OEmbed Picker Property Editor for Umbraco  

[![Build status](https://ci.appveyor.com/api/projects/status/glmu0g4euryf70o1?svg=true)](https://ci.appveyor.com/project/dawoe/oembed-picker-property-editor)



|NuGet Packages    |Version           |
|:-----------------|:-----------------|
|**Release**|[![NuGet download](http://img.shields.io/nuget/v/Dawoe.OEmbedPickerPropertyEditor.svg)](https://www.nuget.org/packages/Dawoe.OEmbedPickerPropertyEditor)
|**Pre-release**|[![MyGet Pre Release](https://img.shields.io/myget/dawoe-umbraco/vpre/Dawoe.OEmbedPickerPropertyEditor.svg)](https://www.myget.org/feed/dawoe-umbraco/package/nuget/Dawoe.OEmbedPickerPropertyEditor)

|Umbraco Packages  |                  |
|:-----------------|:-----------------|
|**Release**|[![Our Umbraco project page](https://img.shields.io/badge/our-umbraco-orange.svg)](https://our.umbraco.org/projects/backoffice-extensions/oembed-picker-property-editor/) 
|**Pre-release**| [![AppVeyor Artifacts](https://img.shields.io/badge/appveyor-umbraco-orange.svg)](https://ci.appveyor.com/project/dawoe/oembed-picker-property-editor/build/artifacts)

## Installation

### Package

Download and install the package from : [http://our.umbraco.org/projects/backoffice-extensions/oembed-picker-property-editor](http://our.umbraco.org/projects/backoffice-extensions/oembed-picker-property-editor)

### Nuget

Install-Package Dawoe.OEmbedPickerPropertyEditor

## Usage

### Backend

1.  In Umbraco create a datatype and choose OEmbed Picker as your property editor
2.  If you want to allow embedding of multiple items check the box "Allow Multiple"
3.  Add a property to your documenttype using the newly created datatype

### Templates/Views

The package comes with a property value convertor for easy use in your views.

For a single embed :

@Model.Content.GetPropertyValue<IHtmlstring>("yourpropertyalias")

For multiple embeds : 

@Model.Content.GetPropertyValue<IEnumerable<IHtmlstring>>("yourpropertyalias")

## Changelog

### 3.0.0

- Better support for modelsbuilder. It now returns IHtmlstring or IEnumerable<IHtmlstring> instead of object when generating models. 
This is can be a potentially breaking changes because the models will be generated differently.

### 2.0.3

- Fix typo

### 2.0.2
- Fix issue #3: Mandatory field not working

### 2.0.1
- Fix issue #2: Property editor doesn't work when used inside Leblender editor

### 2.0.0
- Remove serving of clientside resources through handler. Now files are extracted on first run after installing.

### 1.0.1
- Fix issue #1: Conflict with nuPickers

### 1.0.0
- Initial release



## Contact

Feel free to contact me on twitter : @dawoe21


## Buy me a beer ##

If you like this package and use it in your website, consider giving me a small donation through paypal.me for maintaining this package.

[![Donate](https://img.shields.io/badge/donate-paypal.me-blue.svg)](https://www.paypal.me/dawoe21)


