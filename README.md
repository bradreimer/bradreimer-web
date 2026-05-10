# Schnauzers & Software

[![Azure Static Web App CI/CD](https://github.com/bradreimer/bradreimer-web/actions/workflows/azure-static-web-apps-ashy-flower-0a5dba11e.yml/badge.svg)](https://github.com/bradreimer/bradreimer-web/actions/workflows/azure-static-web-apps-ashy-flower-0a5dba11e.yml)

Source for the website https://bradreimer.com

## Stack

- Hugo `0.161.1` (extended) for the static site
- Git submodule for the `themes/hugo-story` theme

## Local setup

1. Initialize the theme submodule:
   `git submodule update --init --recursive`
2. Install Hugo extended `0.161.1` to match CI.

## Build and test

```bash
hugo --gc --minify
```

## Deployment

GitHub Actions builds the Hugo site and deploys the static output to Azure Static Web Apps.

## Dependency maintenance

Dependabot is configured for:

- GitHub Actions
- Git submodule updates from `.gitmodules`
