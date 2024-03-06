## Description

MAUI 8.0.7 reports new warnings XC0022 and XC0023 if a XAML file is missing x:DataType specification
https://github.com/dotnet/maui/issues/20568

When using `StateContainer` from CommunityToolkit.Maui, XC0022 warning will be raised even though `x:DataType` is specified at the top of the page.

## Github issues

* dotnet/maui#20568

## Steps to Reproduce

* Clone this repo
* Run dotnet build<br>
  `dotnet build -f net8.0-ios -r iossimulator-x64 -c Debug maui-issue6-xaml-datatype-warnings/maui-issue6-xaml-datatype-warnings.csproj`
* Check the warnings: `x:DataType` is specified for both MainPage and SecondaryPage but warnings appear for SecondaryPage

## Version with bug
Maui 8.0.7 (current)<br>
dotnet 8.0.201 (current)

## Last version that worked well
Unknown

## Affected platforms
-

## Affected platform versions
-

## Did you find any workaround?
Warnings can be disabled using:

```
<NoWarn>$(NoWarn);XC0022;XC0023</NoWarn>
```

## Relevant log output

```
$ dotnet build -f net8.0-ios -r iossimulator-x64 -c Debug maui-issue6-xaml-datatype-warnings/maui-issue6-xaml-datatype-warnings.csproj 
MSBuild version 17.9.4+90725d08d for .NET
  Determining projects to restore...
  All projects are up-to-date for restore.
  Detected signing identity:
          
    Bundle Id: com.companyname.maui_issue6_xaml_datatype_warnings
    App Id: com.companyname.maui_issue6_xaml_datatype_warnings
SecondaryPage.xaml(20,21): XamlC XC0022 warning : Binding could be compiled if x:DataType is specified. [/Users/ray_dacted/projects/maui/repros/maui-issue6-xaml-datatype-warnings/maui-issue6-xaml-datatype-warnings/maui-issue6-xaml-datatype-warnings.csproj::TargetFramework=net8.0-ios]
SecondaryPage.xaml(45,25): XamlC XC0022 warning : Binding could be compiled if x:DataType is specified. [/Users/ray_dacted/projects/maui/repros/maui-issue6-xaml-datatype-warnings/maui-issue6-xaml-datatype-warnings/maui-issue6-xaml-datatype-warnings.csproj::TargetFramework=net8.0-ios]
SecondaryPage.xaml(47,25): XamlC XC0022 warning : Binding could be compiled if x:DataType is specified. [/Users/ray_dacted/projects/maui/repros/maui-issue6-xaml-datatype-warnings/maui-issue6-xaml-datatype-warnings/maui-issue6-xaml-datatype-warnings.csproj::TargetFramework=net8.0-ios]
  maui-issue6-xaml-datatype-warnings -> /Users/ray_dacted/projects/maui/repros/maui-issue6-xaml-datatype-warnings/maui-issue6-xaml-datatype-warnings/bin/Debug/net8.0-ios/iossimulator-x64/maui-issue6-xaml-datatype-warnings.dll
  Optimizing assemblies for size may change the behavior of the app. Be sure to test after publishing. See: https://aka.ms/dotnet-illink
  Optimizing assemblies for size. This process might take a while.

Build succeeded.

SecondaryPage.xaml(20,21): XamlC XC0022 warning : Binding could be compiled if x:DataType is specified. [/Users/ray_dacted/projects/maui/repros/maui-issue6-xaml-datatype-warnings/maui-issue6-xaml-datatype-warnings/maui-issue6-xaml-datatype-warnings.csproj::TargetFramework=net8.0-ios]
SecondaryPage.xaml(45,25): XamlC XC0022 warning : Binding could be compiled if x:DataType is specified. [/Users/ray_dacted/projects/maui/repros/maui-issue6-xaml-datatype-warnings/maui-issue6-xaml-datatype-warnings/maui-issue6-xaml-datatype-warnings.csproj::TargetFramework=net8.0-ios]
SecondaryPage.xaml(47,25): XamlC XC0022 warning : Binding could be compiled if x:DataType is specified. [/Users/ray_dacted/projects/maui/repros/maui-issue6-xaml-datatype-warnings/maui-issue6-xaml-datatype-warnings/maui-issue6-xaml-datatype-warnings.csproj::TargetFramework=net8.0-ios]
    3 Warning(s)
    0 Error(s)

Time Elapsed 00:00:10.69
```