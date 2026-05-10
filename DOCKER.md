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

## Notes

- The Astro server in development mode is configured with `host: true` in `astro.config.mjs`, allowing it to be accessible from outside the container
- The production container includes a health check that verifies the server is responding
- Both containers use Node 20 Alpine for a minimal image size
