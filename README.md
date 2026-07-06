# Schnauzers & Software

Source for the website https://bradreimer.com

## Stack

- Astro `7.x`
- y-astro-scholar theme as the base visual/layout system

## Local setup

1. Install Node.js `22+`
2. Install dependencies:
   `npm ci`
3. Start local development server:
   `npm run dev`

## Build and test

```bash
npm run build
```

## Deployment

Azure publishing is currently disabled.

To publish locally as a static site with Docker Compose:

```bash
docker compose up --build -d
```

The Docker image builds the Astro site and serves it with Nginx at `http://localhost:3000`.

## Dependency maintenance

Dependabot is configured for:

- GitHub Actions
- npm dependencies
