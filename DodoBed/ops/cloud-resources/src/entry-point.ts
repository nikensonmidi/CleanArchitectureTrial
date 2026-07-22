import { buildClient } from "./aws/client.js";
import { AWSCredential } from "./aws/credential.js";
import { StorageService } from "./aws/storage.service.js";
import { Config } from "./config-test.js";
import { StorageProcess } from "./processes/storage.js";
import { S3Client } from '@aws-sdk/client-s3';

export async function executeStorePorcess() {
  const credOps = new AWSCredential();
  const labuserCreds = await credOps.getLocalCredentials(
    Config.AWS_LAB_PROFILE,
  );
  const region = Config.AWS_REGION ?? 'us-east-1';

  const storageOrch = new StorageProcess({
    storageSrvc: new StorageService(
      buildClient(S3Client, region, labuserCreds),
    ),
  });

  await storageOrch.testthis();
}
