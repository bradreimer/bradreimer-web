# Docker Setup for Local Development

This project includes Docker configuration for running your Astro site locally.

## Quick Start

### Development (with live reload)

```bash
# Build and start the development container
docker-compose up dev

# The site will be available at http://localhost:4321
```

The dev container includes live reload, so changes to your source code will automatically refresh in the browser.

### Production (static site)

```bash
# Build and start the production container
docker-compose up prod

# The site will be available at http://localhost:3000
```

The production container builds the site once and serves the static files using the `serve` package.

## Individual Docker Commands

### Build the production image
```bash
docker build -t bradreimer-web:latest .
```

### Run the production container
```bash
docker run -p 3000:3000 bradreimer-web:latest
```

### Build the development image
```bash
docker build -f Dockerfile.dev -t bradreimer-web:dev .
```

### Run the development container
```bash
docker run -p 4321:4321 -v $(pwd):/app -v /app/node_modules bradreimer-web:dev
```

## Files Explained

- **Dockerfile** - Multi-stage production build that compiles the Astro site and serves static files
- **Dockerfile.dev** - Development build with live reload capability
- **docker-compose.yml** - Orchestration file for easy local development
- **.dockerignore** - Excludes unnecessary files from Docker builds

## Stopping Containers

```bash
# Stop dev container
docker-compose stop dev

# Stop prod container
docker-compose stop prod

# Stop and remove all containers
docker-compose down
```

## Environment Variables

You can pass environment variables to the containers by adding them to the docker-compose.yml file or using the `-e` flag with `docker run`.

## GitHub Actions Workflow

The `.github/workflows/docker-build-push.yml` workflow automatically builds and pushes your Docker image to GitHub Container Registry (ghcr.io) on:

- **Pushes to main** - Builds and pushes with `latest` tag and commit SHA
- **Version tags** (e.g., `v1.0.0`) - Builds and pushes with semantic versioning tags
- **Pull requests** - Builds for testing (does not push)

### Using the Docker Image from GitHub Container Registry

```bash
# Pull the latest image
docker pull ghcr.io/bradreimer/bradreimer-web:latest

# Run it
docker run -p 3000:3000 ghcr.io/bradreimer/bradreimer-web:latest

# Or use a specific tag
docker run -p 3000:3000 ghcr.io/bradreimer/bradreimer-web:v1.0.0
```

### Image Registry

Images are pushed to: `ghcr.io/bradreimer/bradreimer-web`

Available tags:
- `latest` - Points to the latest main branch build
- `main` - Explicit main branch tag
- Semantic version tags (e.g., `1.0.0`, `1.0`, `1`)
- Commit SHA tags (e.g., `sha-abc1234`)

## Notes

- The Astro server in development mode is configured with `host: true` in `astro.config.mjs`, allowing it to be accessible from outside the container
- The production container includes a health check that verifies the server is responding
- Both containers use Node 20 Alpine for a minimal image size
- GitHub Actions workflow uses BuildKit for efficient layer caching
- Images are private by default; make the repository public or update package permissions in GitHub to share images
