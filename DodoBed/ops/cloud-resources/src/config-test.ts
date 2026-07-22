/**
 * The actual config should be part of .gitignore
 */
export const Config = {
  AWS_REGION: '',
  AWS_LAB_PROFILE: '',
  AWS_CLIENT_PROFILE: '',
  AWS_DEFAULT_PROFILE: '',
  DEV_ROLE_ARN: '',
  BUCKET_NAME: '',
  AWS_ACCESS_KEY_ID: '',
  AWS_SECRET_ACCESS_KEY: '',
  ROUTE53: {
    HOSTED_ZONE: { ID: '', NAME: '' },
    DOMAIN: { NAME: '' },
  },
  DATABASE_CONFIG: {
    HOST: '',
    PORT: 0,
    USERNAME: '',
    DB_NAME: '',
    APP_USER_SECRET: { NAME: '' },
    SECRET: { NAME: '' },
    ARN: '',
    MIGRATION: {
      S3_URI: ``,
      DUMP_FILE: '',
    },
  },
};
