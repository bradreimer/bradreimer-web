# Schnauzers & Software

[![Azure Static Web App CI/CD](https://github.com/bradreimer/bradreimer-web/actions/workflows/azure-static-web-apps-ashy-flower-0a5dba11e.yml/badge.svg)](https://github.com/bradreimer/bradreimer-web/actions/workflows/azure-static-web-apps-ashy-flower-0a5dba11e.yml)

Source for the website https://bradreimer.com

## Stack

- Astro `6.x`
- y-astro-scholar theme as the base visual/layout system

## Local setup

1. Install Node.js `22+`
2. Install dependencies:
   `npm ci`

## Build and test

```bash
npm run build
```

## Deployment

GitHub Actions installs dependencies, builds the Astro site, and deploys `dist/` to Azure Static Web Apps.

## Dependency maintenance

Dependabot is configured for:

- GitHub Actions
- npm dependencies
