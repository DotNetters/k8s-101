FROM node:16 AS build
WORKDIR /app
COPY ["./package*.json", "./"]
RUN npm ci --only=production
RUN mkdir requests
COPY app.js .

FROM gcr.io/distroless/nodejs:16 as final
WORKDIR /app
EXPOSE 8000
COPY --from=build  /app .
CMD ["app.js"]
