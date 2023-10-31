# Stage 1
FROM node:latest as node
WORKDIR /usr/local/app/PulseNexUI/PulseNex
COPY /PulseNex/ /usr/local/app/PulseNexUI/PulseNex/
RUN npm install
RUN npm run build

# Stage 2
FROM nginx:alpine
COPY --from=node /usr/local/app/PulseNexUI/PulseNex/dist/pulse-nex /usr/share/nginx/html