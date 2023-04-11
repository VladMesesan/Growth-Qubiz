const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:12360';

const PROXY_CONFIG = [
  {
    context: [
      "/valueandreferencetypes",
      "/passingparameters",
      "/linq",
      "/boxingandunboxing",
      "/classvsobject",
      "/principlesofoop",
      "/solidprinciples"
    ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
