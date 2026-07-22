import { fromIni } from '@aws-sdk/credential-providers';
import { AwsCredentialIdentity } from '@aws-sdk/types';

export class AWSCredential {
  //Getting local credentials from default profile
  async getLocalCredentials(profile: string): Promise<AwsCredentialIdentity> {
    const baseCreds = fromIni({ profile: profile });

    const c: AwsCredentialIdentity = await baseCreds();
    if (!c.accessKeyId || !c.secretAccessKey) {
      throw new Error('No usable credentials found');
    }
    return c;
  }
}
