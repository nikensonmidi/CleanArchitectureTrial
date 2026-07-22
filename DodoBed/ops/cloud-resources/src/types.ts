import { StorageService } from "./aws/storage.service.js";

export interface LabCleanupProps {
  region?: string;
  profile: string;
  role_arn: string;
  tagKey: string;
  tagValue: string;
  stackNamePrefix?: string;
  dryRun?: boolean;
  force?: boolean;
}

export type CfnStackStatus = string;

export type StackRef = {
  name: string;
  status?: CfnStackStatus;
};

export type StackWithTags = {
  name: string;
  status?: CfnStackStatus;
  tags: Record<string, string>;
};

export interface BastionOpsProps {
  region: string;
  profile: string;
}

export const ACTIVE_STATUSES = new Set([
  'CREATE_IN_PROGRESS',
  'CREATE_FAILED',
  'CREATE_COMPLETE',
  'ROLLBACK_IN_PROGRESS',
  'ROLLBACK_FAILED',
  'ROLLBACK_COMPLETE',
  'DELETE_FAILED',
  'UPDATE_IN_PROGRESS',
  'UPDATE_COMPLETE_CLEANUP_IN_PROGRESS',
  'UPDATE_COMPLETE',
  'UPDATE_ROLLBACK_IN_PROGRESS',
  'UPDATE_ROLLBACK_FAILED',
  'UPDATE_ROLLBACK_COMPLETE_CLEANUP_IN_PROGRESS',
  'UPDATE_ROLLBACK_COMPLETE',
  'REVIEW_IN_PROGRESS',
  'IMPORT_IN_PROGRESS',
  'IMPORT_COMPLETE',
  'IMPORT_ROLLBACK_IN_PROGRESS',
  'IMPORT_ROLLBACK_FAILED',
  'IMPORT_ROLLBACK_COMPLETE',
]);

export type RouteCertInventory = {

};

export interface ICloudServices {
  storageSrvc?: StorageService;
}
