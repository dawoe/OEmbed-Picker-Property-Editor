# OEmbed Picker Property Editor for Umbraco  

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

@Model.Content.GetPropertyValue<MvcHtmlString>("yourpropertyalias")

For multiple embeds : 

@Model.Content.GetPropertyValue<List<MvcHtmlString>>("yourpropertyalias")

## Changelog

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


