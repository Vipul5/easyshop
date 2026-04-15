# Build stage
FROM node:20 AS build
WORKDIR /app

COPY package.json package-lock.json ./
RUN npm install

COPY . .
RUN npm run build

# Serve with nginx
FROM nginx:alpine

# 👇 add this line
COPY nginx.conf /etc/nginx/conf.d/default.conf

COPY --from=build /app/dist /usr/share/nginx/html

# EXPOSE 80