# Schnauzers & Software

[![Azure Static Web App CI/CD](https://github.com/bradreimer/bradreimer-web/actions/workflows/azure-static-web-apps-ashy-flower-0a5dba11e.yml/badge.svg)](https://github.com/bradreimer/bradreimer-web/actions/workflows/azure-static-web-apps-ashy-flower-0a5dba11e.yml)

Source for the website https://bradreimer.com

## Stack

- Hugo `0.161.1` (extended) for the static site
- Azure Functions v4 on .NET 10 isolated worker for `/api`
- Git submodule for the `themes/hugo-story` theme

## Local setup

1. Initialize the theme submodule:
   `git submodule update --init --recursive`
2. Install the .NET 10 SDK. The repo pins SDK selection with `global.json`, and CI uses .NET 10.
3. Install Hugo extended `0.161.1` to match CI.
4. For local Azure Functions development, copy `api/local.settings.example.json` to `api/local.settings.json` and adjust settings as needed.

## Build and test

```bash
dotnet restore api/api.csproj
dotnet test api.Tests/api.Tests.csproj -c Release
dotnet publish api/api.csproj -c Release -o .output/api
hugo --gc --minify
```

## Deployment

GitHub Actions builds and tests the API, publishes the Azure Functions app, builds the Hugo site, and then deploys both artifacts to Azure Static Web Apps.

## Dependency maintenance

Dependabot is configured for:

- GitHub Actions
- NuGet packages in `api/` and `api.Tests/`
- Git submodule updates from `.gitmodules`
