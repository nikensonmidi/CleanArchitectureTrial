import { ICloudServices } from '../types.js';


export class StorageProcess {
  constructor(private readonly services: ICloudServices) {
    if (!services.storageSrvc) {
      throw new Error('Storage service must be provided');
    }
  }

  public async listBuckets(): Promise<string[]> {
    return await this.services.storageSrvc!.listBuckets();
  }

  public async deleteBuckets(bucketNames: string[]): Promise<void> {
    await this.services.storageSrvc!.deleteBuckets(bucketNames);
  }
  public async testthis(): Promise<void> {
    const buckets = await this.listBuckets();
    const bucketsToExcludeFromDeletion = [
      'thisbucketisunique-12hjgjgfdfb-fq',
      'cdk-hnb659fds-assets-145485528452-us-east-1',
    ];
    const filteredForDeletion = buckets.filter(
      (b) => !bucketsToExcludeFromDeletion.includes(b),
    );
    console.log('Buckets to delete:', filteredForDeletion);
    await this.deleteBuckets(filteredForDeletion);
  }
}
