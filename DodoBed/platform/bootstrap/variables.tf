variable "aws_region" {
  description = "AWS region to provision the Terraform state backend in"
  type        = string
}

variable "aws_profile" {
  description = "AWS CLI profile used to authenticate the provider"
  type        = string
}

variable "account_alias" {
  description = "Short alias identifying the target AWS account (e.g. active, recovery)"
  type        = string
}

variable "state_bucket_name" {
  description = "Base name for the S3 bucket that stores Terraform state"
  type        = string
}

variable "lock_table_name" {
  description = "Base name for the DynamoDB table used for Terraform state locking"
  type        = string
}
