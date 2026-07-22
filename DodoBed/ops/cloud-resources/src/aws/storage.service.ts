import {
  S3Client,
  ListBucketsCommand,
  DeleteBucketCommand,
  ListObjectsV2Command,
  DeleteObjectCommand,
} from '@aws-sdk/client-s3';

export class StorageService {
  constructor(private readonly s3: S3Client) {}

  async listBuckets(): Promise<string[]> {
    const resp = await this.s3.send(new ListBucketsCommand({}));
    return (
      resp.Buckets?.map((b) => b.Name!).filter((n): n is string => !!n) ?? []
    );
  }

  async deleteBucket(bucketName: string): Promise<void> {
    await this.s3.send(new DeleteBucketCommand({ Bucket: bucketName }));
  }

  async emptyBucket(bucketName: string): Promise<void> {
    const listObjectsResp = await this.s3.send(
      new ListObjectsV2Command({ Bucket: bucketName }),
    );
    const objects = listObjectsResp.Contents ?? [];
    for (const obj of objects) {
      await this.s3.send(
        new DeleteObjectCommand({ Bucket: bucketName, Key: obj.Key! }),
      );
    }
  }

  async deleteBuckets(bucketNames: string[]): Promise<void> {
    for (const bucketName of bucketNames) {
      await this.emptyBucket(bucketName);
      await this.deleteBucket(bucketName);
    }
  }
}
