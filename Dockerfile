# Multi-stage build for Astro site
# Stage 1: Build
FROM node:22.12-alpine AS builder

WORKDIR /app

# Copy package files
COPY package.json package-lock.json* yarn.lock* pnpm-lock.yaml* ./

# Install dependencies
RUN npm install

# Copy source code
COPY . .

# Build the site
RUN npm run build

# Stage 2: Serve
FROM node:22.12-alpine

WORKDIR /app

# Install a simple HTTP server to serve the static site
RUN npm install -g serve

# Copy built site from builder
COPY --from=builder /app/dist ./dist

# Expose port
EXPOSE 3000

# Health check
HEALTHCHECK --interval=30s --timeout=3s --start-period=5s --retries=3 \
  CMD wget --quiet --tries=1 --spider http://localhost:3000/ || exit 1

# Serve the site
CMD ["serve", "-s", "dist", "-l", "3000"]
