import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: false,
  application: {
    baseUrl,
    name: 'MusicBox',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44334',
    redirectUri: baseUrl,
    clientId: 'MusicBox_App',
    responseType: 'code',
    scope: 'offline_access MusicBox',
    requireHttps: true,
  },
  apis: {
    default: {
      url: 'https://localhost:44334',
      rootNamespace: 'MusicBox',
    },
  },
} as Environment;
